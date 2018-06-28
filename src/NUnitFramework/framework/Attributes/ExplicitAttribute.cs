// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework
{
    /// <summary>
    /// ExplicitAttribute marks a test or test fixture so that it will
    /// only be run if explicitly executed from the gui or command line
    /// or if it is included by use of a filter. The test will not be
    /// run simply because an enclosing suite is run.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
    public class ExplicitAttribute : Attribute
    {
        private string reason;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ExplicitAttribute()
        {
            this.reason = "";
        }

        /// <summary>
        /// Constructor with a reason
        /// </summary>
        /// <param name="reason">The reason test is marked explicit</param>
        public ExplicitAttribute(string reason)
        {
            this.reason = reason;
        }

        /// <summary>
        /// The reason test is marked explicit
        /// </summary>
        public string Reason
        {
            get { return reason; }
        }
    }
}
