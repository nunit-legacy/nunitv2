// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using NUnit.Core;

namespace NUnit.Util
{
	/// <summary>
	/// Base class for servers
	/// </summary>
	public class TestServer : ServerBase
	{
		private TestRunner runner;

		public TestServer( string uri, int port ) : base( uri, port )
		{
			this.runner = new TestDomain();
		}

		public TestRunner TestRunner
		{
			get { return runner; }
		}
	}
}
