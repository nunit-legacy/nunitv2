// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.IgnoreFixture
{
	[TestFixture]
	public class IgnoredTestCaseFixture
	{
        [Test]
        public void CallsIgnore()
        {
            Assert.Ignore("Ignore me");
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void CallsIgnoreWithExpectedException()
        {
            Assert.Ignore("Ignore me");
        }
    }

	[TestFixture]
	public class IgnoredTestSuiteFixture
	{
		[TestFixtureSetUp]
		public void FixtureSetUp()
		{
			Assert.Ignore("Ignore this fixture");
		}

		[Test]
		public void ATest()
		{
		}

		[Test]
		public void AnotherTest()
		{
		}
	}

	[TestFixture]
	public class IgnoreInSetUpFixture
	{
		[SetUp]
		public void SetUp()
		{
			Assert.Ignore( "Ignore this test" );
		}

		[Test]
		public void Test1()
		{
		}

		[Test]
		public void Test2()
		{
		}
	}
}
