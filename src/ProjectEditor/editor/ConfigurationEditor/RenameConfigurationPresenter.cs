// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor
{
    public class RenameConfigurationPresenter
    {
        private IProjectModel model;
        private IRenameConfigurationDialog dlg;
        private string originalName;

        public RenameConfigurationPresenter(IProjectModel model, IRenameConfigurationDialog dlg, string originalName)
        {
            this.model = model;
            this.dlg = dlg;
            this.originalName = originalName;

            dlg.ConfigurationName.Text = originalName;
            dlg.ConfigurationName.Select(0, originalName.Length);

            dlg.ConfigurationName.Changed += delegate
            {
                string text = dlg.ConfigurationName.Text;
                dlg.OkButton.Enabled = text != string.Empty && text != originalName;
            };

            dlg.OkButton.Execute += delegate
            {
                string newName = dlg.ConfigurationName.Text;

                foreach (string existingName in model.ConfigNames)
                {
                    if (existingName == newName)
                    {
                        dlg.MessageDisplay.Error("A configuration with that name already exists");
                        return;
                    }
                }

                model.Configs[originalName].Name = newName;
            };
        }
    }
}
