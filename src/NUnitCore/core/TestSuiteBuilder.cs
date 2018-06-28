// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Core
{
    using NUnit.Core.Builders;
    using System.Collections;
    using System.Reflection;

    /// <summary>
    /// This is the master suite builder for NUnit. It builds a test suite from
    /// one or more assemblies using a list of internal and external suite builders 
    /// to create fixtures from the qualified types in each assembly. It implements
    /// the ISuiteBuilder interface itself, allowing it to be used by other classes
    /// for queries and suite construction.
    /// </summary>D:\Dev\NUnit\nunit20\src\NUnitFramework\core\TestBuilderAttribute.cs
    public class TestSuiteBuilder
    {
        #region Instance Variables

        private ArrayList builders = new ArrayList();

        #endregion

        #region Properties
        public IList Assemblies
        {
            get 
            {
                ArrayList assemblies = new ArrayList();
                foreach( TestAssemblyBuilder builder in builders )
                    assemblies.Add( builder.Assembly );
                return assemblies; 
            }
        }

        public IList AssemblyInfo
        {
            get
            {
                ArrayList info = new ArrayList();
                foreach( TestAssemblyBuilder builder in this.builders )
                    info.Add( builder.AssemblyInfo );

                return info;
            }
        }
        #endregion

        #region Build Methods
        /// <summary>
        /// Build a suite based on a TestPackage
        /// </summary>
        /// <param name="package">The TestPackage</param>
        /// <returns>A TestSuite</returns>
        public TestSuite Build( TestPackage package )
        {
            bool autoNamespaceSuites = package.GetSetting( "AutoNamespaceSuites", true );
            bool mergeAssemblies = package.GetSetting( "MergeAssemblies", false );
            bool checkCompatibility = package.GetSetting("NUnit3Compatibility", false);
            TestExecutionContext.CurrentContext.TestCaseTimeout = package.GetSetting("DefaultTimeout", 0);

            if ( package.IsSingleAssembly )
                return BuildSingleAssembly( package );
            string targetAssemblyName = null;
            if( package.TestName != null && package.Assemblies.Contains( package.TestName ) )
            {
                targetAssemblyName = package.TestName;
                package.TestName = null;
            }
            
            TestSuite rootSuite = new ProjectRootSuite( package.FullName );
            NamespaceTreeBuilder namespaceTree = 
                new NamespaceTreeBuilder( rootSuite );

            builders.Clear();
            foreach(string assemblyName in package.Assemblies)
            {
                if ( targetAssemblyName == null || targetAssemblyName == assemblyName )
                {
                    TestAssemblyBuilder builder = new TestAssemblyBuilder();
                    builders.Add( builder );

                    Test testAssembly =  builder.Build( assemblyName, package.TestName, autoNamespaceSuites && !mergeAssemblies, checkCompatibility );

                    if ( testAssembly != null )
                    {
                        if (!mergeAssemblies)
                        {
                            rootSuite.Add(testAssembly);
                        }
                        else if (autoNamespaceSuites)
                        {
                            namespaceTree.Add(testAssembly.Tests);
                            rootSuite = namespaceTree.RootSuite;
                        }
                        else
                        {
                            foreach (Test test in testAssembly.Tests)
                                rootSuite.Add(test);
                        }
                    }
                }
            }

            ProviderCache.Clear();
            
            if (rootSuite.Tests.Count == 0)
                return null;

            return rootSuite;
        }

        private TestSuite BuildSingleAssembly( TestPackage package )
        {
            TestAssemblyBuilder builder = new TestAssemblyBuilder();
            builders.Clear();
            builders.Add( builder );

            TestSuite suite = (TestSuite)builder.Build( 
                package.FullName, 
                package.TestName, package.GetSetting( "AutoNamespaceSuites", true ),
                package.GetSetting("NUnit3Compatibility", false));

            ProviderCache.Clear();

            return suite;
        }
        #endregion
    }
}
