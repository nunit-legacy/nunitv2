// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Xml;

namespace NUnit.ProjectEditor
{
    public interface IProjectDocument
    {
        #region Events

        event ActionDelegate ProjectCreated;
        event ActionDelegate ProjectClosed;
        event ActionDelegate ProjectChanged;

        #endregion

        #region Properties

        string Name { get; }

        /// <summary>
        /// Gets or sets the path to which a doc will be saved.
        /// </summary>
        string ProjectPath { get; set; }

        bool IsEmpty { get; }
        bool IsValid { get; }

        string XmlText { get; set; }
        Exception Exception { get; }

        XmlNode RootNode { get; }
        XmlNode SettingsNode { get; }
        XmlNodeList ConfigNodes { get; }

        bool HasUnsavedChanges { get; }

        string GetSettingsAttribute(string name);
        void SetSettingsAttribute(string name, string value);
        void RemoveSettingsAttribute(string name);

        #endregion

        #region Methods

        void CreateNewProject();
        void OpenProject(string fileName);
        void CloseProject();
        void SaveProject();
        void SaveProject(string fileName);

        void LoadXml(string xmlText);

        #endregion
    }
}
