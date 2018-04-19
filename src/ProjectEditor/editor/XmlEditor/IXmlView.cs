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
    /// IXmlView is the interface implemented by the XmlView
    /// and consumed by the XmlPresenter.
    /// </summary>
    public interface IXmlView : IView
    {
        /// <summary>
        /// Gets or sets the XML text
        /// </summary>
        ITextElement Xml { get; }

        /// <summary>
        /// Display an error message at bottom of the view,
        /// adjusting the text to make edit box to make room.
        /// </summary>
        /// <param name="message">The message to display</param>
        void DisplayError(string message);

        /// <summary>
        /// Display an error message at bottom of the view,
        /// adjusting the text to make edit box to make room
        /// and highlighting the text that caused the error.
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="lineNumber">The line number in which the error occured.</param>
        /// <param name="linePosition">The position in the line that caused the error.</param>
        void DisplayError(string message, int lineNumber, int linePosition);

        /// <summary>
        /// Remove any error message from the view, adjusting
        /// the edit box so it uses all the space.
        /// </summary>
        void RemoveError();

        
    }
}
