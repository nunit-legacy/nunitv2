#tool "nuget:?package=WiX.Toolset"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// CHANGE TO SET PACKAGE AND ASSEMBLY VERSIONS
//////////////////////////////////////////////////////////////////////

var version = "2.7.0";
var modifier = ""; // for example "-beta2"

var dbgSuffix = configuration == "Debug" ? "-dbg" : "";

// Package version may be changed in Setup on AppVeyor
var packageVersion = version + modifier + dbgSuffix;

//////////////////////////////////////////////////////////////////////
// DEFINE RUN CONSTANTS
//////////////////////////////////////////////////////////////////////

var PROJECT_DIR = Context.Environment.WorkingDirectory.FullPath + "/";
var SOLUTION_FILE = PROJECT_DIR + "nunitv2.sln";

var BIN_DIR = PROJECT_DIR + "bin/" + configuration + "/";
var NUNIT_CONSOLE = BIN_DIR + "nunit-console.exe";

var INSTALL_DIR = PROJECT_DIR + "install/";

var NUGET_DIR = PROJECT_DIR + "nuget/";

var PACKAGE_DIR = PROJECT_DIR + "package/";

//////////////////////////////////////////////////////////////////////
// SETUP
//////////////////////////////////////////////////////////////////////

// These are properties because SetUp can change packageVersion

string PackageBaseName
{
    get { return "NUnit-" + packageVersion; }
}

string PackageWorkDir
{
    get { return PACKAGE_DIR + PackageBaseName + "/"; }
}

//////////////////////////////////////////////////////////////////////
// SETUP
//////////////////////////////////////////////////////////////////////

Setup(context =>
{
    if (BuildSystem.IsRunningOnAppVeyor)
    {
        var buildNumber = AppVeyor.Environment.Build.Number.ToString("00000");
        var branch = AppVeyor.Environment.Repository.Branch;
        var isPullRequest = AppVeyor.Environment.PullRequest.IsPullRequest;

        if (branch == "master" && !isPullRequest)
        {
            packageVersion = version + "-dev-" + buildNumber + dbgSuffix;
        }
        else
        {
            var suffix = "-ci-" + buildNumber + dbgSuffix;

            if (isPullRequest)
                suffix += "-pr-" + AppVeyor.Environment.PullRequest.Number;
            else if (AppVeyor.Environment.Repository.Branch.StartsWith("release", StringComparison.OrdinalIgnoreCase))
                suffix += "-pre-" + buildNumber;
            else
                suffix += "-" + branch;

            // Nuget limits "special version part" to 20 chars. Add one for the hyphen.
            if (suffix.Length > 21)
                suffix = suffix.Substring(0, 21);

            packageVersion = version + suffix;
        }

        AppVeyor.UpdateBuildVersion(packageVersion);
    }

    // Executed BEFORE the first task.
    Information("Building {0} version {1} of NUnit.", configuration, packageVersion);
});

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
        CleanDirectory(PackageWorkDir);
    });

//////////////////////////////////////////////////////////////////////
// NUGET RESTORE
//////////////////////////////////////////////////////////////////////

Task("NuGetRestore")
    .Description("Restores NuGet Packages")
    .Does(() =>
    {
        NuGetRestore(SOLUTION_FILE);
    });

//////////////////////////////////////////////////////////////////////
// Build
//////////////////////////////////////////////////////////////////////

Task("Build")
    .Description("Builds the Solution")
    .IsDependentOn("NuGetRestore")
    .Does(() =>
    {
        MSBuild(SOLUTION_FILE, new MSBuildSettings()
            .SetConfiguration(configuration)
            .SetVerbosity(Verbosity.Minimal));

        // Extra copies of some files are needed for backward compatibility
        // and to avoid changing the structure of the MSI directories.
        CopyFileToDirectory(BIN_DIR + "tests/NSubstitute.dll", BIN_DIR + "lib/");

        // Copy in NUnit project files
        CopyFile(PROJECT_DIR + "NUnitTests.v2.nunit", BIN_DIR + "NUnitTests.nunit");
        CopyFile(PROJECT_DIR + "NUnitTests.config", BIN_DIR + "NUnitTests.config");

        // Copy files for assembly load policy tests
        var targetDir = BIN_DIR + "tests/loadpolicy/lib/";
        CreateDirectory(targetDir);
        CopyFileToDirectory(BIN_DIR + "tests/nunit.framework.dll", targetDir);
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
                WorkingDirectory = BIN_DIR,
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
                Arguments = "nunit.core.tests.net45.dll nunit.framework.tests.net45.dll -noxml -framework:net-4.5"
            });

        if (rc > 0)
            throw new Exception(string.Format("{0} tests failed", rc));
        else if (rc < 0)
            throw new Exception(string.Format("Console returned rc = {0}", rc));
    });

Task("CompatibilityTests")
    .Description("Runs the compatibility tests")
    .IsDependentOn("Build")
    .Does(() =>
    {
        int rc = StartProcess(
            NUNIT_CONSOLE,
            new ProcessSettings()
            {
                WorkingDirectory = BIN_DIR + "tests",
                Arguments = "compatibility-tests.dll -noxml -compatibility"
            });

        if (rc > 0)
            throw new Exception(string.Format("{0} tests failed", rc));
        else if (rc < 0)
            throw new Exception(string.Format("Console returned rc = {0}", rc));
    });

