// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Core.Tests
{
	using System;
	using NUnit.Framework;	
	using NUnit.Core;
	using NUnit.TestUtilities;

	/// <summary>
	/// Summary description for TestResultTests.
	/// </summary>
	[TestFixture]
	public class TestCaseResultFixture
	{
		private TestResult caseResult;

		[SetUp]
		public void SetUp()
		{
			caseResult = new TestResult( new TestInfo(new NUnitTestMethod(Reflect.GetNamedMethod( this.GetType(), "DummyMethod" ) ) ) );
		}

		public void DummyMethod() { }
		
		[Test]
		public void TestCaseDefault()
		{
			Assert.AreEqual( ResultState.Inconclusive, caseResult.ResultState );
		}

		[Test]
		public void TestCaseSuccess()
		{
			caseResult.Success();
			Assert.IsTrue(caseResult.IsSuccess, "result should be success");
		}

		[Test]
		public void TestCaseNotRun()
		{
			caseResult.Ignore( "because" );
			Assert.AreEqual( false, caseResult.Executed );
			Assert.AreEqual( "because", caseResult.Message );
		}

		[Test]
		public void TestCaseFailure()
		{
			caseResult.Failure("message", "stack trace");
			Assert.IsTrue(caseResult.IsFailure);
			Assert.IsFalse(caseResult.IsSuccess);
			Assert.AreEqual("message",caseResult.Message);
			Assert.AreEqual("stack trace",caseResult.StackTrace);
		}
	}
}
