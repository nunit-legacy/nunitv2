// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Util
{
	/// <summary>
	/// Summary description for UnhandledExceptionCatcher.
	/// </summary>
	public class TestExceptionHandler : IDisposable
	{
		private UnhandledExceptionEventHandler handler;

		public TestExceptionHandler( UnhandledExceptionEventHandler handler )
		{
			this.handler = handler;
			AppDomain.CurrentDomain.UnhandledException += handler;
		}

		~TestExceptionHandler()
		{
			if ( handler != null )
			{
				AppDomain.CurrentDomain.UnhandledException -= handler;
				handler = null;
			}
		}



		public void Dispose()
		{
			if ( handler != null )
			{
				AppDomain.CurrentDomain.UnhandledException -= handler;
				handler = null;
			}

			System.GC.SuppressFinalize( this );
		}
	}
}
