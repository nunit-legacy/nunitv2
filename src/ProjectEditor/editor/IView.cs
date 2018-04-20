// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using NUnit.ProjectEditor.ViewElements;

namespace NUnit.ProjectEditor
{
    /// <summary>
    /// Common interface implemented by all views used in
    /// the ProjectEditor application
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Object that knows how to display various messages
        /// in a MessageBox.
        /// </summary>
        IMessageDisplay MessageDisplay { get; }

        /// <summary>
        /// Gets or sets the visibility of the view
        /// </summary>
        bool Visible { get; set; }
    }
}
