// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Tests
{
	/// <summary>
	/// Summary description for ArrayNotEqualFixture.
	/// </summary>
	[TestFixture]
	public class ArrayNotEqualFixture : AssertionHelper
	{
		[Test]
		public void DifferentLengthArrays()
		{
			string[] array1 = { "one", "two", "three" };
			string[] array2 = { "one", "two", "three", "four", "five" };

			Assert.AreNotEqual(array1, array2);
			Assert.AreNotEqual(array2, array1);
            Expect(array1, Not.EqualTo(array2));
            Expect(array2, Not.EqualTo(array1));
		}

		[Test]
		public void SameLengthDifferentContent()
		{
			string[] array1 = { "one", "two", "three" };
			string[] array2 = { "one", "two", "ten" };
			Assert.AreNotEqual(array1, array2);
			Assert.AreNotEqual(array2, array1);
            Expect(array1, Not.EqualTo(array2));
            Expect(array2, Not.EqualTo(array1));
		}

		[Test]
		public void ArraysDeclaredAsDifferentTypes()
		{
			string[] array1 = { "one", "two", "three" };
			object[] array2 = { "one", "three", "two" };
			Assert.AreNotEqual(array1, array2);
            Expect(array1, Not.EqualTo(array2));
            Expect(array2, Not.EqualTo(array1));
		}

	}
}
