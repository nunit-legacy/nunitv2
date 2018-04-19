// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor.ViewElements
{
    /// <summary>
    /// The ISelectionList interface represents
    /// a ui element that allows the user to select one of
    /// a set of items.
    /// </summary>
    public interface ISelectionList : ISelection
    {
        /// <summary>
        /// Gets or sets the currently selected item
        /// </summary>
        string SelectedItem { get; set; }

        /// <summary>
        /// Gets or sets the contents of the selection list
        /// </summary>
        string[] SelectionList { get; set; }
    }
}
