// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class AttributeExistsConstraintTest : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new AttributeExistsConstraint(typeof(TestFixtureAttribute));
            expectedDescription = "type with attribute <NUnit.Framework.TestFixtureAttribute>";
            stringRepresentation = "<attributeexists NUnit.Framework.TestFixtureAttribute>";
        }

        internal object[] SuccessData = new object[] { typeof(AttributeExistsConstraintTest) };

        internal object[] FailureData = new object[] { typeof(D2) };

        internal string[] ActualValues = new string[]
            {
                "<NUnit.Framework.Constraints.D2>"
            };

        [Test, ExpectedException(typeof(System.ArgumentException))]
        public void NonAttributeThrowsException()
        {
            new AttributeExistsConstraint(typeof(string));
        }

        [Test]
        public void AttributeExistsOnMethodInfo()
        {
            Assert.That(
                System.Reflection.MethodInfo.GetCurrentMethod(),
                new AttributeExistsConstraint(typeof(TestAttribute)));
        }

        [Test, Description("my description")]
        public void AttributeTestPropertyValueOnMethodInfo()
        {
            Assert.That(
                System.Reflection.MethodInfo.GetCurrentMethod(),
                Has.Attribute(typeof(DescriptionAttribute)).Property("Description").EqualTo("my description"));
        }

        [Test]
        public void CanCombineAttributeConstraints()
        {
            Assert.That(
                System.Reflection.MethodInfo.GetCurrentMethod(),
                new AttributeExistsConstraint(typeof(TestFixtureAttribute)) | new AttributeExistsConstraint(typeof(TestAttribute)));
            //Has.Attribute<TestFixtureAttribute>() || Has.Attribute<TestAttribute>());
            //new AttributeExistsConstraint(typeof(TestAttribute)));
        }
    }

    class B { }

    class D1 : B { }

    class D2 : D1 { }
}
