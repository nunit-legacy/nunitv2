// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Framework.Tests
{
    public class TestDelegates
    {
        public static void ThrowsArgumentException()
        {
            throw new ArgumentException("myMessage", "myParam");
        }

        public static void ThrowsApplicationException()
        {
            throw new ApplicationException("my message");
        }

        public static void ThrowsSystemException()
        {
            throw new Exception("my message");
        }

        public static void ThrowsNothing()
        {
        }

        public static void ThrowsDerivedApplicationException()
        {
            throw new DerivedApplicationException();
        }

        public class DerivedApplicationException : ApplicationException
        {
        }
    }
}
