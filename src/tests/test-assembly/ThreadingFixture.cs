// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using NUnit.Framework;

namespace NUnit.TestData
{
    [TestFixture]
    public class ThreadingFixture
    {
        public bool TearDownWasRun;

        [SetUp]
        public void SetUp()
        {
            TearDownWasRun = false;
        }

        [TearDown]
        public void TearDown()
        {
            TearDownWasRun = true;
        }

        [Test, Timeout(50)]
        public void InfiniteLoopWith50msTimeout()
        {
            while (true) { }
        }
        
        [Test, RequiresThread]
        public void MethodWithThreeAsserts()
        {
            Assert.True(true);
            Assert.True(true);
            Assert.True(true);
        }
    }

    public class ThreadingFixtureWithTimeoutInSetUp
    {
        public bool TearDownWasRun;

        [SetUp]
        public void SetUp()
        {
            TearDownWasRun = false;

            while (true) { }
        }

        [TearDown]
        public void TearDown()
        {
            TearDownWasRun = true;
        }

        [Test, Timeout(50)]
        public void TestWithTimeout() { }
    }

    public class ThreadingFixtureWithTimeoutInTearDown
    {
        public bool TearDownWasRun;

        [SetUp]
        public void SetUp()
        {
            TearDownWasRun = false;
        }

        [TearDown]
        public void TearDown()
        {
            TearDownWasRun = true;

            while (true) { }
        }

        [Test, Timeout(50)]
        public void TestWithTimeout() { }
    }

    [TestFixture, Timeout(50)]
    public class ThreadingFixtureWithTimeout
    {
        [Test]
        public void Test1() { }
        [Test]
        public void Test2WithInfiniteLoop() { while (true) { } }
        [Test]
        public void Test3() { }
    }
}
