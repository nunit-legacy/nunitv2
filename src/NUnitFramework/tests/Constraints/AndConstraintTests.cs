// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class AndConstraintTests : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new AndConstraint(new GreaterThanConstraint(40), new LessThanConstraint(50));
            expectedDescription = "greater than 40 and less than 50";
            stringRepresentation = "<and <greaterthan 40> <lessthan 50>>";
        }

        internal object[] SuccessData = new object[] { 42 };
    
        internal object[] FailureData = new object[] { 37, 53 };

        internal string[] ActualValues = new string[] { "37", "53" };

        [Test]
        public void CanCombineTestsWithAndOperator()
        {
            Assert.That(42, new GreaterThanConstraint(40) & new LessThanConstraint(50));
        }
    }
}