// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NUnit.Core
{
    /// <summary>
    /// SetUpFixture extends TestSuite and supports
    /// Setup and TearDown methods.
    /// </summary>
    public class SetUpFixture : TestSuite
    {
        #region Constructor
        public SetUpFixture( Type type ) : base( type )
        {
            this.TestName.Name = type.Namespace;
            if (this.TestName.Name == null)
                this.TestName.Name = "[default namespace]";
            int index = TestName.Name.LastIndexOf('.');
            if (index > 0)
                this.TestName.Name = this.TestName.Name.Substring(index + 1);

            var fixtureSetUpMethods = new List<MethodInfo>();
            fixtureSetUpMethods.AddRange(Reflect.GetMethodsWithAttribute(type, NUnitFramework.SetUpAttribute, true));
            fixtureSetUpMethods.AddRange(Reflect.GetMethodsWithAttribute(type, NUnitFramework.OneTimeSetUpAttribute, true));
            FixtureSetUpMethods = fixtureSetUpMethods;

            var fixtureTearDownMethods = new List<MethodInfo>();
            fixtureTearDownMethods.AddRange(Reflect.GetMethodsWithAttribute(type, NUnitFramework.TearDownAttribute, true));
            fixtureTearDownMethods.AddRange(Reflect.GetMethodsWithAttribute(type, NUnitFramework.OneTimeTearDownAttribute, true));
            FixtureTearDownMethods = fixtureTearDownMethods;

#if CLR_2_0 || CLR_4_0
            this.actions = ActionsHelper.GetActionsFromTypesAttributes(type);
#endif
        }
        #endregion

        #region TestSuite Overrides

        /// <summary>
        /// Gets a string representing the kind of test
        /// that this object represents, for use in display.
        /// </summary>
        public override string TestType
        {
            get { return "SetUpFixture"; }
        }

        public override TestResult Run(EventListener listener, ITestFilter filter)
        {
            using ( new DirectorySwapper( AssemblyHelper.GetDirectoryName( FixtureType.Assembly ) ) )
            {
                return base.Run(listener, filter);
            }
        }
        #endregion
    }
}
