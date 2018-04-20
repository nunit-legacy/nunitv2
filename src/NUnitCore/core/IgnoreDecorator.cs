// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Reflection;

namespace NUnit.Core
{
	/// <summary>
	/// Ignore Decorator is an alternative method of marking tests to
	/// be ignored. It is currently not used, since the test builders
	/// take care of the ignore attribute.
	/// </summary>
	public class IgnoreDecorator : Extensibility.ITestDecorator
	{
		public IgnoreDecorator( string ignoreAttributeType )
		{
		}

		#region ITestDecorator Members

		public Test Decorate( Test test, MemberInfo member )
		{
			Attribute ignoreAttribute = Reflect.GetAttribute( member, NUnitFramework.IgnoreAttribute, false );

			if ( ignoreAttribute != null )
			{
				test.RunState = RunState.Ignored;
				test.IgnoreReason = NUnitFramework.GetIgnoreReason( ignoreAttribute );
			}

			return test;
		}

		#endregion
	}
}
