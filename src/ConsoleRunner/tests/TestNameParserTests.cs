// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.ConsoleRunner.Tests
{
    public class TestNameParserTests
    {
        [TestCase("Test.Namespace.Fixture.Method")]
        [TestCase("Test.Namespace.Fixture.Method,")]
        [TestCase("  Test.Namespace.Fixture.Method  ")]
        [TestCase("  Test.Namespace.Fixture.Method  ,")]
        [TestCase("Test.Namespace.Fixture.Method()")]
        [TestCase("Test.Namespace.Fixture.Method(\"string,argument\")")]
        [TestCase("Test.Namespace.Fixture.Method(1,2,3)")]
        [TestCase("Test.Namespace.Fixture.Method<int,int>()")]
        [TestCase("Test.Namespace.Fixture.Method(\")\")")]
        public void SingleName(string name)
        {
            string[] names = TestNameParser.Parse(name);
            Assert.AreEqual(1, names.Length);
            Assert.AreEqual(name.Trim(new char[] { ' ', ',' }), names[0]);
        }

        [TestCase("Test.Namespace.Fixture.Method1", "Test.Namespace.Fixture.Method2")]
        [TestCase("Test.Namespace.Fixture.Method1", "Test.Namespace.Fixture.Method2,")]
        [TestCase("Test.Namespace.Fixture.Method1(1,2)", "Test.Namespace.Fixture.Method2(3,4)")]
        [TestCase("Test.Namespace.Fixture.Method1(\"(\")", "Test.Namespace.Fixture.Method2(\"<\")")]
        public void TwoNames(string name1, string name2)
        {
            char[] delims = new char[] { ' ', ',' };
            string[] names = TestNameParser.Parse(name1 + "," + name2);
            Assert.AreEqual(2, names.Length);
            Assert.AreEqual(name1.Trim(delims), names[0]);
            Assert.AreEqual(name2.Trim(delims), names[1]);
        }
    }
}
