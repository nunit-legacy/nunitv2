// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework
{
    using System;

    /// <summary>
    /// SetUpAttribute is used in a TestFixture to identify a method
    /// that is called immediately before each test is run. It is 
    /// also used in a SetUpFixture to identify the method that is
    /// called once, before any of the subordinate tests are run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class SetUpAttribute : Attribute
    {}
}
