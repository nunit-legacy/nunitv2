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
	/// The ICall interface is implemented by objects that can be called
	/// with an array of arguments and return a value.
	/// </summary>
    [Obsolete("NUnit now uses NSubstitute")]
    public interface ICall
	{
		/// <summary>
		/// Process a call with a possibly empty set of arguments.
		/// </summary>
		/// <param name="args">Arguments for this call</param>
		/// <returns>An implementation-defined return value</returns>
		object Call( object[] args );
	}
}
