// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using NUnit.Framework;
using NUnit.Core.Builders;

namespace NUnit.Core.Tests
{
    // It's no longer possible to load assemblies at a relative
    // location to the current directory.
    // TODO: Create other tests
	//[TestFixture]
    //public class TestAssemblyBuilderTests
    //{
    //    [Test]
    //    public void CanLoadAssemblyInCurrentDirectory()
    //    {
    //        TestAssemblyBuilder builder = new TestAssemblyBuilder();
    //        Assert.IsNotNull( builder.Build( "mock-assembly.dll", false ) );
    //    }

    //    [Test]
    //    public void CanLoadAssemblyAtRelativeDirectoryLocation()
    //    {
    //        DirectoryInfo current = new DirectoryInfo( Environment.CurrentDirectory );
    //        string dir = current.Name;
    //        string parentDir = current.Parent.FullName;

    //        try
    //        {
    //            Environment.CurrentDirectory = parentDir;
    //            TestAssemblyBuilder builder = new TestAssemblyBuilder();
    //            Assert.IsNotNull( builder.Build( dir + Path.DirectorySeparatorChar + "mock-assembly.dll", false ) );
    //        }
    //        finally
    //        {
    //            Environment.CurrentDirectory = current.FullName;
    //        }
    //    }
	//}
}
