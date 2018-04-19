// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// ExceptionTypeConstraint is a special version of ExactTypeConstraint
    /// used to provided detailed info about the exception thrown in
    /// an error message.
    /// </summary>
    public class ExceptionTypeConstraint : ExactTypeConstraint
    {
        /// <summary>
        /// Constructs an ExceptionTypeConstraint
        /// </summary>
        public ExceptionTypeConstraint(Type type) : base(type) { }

        /// <summary>
        /// Write the actual value for a failing constraint test to a
        /// MessageWriter. Overriden to write additional information 
        /// in the case of an Exception.
        /// </summary>
        /// <param name="writer">The MessageWriter to use</param>
        public override void WriteActualValueTo(MessageWriter writer)
        {
            Exception ex = actual as Exception;
            base.WriteActualValueTo(writer);

            if (ex != null)
            {
                writer.WriteLine(" ({0})", ex.Message);
                writer.Write(ex.StackTrace);
            }
        }
    }
}
