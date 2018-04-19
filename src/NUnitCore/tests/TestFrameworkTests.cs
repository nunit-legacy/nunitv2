// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;
using System.Reflection;
using NUnit.Core.Extensibility;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// Summary description for TestFrameworkTests.
	/// </summary>
	[TestFixture]
	public class TestFrameworkTests
	{
		[Test]
		public void NUnitFrameworkIsKnownAndReferenced()
		{
			FrameworkRegistry frameworks = (FrameworkRegistry)CoreExtensions.Host.GetExtensionPoint("FrameworkRegistry");
			foreach( AssemblyName assemblyName in frameworks.GetReferencedFrameworks( Assembly.GetExecutingAssembly() ) )
				if ( assemblyName.Name == "nunit.framework" ) return;
			Assert.Fail("Cannot find nunit.framework");
		}
	}
}
