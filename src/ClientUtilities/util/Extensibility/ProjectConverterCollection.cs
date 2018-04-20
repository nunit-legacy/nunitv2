// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Collections;
using NUnit.Core.Extensibility;

namespace NUnit.Util.Extensibility
{
	/// <summary>
	/// Summary description for ProjectConverterCollection.
	/// </summary>
	public class ProjectConverterCollection : IProjectConverter, IExtensionPoint
	{
		private ArrayList converters = new ArrayList();

		public ProjectConverterCollection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region IProjectConverter Members

		public bool CanConvertFrom(string path)
		{
			foreach( IProjectConverter converter in converters )
				if ( converter.CanConvertFrom( path ) )
					return true;

			return false;
		}

		public NUnitProject ConvertFrom(string path)
		{
			foreach( IProjectConverter converter in converters )
				if ( converter.CanConvertFrom( path ) )
					return converter.ConvertFrom( path );
			
			return null;
		}

		#endregion

		#region IExtensionPoint Members

		public void Remove(object extension)
		{
			// TODO:  Add ProjectConverterCollection.Remove implementation
		}

        public void Install(object extension)
        {
            // TODO:  Add ProjectConverterCollection.Install implementation
        }

        public void Install(object extension, int priority)
        {
            // TODO:  Add ProjectConverterCollection.Install implementation
        }

		public IExtensionHost Host
		{
			get
			{
				// TODO:  Add ProjectConverterCollection.Host getter implementation
				return null;
			}
		}

		public string Name
		{
			get
			{
				return "Converters";
			}
		}

		#endregion
	}
}
