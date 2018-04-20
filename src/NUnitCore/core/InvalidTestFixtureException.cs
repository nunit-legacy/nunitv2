// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Core
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// Summary description for NoTestMethodsException.
	/// </summary>
	/// 
	[Serializable]
	public class InvalidTestFixtureException : ApplicationException
	{
		public InvalidTestFixtureException() : base() {}

		public InvalidTestFixtureException(string message) : base(message)
		{}

		public InvalidTestFixtureException(string message, Exception inner) : base(message, inner)
		{}

		/// <summary>
		/// Serialization Constructor
		/// </summary>
		protected InvalidTestFixtureException(SerializationInfo info, 
			StreamingContext context) : base(info,context){}

	}
}