// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.TestFixtureExtension
{
	[TestFixture]
	public abstract class BaseTestFixture
	{
		public bool baseSetup = false;
		public bool baseTeardown = false;

        [SetUp]
		public void SetUp()
		{ baseSetup = true; }

        [TearDown]
		public void TearDown()
		{ baseTeardown = true; }
	}

	public class DerivedTestFixture : BaseTestFixture
	{
		[Test]
		public void Success()
		{
			Assert.IsTrue(true);
		}
	}

	public class SetUpDerivedTestFixture : BaseTestFixture
	{
		[SetUp]
		public void Init()
		{
			base.SetUp();
		}

		[Test]
		public void Success()
		{
			Assert.IsTrue(true);
		}
	}
}
