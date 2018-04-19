// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Util
{
	/// <summary>
	/// The TestObserver interface is implemented by a class that
	/// subscribes to the events generated in loading and running
	/// tests and uses that information in some way.
	/// </summary>
	public interface TestObserver
	{
		void Subscribe( ITestEvents events );
	}
}
