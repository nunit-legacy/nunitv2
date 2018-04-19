// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Core
{
	/// <summary>
	/// TestBuilderAttribute is used to mark custom test case builders.
	/// The class so marked must implement the ITestCaseBuilder interface.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
	public sealed class TestCaseBuilderAttribute : System.Attribute
	{}
}
