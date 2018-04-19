// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.Core
{
    /// <summary>
    /// Enumeration expressing the level of log messages to be 
    /// captured by NUnit and sent to the runner. These happen
    /// to match the standard levels used by log4net, but will
    /// be translated for any other loggers we support.
    /// </summary>
    public enum LoggingThreshold
    {
        /// <summary>No logging</summary>
        Off = 0,
        /// <summary>Severe error beyond which continuation is not possible</summary>
        Fatal = 1,
        /// <summary>Error that may allow continuation</summary>
        Error = 2,
        /// <summary>A warning message</summary>
        Warn = 3,
        /// <summary>An informational message</summary>
        Info = 4,
        /// <summary>Messages used for debugging</summary>
        Debug = 5,
        /// <summary>All of the preceding plus more detailled messages if supported</summary>
        All = 6,
    }
}
