// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Tests
{
    /// <summary>
    /// MessageCheckingTest is an abstract base for tests
    /// that check for an expected message in the exception
    /// handler.
    /// </summary>
    public abstract class MessageChecker : AssertionHelper, IExpectException
    {
        protected string expectedMessage;
        protected MessageMatch matchType = MessageMatch.Exact;

        [SetUp]
        public void SetUp()
        {
            expectedMessage = null;
        }

        public void HandleException( Exception ex )
        {
            if ( expectedMessage != null )
            {
                switch(matchType)
                {
                    default:
                    case MessageMatch.Exact:
                        Assert.AreEqual( expectedMessage, ex.Message );
                        break;
                    case MessageMatch.Contains:
                        Assert.That(ex.Message, Is.StringContaining(expectedMessage));
                        break;
                    case MessageMatch.StartsWith:
                        Assert.That(ex.Message, Is.StringStarting(expectedMessage));
                        break;
                    case MessageMatch.Regex:
                        Assert.That(ex.Message, Is.StringMatching(expectedMessage));
                        break;
                }
            }
        }
    }
}
