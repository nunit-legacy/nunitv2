// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor
{
    public interface IProjectConfig
    {
        string Name { get; set; }

        string BasePath { get; set; }

        string RelativeBasePath { get; }

        string EffectiveBasePath { get; }

        string ConfigurationFile { get; set; }

        string PrivateBinPath { get; set; }

        BinPathType BinPathType { get; set; }

        AssemblyList Assemblies { get; }

        RuntimeFramework RuntimeFramework { get; set; }
    }
}
