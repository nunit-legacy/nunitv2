// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework
{
    /// <summary>
    /// Used to mark a field for use as a datapoint when executing a theory
    /// within the same fixture that requires an argument of the field's Type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class DatapointAttribute : Attribute
    {
    }

    /// <summary>
    /// Used to mark an array as containing a set of datapoints to be used
    /// executing a theory within the same fixture that requires an argument 
    /// of the Type of the array elements.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class DatapointsAttribute : Attribute
    {
    }
}
