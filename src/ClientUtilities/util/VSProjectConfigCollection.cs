// ****************************************************************
// Copyright 2002-2003, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Util
{
	/// <summary>
	/// A simple collection to hold VSProjectConfigs. Originally,
	/// we used the (NUnit) ProjectConfigCollection, but the
	/// classes have since diverged.
	/// </summary>
	public class VSProjectConfigCollection : CollectionBase
	{
		public VSProjectConfig this[int index]
		{
			get { return List[index] as VSProjectConfig; }
		}

		public VSProjectConfig this[string name]
		{
			get
			{
				foreach ( VSProjectConfig config in InnerList )
					if ( config.Name == name ) return config;

				return null;
			}
		}

		public void Add( VSProjectConfig config )
		{
			List.Add( config );
		}

		public bool Contains( string name )
		{
			foreach( VSProjectConfig config in InnerList )
				if ( config.Name == name ) return true;

			return false;
		}
	}
}
