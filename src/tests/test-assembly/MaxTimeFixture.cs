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
    public class MaxTimeFixture
    {
        [Test, MaxTime(1)]
        public void MaxTimeExceeded()
        {
            System.Threading.Thread.Sleep(20);
        }
    }

    [TestFixture]
    public class MaxTimeFixtureWithFailure
    {
        [Test, MaxTime(1)]
        public void MaxTimeExceeded()
        {
            System.Threading.Thread.Sleep(20);
            Assert.Fail("Intentional Failure");
        }
    }

    [TestFixture]
    public class MaxTimeFixtureWithError
    {
        [Test, MaxTime(1)]
        public void MaxTimeExceeded()
        {
            System.Threading.Thread.Sleep(20);
            throw new Exception("Exception message");
        }
    }
}
