// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.TestData.CategoryAttributeTests
{
	[TestFixture, InheritableCategory("MyCategory")]
	public abstract class AbstractBase { }
	
	[TestFixture, Category( "DataBase" )]
	public class FixtureWithCategories : AbstractBase
	{
		[Test, Category("Long")]
		public void Test1() { }

		[Test, Critical]
		public void Test2() { }
	}
	
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
	public class CriticalAttribute : CategoryAttribute { }
	
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
	public class InheritableCategoryAttribute : CategoryAttribute
	{ 
		public InheritableCategoryAttribute(string name) : base(name) { }
	}
}