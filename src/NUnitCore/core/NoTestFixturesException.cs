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
	/// Summary description for NoTestFixtureException.
	/// </summary>
	[Serializable]
	public class NoTestFixturesException : ApplicationException
	{
		public NoTestFixturesException() : base () {}

		public NoTestFixturesException(string message) : base(message)
		{}

		public NoTestFixturesException(string message, Exception inner) : base(message, inner) {}

		protected NoTestFixturesException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
	}
}
