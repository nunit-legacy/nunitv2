// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Text;
using System.Xml;
using System.IO;
using NUnit.Framework;

namespace NUnit.Util.Tests
{
    [TestFixture]
    public class NUnitProjectSave
    {
        static readonly string xmlfile = Path.Combine(Path.GetTempPath(), "test.nunit");

        private NUnitProject project;

        [SetUp]
        public void SetUp()
        {
            project = new ProjectService().EmptyProject();
        }

        [TearDown]
        public void TearDown()
        {
            if ( File.Exists( xmlfile ) )
                File.Delete( xmlfile );
        }

        private void CheckContents( string expected )
        {
            StreamReader reader = new StreamReader( xmlfile );
            string contents = reader.ReadToEnd();
            reader.Close();
            Assert.AreEqual( expected, contents );
        }

        [Test]
        public void SaveEmptyProject()
        {
            project.Save( xmlfile );

            CheckContents( NUnitProjectXml.EmptyProject );
        }

        [Test]
        public void SaveEmptyConfigs()
        {
            project.Configs.Add( "Debug" );
            project.Configs.Add( "Release" );

            project.Save( xmlfile );

            CheckContents( NUnitProjectXml.EmptyConfigs );			
        }

        [Test]
        public void SaveNormalProject()
        {
            string tempPath = Path.GetTempPath();

            ProjectConfig config1 = new ProjectConfig( "Debug" );
            config1.BasePath = "bin" + Path.DirectorySeparatorChar + "debug";
            config1.Assemblies.Add( Path.Combine(tempPath, "bin" + Path.DirectorySeparatorChar + "debug" + Path.DirectorySeparatorChar + "assembly1.dll" ) );
            config1.Assemblies.Add( Path.Combine(tempPath, "bin" + Path.DirectorySeparatorChar + "debug" + Path.DirectorySeparatorChar + "assembly2.dll" ) );

            ProjectConfig config2 = new ProjectConfig( "Release" );
            config2.BasePath = "bin" + Path.DirectorySeparatorChar + "release";
            config2.Assemblies.Add( Path.Combine(tempPath, "bin" + Path.DirectorySeparatorChar + "release" + Path.DirectorySeparatorChar + "assembly1.dll" ) );
            config2.Assemblies.Add( Path.Combine(tempPath, "bin" + Path.DirectorySeparatorChar + "release" + Path.DirectorySeparatorChar + "assembly2.dll" ) );

            project.Configs.Add( config1 );
            project.Configs.Add( config2 );

            project.Save( xmlfile );

            CheckContents( NUnitProjectXml.NormalProject );
        }
    }
}
