// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NUnit.Core.Tests.Generic
{
    [TestFixture,Category("Generics")]
    class SimpleGenericMethods
    {
        [TestCase(5, 2, "ABC")]
        [TestCase(5.0, 2.0, "ABC")]
        [TestCase(5, 2.0, "ABC")]
        [TestCase(5.0, 2L, "ABC")]
        public void GenericTestMethodWithOneTypeParameter<T>(T x, T y, string label)
        {
            Assert.AreEqual(5, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual("ABC", label);
        }

        [TestCase(5, 2, "ABC")]
        [TestCase(5.0, 2.0, "ABC")]
        [TestCase(5, 2.0, "ABC")]
        [TestCase(5.0, 2L, "ABC")]
        public void GenericTestMethodWithTwoTypeParameters<T1, T2>(T1 x, T2 y, string label)
        {
            Assert.AreEqual(5, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual("ABC", label);
        }

        [TestCase(5, 2, "ABC")]
        [TestCase(5.0, 2.0, "ABC")]
        [TestCase(5, 2.0, "ABC")]
        [TestCase(5.0, 2L, "ABC")]
        public void GenericTestMethodWithTwoTypeParameters_Reversed<T1, T2>(T2 x, T1 y, string label)
        {
            Assert.AreEqual(5, x);
            Assert.AreEqual(2, y);
            Assert.AreEqual("ABC", label);
        }
    }
}
#endif