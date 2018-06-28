// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

namespace NUnit.ConsoleRunner.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using NUnit.Framework;
    using NUnit.Core;

    [TestFixture]
    public class CommandLineTests
    {
        [Test]
        public void NoParametersCount()
        {
            ConsoleOptions options = new ConsoleOptions();
            Assert.IsTrue(options.NoArgs);
        }

        [Test]
        public void AllowForwardSlashDefaultsCorrectly()
        {
            ConsoleOptions options = new ConsoleOptions();
            Assert.AreEqual( Path.DirectorySeparatorChar != '/', options.AllowForwardSlash );
        }

        [TestCase( "nologo", "nologo")]
        [TestCase( "help", "help" )]
        [TestCase( "help", "?" )]
        [TestCase( "wait", "wait" )]
        [TestCase( "xmlConsole", "xmlConsole")]
        [TestCase( "labels", "labels")]
        [TestCase( "noshadow", "noshadow" )]
        [TestCase( "nothread", "nothread" )]
        [TestCase( "compatibility", "compatibility")]
        [TestCase( "compatibility", "compat")]
        [TestCase( "noresult", "noresult")]
        [TestCase( "noxml", "noxml")]
        public void BooleanOptionAreRecognized( string fieldName, string option )
        {
            FieldInfo field = typeof(ConsoleOptions).GetField( fieldName );
            Assert.IsNotNull( field, "Field '{0}' not found", fieldName );
            Assert.AreEqual( typeof(bool), field.FieldType, "Field '{0}' is wrong type", fieldName );

            ConsoleOptions options = new ConsoleOptions( "-" + option );
            Assert.AreEqual( true, (bool)field.GetValue( options ), "Didn't recognize -" + option );
            options = new ConsoleOptions( "--" + option );
            Assert.AreEqual( true, (bool)field.GetValue( options ), "Didn't recognize --" + option );
            options = new ConsoleOptions( false, "/" + option );
            Assert.AreEqual( false, (bool)field.GetValue( options ), "Incorrectly recognized /" + option );
            options = new ConsoleOptions( true, "/" + option );
            Assert.AreEqual( true, (bool)field.GetValue( options ), "Didn't recognize /" + option );
        }

        [TestCase( "fixture", "fixture" )]
        [TestCase( "config", "config")]
        [TestCase( "result", "result")]
        [TestCase( "xml", "xml" )]
        [TestCase( "output", "output" )]
        [TestCase( "output", "out" )]
        [TestCase( "err", "err" )]
        [TestCase( "include", "include" )]
        [TestCase( "exclude", "exclude" )]
        [TestCase( "test", "test")]
        [TestCase("run", "run")]
        [TestCase("testlist", "testlist")]
        [TestCase("runlist", "runlist")]
        [TestCase("basepath", "basepath")]
        [TestCase("privatebinpath", "privatebinpath")]
        public void StringOptionsAreRecognized( string fieldName, string option )
        {
            FieldInfo field = typeof(ConsoleOptions).GetField( fieldName );
            Assert.IsNotNull( field, "Field {0} not found", fieldName );
            Assert.AreEqual( typeof(string), field.FieldType );

            ConsoleOptions options = new ConsoleOptions( "-" + option + ":text" );
            Assert.AreEqual( "text", (string)field.GetValue( options ), "Didn't recognize -" + option );
            options = new ConsoleOptions( "--" + option + ":text" );
            Assert.AreEqual( "text", (string)field.GetValue( options ), "Didn't recognize --" + option );
            options = new ConsoleOptions( false, "/" + option + ":text" );
            Assert.AreEqual( null, (string)field.GetValue( options ), "Incorrectly recognized /" + option );
            options = new ConsoleOptions( true, "/" + option + ":text" );
            Assert.AreEqual( "text", (string)field.GetValue( options ), "Didn't recognize /" + option );
        }

        [TestCase("domain")]
        [TestCase("trace")]
        public void EnumOptionsAreRecognized( string fieldName )
        {
            FieldInfo field = typeof(ConsoleOptions).GetField( fieldName );
            Assert.IsNotNull( field, "Field {0} not found", fieldName );
            Assert.IsTrue( field.FieldType.IsEnum, "Field {0} is not an enum", fieldName );
        }

        [Test]
        public void AssemblyName()
        {
            ConsoleOptions options = new ConsoleOptions( "nunit.tests.dll" );
            Assert.AreEqual( "nunit.tests.dll", options.Parameters[0] );
        }

        [Test]
        public void FixtureNamePlusAssemblyIsValid()
        {
            ConsoleOptions options = new ConsoleOptions( "-fixture:NUnit.Tests.AllTests", "nunit.tests.dll" );
            Assert.AreEqual("nunit.tests.dll", options.Parameters[0]);
            Assert.AreEqual("NUnit.Tests.AllTests", options.fixture);
            Assert.IsTrue(options.Validate());
        }

        [Test]
        public void AssemblyAloneIsValid()
        {
            ConsoleOptions options = new ConsoleOptions( "nunit.tests.dll" );
            Assert.IsTrue(options.Validate(), "command line should be valid");
        }

        [Test]
        public void InvalidOption()
        {
            ConsoleOptions options = new ConsoleOptions( "-asembly:nunit.tests.dll" );
            Assert.IsFalse(options.Validate());
        }


        [Test]
        public void NoFixtureNameProvided()
        {
            ConsoleOptions options = new ConsoleOptions( "-fixture:", "nunit.tests.dll" );
            Assert.IsFalse(options.Validate());
        }

        [Test] 
        public void InvalidCommandLineParms()
        {
            ConsoleOptions options = new ConsoleOptions( "-garbage:TestFixture", "-assembly:Tests.dll" );
            Assert.IsFalse(options.Validate());
        }

        [Test]
        public void XmlParameter()
        {
            ConsoleOptions options = new ConsoleOptions("tests.dll", "-xml:results.xml");
            Assert.IsTrue(options.ParameterCount == 1, "assembly should be set");
            Assert.AreEqual("tests.dll", options.Parameters[0]);
            Assert.AreEqual("results.xml", options.xml);
        }

        [Test]
        public void ResultParameter()
        {
            ConsoleOptions options = new ConsoleOptions("tests.dll", "-result:results.xml");
            Assert.IsTrue(options.ParameterCount == 1, "assembly should be set");
            Assert.AreEqual("tests.dll", options.Parameters[0]);
            Assert.AreEqual("results.xml", options.result);
        }

        [Test]
        public void XmlParameterWithFullPath()
        {
            ConsoleOptions options = new ConsoleOptions( "tests.dll", "-xml:C:/nunit/tests/bin/Debug/console-test.xml" );
            Assert.IsTrue(options.ParameterCount == 1, "assembly should be set");
            Assert.AreEqual("tests.dll", options.Parameters[0]);
            Assert.AreEqual("C:/nunit/tests/bin/Debug/console-test.xml", options.xml);
        }

        [Test]
        public void XmlParameterWithFullPathUsingEqualSign()
        {
            ConsoleOptions options = new ConsoleOptions( "tests.dll", "-xml=C:/nunit/tests/bin/Debug/console-test.xml" );
            Assert.IsTrue(options.ParameterCount == 1, "assembly should be set");
            Assert.AreEqual("tests.dll", options.Parameters[0]);
            Assert.AreEqual("C:/nunit/tests/bin/Debug/console-test.xml", options.xml);
        }

        [Test]
        public void FileNameWithoutXmlParameterLooksLikeParameter()
        {
            ConsoleOptions options = new ConsoleOptions( "tests.dll", "result.xml" );
            Assert.IsTrue(options.Validate());
            Assert.AreEqual(2, options.Parameters.Count);
        }

        [Test]
        public void XmlParameterWithoutFileNameIsInvalid()
        {
            ConsoleOptions options = new ConsoleOptions( "tests.dll", "-xml:" );
            Assert.IsFalse(options.Validate());			
        }

        [Test]
        public void HelpTextUsesCorrectDelimiterForPlatform()
        {
            string helpText = new ConsoleOptions().GetHelpText();
            char delim = System.IO.Path.DirectorySeparatorChar == '/' ? '-' : '/';

            string expected = string.Format( "{0}output=", delim );
            StringAssert.Contains( expected, helpText );
            
            expected = string.Format( "{0}out=", delim );
            StringAssert.Contains( expected, helpText );
        }

        [TestCase("--fixture", 1)]
        [TestCase("--run", 1)]
        [TestCase("--runlist", 1)]
        [TestCase("--include", 1)]
        [TestCase("--exclude", 1)]
        [TestCase("--apartment:STA", 1)]
        [TestCase("--result", 0)]
        [TestCase("--xml", 1)]
        [TestCase("--noresult", 0)]
        [TestCase("--noxml", 1)]
        [TestCase("--xmlConsole", 1)]
        [TestCase("--basepath", 1)]
        [TestCase("--privatebinpath", 1)]
        [TestCase("--cleanup", 1)]
        [TestCase("--nodots", 1)]
        public void CompatibilityReport(string opt, int expected)
        {
            var options = new ConsoleOptions("tests.dll", opt, "--compat", "--process:Single", "--domain:Single");
            Assert.IsTrue(options.Validate());

            var issues = new List<Compatibility.Issue>(options.CompatibilityIssues);
            Assert.That(issues.Count, Is.EqualTo(expected));
            foreach (var issue in issues)
                Assert.That(issue.Message, Does.Contain("option is no longer supported"));
        }

        [Test]
        public void CompatibilityReport_NoErrors()
        {
            ConsoleOptions options = new ConsoleOptions("tests.dll", "--compat", "--process:Single", "--domain:Single");
            Assert.IsTrue(options.Validate());

            var issues = new List<Compatibility.Issue>(options.CompatibilityIssues);
            Assert.That(issues.Count == 0);
        }

        [Test]
        public void CompatibilityReport_DefaultProcessModel()
        {
            ConsoleOptions options = new ConsoleOptions("tests.dll", "--compat");
            Assert.IsTrue(options.Validate());

            var issues = new List<Compatibility.Issue>(options.CompatibilityIssues);
            Assert.That(issues.Count == 1);
            Assert.That(issues[0].Message, Does.Contain("--process option defaults to Multiple"));
        }

        [Test]
        public void CompatibilityReport_DefaultDomainUsage()
        {
            ConsoleOptions options = new ConsoleOptions("tests.dll", "--compat", "--process:Single");
            Assert.IsTrue(options.Validate());

            var issues = new List<Compatibility.Issue>(options.CompatibilityIssues);
            Assert.That(issues.Count == 1);
            Assert.That(issues[0].Message, Does.Contain("--domain option defaults to Multiple"));
        }
    }
}
