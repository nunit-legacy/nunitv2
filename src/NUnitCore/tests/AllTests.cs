// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;
using NUnit.Core.Builders;
using NUnit.TestData;

namespace NUnit.Core.Tests
{
	public class AllTests
	{
		[Suite]
		public static TestSuite Suite
		{
			get 
			{
				TestSuite suite = new TestSuite("All Tests");
				suite.Add( new OneTestCase() );
				suite.Add( new AssemblyTests() );
				suite.Add( new NoNamespaceTestFixture() );
				return suite;
			}
		}
	}
}
