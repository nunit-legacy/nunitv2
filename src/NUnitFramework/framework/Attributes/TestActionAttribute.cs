// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Framework
{
    /// <summary>
    /// Provide actions to execute before and after tests.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class TestActionAttribute : Attribute, ITestAction
    {
        /// <summary>
        /// Method called before each test
        /// </summary>
        /// <param name="testDetails">Info about the test to be run</param>
        public virtual void BeforeTest(TestDetails testDetails) { }

        /// <summary>
        /// Method called after each test
        /// </summary>
        /// <param name="testDetails">Info about the test that was just run</param>
        public virtual void AfterTest(TestDetails testDetails) { }
        
        /// <summary>
        /// Gets or sets the ActionTargets for this attribute
        /// </summary>
        public virtual ActionTargets Targets
        {
            get { return ActionTargets.Default; }
        }
    }
}
#endif