Task("AssemblyLoadPolicyTests")
    .Description("Runs the assembly load policy tests")
    .IsDependentOn("Build")
    .Does(() =>
    {
        int rc = StartProcess(
            NUNIT_CONSOLE,
            new ProcessSettings()
            {
                WorkingDirectory = BIN_DIR + "tests/loadpolicy",
                Arguments = "simple-assembly.dll -noxml"
            });

        if (rc > 0)
            throw new Exception(string.Format("{0} tests failed", rc));
        else if (rc < 0)
            throw new Exception(string.Format("Console returned rc = {0}", rc));
    });

//////////////////////////////////////////////////////////////////////
// Package
//////////////////////////////////////////////////////////////////////

// NOTE:
//
// The Package targets do NOT depend on the Build! It is necessary to ensure
// that the build is updated before running any of these targets.
//
// Furthermore, it is not sufficient to just run the build in the IDE. Rather,
// it must be done using this script, which copies additional files to the
// directories where they need to be in order for packaging to work.

Task("CreatePackageDir")
    .Description("Creates the package directory")
    .Does(() =>
    {
        CreateDirectory(PACKAGE_DIR);
    });

Task("PackageSource")
    .Description("Create Source Package")
    .IsDependentOn("CreatePackageDir")
    .Does(() =>
    {
        string zipOutput = PACKAGE_DIR + PackageBaseName + "-src.zip";
        int rc = StartProcess("git", "archive --format=zip --output=" + zipOutput + " HEAD");
    });

Task("BuildInstallImage")
    .Description("Build the install image for zip or msi")
    .IsDependentOn("CreatePackageDir")
    .IsDependentOn("CleanPackageWorkDir")
    .Does(() =>
    {
        CopyFiles(
            new FilePath[] {
                "license.txt",
                "src/GuiRunner/nunit-gui/Logo.ico"
            },
            PackageWorkDir);
        
        var binDir = PackageWorkDir + "bin/";

        // TODO: Create a method to handle wildcard directories
        CopyFilesToDirectory(BIN_DIR + "*", binDir);
        CopyFilesToDirectory(BIN_DIR + "lib/*", binDir + "lib/");
        CopyFilesToDirectory(BIN_DIR + "lib/Images/*", binDir + "lib/Images/");
        CopyFilesToDirectory(BIN_DIR + "lib/Images/Tree/Circles/*", binDir + "lib/Images/Tree/Circles/");
        CopyFilesToDirectory(BIN_DIR + "lib/Images/Tree/Classic/*", binDir + "lib/Images/Tree/Classic/");
        CopyFilesToDirectory(BIN_DIR + "lib/Images/Tree/Default/*", binDir + "lib/Images/Tree/Default/");
        CopyFilesToDirectory(BIN_DIR + "lib/Images/Tree/Visual Studio/*", binDir + "lib/Images/Tree/Visual Studio/");
        CopyFilesToDirectory(BIN_DIR + "tests/*", binDir + "tests/");
        CopyFilesToDirectory(BIN_DIR + "framework/*", binDir + "framework/");
    });

Task("PackageZip")
    .Description("Create Binary Zip Package")
    .IsDependentOn("BuildInstallImage")
    .Does(() =>
    {
        var zipOutput = PACKAGE_DIR + PackageBaseName + ".zip";
        Zip(PackageWorkDir, zipOutput);
    });

Task("PackageMsi")
    .Description("Create the MSI Installer")
    .IsDependentOn("BuildInstallImage")
    .Does(() =>
    {
        WiXCandle(
            INSTALL_DIR + "*.wxs",

            new CandleSettings()
            {
                Defines = new Dictionary<string, string>()
                {
                    {"ProductVersion", version},
                    {"NominalVersion", packageVersion},
                    {"TargetRuntime", "net-3.5"},
                    {"InstallImage", PackageWorkDir}
                },

                OutputDirectory = PackageWorkDir
            });

        WiXLight(
            PackageWorkDir + "*.wixobj", 

            new LightSettings()
            {
                Extensions = new [] { "WixUiExtension" },

                OutputFile = PACKAGE_DIR + PackageBaseName + ".msi"
            });
    });

Task("PackageNuGet")
    .Description("Create the nuget packages")
    .IsDependentOn("BuildInstallImage")
    .Does(() =>
    {
        foreach (var nuspecFile in GetFiles(NUGET_DIR + "*.nuspec"))
            NuGetPack(nuspecFile, new NuGetPackSettings()
            {
                Version = packageVersion,
                BasePath = PackageWorkDir,
                OutputDirectory = PACKAGE_DIR,
                NoPackageAnalysis = true
            });
    });

//////////////////////////////////////////////////////////////////////
// HELPER METHODS
//////////////////////////////////////////////////////////////////////

void CopyFilesToDirectory(string pattern, string toDir)
{
    if (!DirectoryExists(toDir))
        CreateDirectory(toDir);

    CopyFiles(pattern, toDir);
}

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Rebuild")
    .IsDependentOn("Clean")
    .IsDependentOn("Build");

Task("Test")
    .IsDependentOn("BasicTests")
    .IsDependentOn("Net45Tests")
    .IsDependentOn("CompatibilityTests")
    .IsDependentOn("AssemblyLoadPolicyTests");

Task("Package")
    .IsDependentOn("PackageSource")
    .IsDependentOn("PackageZip")
    .IsDependentOn("PackageMsi")
    .IsDependentOn("PackageNuGet");

Task("AppVeyor")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Package");

Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
