﻿// ----------------------------------------------------------------
// ErrorBrowser
// Copyright 2008-2009, Irénée HOTTIER,
// 
// This is free software licensed under the NUnit license, You may
// obtain a copy of the license at http://nunit.org/?p=license&r=2.4
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.UiException.StackTraceAnalyzers;
using NUnit.UiException.StackTraceAnalysers;

namespace NUnit.UiException.Tests.StackTraceAnalyzers
{
    [TestFixture]
    public class TestLineNumberParser :
        TestIErrorParser
    {
        private IErrorParser _parser;

        [SetUp]
        public new void SetUp()
        {
            _parser = new LineNumberParser();

            return;
        }

        [Test]
        public void Test_Ability_To_Parse_Regular_Line_Number_Values()
        {
            RawError res;

            // a basic test
            res = AcceptValue(_parser, "à get_Text() dans C:\\folder\\file1:line 1");
            Assert.That(res.Line, Is.EqualTo(1));

            // parser doesn't rely upon the presence of words between
            // the colon and the number
            res = AcceptValue(_parser, "à get_Text() dans C:\\folder\\file1:42");
            Assert.That(res.Line, Is.EqualTo(42));

            // parser doesn't rely on the existence of
            // a method name or path value
            res = AcceptValue(_parser, ":43");
            Assert.That(res.Line, Is.EqualTo(43));

            return;
        }

        [Test]
        public void Test_Ability_To_Reject_Odd_Line_Number_Values()
        {
            // after the terminal ':' parser expects to have only one integer value            
            RejectValue(_parser, "à get_Text() dans C:\\folder\\file1 line 42");
            RejectValue(_parser, "à get_Text() dans C:\\folder\\file42");

            // check it fails to parse int values that are part of a word
            RejectValue(_parser, "à get_Text() dans C:\\folder\\file1:line43");

            // a line number should not be zero
            RejectValue(_parser, "à get_Text() dans C:\\folder\\file1:line 0");

            // a line number should not be negative
            RejectValue(_parser, "à get_Text() dans C:\\folder\\file1:line -42");

            return;
        }        
    }
}
