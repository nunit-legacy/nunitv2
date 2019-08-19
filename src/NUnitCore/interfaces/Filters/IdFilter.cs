// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections.Generic;

namespace NUnit.Core.Filters
{
    /// <summary>
    /// Summary description for NameFilter.
    /// </summary>
    /// 
    [Serializable]
    public class IdFilter : TestFilter
    {
        private int _runnerID;
        private TestID _testID;

        /// <summary>
        /// Construct a IdFilter for a single TestID
        /// </summary>
        /// <param name="runnerID">The ID of the expected runner</param>
        /// <param name="testID">The ID of the test itself</param>
        public IdFilter(int runnerID, TestID testID)
        {
            _runnerID = runnerID;
            _testID = testID;
        }

        /// <summary>
        /// Check if a test matches the filter
        /// </summary>
        /// <param name="test">The test to match</param>
        /// <returns>True if it matches, false if not</returns>
        public override bool Match(ITest test)
        {
            return test.TestName.RunnerID == _runnerID
                && test.TestName.TestID == _testID;
        }
    }
}
