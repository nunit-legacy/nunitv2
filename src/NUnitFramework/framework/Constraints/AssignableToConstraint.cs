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
    /// AssignableToConstraint is used to test that an object
    /// can be assigned to a given Type.
    /// </summary>
    public class AssignableToConstraint : TypeConstraint
    {
        /// <summary>
        /// Construct an AssignableToConstraint for the type provided
        /// </summary>
        /// <param name="type"></param>
        public AssignableToConstraint(Type type) : base(type) { }

        /// <summary>
        /// Test whether an object can be assigned to the specified type
        /// </summary>
        /// <param name="actual">The object to be tested</param>
        /// <returns>True if the object can be assigned a value of the expected Type, otherwise false.</returns>
        public override bool Matches(object actual)
        {
            this.actual = actual;
            return actual != null && expectedType.IsAssignableFrom(actual.GetType());
        }

        /// <summary>
        /// Write a description of this constraint to a MessageWriter
        /// </summary>
        /// <param name="writer">The MessageWriter to use</param>
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WritePredicate("assignable to");
            writer.WriteExpectedValue(expectedType);
        }
    }
}
