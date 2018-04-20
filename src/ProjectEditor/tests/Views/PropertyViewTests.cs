// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Reflection;
using NUnit.Framework;

namespace NUnit.ProjectEditor.Tests.Views
{
    public class PropertyViewTests
    {
        [Test]
        public void AllViewElementsAreInitialized()
        {
            PropertyView view = new PropertyView();

            foreach (PropertyInfo prop in typeof(PropertyView).GetProperties())
            {
                if (typeof(IViewElement).IsAssignableFrom(prop.PropertyType))
                {
                    if (prop.GetValue(view, new object[0]) == null)
                        Assert.Fail("{0} was not initialized", prop.Name);
                }
            }
        }
    }
}
