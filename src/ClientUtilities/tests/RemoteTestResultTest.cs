// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;
using NUnit.Core;

namespace NUnit.Util.Tests
{
    [TestFixture]
    public class RemoteTestResultTest
    {
        private static readonly string mockDll = 
            NUnit.Tests.Assemblies.MockAssembly.AssemblyPath; 
        private TestDomain domain;

        [SetUp]
        public void CreateRunner()
        {
            domain = new TestDomain();
        }

        [TearDown]
        public void UnloadRunner()
        {
            if ( domain != null )
                domain.Unload();
        }

        [Test]
        public void ResultStillValidAfterDomainUnload() 
        {
            //TODO: This no longer appears to test anything
            TestPackage package = new TestPackage( mockDll );
            Assert.IsTrue( domain.Load( package ) );
            TestResult result = domain.Run( new NullListener(), TestFilter.Empty, false, LoggingThreshold.Off );
            TestResult caseResult = findCaseResult(result);
            Assert.IsNotNull(caseResult);
            //TestResultItem item = new TestResultItem(caseResult);
            //string message = item.GetMessage();
            //Assert.IsNotNull(message);
        }

        [Test, Explicit("Fails intermittently")]
        public void AppDomainUnloadedBug()
        {
            TestDomain domain = new TestDomain();
            domain.Load( new TestPackage( mockDll ) );
            domain.Run(new NullListener(), TestFilter.Empty, false, LoggingThreshold.Off);
            domain.Unload();
        }

        private TestResult findCaseResult(TestResult suite) 
        {
            foreach (TestResult r in suite.Results) 
            {
                if (!r.Test.IsSuite)
                {
                    return r;
                }
                else 
                {
                    TestResult result = findCaseResult(r);
                    if (result != null)
                        return result;
                }

            }

            return null;
        }
    }
}
