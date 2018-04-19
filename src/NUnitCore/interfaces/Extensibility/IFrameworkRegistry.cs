// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Core.Extensibility
{
	/// <summary>
	/// The IFrameworkRegistry allows extensions to register new
	/// frameworks or emulations of other frameworks.
	/// </summary>
	public interface IFrameworkRegistry
	{
		/// <summary>
		/// Register a framework
		/// </summary>
		/// <param name="frameworkName">The name of the framework</param>
		/// <param name="assemblyName">The name of the assembly that the tests reference</param>
		void Register( string frameworkName, string assemblyName );
	}
}
