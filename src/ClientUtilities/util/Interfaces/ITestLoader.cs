// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using NUnit.Core;

namespace NUnit.Util
{
	/// <summary>
	/// The ITestLoader interface supports the loading and running
	/// of tests in a remote domain.
	/// </summary>
	public interface ITestLoader
	{
		#region Properties

		// See if a project is loaded
		bool IsProjectLoaded { get; }

		// See if a test has been loaded from the project
		bool IsTestLoaded { get; }

		// See if a test is running
		bool Running { get; }

		// The loaded test project
		NUnitProject TestProject { get; }

		string TestFileName { get; }

		// Our last test results
		TestResult TestResult { get; }

		#endregion

		#region Methods

		// Create a new empty project using a default name
		void NewProject();

		// Create a new project given a filename
		void NewProject( string filename );

		// Load a project given a filename
		void LoadProject( string filename );

		// Load a project given a filename and config
		void LoadProject( string filename, string configname );

		// Load a project given an array of assemblies
		void LoadProject( string[] assemblies );

		// Unload current project
		void UnloadProject();

		// Load tests for current project and config
		void LoadTest();

		// Load a specific test for current project and config
		void LoadTest( string testName );

		// Unload current test
		void UnloadTest();
		
		// Reload current test
		void ReloadTest();

		// Run the tests
		void RunTests( ITestFilter filter );

		// Cancel the running test
		void CancelTestRun();

		#endregion
	}
}