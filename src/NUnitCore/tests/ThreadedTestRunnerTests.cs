// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Threading;
using NUnit.Framework;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// Summary description for ThreadedTestRunnerTests.
	/// </summary>
	[TestFixture]
	public class ThreadedTestRunnerTests : BasicRunnerTests
	{
		protected override TestRunner CreateRunner( int runnerID )
		{
			return new ThreadedTestRunner( new SimpleTestRunner( runnerID ), ApartmentState.Unknown, ThreadPriority.Normal );
		}

	}
}
