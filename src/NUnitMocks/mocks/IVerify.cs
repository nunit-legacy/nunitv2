// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Mocks
{
	/// <summary>
	/// The IVerify interface is implemented by objects capable of self-verification.
	/// </summary>
    [Obsolete("NUnit now uses NSubstitute")]
    public interface IVerify
	{
		void Verify();
	}
}
