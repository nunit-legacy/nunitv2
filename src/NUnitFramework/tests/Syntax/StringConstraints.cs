﻿// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Syntax
{
    [Obsolete]
    public class SubstringTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<substring ""X"">";
            staticSyntax = Is.StringContaining("X");
            inheritedSyntax = Helper().ContainsSubstring("X");
            builderSyntax = Builder().ContainsSubstring("X");
        }
    }

    [Obsolete]
    public class TextContains : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<substring ""X"">";
            staticSyntax = Text.Contains("X");
            inheritedSyntax = Helper().ContainsSubstring("X");
            builderSyntax = Builder().ContainsSubstring("X");
        }
    }

    public class DoesContain : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<substring ""X"">";
            staticSyntax = Does.Contain("X");
            inheritedSyntax = Helper().ContainsSubstring("X");
            builderSyntax = Builder().ContainsSubstring("X");
        }
    }

    public class SubstringTest_IgnoreCase : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<substring ""X"">";
            staticSyntax = Does.Contain("X").IgnoreCase;
            inheritedSyntax = Helper().ContainsSubstring("X").IgnoreCase;
            builderSyntax = Builder().ContainsSubstring("X").IgnoreCase;
        }
    }

    [Obsolete]
    public class StartsWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<startswith ""X"">";
            staticSyntax = Is.StringStarting("X");
            inheritedSyntax = Helper().StartsWith("X");
            builderSyntax = Builder().StartsWith("X");
        }
    }

    [Obsolete]
    public class TextStartsWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<startswith ""X"">";
            staticSyntax = Text.StartsWith("X");
            inheritedSyntax = Helper().StartsWith("X");
            builderSyntax = Builder().StartsWith("X");
        }
    }

    public class DoesStartWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<startswith ""X"">";
            staticSyntax = Does.StartWith("X");
            inheritedSyntax = Helper().StartsWith("X");
            builderSyntax = Builder().StartsWith("X");
        }
    }

    public class StartsWithTest_IgnoreCase : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<startswith ""X"">";
            staticSyntax = Does.StartWith("X").IgnoreCase;
            inheritedSyntax = Helper().StartsWith("X").IgnoreCase;
            builderSyntax = Builder().StartsWith("X").IgnoreCase;
        }
    }

    [Obsolete]
    public class EndsWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<endswith ""X"">";
            staticSyntax = Is.StringEnding("X");
            inheritedSyntax = Helper().EndsWith("X");
            builderSyntax = Builder().EndsWith("X");
        }
    }

    [Obsolete]
    public class TextEndsWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<endswith ""X"">";
            staticSyntax = Text.EndsWith("X");
            inheritedSyntax = Helper().EndsWith("X");
            builderSyntax = Builder().EndsWith("X");
        }
    }

    public class DoesEndWithTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<endswith ""X"">";
            staticSyntax = Does.EndWith("X");
            inheritedSyntax = Helper().EndsWith("X");
            builderSyntax = Builder().EndsWith("X");
        }
    }

    public class EndsWithTest_IgnoreCase : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<endswith ""X"">";
            staticSyntax = Does.EndWith("X").IgnoreCase;
            inheritedSyntax = Helper().EndsWith("X").IgnoreCase;
            builderSyntax = Builder().EndsWith("X").IgnoreCase;
        }
    }

    [Obsolete]
    public class RegexTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<regex ""X"">";
            staticSyntax = Is.StringMatching("X");
            inheritedSyntax = Helper().Matches("X");
            builderSyntax = Builder().Matches("X");
        }
    }

    [Obsolete]
    public class TextMatchesTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<regex ""X"">";
            staticSyntax = Text.Matches("X");
            inheritedSyntax = Helper().Matches("X");
            builderSyntax = Builder().Matches("X");
        }
    }

    public class DoesMatchTest : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<regex ""X"">";
            staticSyntax = Does.Match("X");
            inheritedSyntax = Helper().Matches("X");
            builderSyntax = Builder().Matches("X");
        }
    }

    public class RegexTest_IgnoreCase : SyntaxTest
    {
        [SetUp]
        public void SetUp()
        {
            parseTree = @"<regex ""X"">";
            staticSyntax = Does.Match("X").IgnoreCase;
            inheritedSyntax = Helper().Matches("X").IgnoreCase;
            builderSyntax = Builder().Matches("X").IgnoreCase;
        }
    }
}
