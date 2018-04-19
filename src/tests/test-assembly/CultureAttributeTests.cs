// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.CultureAttributeTests
{
	[TestFixture, Culture( "en,fr,de" )]
	public class FixtureWithCultureAttribute
	{
		[Test, Culture("en,de")]
		public void EnglishAndGermanTest() { }

		[Test, Culture("fr")]
		public void FrenchTest() { }

		[Test, Culture("fr-CA")]
		public void FrenchCanadaTest() { }
	}

	[TestFixture]
	public class InvalidCultureFixture
	{
		[Test,SetCulture("xx-XX")]
		public void InvalidCultureSet() { }
	}
}