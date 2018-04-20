// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Framework.Tests
{
    public class TestFixtureAttributeTests
    {
        static object[] fixtureArgs = new object[] { 10, 20, "Charlie" };
#if CLR_2_0 || CLR_4_0
        static Type[] typeArgs = new Type[] { typeof(int), typeof(string) };
        static object[] combinedArgs = new object[] { typeof(int), typeof(string), 10, 20, "Charlie" };
#endif

        [Test]
        public void ConstructWithoutArguments()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute();
            Assert.That(attr.Arguments.Length == 0);
#if CLR_2_0 || CLR_4_0
            Assert.That(attr.TypeArgs == null);
#endif
        }

        [Test]
        public void ConstructWithFixtureArgs()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute(fixtureArgs);
            Assert.That(attr.Arguments, Is.EqualTo( fixtureArgs ) );
#if CLR_2_0 || CLR_4_0
            Assert.That(attr.TypeArgs == null );
#endif
        }

#if CLR_2_0 || CLR_4_0
        [Test, Category("Generics")]
        public void ConstructWithJustTypeArgs()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute(typeArgs);
            Assert.That(attr.Arguments.Length == 2);
            Assert.That(attr.TypeArgs == null);
        }

        [Test, Category("Generics")]
        public void ConstructWithNoArgumentsAndSetTypeArgs()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute();
            attr.TypeArgs = typeArgs;
            Assert.That(attr.Arguments.Length == 0);
            Assert.That(attr.TypeArgs, Is.EqualTo(typeArgs));
        }

        [Test, Category("Generics")]
        public void ConstructWithFixtureArgsAndSetTypeArgs()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute(fixtureArgs);
            attr.TypeArgs = typeArgs;
            Assert.That(attr.Arguments, Is.EqualTo(fixtureArgs));
            Assert.That(attr.TypeArgs, Is.EqualTo(typeArgs));
        }

        [Test, Category("Generics")]
        public void ConstructWithCombinedArgs()
        {
            TestFixtureAttribute attr = new TestFixtureAttribute(combinedArgs);
            Assert.That(attr.Arguments, Is.EqualTo(combinedArgs));
            Assert.That(attr.TypeArgs, Is.Null);
        }
#endif
	}
}
