// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using NUnit.Framework;

[TestFixture]
public class NoNamespaceTestFixture
{
    public static readonly int Tests = 3;

    public static readonly string AssemblyPath = NUnit.Core.AssemblyHelper.GetAssemblyPath(typeof(NoNamespaceTestFixture));

    [Test]
    public void Test1()
    {
    }

    [Test]
    public void Test2()
    {
    }

    [Test]
    public void Test3()
    {
    }
}
