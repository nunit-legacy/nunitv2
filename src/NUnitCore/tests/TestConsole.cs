// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// This test is designed to check that console output is being passed
	/// correctly accross the AppDomain boundry.  Non-remotable objects should
	/// be converted to a string before being passed accross.
	/// </summary>
	[TestFixture]
	public class TestConsole
	{
		[Test]
		public void ConsoleWrite()
		{
			Console.Write("I am a 'String' object.");
			Console.WriteLine();
			Console.Write(new TestSerialisable());
			Console.WriteLine();
			Console.Write(new TestMarshalByRefObject());
			Console.WriteLine();
			System.Diagnostics.Trace.WriteLine( "Output from Trace", "NUnit" );
			Console.Write(new TestNonRemotableObject());
			Console.WriteLine();
			Console.Error.WriteLine( "This is from Console.Error" );
		}

		[Test]
		public void ConsoleWriteLine()
		{
			Console.WriteLine("I am a 'String' object.");
			Console.WriteLine(new TestSerialisable());
			Console.WriteLine(new TestMarshalByRefObject());
			Console.WriteLine(new TestNonRemotableObject());
		}

		[Serializable] 
		public class TestSerialisable
		{
			override public string ToString()
			{
				return "I am a 'Serializable' object.";
			}
		}

		public class TestMarshalByRefObject : MarshalByRefObject
		{
			override public string ToString()
			{
				return "I am a 'MarshalByRefObject' object.";
			}
		}

		public class TestNonRemotableObject
		{
			override public string ToString()
			{
				return "I am a non-remotable object.";
			}
		}
	}
}
