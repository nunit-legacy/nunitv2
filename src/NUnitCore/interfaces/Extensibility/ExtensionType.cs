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
	/// The ExtensionType enumeration is used to indicate the
	/// kinds of extensions provided by an Addin. The addin
	/// is only installed by hosts supporting one of its
	/// extension types.
	/// </summary>
	[Flags]
	public enum ExtensionType
	{
		/// <summary>
		/// A Core extension is installed by the CoreExtensions
		/// host in each test domain.
		/// </summary>
		Core=1,

		/// <summary>
		/// A Client extension is installed by all clients
		/// </summary>
		Client=2,

		/// <summary>
		/// A Gui extension is installed by the gui client
		/// </summary>
		Gui=4
	}
}
