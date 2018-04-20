// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Core;

namespace NUnit.Util
{
    /// <summary>
    /// A Test Runner factory can supply a suitable test runner for a given package
    /// </summary>
    public interface ITestRunnerFactory
    {
        /// <summary>
        /// Return a suitable runner for the package provided as an argument
        /// </summary>
        /// <param name="package">The test package to be loaded by the runner</param>
        /// <returns>A TestRunner</returns>
        TestRunner MakeTestRunner(TestPackage package);

        /// <summary>
        /// Return true if the provided runner is suitable for reuse in loading
        /// the test package provided. Otherwise, return false.
        /// </summary>
        /// <param name="package"></param>
        /// <param name="runner"></param>
        /// <returns>True if the runner may be reused</returns>
        bool CanReuse(TestRunner runner, TestPackage package);
    }
}
