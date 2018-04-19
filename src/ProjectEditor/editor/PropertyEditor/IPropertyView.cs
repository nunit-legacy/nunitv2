// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections.Generic;
using NUnit.ProjectEditor.ViewElements;

namespace NUnit.ProjectEditor
{
    public interface IPropertyView : IView
    {
        #region Properties

        IDialogManager DialogManager { get; }
        IConfigurationEditorDialog ConfigurationEditorDialog { get; }

        #region Command Elements

        ICommand BrowseProjectBaseCommand { get; }
        ICommand EditConfigsCommand { get; }
        ICommand BrowseConfigBaseCommand { get; }

        ICommand AddAssemblyCommand { get; }
        ICommand RemoveAssemblyCommand { get; }
        ICommand BrowseAssemblyPathCommand { get; }

        #endregion

        #region Properties of the Model as a Whole

        ITextElement ProjectPath { get; }
        ITextElement ProjectBase { get; }
        ISelectionList ProcessModel { get; }
        ISelectionList DomainUsage { get; }
        ITextElement ActiveConfigName { get; }

        ISelectionList ConfigList { get; }

        #endregion

        #region Properties of the Selected Config

        ISelectionList Runtime { get; }
        IComboBox RuntimeVersion { get; }
        ITextElement ApplicationBase { get; }
        ITextElement ConfigurationFile { get; }

        ISelection BinPathType { get; }
        ITextElement PrivateBinPath { get; }

        ISelectionList AssemblyList { get; }
        ITextElement AssemblyPath { get; }

        #endregion

        #endregion
    }
}
