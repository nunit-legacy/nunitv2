// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace NUnit.UiException.Controls
{
    /// <summary>
    /// This enum defines indicators telling how instances of IStackTraceView
    /// should deal with item order in their list.
    /// </summary>
    public enum ErrorListOrderPolicy
    {
        /// <summary>
        /// Tells IStackTraceView to order items in the list in the same
        /// order they appear in the stack trace.
        /// </summary>
        InitialOrder,

        /// <summary>
        /// Tells IStackTraceView to order items in the list in the reverse
        /// order they appear in the stack trace. At Test Driven Development time
        /// this value is useful to point out the location where a test is expected
        /// to fail.
        /// </summary>
        ReverseOrder,
    }

    /// <summary>
    /// The interface through which SourceCodeDisplay interacts with the error list.
    /// 
    /// Direct implementations are:
    ///     - ErrorList
    /// </summary>
    public interface IStackTraceView
    {
        event EventHandler SelectedItemChanged;

        string StackTrace { get; set; }
        ErrorItem SelectedItem { get; }
        bool AutoSelectFirstItem { get; set; }
        ErrorListOrderPolicy ListOrderPolicy { get; set; }        
    }
}
