// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Threading;
using NUnit.Framework;

namespace NUnit.Core.Tests
{
	/// <summary>
	/// Summary description for TestDelegate.
	/// </summary>
	/// 
	[TestFixture]
	public class TestDelegateFixture
	{
		internal class TestDelegate 
		{ 
			public bool delegateCalled = false;
			public System.IAsyncResult ar;

			public delegate void CallBackFunction(); 

			public TestDelegate() 
			{ 
				ar = new CallBackFunction 
					(DoSomething).BeginInvoke 
					(null,null); 
			} 

			public void DoSomething() 
			{ 
				delegateCalled = true;
			} 
		} 

		[Test]
		public void DelegateTest()
		{
			TestDelegate testDelegate = new TestDelegate(); 
			testDelegate.ar.AsyncWaitHandle.WaitOne(1000, false );
			Assert.IsTrue(testDelegate.delegateCalled);
		}
	}
} 

