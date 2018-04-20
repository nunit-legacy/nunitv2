// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Framework
{
	using System;

	/// <summary>
	/// Attribute used to mark a test that is to be ignored.
	/// Ignored tests result in a warning message when the
	/// tests are run.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method|AttributeTargets.Class|AttributeTargets.Assembly, AllowMultiple=false, Inherited=false)]
	public class IgnoreAttribute : Attribute
	{
		private string reason;

		/// <summary>
		/// Constructs the attribute without giving a reason 
		/// for ignoring the test.
		/// </summary>
		public IgnoreAttribute()
		{
			this.reason = "";
		}

		/// <summary>
		/// Constructs the attribute giving a reason for ignoring the test
		/// </summary>
		/// <param name="reason">The reason for ignoring the test</param>
		public IgnoreAttribute(string reason)
		{
			this.reason = reason;
		}

		/// <summary>
		/// The reason for ignoring a test
		/// </summary>
		public string Reason
		{
			get { return reason; }
		}
	}
}
