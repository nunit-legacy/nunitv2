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
	/// Thrown when an assertion failed.
	/// </summary>
	[Serializable]
	public class AssertionException : System.Exception
	{
		/// <param name="message">The error message that explains 
		/// the reason for the exception</param>
		public AssertionException (string message) : base(message) 
		{}

		/// <param name="message">The error message that explains 
		/// the reason for the exception</param>
		/// <param name="inner">The exception that caused the 
		/// current exception</param>
		public AssertionException(string message, Exception inner) :
			base(message, inner) 
		{}

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		protected AssertionException(System.Runtime.Serialization.SerializationInfo info, 
			System.Runtime.Serialization.StreamingContext context) : base(info,context)
		{}

	}
}
