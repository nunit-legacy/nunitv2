// ****************************************************************
// Copyright 2002-2003, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.UiKit.Tests
{
	using System;
	using System.Drawing;
	using NUnit.Framework;
	using NUnit.Core;
	using NUnit.Util;
	using NUnit.Tests.Assemblies;
	using NUnit.TestUtilities;

	/// <summary>
	/// Summary description for ProgressBarTests.
	/// </summary>
	[TestFixture]
	public class ProgressBarTests
	{
		private TestProgressBar progressBar;
		private MockTestEventSource mockEvents;
		private string testsDll = MockAssembly.AssemblyPath;
		private TestSuite suite;
		int testCount;

		[SetUp]
		public void Setup()
		{
			progressBar = new TestProgressBar();

			TestSuiteBuilder builder = new TestSuiteBuilder();
			suite = builder.Build( new TestPackage( testsDll ) );

			mockEvents = new MockTestEventSource( suite );
		}

        // .NET 1.0 sometimes throws:
        // ExternalException : A generic error occurred in GDI+.
        [Test, Platform(Exclude = "Net-1.0")]
        public void TestProgressDisplay()
		{
			progressBar.Subscribe( mockEvents );
			mockEvents.TestFinished += new TestEventHandler( OnTestFinished );

			testCount = 0;
			mockEvents.SimulateTestRun();
			
			Assert.AreEqual( 0, progressBar.Minimum );
			Assert.AreEqual( MockAssembly.Tests, progressBar.Maximum );
			Assert.AreEqual( 1, progressBar.Step );
			Assert.AreEqual( MockAssembly.ResultCount, progressBar.Value );
			Assert.AreEqual( Color.Red, progressBar.ForeColor );
		}

		private void OnTestFinished( object sender, TestEventArgs e )
		{
			++testCount;
			// Assumes delegates are called in order of adding
			Assert.AreEqual( testCount, progressBar.Value );
		}
	}
}
