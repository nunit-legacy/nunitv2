// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework.Tests;

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class ThrowsConstraintTest_ExactType : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new ThrowsConstraint(
                new ExactTypeConstraint(typeof(ArgumentException)));
            expectedDescription = "<System.ArgumentException>";
            stringRepresentation = "<throws <typeof System.ArgumentException>>";
        }

        internal static object[] SuccessData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsArgumentException )
        };

        internal static object[] FailureData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsApplicationException ),
            new TestDelegate( TestDelegates.ThrowsNothing ),
            new TestDelegate( TestDelegates.ThrowsSystemException )
        };

        internal static string[] ActualValues = new string[]
        {
            "<System.ApplicationException>",
            "no exception thrown",
            "<System.Exception>"
        };
    }

    [TestFixture]
    public class ThrowsConstraintTest_InstanceOfType : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new ThrowsConstraint(
                new InstanceOfTypeConstraint(typeof(ApplicationException)));
            expectedDescription = "instance of <System.ApplicationException>";
            stringRepresentation = "<throws <instanceof System.ApplicationException>>";
        }

        internal static object[] SuccessData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsApplicationException ),
            new TestDelegate( TestDelegates.ThrowsDerivedApplicationException )
        };

        internal static object[] FailureData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsArgumentException ),
            new TestDelegate( TestDelegates.ThrowsNothing ),
            new TestDelegate( TestDelegates.ThrowsSystemException )
        };

        internal static string[] ActualValues = new string[]
        {
            "<System.ArgumentException>",
            "no exception thrown",
            "<System.Exception>"
        };
    }

    public class ThrowsConstraintTest_WithConstraint : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new ThrowsConstraint(
                new AndConstraint(
                    new ExactTypeConstraint(typeof(ArgumentException)),
                    new PropertyConstraint("ParamName", new EqualConstraint("myParam"))));
            expectedDescription = @"<System.ArgumentException> and property ParamName equal to ""myParam""";
            stringRepresentation = @"<throws <and <typeof System.ArgumentException> <property ParamName <equal ""myParam"">>>>";
        }

        internal static object[] SuccessData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsArgumentException )
        };

        internal static object[] FailureData = new object[]
        {
            new TestDelegate( TestDelegates.ThrowsApplicationException ),
            new TestDelegate( TestDelegates.ThrowsNothing ),
            new TestDelegate( TestDelegates.ThrowsSystemException )
        };

        internal static string[] ActualValues = new string[]
        {
            "<System.ApplicationException>",
            "no exception thrown",
            "<System.Exception>"
        };
    }
}
