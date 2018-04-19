// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework
{
	using System;

	/// <summary>
	/// Adding this attribute to a method within a <seealso cref="TestFixtureAttribute"/> 
	/// class makes the method callable from the NUnit test runner. There is a property 
	/// called Description which is optional which you can provide a more detailed test
	/// description. This class cannot be inherited.
	/// </summary>
	/// 
	/// <example>
	/// [TestFixture]
	/// public class Fixture
	/// {
	///   [Test]
	///   public void MethodToTest()
	///   {}
	///   
	///   [Test(Description = "more detailed description")]
	///   publc void TestDescriptionMethod()
	///   {}
	/// }
	/// </example>
	/// 
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=true)]
	public class TestAttribute : Attribute
	{
		private string description;

		/// <summary>
		/// Descriptive text for this test
		/// </summary>
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	}
}
