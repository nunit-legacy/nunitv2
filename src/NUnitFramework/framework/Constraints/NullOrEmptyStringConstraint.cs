// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// NullEmptyStringConstraint tests whether a string is either null or empty.
    /// </summary>
    [Obsolete("Use Constraint syntax")]
    public class NullOrEmptyStringConstraint : Constraint
    {
        /// <summary>
        /// Constructs a new NullOrEmptyStringConstraint
        /// </summary>
        public NullOrEmptyStringConstraint()
        {
            this.DisplayName = "nullorempty";

            TestContext.Compatibility.Error("NullOrEmptyConstraint is not supported in NUnit 3.");
        }

        /// <summary>
        /// Test whether the constraint is satisfied by a given value
        /// </summary>
        /// <param name="actual">The value to be tested</param>
        /// <returns>True for success, false for failure</returns>
        public override bool Matches(object actual)
        {
            // NOTE: Do not change this to use string.IsNullOrEmpty
            // since that won't work in earlier versions of .NET

            this.actual = actual;

            if (actual == null) return true;

            string actualAsString = actual as string;

            if (actualAsString == null)
                throw new ArgumentException("Actual value must be a string", "actual");

            return actualAsString == string.Empty;
        }

        /// <summary>
        /// Write the constraint description to a MessageWriter
        /// </summary>
        /// <param name="writer">The writer on which the description is displayed</param>
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.Write("null or empty string");
        }
    }
}
