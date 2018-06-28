// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// Abstract base class used for prefixes
    /// </summary>
    public abstract class PrefixConstraint : Constraint
    {
        /// <summary>
        /// The base constraint
        /// </summary>
        protected Constraint baseConstraint;

        /// <summary>
        /// Construct given a base constraint
        /// </summary>
        /// <param name="resolvable"></param>
        protected PrefixConstraint(IResolveConstraint resolvable) : base(resolvable)
        {
            if ( resolvable != null )
                this.baseConstraint = resolvable.Resolve();
        }
    }
}