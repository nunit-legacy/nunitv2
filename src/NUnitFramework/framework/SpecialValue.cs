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
    /// The SpecialValue enum is used to represent TestCase arguments
    /// that cannot be used as arguments to an Attribute.
    /// </summary>
    public enum SpecialValue
    {
        /// <summary>
        /// Null represents a null value, which cannot be used as an 
        /// argument to an attribute under .NET 1.x
        /// </summary>
        Null
    }
}
