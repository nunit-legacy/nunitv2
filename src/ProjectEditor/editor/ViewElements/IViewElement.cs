// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.ProjectEditor
{
    /// <summary>
    /// The IViewElement interface is exposed by the view
    /// for an individual gui element. It is the base of
    /// other more specific interfaces.
    /// </summary>
    public interface IViewElement
    {
        /// <summary>
        /// Gets the name of the element in the view
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the enabled status of the element
        /// </summary>
        bool Enabled { get; set; }
    }
}
