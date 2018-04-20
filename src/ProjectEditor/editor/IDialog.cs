// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Windows.Forms;

namespace NUnit.ProjectEditor
{
    /// <summary>
    /// Common interface implemented by all modal dialog views used in
    /// the ProjectEditor application
    /// </summary>
    public interface IDialog : IView
    {
        DialogResult ShowDialog();
        void Close();
    }
}
