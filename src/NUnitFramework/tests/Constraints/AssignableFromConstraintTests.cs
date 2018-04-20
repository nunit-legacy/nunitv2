// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class AssignableFromConstraintTests : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new AssignableFromConstraint(typeof(D1));
            expectedDescription = string.Format("assignable from <{0}>", typeof(D1));
            stringRepresentation = string.Format("<assignablefrom {0}>", typeof(D1));
        }

        internal object[] SuccessData = new object[] { new D1(), new B() };

        internal object[] FailureData = new object[] { new D2() };

        internal string[] ActualValues = new string[]
            {
                "<NUnit.Framework.Constraints.AssignableFromConstraintTests+D2>"
            };

        class B { }

        class D1 : B { }

        class D2 : D1 { }
    }
}