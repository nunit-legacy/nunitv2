// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
	/// <summary>
	/// The List class is a helper class with properties and methods
	/// that supply a number of constraints used with lists and collections.
	/// </summary>
	public class List
	{
		/// <summary>
		/// List.Map returns a ListMapper, which can be used to map
		/// the original collection to another collection.
		/// </summary>
		/// <param name="actual"></param>
		/// <returns></returns>
		public static ListMapper Map( ICollection actual )
		{
			return new ListMapper( actual );
		}
	}
}
