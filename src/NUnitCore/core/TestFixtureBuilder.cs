// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Reflection;

namespace NUnit.Core
{
	/// <summary>
	/// TestFixtureBuilder contains static methods for building
	/// TestFixtures from types. It uses builtin SuiteBuilders
	/// and any installed extensions to do it.
	/// </summary>
	public class TestFixtureBuilder
	{
		public static bool CanBuildFrom( Type type )
		{
			return CoreExtensions.Host.SuiteBuilders.CanBuildFrom( type );
		}

		/// <summary>
		/// Build a test fixture from a given type.
		/// </summary>
		/// <param name="type">The type to be used for the fixture</param>
		/// <returns>A TestSuite if the fixture can be built, null if not</returns>
		public static Test BuildFrom( Type type )
		{
			Test suite = CoreExtensions.Host.SuiteBuilders.BuildFrom( type );

			if ( suite != null )
				suite = CoreExtensions.Host.TestDecorators.Decorate( suite, type );

			return suite;
		}

		/// <summary>
		/// Build a fixture from an object. 
		/// </summary>
		/// <param name="fixture">The object to be used for the fixture</param>
		/// <returns>A TestSuite if fixture type can be built, null if not</returns>
		public static Test BuildFrom( object fixture )
		{
			Test suite = BuildFrom( fixture.GetType() );
			
			if( suite != null)
			{
				suite.Fixture = fixture;
				
				// TODO: Integrate building from an object as part of NUnitTestFixtureBuilder
				if (suite.RunState == RunState.NotRunnable &&
					Reflect.GetConstructor(fixture.GetType()) == null)
				{
					suite.RunState = RunState.Runnable;
					suite.IgnoreReason = null;
				}
			}
			
			return suite;
		}

		/// <summary>
		/// Private constructor to prevent instantiation
		/// </summary>
		private TestFixtureBuilder() { }
	}
}
