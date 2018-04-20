// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework
{
    /// <summary>
    /// The TestStatus enum indicates the result of running a test
    /// </summary>
    public enum TestStatus
    {
        /// <summary>
        /// The test was inconclusive
        /// </summary>
        Inconclusive = 0,

        /// <summary>
        /// The test has skipped 
        /// </summary>
        Skipped = 1,

        /// <summary>
        /// The test succeeded
        /// </summary>
        Passed = 2,

        /// <summary>
        /// The test failed
        /// </summary>
        Failed = 3
    }
}
