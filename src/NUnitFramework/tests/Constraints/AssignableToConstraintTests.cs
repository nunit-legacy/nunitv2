// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class AssignableToConstraintTests : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new AssignableToConstraint(typeof(D1));
            expectedDescription = string.Format("assignable to <{0}>", typeof(D1));
            stringRepresentation = string.Format("<assignableto {0}>", typeof(D1));
        }
        
        internal object[] SuccessData = new object[] { new D1(), new D2() };
            
        internal object[] FailureData = new object[] { new B() };

        internal string[] ActualValues = new string[]
            {
                "<NUnit.Framework.Constraints.AssignableToConstraintTests+B>"
            };

        class B { }

        class D1 : B { }

        class D2 : D1 { }
    }
}