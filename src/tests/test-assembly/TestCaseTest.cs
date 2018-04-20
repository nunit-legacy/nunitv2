// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.TestCaseTest
{
	[TestFixture]
	public class HasCategories 
	{
		[Test] 
		[Category("A category")]
		[Category("Another Category")]
		public void ATest()
		{}
	}
}
