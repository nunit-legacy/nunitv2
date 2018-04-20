// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using NUnit.Util;

namespace NUnit.Util.Tests
{
	/// <summary>
	/// MockAssemblyWatcher provides way of triggering change
	/// events for test purposes.
	/// </summary>
	public class MockAssemblyWatcher : AssemblyWatcher
	{
		private bool eventPublished = false;

		private DateTime triggerTime;
		private DateTime publishTime;

		public bool EventPublished
		{
			get { return eventPublished; }
		}

		public int ElapsedTime
		{
			get 
			{ 
				TimeSpan elapsed = publishTime - triggerTime;
				return (int)elapsed.TotalMilliseconds;
			}
		}

		public void TriggerEvent( int delay )
		{
			Delay = delay;
			TriggerEvent( );
		}

		public void TriggerEvent( )
		{
			eventPublished = false;
			triggerTime = DateTime.Now;

			OnChanged( this, 
				new FileSystemEventArgs( WatcherChangeTypes.Changed, 
				GetFileInfo(0).DirectoryName, 
				GetFileInfo(0).Name ) );
		}

		public int Delay
		{
			get { return (int)timer.Interval; }
			set { timer.Interval = value; }
		}

		protected new void PublishEvent()
		{
			publishTime = DateTime.Now;

			base.PublishEvent();
			eventPublished = true;
		}
	}
}
