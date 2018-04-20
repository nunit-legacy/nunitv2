// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor.ViewElements
{
    public interface ISelection : IViewElement
    {
        /// <summary>
        /// Gets or sets the index of the currently selected item
        /// </summary>
        int SelectedIndex { get; set; }

        /// <summary>
        /// Event raised when the selection is changed by the user
        /// </summary>
        event ActionDelegate SelectionChanged;
    }
}
