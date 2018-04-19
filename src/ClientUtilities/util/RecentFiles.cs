// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Util
{
	/// <summary>
	/// The RecentFiles interface is used to isolate the app
	/// from various implementations of recent files.
	/// </summary>
	public interface RecentFiles
	{ 
		/// <summary>
		/// The max number of files saved
		/// </summary>
		int MaxFiles { get; set; }

		/// <summary>
		/// The current number of saved files
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Get a list of all the file entries
		/// </summary>
		/// <returns>The most recent file list</returns>
		RecentFilesCollection Entries { get; }

		/// <summary>
		/// Set the most recent file entry, reordering
		/// the saved names as needed and removing the oldest
		/// if the max number of files would be exceeded.
		/// </summary>
		void SetMostRecent( RecentFileEntry entry );

		/// <summary>
		/// Set the most recent file name, reordering
		/// the saved names as needed and removing the oldest
		/// if the max number of files would be exceeded.
		/// The current CLR version is used to create the entry.
		/// </summary>
		void SetMostRecent( string fileName );

		/// <summary>
		/// Remove a file from the list
		/// </summary>
		/// <param name="fileName">The name of the file to remove</param>
		void Remove( string fileName );
	}
}
