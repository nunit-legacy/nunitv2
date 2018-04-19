// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using NUnit.Framework;
using NUnit.Core;

namespace NUnit.TestData.LegacySuiteData
{
	public class Suite
	{
		[Suite]
		public static TestSuite MockSuite
		{
			get 
			{
				TestSuite testSuite = new TestSuite("TestSuite");
				return testSuite;
			}
		}
	}

	class NonConformingSuite
	{
		[Suite]
		public static int Integer
		{
			get 
			{
				return 5;
			}
		}
	}

    public class LegacySuiteReturningFixtureWithArguments
    {
        [Suite]
        public static IEnumerable Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(new TestClass(5));
                return suite;
            }
        }

        [TestFixture]
        public class TestClass
        {
            public int num;

            public TestClass(int num)
            {
                this.num = num;
            }
        }
    }
}
