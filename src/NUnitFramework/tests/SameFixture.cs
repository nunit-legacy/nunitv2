// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Text;
using NUnit.Framework;

namespace NUnit.Framework.Tests
{
	[TestFixture]
	public class SameFixture : MessageChecker
	{
		[Test]
		public void Same()
		{
			string s1 = "S1";
			Assert.AreSame(s1, s1);
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void SameFails()
		{
			Exception ex1 = new Exception( "one" );
			Exception ex2 = new Exception( "two" );
			expectedMessage =
				"  Expected: same as <System.Exception: one>" + Environment.NewLine +
				"  But was:  <System.Exception: two>" + Environment.NewLine;
			Assert.AreSame(ex1, ex2);
		}

		[Test,ExpectedException(typeof(AssertionException))]
		public void SameValueTypes()
		{
			int index = 2;
			expectedMessage =
				"  Expected: same as 2" + Environment.NewLine +
				"  But was:  2" + Environment.NewLine;
			Assert.AreSame(index, index);
		}
	}
}
