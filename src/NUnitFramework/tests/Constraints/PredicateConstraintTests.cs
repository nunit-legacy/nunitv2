// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;

namespace NUnit.Framework.Constraints
{
    [TestFixture]
    public class PredicateConstraintTests : ConstraintTestBase
    {
        [SetUp]
        public void SetUp()
        {
            theConstraint = new PredicateConstraint<int>((x) => x < 5 );
            expectedDescription = @"value matching lambda expression";
            stringRepresentation = "<predicate>";
        }

        internal object[] SuccessData = new object[] 
        {
            0,
            -5
        };

        internal object[] FailureData = new object[]
        {
            123
        };
        internal string[] ActualValues = new string[]
        {
            "123"
        };
    }
}
#endif
