// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class EmptyConstraintTest : ConstraintTestBaseWithArgumentException
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new EmptyConstraint();
            expectedDescription = "<empty>";
            stringRepresentation = "<empty>";
        }

        internal static object[] SuccessData = new object[] 
        {
            string.Empty,
            new object[0],
            new ArrayList(),
#if CLR_2_0 || CLR_4_0
            new System.Collections.Generic.List<int>()
#endif  
        };

        internal static object[] FailureData = new object[]
        {
            "Hello",
            new object[] { 1, 2, 3 }
        };

        internal static string[] ActualValues = new string[]
        {
            "\"Hello\"",
            "< 1, 2, 3 >"
        };

        internal static object[] InvalidData = new object[]
            {
                null,
                5
            };
    }

    [TestFixture]
    public class NullOrEmptyStringConstraintTest : ConstraintTestBaseWithArgumentException
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new NullOrEmptyStringConstraint();
            expectedDescription = "null or empty string";
            stringRepresentation = "<nullorempty>";
        }

        internal static object[] SuccessData = new object[] 
        {
            string.Empty,
            null
        };

        internal static object[] FailureData = new object[]
        {
            "Hello"
        };

        internal static string[] ActualValues = new string[]
        {
            "\"Hello\""
        };

        internal static object[] InvalidData = new object[]
            {
                5
            };
    }
}