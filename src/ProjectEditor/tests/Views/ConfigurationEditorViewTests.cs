// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.Framework;

namespace NUnit.ProjectEditor.Tests.Views
{
    public class ConfigurationEditorViewTests
    {
        [Test]
        public void AllViewElementsAreWrapped()
        {
            ConfigurationEditorDialog view = new ConfigurationEditorDialog();

            Assert.NotNull(view.AddCommand);
            Assert.NotNull(view.RemoveCommand);
            Assert.NotNull(view.RenameCommand);
            Assert.NotNull(view.ActiveCommand);

            Assert.NotNull(view.ConfigList);
        }
    }
}
