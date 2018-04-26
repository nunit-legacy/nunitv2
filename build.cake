//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// CHANGE TO SET PACKAGE AND ASSEMBLY VERSIONS
//////////////////////////////////////////////////////////////////////

var version = "2.6.6";
var modifier = ""; // for example "-beta2"

//////////////////////////////////////////////////////////////////////
// DEFINE RUN CONSTANTS
//////////////////////////////////////////////////////////////////////

var DBG_SUFFIX = configuration == "Debug" ? "-dbg" : "";
var PACKAGE_VERSION = version + modifier + DBG_SUFFIX;
var PACKAGE_BASE_NAME = "NUnit-" + PACKAGE_VERSION;

var PROJECT_DIR = Context.Environment.WorkingDirectory.FullPath + "/";
var SOLUTION_FILE = PROJECT_DIR + "nunitv2.sln";

var BIN_DIR = PROJECT_DIR + "bin/" + configuration + "/";
var NUNIT_CONSOLE = BIN_DIR + "nunit-console.exe";

var PACKAGE_DIR = PROJECT_DIR + "packages/";
var PACKAGE_WORK_DIR = PACKAGE_DIR + PACKAGE_BASE_NAME + "/";

//////////////////////////////////////////////////////////////////////
// CLEAN
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Description("Deletes all files in the BIN directory")
    .Does(() =>
    {
        CleanDirectory(BIN_DIR);
    });

Task("CleanPackageWorkDir")
	.Description("Deletes all files in the package work directory")
	.Does(() =>
	{
		CleanDirectory(PACKAGE_WORK_DIR);
	});

//////////////////////////////////////////////////////////////////////
// Build
//////////////////////////////////////////////////////////////////////

Task("Build")
	.Description("Builds the Solution")
	.Does(() =>
	{
		MSBuild(SOLUTION_FILE, new MSBuildSettings()
		{
			Configuration = configuration
		});
	});

//////////////////////////////////////////////////////////////////////
// TEST
//////////////////////////////////////////////////////////////////////

Task("BasicTests")
	.Description("Runs the tests")
	.IsDependentOn("Build")
	.Does(() =>
	{
		int rc = StartProcess(
			NUNIT_CONSOLE, 
			new ProcessSettings()
			{
				WorkingDirectory = PROJECT_DIR,
				Arguments = "NUnitTests.nunit"
			});

		if (rc > 0)
			throw new Exception(string.Format("{0} tests failed", rc));
		else if (rc < 0)
			throw new Exception(string.Format("Console returned rc = {0}", rc));
	});

Task("Net45Tests")
	.Description("Runs the .NET 4.5 tests")
	.IsDependentOn("Build")
	.Does(() =>
	{
		int rc = StartProcess(
			NUNIT_CONSOLE,
			new ProcessSettings()
			{
				WorkingDirectory = BIN_DIR + "tests",
				Arguments = "nunit.core.tests.45.dll nunit.framework.tests.net45.dll -noxml -framework:net-4.5"
			});

		if (rc > 0)
			throw new Exception(string.Format("{0} tests failed", rc));
		else if (rc < 0)
			throw new Exception(string.Format("Console returned rc = {0}", rc));
	});

//////////////////////////////////////////////////////////////////////
// Package
//////////////////////////////////////////////////////////////////////

Task("PackageSource")
	.Description("CreateSourcePackage")
	.IsDependentOn("CleanPackageWorkDir")
	.Does(() =>
	{
		string outfile = PACKAGE_DIR + PACKAGE_BASE_NAME + "-src.zip";
		int rc = StartProcess("git", "archive --format=zip --output=" + outfile + " HEAD");
	});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Test")
	.IsDependentOn("BasicTests")
	.IsDependentOn("Net45Tests");

Task("Package")
	.IsDependentOn("PackageSource");

Task("AppVeyor")
	.IsDependentOn("Build")
	.IsDependentOn("Test");

Task("Default")
	.IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
