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
    /// Attribute used in a TestFixture to identify a method that is 
    /// called immediately after each test is run. It is also used
    /// in a SetUpFixture to identify the method that is called once,
    /// after all subordinate tests have run. In either case, the method 
    /// is guaranteed to be called, even if an exception is thrown.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    public class TearDownAttribute : Attribute
    {}
}
