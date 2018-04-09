using System.IO;
using System.Collections.Generic;
using System.Text;

namespace NUnit.Framework
{
    /// <summary>
    /// Class used to report compatibility errors at execution
    /// time from the framework, using the writer passed in by
    /// the core runners.
    /// </summary>
    public class CompatibilityLogger
    {
        private const string REPORT_FORMAT = "{0}:{1}:{2}";

        private TextWriter _writer;

        /// <summary>
        /// Construct a new CompatibilityLogger
        /// </summary>
        /// <param name="writer">The TextWriter to use for logging</param>
        public CompatibilityLogger(TextWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Report a compatibility error
        /// </summary>
        public void Error(string message)
        {
            Report("Error", message);
        }

        /// <summary>
        /// Report a compatibility warning
        /// </summary>
        public void Warning(string message)
        {
            Report("Warning", message);
        }

        /// <summary>
        /// Report a compatibility note
        /// </summary>
        public void Note(string message)
        {
            Report("Note", message);
        }

        private void Report(string level, string message)
        {
            if (_writer != null)
            {
                string location = TestContext.CurrentContext.Test.ClassNamePlusMethodName;
                _writer.WriteLine(string.Format(REPORT_FORMAT, level, location, message));
            }
        }
    }
}
