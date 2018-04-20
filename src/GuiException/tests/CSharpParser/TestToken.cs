// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using NUnit.Framework;
using NUnit.UiException.CodeFormatters;

namespace NUnit.UiException.Tests.CodeFormatters
{
    [TestFixture]
    public class TestToken
    {
        [Test]
        public void Test_Equals()
        {
            Assert.That(new TestingToken("text", 0, LexerTag.Text).Equals(null), Is.False);
            Assert.That(new TestingToken("text", 1, LexerTag.Text).Equals("text"), Is.False);
            Assert.That(new TestingToken("text", 0, LexerTag.Text).Equals(
                new TestingToken("", 0, LexerTag.Text)), Is.False);
            Assert.That(new TestingToken("text", 0, LexerTag.Text).Equals(
                new TestingToken("text", 1, LexerTag.Text)), Is.False);
            Assert.That(new TestingToken("text", 0, LexerTag.Text).Equals(
                new TestingToken("text", 0, LexerTag.SingleQuote)), Is.False);
            Assert.That(new TestingToken("text", 0, LexerTag.Text).Equals(
                new TestingToken("text", 0, LexerTag.Text)), Is.True);

            return;
        }

        #region TestingToken

        class TestingToken :
            LexToken
        {
            public TestingToken(string text, int start, LexerTag attr)
            {
                _text = text;
                _start = start;
                _tag = attr;

                return;
            }
        }

        #endregion
    }
}
