// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using System.Text;
//using System.Windows.Forms;
using Microsoft.Win32;
using NUnit.Framework;

namespace NUnit.Util.Tests
{
	/// <summary>
	/// Summary description for NUnitRegistryTests.
	/// </summary>
	[TestFixture]
	public class NUnitRegistryTests
	{
		[TearDown]
		public void RestoreRegistry()
		{
			NUnitRegistry.TestMode = false;
		}

		[Test]
		public void CurrentUser()
		{
			NUnitRegistry.TestMode = false;
			using( RegistryKey key = NUnitRegistry.CurrentUser )
			{
				Assert.IsNotNull( key );
				Assert.AreEqual( @"HKEY_CURRENT_USER\Software\nunit.org\Nunit\2.4".ToLower(), key.Name.ToLower() );
			}
		}

		[Test]
		public void CurrentUserTestMode()
		{

			NUnitRegistry.TestMode = true;
			using( RegistryKey key = NUnitRegistry.CurrentUser )
			{
				Assert.IsNotNull( key );
				Assert.AreEqual( @"HKEY_CURRENT_USER\Software\nunit.org\Nunit-Test".ToLower(), key.Name.ToLower() );
			}
		}

		[Test]
		public void TestClearRoutines()
		{
			NUnitRegistry.TestMode = true;

			using( RegistryKey key = NUnitRegistry.CurrentUser )
			using( RegistryKey foo = key.CreateSubKey( "foo" ) )
			using( RegistryKey bar = key.CreateSubKey( "bar" ) )
			using( RegistryKey footoo = foo.CreateSubKey( "foo" ) )
			{
				key.SetValue("X", 5);
				key.SetValue("NAME", "Joe");
				foo.SetValue("Y", 17);
				bar.SetValue("NAME", "Jennifer");
				footoo.SetValue( "X", 5 );
				footoo.SetValue("NAME", "Charlie" );
				
				NUnitRegistry.ClearTestKeys();

				Assert.AreEqual( 0, key.ValueCount );
				Assert.AreEqual( 0, key.SubKeyCount );
			}
		}
	}
}
