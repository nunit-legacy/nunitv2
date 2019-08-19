// ****************************************************************
// Copyright 2019, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using NUnit.Framework;
using NUnit.Tests.Assemblies;
using NUnit.Core.Builders;
using NUnit.Core.Filters;
using NUnit.Tests.Singletons;
using NUnit.TestUtilities;

namespace NUnit.Core.Tests
{
    [TestFixture]
    public class IdFilterTests
    {
        private TestSuite _suite;
        private TestSuite _fixture;
        private Test _mock1;
        private Test _mock2;
        private Test _mock3;
        private Test _explicitTest;

        [SetUp]
        public void SetUp()
        {
            _suite = new TestSuite("TopLevelSuite");
            _fixture = TestBuilder.MakeFixture(typeof(MockTestFixture));
            _suite.Add(_fixture);
            _mock1 = TestFinder.Find("MockTest1", _fixture, false);
            _mock2 = TestFinder.Find("MockTest2", _fixture, false);
            _mock3 = TestFinder.Find("MockTest3", _fixture, false);
            _explicitTest = TestFinder.Find("ExplicitlyRunTest", _fixture, false);
            Assert.NotNull(_mock1, "MockTest1 not found");
            Assert.NotNull(_mock2, "MockTest2 not found");
            Assert.NotNull(_mock3, "MockTest3 not found");
        }

        [Test]
        public void TestCaseIdMatch()
        {
            IdFilter filter = CreateIdFilter(_mock3);
            Assert.IsFalse(filter.Pass(_mock1), "Filter should not have passed MockTest1");
            Assert.IsFalse(filter.Pass(_mock2), "Filter should not have passed MockTest2");
            Assert.IsTrue(filter.Pass(_mock3), "Filter did not pass MockTest3");
            Assert.IsFalse(filter.Pass(_explicitTest), "Filter should not have passed ExplicitlyRunTest");
            Assert.IsTrue(filter.Pass(_fixture), "Filter did not pass MockTestFixture");
            Assert.IsTrue(filter.Pass(_suite), "Filter did not pass TopLevelSuite");
        }

        [Test]
        public void ExplicitTestCaseMatch()
        {
            IdFilter filter = CreateIdFilter(_explicitTest);
            Assert.IsFalse(filter.Pass(_mock1), "Filter should not have passed MockTest1");
            Assert.IsFalse(filter.Pass(_mock2), "Filter should not have passed MockTest2");
            Assert.IsFalse(filter.Pass(_mock3), "Filter should not have passed MockTest3");
            Assert.IsTrue(filter.Pass(_explicitTest), "Filter did not pass ExplicitlyRunTest");
            Assert.IsTrue(filter.Pass(_fixture), "Filter did not pass MockTestFixture");
            Assert.IsTrue(filter.Pass(_suite), "Filter did not pass TopLevelSuite");
        }

        [Test]
        public void FixtureIdMatch()
        {
            IdFilter filter = CreateIdFilter(_fixture);
            Assert.IsTrue(filter.Pass(_mock1), "Filter did not pass MockTest1");
            Assert.IsTrue(filter.Pass(_mock2), "Filter did not pass MockTest2");
            Assert.IsTrue(filter.Pass(_mock3), "Filter did not pass MockTest3");
            Assert.IsFalse(filter.Pass(_explicitTest), "Filter should not have passed ExplicitlyRunTest");
            Assert.IsTrue(filter.Pass(_fixture), "Filter did not pass MockTestFixture");
            Assert.IsTrue(filter.Pass(_suite), "Filter did not pass TopLevelSuite");
        }

        [Test]
        public void TopLevelIdMatch()
        {
            IdFilter filter = CreateIdFilter(_suite);
            Assert.IsTrue(filter.Pass(_mock1), "Filter did not pass MockTest1");
            Assert.IsTrue(filter.Pass(_mock2), "Filter did not pass MockTest2");
            Assert.IsTrue(filter.Pass(_mock3), "Filter did not pass MockTest3");
            Assert.IsFalse(filter.Pass(_explicitTest), "Filter should not have passed ExplicitlyRunTest");
            Assert.IsTrue(filter.Pass(_fixture), "Filter did not pass MockTestFixture");
            Assert.IsTrue(filter.Pass(_suite), "Filter did not pass TopLevelSuite");
        }

        [Test]
        public void MulitpleTestCaseIdMatch()
        {
            OrFilter filter = new OrFilter(CreateIdFilter(_mock1), CreateIdFilter(_mock3));
            Assert.IsTrue(filter.Pass(_mock1), "Filter did not pass MockTest1");
            Assert.IsFalse(filter.Pass(_mock2), "Filter should not have passed MockTest2");
            Assert.IsTrue(filter.Pass(_mock3), "Filter did not pass MockTest3");
            Assert.IsFalse(filter.Pass(_explicitTest), "Filter should not have passed ExplicitlyRunTest");
            Assert.IsTrue(filter.Pass(_fixture), "Filter did not pass MockTestFixture");
            Assert.IsTrue(filter.Pass(_suite), "Filter did not pass TopLevelSuite");
        }

        private IdFilter CreateIdFilter(Test test)
        {
            return new IdFilter(test.TestName.RunnerID, test.TestName.TestID);
        }
    }
}
