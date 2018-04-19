// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;
using System.Reflection;

namespace NUnit.Framework
{
    /// <summary>
    /// When implemented by an attribute, this interface implemented to provide actions to execute before and after tests.
    /// </summary>
    public interface ITestAction
    {
        /// <summary>
        /// Executed before each test is run
        /// </summary>
        /// <param name="testDetails">Provides details about the test that is going to be run.</param>
        void BeforeTest(TestDetails testDetails);

        /// <summary>
        /// Executed after each test is run
        /// </summary>
        /// <param name="testDetails">Provides details about the test that has just been run.</param>
        void AfterTest(TestDetails testDetails);


        /// <summary>
        /// Provides the target for the action attribute
        /// </summary>
        /// <returns>The target for the action attribute</returns>
        ActionTargets Targets { get; }
    }
}
#endif
