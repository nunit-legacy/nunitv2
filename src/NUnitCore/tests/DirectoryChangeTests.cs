// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;
using NUnit.TestData;
using NUnit.TestUtilities;

namespace NUnit.Core.Tests
{
	[TestFixture]
	public class DirectoryChangeTests
	{
		[Test]
		public void ChangingCurrentDirectoryGivesWarning()
		{
			TestResult result = TestBuilder.RunTestCase(typeof(DirectoryChangeFixture), "ChangeCurrentDirectory");
			Assert.AreEqual(ResultState.Success, result.ResultState);
			Assert.AreEqual("Warning: Test changed the CurrentDirectory", result.Message);
		}
	}
}

