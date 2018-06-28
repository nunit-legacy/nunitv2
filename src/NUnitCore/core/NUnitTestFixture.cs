// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Reflection;
using System.Collections.Generic;

namespace NUnit.Core
{
    /// <summary>
    /// Class to implement an NUnit test fixture
    /// </summary>
    public class NUnitTestFixture : TestFixture
    {
        public NUnitTestFixture(Type fixtureType)
            : this(fixtureType, null) { }

        public NUnitTestFixture(Type fixtureType, object[] arguments)
            : base(fixtureType, arguments)
        {

            var fixtureSetUpMethods = new List<MethodInfo>();
            fixtureSetUpMethods.AddRange(Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.FixtureSetUpAttribute, true));
            fixtureSetUpMethods.AddRange(Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.OneTimeSetUpAttribute, true));
            FixtureSetUpMethods = fixtureSetUpMethods;

            var fixtureTearDownMethods = new List<MethodInfo>();
            fixtureTearDownMethods.AddRange(Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.FixtureTearDownAttribute, true));
            fixtureTearDownMethods.AddRange(Reflect.GetMethodsWithAttribute(fixtureType, NUnitFramework.OneTimeTearDownAttribute, true));
            FixtureTearDownMethods = fixtureTearDownMethods;

            SetUpMethods = 
                Reflect.GetMethodsWithAttribute(this.FixtureType, NUnitFramework.SetUpAttribute, true);
            TearDownMethods = 
                Reflect.GetMethodsWithAttribute(this.FixtureType, NUnitFramework.TearDownAttribute, true);

#if CLR_2_0 || CLR_4_0
            this.actions = ActionsHelper.GetActionsFromTypesAttributes(fixtureType);
#endif
        }

        protected override void DoOneTimeSetUp(TestResult suiteResult)
        {
            base.DoOneTimeSetUp(suiteResult);

            suiteResult.AssertCount = NUnitFramework.Assert.GetAssertCount(); ;
        }

        protected override void DoOneTimeTearDown(TestResult suiteResult)
        {
            base.DoOneTimeTearDown(suiteResult);

            suiteResult.AssertCount += NUnitFramework.Assert.GetAssertCount();
        }
    }
}
