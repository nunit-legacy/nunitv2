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
	/// Attribute used to mark a static (shared in VB) property
	/// that returns a list of tests.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=false)]
    [Obsolete("Not supported in NUnit 3")]
	public class SuiteAttribute : Attribute
	{}
}
