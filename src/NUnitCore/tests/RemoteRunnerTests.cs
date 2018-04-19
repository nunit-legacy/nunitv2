// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using System.Collections;

using NUnit.Framework;
using NUnit.Core;
using NUnit.Util;
using NUnit.Tests.Assemblies;

namespace NUnit.Core.Tests
{
	[TestFixture]
	public class RemoteRunnerTests : BasicRunnerTests
	{
		protected override TestRunner CreateRunner( int runnerID )
		{
			return new RemoteTestRunner( runnerID );
		}
	}
}
