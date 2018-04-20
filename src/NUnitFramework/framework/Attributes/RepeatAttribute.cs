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
	/// RepeatAttribute may be applied to test case in order
	/// to run it multiple times.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=false, Inherited=false)]
	public class RepeatAttribute : PropertyAttribute
	{
        /// <summary>
        /// Construct a RepeatAttribute
        /// </summary>
        /// <param name="count">The number of times to run the test</param>
        public RepeatAttribute(int count) : base(count) { }

        //private int count;

        ///// <summary>
        ///// Construct a RepeatAttribute
        ///// </summary>
        ///// <param name="count">The number of times to run the test</param>
        //public RepeatAttribute(int count)
        //{
        //    this.count = count;
        //}

        ///// <summary>
        ///// Gets the number of times to run the test.
        ///// </summary>
        //public int Count
        //{
        //    get { return count; }
        //}
	}
}
