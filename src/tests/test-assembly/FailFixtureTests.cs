// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.FailFixture
{
	[TestFixture]
	public class VerifyFailThrowsException
	{
		public static string failureMessage = "This should call fail";

		[Test]
		public void CallAssertFail()
		{
			Assert.Fail(failureMessage);
		}
	}

	[TestFixture]
	public class VerifyTestResultRecordsInnerExceptions
	{
		[Test]
		public void ThrowInnerException()
		{
			throw new Exception("Outer Exception", new Exception("Inner Exception"));
		}
	}

	[TestFixture]
	public class BadStackTraceFixture
	{
		[Test]
		public void TestFailure()
		{
			throw new ExceptionWithBadStackTrace("thrown by me");
		}
	}

	public class ExceptionWithBadStackTrace : Exception
	{
		public ExceptionWithBadStackTrace( string message )
			: base( message ) { }

		public override string StackTrace
		{
			get
			{
				throw new InvalidOperationException( "Simulated failure getting stack trace" );
			}
		}
	}

	[TestFixture]
	public class CustomExceptionFixture
	{
		[Test]
		public void ThrowCustomException()
		{
			throw new CustomException( "message", new CustomType() );
		}

		private class CustomType
		{
		}

		private class CustomException : Exception
		{
			public CustomType custom;

			public CustomException( string msg, CustomType custom ) : base( msg )
			{
				this.custom = custom;
			}
		}
	}
}
