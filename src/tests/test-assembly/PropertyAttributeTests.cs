// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.PropertyAttributeTests
{
	[TestFixture, Property("ClassUnderTest","SomeClass" )]
	public class FixtureWithProperties
	{
		[Test, Property("user","Charlie")]
		public void Test1() { }

		[Test, Property("X",10.0), Property("Y",17.0)]
		public void Test2() { }

		[Test, Priority(5)]
		public void Test3() { }
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
	public class PriorityAttribute : PropertyAttribute
	{
		public PriorityAttribute( int level ) : base( level ) { }
	}
}
