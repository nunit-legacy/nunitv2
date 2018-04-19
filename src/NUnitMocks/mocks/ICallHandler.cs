// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Mocks
{
	/// <summary>
	/// The ICallHandler interface dispatches calls to methods or
	/// other objects implementing the ICall interface.
	/// </summary>
    [Obsolete("NUnit now uses NSubstitute")]
    public interface ICallHandler
	{		
		/// <summary>
		/// Simulate a method call on the mocked object.
		/// </summary>
		/// <param name="methodName">The name of the method</param>
		/// <param name="args">Arguments for this call</param>
		/// <returns>Previously specified object or null</returns>
		object Call( string methodName, params object[] args );
	}
}
