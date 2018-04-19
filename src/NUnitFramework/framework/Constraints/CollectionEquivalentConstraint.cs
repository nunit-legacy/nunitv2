// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System.Collections;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// CollectionEquivalentCOnstraint is used to determine whether two
    /// collections are equivalent.
    /// </summary>
    public class CollectionEquivalentConstraint : CollectionItemsEqualConstraint
    {
        private readonly IEnumerable expected;

        /// <summary>
        /// Construct a CollectionEquivalentConstraint
        /// </summary>
        /// <param name="expected"></param>
        public CollectionEquivalentConstraint(IEnumerable expected)
            : base(expected)
        {
            this.expected = expected;
            this.DisplayName = "equivalent";
        }

        /// <summary>
        /// Test whether two collections are equivalent
        /// </summary>
        /// <param name="actual"></param>
        /// <returns></returns>
        protected override bool doMatch(IEnumerable actual)
        {
            // This is just an optimization
            if (expected is ICollection && actual is ICollection)
                if (((ICollection)actual).Count != ((ICollection)expected).Count)
                    return false;

            CollectionTally tally = Tally(expected);
            return tally.TryRemove(actual) && tally.Count == 0;
        }

        /// <summary>
        /// Write a description of this constraint to a MessageWriter
        /// </summary>
        /// <param name="writer"></param>
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WritePredicate("equivalent to");
            writer.WriteExpectedValue(expected);
        }
    }
}
