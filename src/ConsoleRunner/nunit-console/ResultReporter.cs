// ****************************************************************
// This is free software licensed under the NUnit license. You
// may obtain a copy of the license as well as information regarding
// copyright ownership at http://nunit.org.
// ****************************************************************

using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Core;
using NUnit.Util;

namespace NUnit.ConsoleRunner
{
    public class ResultReporter
    {
        private ConsoleOptions _options;
        private TestResult _result;

        public ResultReporter(TestResult result, ConsoleOptions options)
        {
            _result = result;
            _options = options;
        }

        public void ReportResults()
        {
            var summary = new ResultSummarizer(_result);
            WriteSummaryReport(summary);

            bool hasErrors = summary.Errors > 0 || summary.Failures > 0 || _result.IsError || _result.IsFailure;

            if (_options.stoponerror && (hasErrors || summary.NotRunnable > 0))
            {
                Console.WriteLine("Test run was stopped after first error, as requested.");
                Console.WriteLine();
            }

            if (hasErrors)
                WriteErrorsAndFailuresReport(_result);

            if (summary.TestsNotRun > 0)
                WriteNotRunReport(_result);

            if (_options.compatibility)
                WriteCompatibilityReport(_options);
        }

        private static void WriteSummaryReport(ResultSummarizer summary)
        {
            Console.WriteLine(
                "Tests run: {0}, Errors: {1}, Failures: {2}, Inconclusive: {3}, Time: {4} seconds",
                summary.TestsRun, summary.Errors, summary.Failures, summary.Inconclusive, summary.Time);
            Console.WriteLine(
                "  Not run: {0}, Invalid: {1}, Ignored: {2}, Skipped: {3}",
                summary.TestsNotRun, summary.NotRunnable, summary.Ignored, summary.Skipped);
            Console.WriteLine();
        }

        private static void WriteErrorsAndFailuresReport(TestResult result)
        {
            int reportIndex = 0;
            Console.WriteLine("Errors and Failures:");
            WriteErrorsAndFailures(result, ref reportIndex);
            Console.WriteLine();
        }

        private static void WriteErrorsAndFailures(TestResult result, ref int reportIndex)
        {
            if (result.Executed)
            {
                if (result.HasResults)
                {
                    if (result.IsFailure || result.IsError)
                        if (result.FailureSite == FailureSite.SetUp || result.FailureSite == FailureSite.TearDown)
                            WriteSingleResult(result, ref reportIndex);

                    foreach (TestResult childResult in result.Results)
                        WriteErrorsAndFailures(childResult, ref reportIndex );
                }
                else if (result.IsFailure || result.IsError)
                {
                    WriteSingleResult(result, ref reportIndex);
                }
            }
        }

        private static void WriteNotRunReport(TestResult result)
        {
            int reportIndex = 0;
            Console.WriteLine("Tests Not Run:");
            WriteNotRunResults(result, ref reportIndex);
            Console.WriteLine();
        }

        private static void WriteNotRunResults(TestResult result, ref int reportIndex)
        {
            if (result.HasResults)
                foreach (TestResult childResult in result.Results)
                    WriteNotRunResults(childResult, ref reportIndex);
            else if (!result.Executed)
                WriteSingleResult(result, ref reportIndex);
        }

        private static void WriteSingleResult(TestResult result, ref int reportIndex)
        {
            string status = result.IsFailure || result.IsError
                ? string.Format("{0} {1}", result.FailureSite, result.ResultState)
                : result.ResultState.ToString();

            Console.WriteLine("{0}) {1} : {2}", ++reportIndex, status, result.FullName);

            if (result.Message != null && result.Message != string.Empty)
                Console.WriteLine("   {0}", result.Message);

            if (result.StackTrace != null && result.StackTrace != string.Empty)
                Console.WriteLine(result.IsFailure
                    ? StackTraceFilter.Filter(result.StackTrace)
                    : result.StackTrace + Environment.NewLine);
        }

        private static void WriteCompatibilityReport(ConsoleOptions options)
        {
            Console.WriteLine("NUnit 3 Compatibility Issues:");

            int reportIndex = 0;
            WriteIssues(options.CompatibilityIssues, ref reportIndex);
            WriteIssues(Compatibility.Issues, ref reportIndex);

            if (reportIndex == 0)
                Console.WriteLine("    No Issues Found.");

            Console.WriteLine();
        }
        
        private static void WriteIssues(IEnumerable<Compatibility.Issue> issues, ref int reportIndex)
        {
            foreach (var issue in issues)
            {
                Console.WriteLine("{0}) {1}", ++reportIndex, issue.Location);
                Console.WriteLine("   {0}: {1}", issue.Level, issue.Message);
            }
        }
    }
}
