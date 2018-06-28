// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System.Reflection;

namespace NUnit.Core
{
    /// <summary>
    /// Class to implement an NUnit test method
    /// </summary>
    public class NUnitTestMethod : TestMethod
    {
        #region Constructor
        public NUnitTestMethod(MethodInfo method) : base(method) 
        {
        }
        #endregion

        #region TestMethod Overrides

        /// <summary>
        /// Run a test returning the result. Overrides TestMethod
        /// to count assertions.
        /// </summary>
        /// <param name="testResult"></param>
        public override TestResult RunTest()
        {
            TestResult testResult = base.RunTest();

            testResult.AssertCount = NUnitFramework.Assert.GetAssertCount();
            
            return testResult;
        }
        #endregion
    }
}
