// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.UiException.CodeFormatters;

namespace NUnit.UiException.CodeFormatters
{
    /// <summary>
    /// ICodeFormatter is the interface to make the syntax
    /// coloring of a string for a specific developpment language.
    /// </summary>
    public interface ICodeFormatter
    {
        /// <summary>
        /// The language name handled by this formatter.
        /// Ex: "C#", "Java", "C++" and so on...
        /// </summary>
        string Language { get; }

        /// <summary>
        /// Makes the coloring syntax of the given text.
        /// </summary>
        /// <param name="code">The text to be formatted. This
        /// parameter cannot be null.</param>
        /// <returns>A FormattedCode instance.</returns>
        FormattedCode Format(string code);
    }
}
