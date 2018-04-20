// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

#if CLR_2_0 || CLR_4_0
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnit.Core.Tests.Generic
{
    [Category("Generics")]
    [TestFixture(typeof(List<int>))]
    [TestFixture(TypeArgs=new Type[] {typeof(ArrayList)} )]
    public class SimpleGenericFixture<TList> where TList : IList, new()
    {
        [Test]
        public void TestCollectionCount()
        {
            Console.WriteLine("TList is {0}", typeof(TList));
            IList list = new TList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Count);
        }
    }
}
#endif