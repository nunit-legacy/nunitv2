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
	///  MemorySettingsStorage is used to hold settings for
	///  the NUnit tests and also serves as the base class
	///  for XmlSettingsStorage.
	/// </summary>
	public class MemorySettingsStorage : ISettingsStorage
	{
		protected Hashtable settings = new Hashtable();

		#region ISettingsStorage Members

		public object GetSetting(string settingName)
		{
			return settings[settingName];
		}

		public void RemoveSetting(string settingName)
		{
			settings.Remove( settingName );
		}

		public void RemoveGroup( string groupName )
		{
			ArrayList keysToRemove = new ArrayList();

			string prefix = groupName;
			if ( !prefix.EndsWith(".") )
				prefix = prefix + ".";

			foreach( string key in settings.Keys )
				if ( key.StartsWith( prefix ) )
					keysToRemove.Add( key );

			foreach( string key in keysToRemove )
				settings.Remove( key );
		}

		public void SaveSetting(string settingName, object settingValue)
		{
			settings[settingName] = settingValue;
		}

		public ISettingsStorage MakeChildStorage(string name)
		{
			return new MemorySettingsStorage();
		}

		public virtual void LoadSettings()
		{
			// No action required
		}

		public virtual void SaveSettings()
		{
			// No action required
		}
		#endregion

		#region IDisposable Members

		public void Dispose()
		{
			// TODO:  Add MemorySettingsStorage.Dispose implementation
		}

		#endregion
	}
}
