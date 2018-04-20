// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework.Syntax
{
    [TestFixture]
    public class BinarySerializableTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<binaryserializable>";
            staticSyntax = Is.BinarySerializable;
            inheritedSyntax = Helper().BinarySerializable;
            builderSyntax = Builder().BinarySerializable;
        }
    }

    [TestFixture]
    public class XmlSerializableTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<xmlserializable>";
            staticSyntax = Is.XmlSerializable;
            inheritedSyntax = Helper().XmlSerializable;
            builderSyntax = Builder().XmlSerializable;
        }
    }
}
