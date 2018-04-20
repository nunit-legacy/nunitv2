// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData
{
    [TestFixture(1)]
    [TestFixture(2)]
    public class ParameterizedTestFixture
    {
        [Test]
        public void MethodWithoutParams()
        {
        }

        [TestCase(10,20)]
        public void MethodWithParams(int x, int y)
        {
        }
    }

    [TestFixture(Category = "XYZ")]
    public class TestFixtureWithSingleCategory
    {
    }

    [TestFixture(Category = "X,Y,Z")]
    public class TestFixtureWithMultipleCategories
    {
    }
}
