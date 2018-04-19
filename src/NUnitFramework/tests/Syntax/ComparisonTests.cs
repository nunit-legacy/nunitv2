// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Syntax
{
    public class GreaterThanTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<greaterthan 7>";
            staticSyntax = Is.GreaterThan(7);
            inheritedSyntax = Helper().GreaterThan(7);
            builderSyntax = Builder().GreaterThan(7);
        }
    }

    public class GreaterThanOrEqualTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<greaterthanorequal 7>";
            staticSyntax = Is.GreaterThanOrEqualTo(7);
            inheritedSyntax = Helper().GreaterThanOrEqualTo(7);
            builderSyntax = Builder().GreaterThanOrEqualTo(7);
        }
    }

    public class AtLeastTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<greaterthanorequal 7>";
            staticSyntax = Is.AtLeast(7);
            inheritedSyntax = Helper().AtLeast(7);
            builderSyntax = Builder().AtLeast(7);
        }
    }

    public class LessThanTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<lessthan 7>";
            staticSyntax = Is.LessThan(7);
            inheritedSyntax = Helper().LessThan(7);
            builderSyntax = Builder().LessThan(7);
        }
    }

    public class LessThanOrEqualTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<lessthanorequal 7>";
            staticSyntax = Is.LessThanOrEqualTo(7);
            inheritedSyntax = Helper().LessThanOrEqualTo(7);
            builderSyntax = Builder().LessThanOrEqualTo(7);
        }
    }

    public class AtMostTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = "<lessthanorequal 7>";
            staticSyntax = Is.AtMost(7);
            inheritedSyntax = Helper().AtMost(7);
            builderSyntax = Builder().AtMost(7);
        }
    }
}
