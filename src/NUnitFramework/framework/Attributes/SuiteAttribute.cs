// ****************************************************************
// Copyright 2018, Charlie Poole
// This is free software licensed under the NUnit license. You
// may obtain a copy of the license at http://nunit.org.
// ****************************************************************

namespace NUnit.Framework
{
	using System;

	/// <summary>
	/// Attribute used to mark a static (shared in VB) property
	/// that returns a list of tests.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=false)]
    [Obsolete("Not supported in NUnit 3")]
	public class SuiteAttribute : Attribute
	{}
}
