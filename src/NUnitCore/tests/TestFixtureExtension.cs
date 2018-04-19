// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;
using NUnit.Core.Builders;
using NUnit.TestUtilities;
using NUnit.TestData.TestFixtureExtension;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// Summary description for TestFixtureExtension.
	/// </summary>
	/// 
	[TestFixture]
	public class TestFixtureExtension
	{
		private Test suite;

		private void RunTestOnFixture( object fixture )
		{
			Test suite = TestBuilder.MakeFixture( fixture );
            suite.Run(NullListener.NULL, TestFilter.Empty);
		}

		[SetUp] public void LoadFixture()
		{
            string testsDll = AssemblyHelper.GetAssemblyPath(typeof(DerivedTestFixture));
			TestSuiteBuilder builder = new TestSuiteBuilder();
			TestPackage package = new TestPackage( testsDll );
			package.TestName = typeof(DerivedTestFixture).FullName;
			suite= builder.Build( package );
		}

		[Test] 
		public void CheckMultipleSetUp()
		{
			SetUpDerivedTestFixture fixture = new SetUpDerivedTestFixture();
			RunTestOnFixture( fixture );

			Assert.AreEqual(true, fixture.baseSetup);		}

		[Test]
		public void DerivedTest()
		{
			Assert.IsNotNull(suite);

            TestResult result = suite.Run(NullListener.NULL, TestFilter.Empty);
			Assert.IsTrue(result.IsSuccess);
		}

		[Test]
		public void InheritSetup()
		{
			DerivedTestFixture fixture = new DerivedTestFixture();
			RunTestOnFixture( fixture );

			Assert.AreEqual(true, fixture.baseSetup);
		}

		[Test]
		public void InheritTearDown()
		{
			DerivedTestFixture fixture = new DerivedTestFixture();
			RunTestOnFixture( fixture );

			Assert.AreEqual(true, fixture.baseTeardown);
		}
	}
}
