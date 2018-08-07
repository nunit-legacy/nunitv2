// ****************************************************************
// Copyright 2018, Sune Foldager
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using NUnit.Framework;

namespace simple_assembly
{
    class SimpleTestAction : TestActionAttribute
    {
        internal static bool TestActionWasRun;

        public override void BeforeTest(TestDetails testDetails)
        {
            TestActionWasRun = true;
        }
    }

    [SimpleTestAction]
    class SimpleTestFixture
    {
        [Test]
        public void Test()
        {
            Assert.That(SimpleTestAction.TestActionWasRun, Is.True);
        }
    }
}
