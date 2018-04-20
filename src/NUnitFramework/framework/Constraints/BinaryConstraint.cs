// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
	/// <summary>
	/// BinaryConstraint is the abstract base of all constraints
	/// that combine two other constraints in some fashion.
	/// </summary>
    public abstract class BinaryConstraint : Constraint
    {
		/// <summary>
		/// The first constraint being combined
		/// </summary>
		protected Constraint left;
		/// <summary>
		/// The second constraint being combined
		/// </summary>
		protected Constraint right;

		/// <summary>
		/// Construct a BinaryConstraint from two other constraints
		/// </summary>
		/// <param name="left">The first constraint</param>
		/// <param name="right">The second constraint</param>
        protected BinaryConstraint(Constraint left, Constraint right)
            : base(left, right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
