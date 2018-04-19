// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor
{
    public interface IProjectModel
    {
        #region Properties

        IProjectDocument Document { get; }

        string ProjectPath { get; set; }
        string BasePath { get; set; }
        string EffectiveBasePath { get; }

        string ActiveConfigName { get; set; }

        string ProcessModel { get; set; }
        string DomainUsage { get; set; }

        ConfigList Configs { get; }
        string[] ConfigNames { get; }

        #endregion

        #region Methods

        IProjectConfig AddConfig(string name);
        void RemoveConfig(string name);
        void RemoveConfigAt(int index);

        #endregion
    }
}
