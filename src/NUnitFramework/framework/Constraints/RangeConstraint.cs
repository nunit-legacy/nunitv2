// ****************************************************************
// Copyright 2008, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org/?p=license&r=2.4
// ****************************************************************

using System;

namespace NUnit.Framework.Constraints
{
    public class RangeConstraint : Constraint
    {
        private IComparable from;
        private IComparable to;

        public RangeConstraint(IComparable from, IComparable to)
        {
            this.from = from;
            this.to = to;
        }

        public override bool Matches(object actual)
        {
            this.actual = actual;

            return Numerics.Compare(from, actual) <= 0 &&
                   Numerics.Compare(to, actual) >= 0;
        }

        public override void WriteDescriptionTo(MessageWriter writer)
        {

            writer.Write("in range ({0},{1})", from, to);
        }
    }
}