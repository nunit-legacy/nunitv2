// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// Operator used to test for the presence of a named Property
    /// on an object and optionally apply further tests to the
    /// value of that property.
    /// </summary>
    public class PropOperator : SelfResolvingOperator
    {
        private readonly string name;

        /// <summary>
        /// Gets the name of the property to which the operator applies
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Constructs a PropOperator for a particular named property
        /// </summary>
        public PropOperator(string name)
        {
            this.name = name;

            // Prop stacks on anything and allows only 
            // prefix operators to stack on it.
            this.left_precedence = this.right_precedence = 1;
        }

        /// <summary>
        /// Reduce produces a constraint from the operator and 
        /// any arguments. It takes the arguments from the constraint 
        /// stack and pushes the resulting constraint on it.
        /// </summary>
        /// <param name="stack"></param>
        public override void Reduce(ConstraintBuilder.ConstraintStack stack)
        {
            if (RightContext == null || RightContext is BinaryOperator)
                stack.Push(new PropertyExistsConstraint(name));
            else
                stack.Push(new PropertyConstraint(name, stack.Pop()));
        }
    }
}
