// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System.Diagnostics;
using System.IO;
using NUnit.Core;
using NUnit.Core.Tests;
using NUnit.Framework;
using NUnit.Tests.Assemblies;

namespace NUnit.Util.Tests
{
	/// <summary>
	/// Summary description for ProcessRunnerTests.
	/// </summary>
    [TestFixture, Timeout(30000)]
    [Platform(Exclude = "Mono", Reason = "Process Start not working correctly")]
    public class ProcessRunnerTests : BasicRunnerTests
    {
        private ProcessRunner myRunner;

        protected override TestRunner CreateRunner(int runnerID)
        {
            myRunner = new ProcessRunner(runnerID);
            return myRunner;
        }

        protected override void DestroyRunner()
        {
            if (myRunner != null)
            {
                myRunner.Unload();
                myRunner.Dispose();
            }
        }

        [Test]
        public void  TestProcessIsReused()
        {
            TestPackage package = new TestPackage(MockAssembly.AssemblyPath);
            myRunner.Load(package);
            int processId = ((TestAssemblyInfo)myRunner.AssemblyInfo[0]).ProcessId;
            Assert.AreNotEqual(Process.GetCurrentProcess().Id, processId, "Not in separate process");
            myRunner.Unload();
            myRunner.Load(package);
            Assert.AreEqual(processId, ((TestAssemblyInfo)myRunner.AssemblyInfo[0]).ProcessId, "Reloaded in different process");
        }
    }
}
