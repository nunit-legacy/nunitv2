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
    /// Attribute used to identify a method that is called after
    /// all the tests in a fixture have run. The method is 
    /// guaranteed to be called, even if an exception is thrown.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
    [Obsolete("Use OneTimeTearDownAttribute")]
    public class TestFixtureTearDownAttribute : Attribute
    {
    }
}

