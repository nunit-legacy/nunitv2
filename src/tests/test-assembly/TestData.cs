// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData
{
	[TestFixture]
	public class EmptyFixture 
	{}

	/// <summary>
	/// Summary description for OneTestCase. This class serves the purpose of 
	/// having a test fixture that has one and only one test case. It is used 
	/// internally for the framework tests. 
	/// </summary>
	/// 
	[TestFixture]
	public class OneTestCase
	{
		/// <summary>
		///  The one and only test case in this fixture. It always succeeds. 
		/// </summary>
		[Test]
		public virtual void TestCase() {}
	}

	public class InheritedTestFixture : OneTestCase 
	{
		public static readonly int Tests = 2;
 
		[Test]
		public void Test2() 
		{}
	}
}
