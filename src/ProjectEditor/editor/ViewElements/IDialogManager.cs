// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor.ViewElements
{
    public interface IDialogManager
    {
        string GetFileOpenPath(string title, string filter, string initialDirectory);

        string GetSaveAsPath(string title, string filter);

        string GetFolderPath(string message, string initialPath);
    }
}
