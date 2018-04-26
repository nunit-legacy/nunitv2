//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// DEFINE RUN CONSTANTS
//////////////////////////////////////////////////////////////////////

var PROJECT_DIR = Context.Environment.WorkingDirectory.FullPath + "/";
var PACKAGE_DIR = PROJECT_DIR + "packages/";
var BIN_DIR = PROJECT_DIR + "bin/" + configuration + "/";
var SOLUTION_FILE = PROJECT_DIR + "nunitv2.sln";
var NUNIT_CONSOLE = BIN_DIR + "nunit-console.exe";

//////////////////////////////////////////////////////////////////////
// CLEAN
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Description("Deletes all files in the BIN directory")
    .Does(() =>
    {
        CleanDirectory(BIN_DIR);
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
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Test")
	.IsDependentOn("BasicTests")
	.IsDependentOn("Net45Tests");

Task("AppVeyor")
	.IsDependentOn("Build")
	.IsDependentOn("Test");

Task("Default")
	.IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
