// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using System.Text;
using NUnit.Framework;
using NUnit.TestUtilities;

namespace NUnit.Core.Tests
{
    [TestFixture, Explicit("These tests fail by design")]
    public class UnhandledExceptionTests
    {
        #region Normal
        [NUnit.Framework.Test]
        public void Normal()
        {
            testDummy("Normal", false);
        }

        private static void testDummy(string dummyName, bool shouldPass)
        {
            Type fixtureType = typeof(NUnit.TestData.UnhandledExceptions);
            Test test = TestBuilder.MakeTestCase(fixtureType, dummyName);
            TestResult result = test.Run(NullListener.NULL, TestFilter.Empty);
            if (shouldPass)
                Assert.IsTrue(result.IsSuccess, "{0} test should have passed", dummyName);
            else
            {
                Assert.IsTrue(result.IsFailure, "{0} test should have failed", dummyName);
                Assert.AreEqual("System.ApplicationException : Test exception", result.Message);
            }
        }
        #endregion Normal

        #region Threaded
        [NUnit.Framework.Test]
        public void Threaded()
        {
            // TODO: Make this fail
            testDummy("Threaded", true);
        }
        #endregion Threaded

        #region ThreadedAndWait
        [NUnit.Framework.Test]
        public void ThreadedAndWait()
        {
            // TODO: Make this fail
            testDummy("ThreadedAndWait", true);
        }
        #endregion ThreadedAndWait

        #region ThreadedAndForget
        [NUnit.Framework.Test]
        public void ThreadedAndForget()
        {
            // TODO: Make this fail
            testDummy("ThreadedAndForget", true);
        }
        #endregion ThreadedAndForget

        #region ThreadedAssert
        [NUnit.Framework.Test]
        public void ThreadedAssert()
        {
            testDummy("ThreadedAssert", true);
        }
        #endregion
    }

}
