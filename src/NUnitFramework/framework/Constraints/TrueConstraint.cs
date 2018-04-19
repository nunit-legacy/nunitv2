// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// TrueConstraint tests that the actual value is true
    /// </summary>
    public class TrueConstraint : BasicConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrueConstraint"/> class.
        /// </summary>
        public TrueConstraint() : base(true, "True") { }
    }
}
