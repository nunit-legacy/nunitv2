// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;

namespace NUnit.Framework
{
    /// <summary>
    /// The different targets a test action attribute can be applied to
    /// </summary>
    [Flags]
    public enum ActionTargets
    {
        /// <summary>
        /// Default target, which is determined by where the action attribute is attached
        /// </summary>
        Default = 0,

        /// <summary>
        /// Target a individual test case
        /// </summary>
        Test = 1,

        /// <summary>
        /// Target a suite of test cases
        /// </summary>
        Suite = 2
    }
}
#endif
