// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Collections;
using System.Collections.Specialized;

namespace NUnit.Core
{
    /// <summary>
    /// TestDecorator is used to add functionality to
    /// another Test, which it aggregates.
    /// </summary>
    public abstract class TestDecorator : TestMethod
    {
        protected TestMethod test;

        public TestDecorator( TestMethod test )
            //: base( (TestName)test.TestName.Clone() )
            : base( test.Method )
        {
            this.test = test;
            this.RunState = test.RunState;
            this.IgnoreReason = test.IgnoreReason;
            this.Description = test.Description;
            this.Categories = new System.Collections.ArrayList( test.Categories );
            if ( test.Properties != null )
            {
                this.Properties = new ListDictionary();
                foreach (DictionaryEntry entry in test.Properties)
                    this.Properties.Add(entry.Key, entry.Value);
            }
        }

        public override int TestCount
        {
            get { return test.TestCount; }
        }
    }
}
