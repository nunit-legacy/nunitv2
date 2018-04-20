// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Collections;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using NUnit.Framework;

namespace NUnit.Util.Tests
{
	/// <summary>
	/// Summary description for RemotingUtilitiesTests.
	/// </summary>
	[TestFixture]
	public class ServerUtilityTests
	{
		TcpChannel channel1;
		TcpChannel channel2;

		[TearDown]
		public void ReleaseChannels()
		{
			ServerUtilities.SafeReleaseChannel( channel1 );
			ServerUtilities.SafeReleaseChannel( channel2 );
		}

		[Test]
		public void CanGetTcpChannelOnSpecifiedPort()
		{
			channel1 = ServerUtilities.GetTcpChannel( "test", 1234 );
			Assert.AreEqual( "test", channel1.ChannelName );
			channel2 = ServerUtilities.GetTcpChannel( "test", 4321 );
			Assert.AreEqual( "test", channel2.ChannelName );
			Assert.AreEqual( channel1, channel2 );
			Assert.AreSame( channel1, channel2 );
			ChannelDataStore cds = (ChannelDataStore)channel1.ChannelData;
			Assert.AreEqual( "tcp://127.0.0.1:1234", cds.ChannelUris[0] );
		}

		[Test]
		public void CanGetTcpChannelOnUnpecifiedPort()
		{
			channel1 = ServerUtilities.GetTcpChannel( "test", 0 );
			Assert.AreEqual( "test", channel1.ChannelName );
			channel2 = ServerUtilities.GetTcpChannel( "test", 0 );
			Assert.AreEqual( "test", channel2.ChannelName );
			Assert.AreEqual( channel1, channel2 );
			Assert.AreSame( channel1, channel2 );
		}
	}
}
