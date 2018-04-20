// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Core
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
	public class TestBuilderAttribute : Attribute
	{
		private Type builderType;

		public TestBuilderAttribute(Type builderType)
		{
			this.builderType = builderType;
		}

		public Type BuilderType
		{
			get { return builderType; }
		}
	}
}
