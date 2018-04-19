// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Util
{
	public class RecentFileEntry
	{
		public static readonly char Separator = ',';

		private string path;
		
		private Version clrVersion;

		public RecentFileEntry( string path )
		{
			this.path = path;
			this.clrVersion = Environment.Version;
		}

		public RecentFileEntry( string path, Version clrVersion )
		{
			this.path = path;
			this.clrVersion = clrVersion;
		}

		public string Path
		{
			get { return path; }
		}

		public Version CLRVersion
		{
			get { return clrVersion; }
		}

		public bool Exists
		{
			get { return path != null && System.IO.File.Exists( path ); }
		}

		public bool IsCompatibleCLRVersion
		{
			get { return clrVersion.Major <= Environment.Version.Major; }
		}

		public override string ToString()
		{
			return Path + Separator + CLRVersion.ToString();
		}

		public static RecentFileEntry Parse( string text )
		{
			int sepIndex = text.LastIndexOf( Separator );

			if ( sepIndex > 0 )
				try
				{
					return new RecentFileEntry( text.Substring( 0, sepIndex ), 
						new Version( text.Substring( sepIndex + 1 ) ) );
				}
				catch
				{
					//The last part was not a version, so fall through and return the whole text
				}
			
			return new RecentFileEntry( text );
		}
	}
}
