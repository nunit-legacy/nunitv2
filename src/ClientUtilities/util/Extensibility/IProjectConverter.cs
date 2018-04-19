// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Util.Extensibility
{
	/// <summary>
	/// The IProjectConverter interface is implemented by any class
	/// that knows how to convert a foreign project format to an
	/// NUnitProject.
	/// </summary>
	public interface IProjectConverter
	{
		/// <summary>
		/// Returns true if the file indicated is one that this
		/// converter knows how to convert.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		bool CanConvertFrom( string path );

		/// <summary>
		/// Converts an external project returning an NUnitProject
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		NUnitProject ConvertFrom( string path );
	}
}
