// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using NUnit.Core;

namespace NUnit.Gui.SettingsPages
{
    public partial class InternalTraceSettingsPage : NUnit.UiKit.SettingsPage
    {
        public InternalTraceSettingsPage(string key) : base(key)
        {
            InitializeComponent();
        }

        public override void LoadSettings()
        {
            traceLevelComboBox.SelectedIndex = (int)(InternalTraceLevel)settings.GetSetting("Options.InternalTraceLevel", InternalTraceLevel.Default);
            logDirectoryLabel.Text = NUnitConfiguration.LogDirectory;
        }

        public override void ApplySettings()
        {
            InternalTraceLevel level = (InternalTraceLevel)traceLevelComboBox.SelectedIndex;
            settings.SaveSetting("Options.InternalTraceLevel", level);
            InternalTrace.Level = level;
        }
    }
}
