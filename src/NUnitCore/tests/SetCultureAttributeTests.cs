// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Threading;
using System.Globalization;
using NUnit.Framework;
using NUnit.TestData.CultureAttributeTests;
using NUnit.TestUtilities;

namespace NUnit.Core.Tests
{
    [TestFixture]
    public class SetCultureAttributeTests
    {
        private CultureInfo originalCulture;
//        private CultureInfo originalUICulture;

        [SetUp]
        public void Setup()
        {
            originalCulture = CultureInfo.CurrentCulture;
//            originalUICulture = CultureInfo.CurrentUICulture;
        }        

        [Test, SetUICulture("fr-FR")]
        public void SetUICultureOnlyToFrench()
        {
            Assert.AreEqual(CultureInfo.CurrentCulture, originalCulture, "Culture should not change");
            Assert.AreEqual("fr-FR", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetUICulture("fr-CA")]
        public void SetUICultureOnlyToFrenchCanadian()
        {
            Assert.AreEqual(CultureInfo.CurrentCulture, originalCulture, "Culture should not change");
            Assert.AreEqual("fr-CA", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetUICulture("ru-RU")]
        public void SetUICultureOnlyToRussian()
        {
            Assert.AreEqual(CultureInfo.CurrentCulture, originalCulture, "Culture should not change");
            Assert.AreEqual("ru-RU", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetCulture("fr-FR"), SetUICulture("fr-FR")]
        public void SetBothCulturesToFrench()
        {
            Assert.AreEqual("fr-FR", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
            Assert.AreEqual("fr-FR", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetCulture("fr-CA"), SetUICulture("fr-CA")]
        public void SetBothCulturesToFrenchCanadian()
        {
            Assert.AreEqual("fr-CA", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
            Assert.AreEqual("fr-CA", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetCulture("ru-RU"), SetUICulture("ru-RU")]
        public void SetBothCulturesToRussian()
        {
            Assert.AreEqual("ru-RU", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
            Assert.AreEqual("ru-RU", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetCulture("fr-FR"), SetUICulture("fr-CA")]
        public void SetMixedCulturesToFrenchAndUIFrenchCanadian()
        {
            Assert.AreEqual("fr-FR", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
            Assert.AreEqual("fr-CA", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [Test, SetCulture("ru-RU"), SetUICulture("en-US")]
        public void SetMixedCulturesToRussianAndUIEnglishUS()
        {
            Assert.AreEqual("ru-RU", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
            Assert.AreEqual("en-US", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
        }

        [TestFixture, SetCulture("ru-RU"), SetUICulture("ru-RU")]
        class NestedBehavior
        {
            [Test]
            public void InheritedRussian()
            {
                Assert.AreEqual("ru-RU", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
                Assert.AreEqual("ru-RU", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
            }

            [Test, SetUICulture("fr-FR")]
            public void InheritedRussianWithUIFrench()
            {
                Assert.AreEqual("ru-RU", CultureInfo.CurrentCulture.Name, "Culture not set correctly");
                Assert.AreEqual("fr-FR", CultureInfo.CurrentUICulture.Name, "UICulture not set correctly");
            }
        }        
    }
}
