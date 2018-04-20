// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Core
{
	/// <summary>
	/// Summary description for NullListener.
	/// </summary>
	/// 
	[Serializable]
	public class NullListener : EventListener
	{
		public void RunStarted( string name, int testCount ){ }

		public void RunFinished( TestResult result ) { }

		public void RunFinished( Exception exception ) { }

		public void TestStarted(TestName testName){}
			
		public void TestFinished(TestResult result){}

		public void SuiteStarted(TestName testName){}

		public void SuiteFinished(TestResult result){}

		public void UnhandledException( Exception exception ) {}

		public void TestOutput(TestOutput testOutput) {}

		public static EventListener NULL
		{
			get { return new NullListener();}
		}
	}
}
