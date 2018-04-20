// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Core.Filters
{
	/// <summary>
	/// Summary description for NameFilter.
	/// </summary>
	/// 
	[Serializable]
	public class NameFilter : TestFilter
	{
		private ArrayList testNames = new ArrayList();

		/// <summary>
		/// Construct an empty NameFilter
		/// </summary>
		public NameFilter() { }

		/// <summary>
		/// Construct a NameFilter for a single TestName
		/// </summary>
		/// <param name="testName"></param>
		public NameFilter( TestName testName )
		{
			testNames.Add( testName );
		}

		/// <summary>
		/// Add a TestName to a NameFilter
		/// </summary>
		/// <param name="testName"></param>
		public void Add( TestName testName )
		{
			testNames.Add( testName );
		}

		/// <summary>
		/// Check if a test matches the filter
		/// </summary>
		/// <param name="test">The test to match</param>
		/// <returns>True if it matches, false if not</returns>
		public override bool Match( ITest test )
		{
			foreach( TestName testName in testNames )
				if ( test.TestName == testName )
					return true;

			return false;
		}
	}
}
