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
	/// The AddinStatus enum indicates the load status of an addin.
	/// </summary>
    public enum AddinStatus
    {
		/// <summary>
		/// Not known - default
		/// </summary>
        Unknown,
		/// <summary>
		/// The addin is enabled but not loaded
		/// </summary>
        Enabled,
		/// <summary>
		/// The addin is disabled
		/// </summary>
        Disabled,
		/// <summary>
		/// The addin was loaded successfully
		/// </summary>
        Loaded,
		/// <summary>
		/// An error was encountered loading the addin
		/// </summary>
        Error
    }
}
