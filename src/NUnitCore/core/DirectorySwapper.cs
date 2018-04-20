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
	/// Utility class that allows changing the current directory 
	/// for the duration of some lexical scope and guaranteeing
	/// that it will be restored upon exit.
	/// 
	/// Use it as follows:
	///    using( new DirectorySwapper( @"X:\New\Path" )
	///    {
	///        // Code that operates in the new current directory
	///    }
	///    
	/// Instantiating DirectorySwapper without a path merely
	/// saves the current directory, but does not change it.
	/// </summary>
	public class DirectorySwapper : IDisposable
	{
		private string savedDirectoryName;

		public DirectorySwapper() : this( null ) { }

		public DirectorySwapper( string directoryName )
		{
			savedDirectoryName = Environment.CurrentDirectory;
			
			if ( directoryName != null && directoryName != string.Empty )
				Environment.CurrentDirectory = directoryName;
		}

		public void Dispose()
		{
			Environment.CurrentDirectory = savedDirectoryName;
		}
	}
}
