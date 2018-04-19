// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Util;

namespace NUnit.UiKit
{
	[Serializable]
	public class TestEventInvocationException : Exception
	{
		public TestEventInvocationException( Exception inner )
			: base( "Exception invoking TestEvent handler", inner )
		{
		}
	}	

	/// <summary>
	/// Summary description for GuiTestEventDispatcher.
	/// </summary>
	public class GuiTestEventDispatcher : TestEventDispatcher
	{
		protected override void Fire(TestEventHandler handler, TestEventArgs e)
		{
			if ( handler != null )
				InvokeHandler( handler, e );
		}

		private void InvokeHandler( MulticastDelegate handlerList, EventArgs e )
		{
			object[] args = new object[] { this, e };
			foreach( Delegate handler in handlerList.GetInvocationList() )
			{
				object target = handler.Target;
				System.Windows.Forms.Control control 
					= target as System.Windows.Forms.Control;
				try 
				{
					if ( control != null && control.InvokeRequired )
						control.Invoke( handler, args );
					else
						handler.Method.Invoke( target, args );
				}
				catch( Exception ex )
				{
					// TODO: Stop rethrowing this since it goes back to the
					// Test domain which may not know how to handle it!!!
					Console.WriteLine( "Exception:" );
					Console.WriteLine( ex );
					//throw new TestEventInvocationException( ex );
					//throw;
				}
			}
		}

	}
}

