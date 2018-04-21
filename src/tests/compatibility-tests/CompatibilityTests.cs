using System;
using NUnit.Core;
using NUnit.Core.Extensibility;
using NUnit.Framework;

// Uncomment to test compatibility message for RequiredAddin
// If this is left uncommented, none of the other tests run!
[assembly: RequiredAddin("SomeAddin")] // ISSUE

namespace NUnit.Tests
{
    [SetUpFixture]
    public class IncompatibleSetUpFixture
    {
        [SetUp]
        public void OneTimeSetUpMethod() { }

        [TearDown]
        public void OneTimeTearDownMethod() { }
    }

    public class CompatibilityTests
    {
        #region Unsupported Attributes

        // Also see RequiredAddinAttribute above

        [TestFixtureSetUp] // ISSUE
        public void FixtureSetUp() { }

        [TestFixtureTearDown] // ISSUE
        public void FixtureTearDown() { }

        [Test, ExpectedException(typeof(ArgumentException))] // ISSUE
        public void ExpectedExceptionTest()
        {
            throw new ArgumentException("DUMMY");
        }

        [Test, RequiresSTA] // ISSUE
        public void TestRequiringSTA() { }

        [Test, RequiresMTA] // ISSUE
        public void TestRequiringMTA() { }

        #endregion

        #region TestCaseAttribute

        [TestCase(42, Ignore = true)] // ISSUE
        public void IgnoredTestCaseWithoutReason(int x) { }

        [TestCase(Result = 42)] // ISSUE
        public int TestCaseWithResult()
        {
            return 42;
        }

        [TestCase(42, ExpectedException = typeof(ArgumentException))] // ISSUE
        public void ExpectedExceptionTestCase(int arg)
        {
            throw new ArgumentException("DUMMY");
        }

        #endregion

        #region TestCaseSourceAttribute

        [TestCaseSource("ExceptionSource")]
        public void ExpectedExceptionTestCaseSource(int arg)
        {
            throw new ArgumentException("Dummy");
        }

        [TestCaseSource("IgnoredSource")]
        public void IgnoredTestCaseSource(int arg) { }

        [TestCaseSource("InstanceField")]
        [TestCaseSource("InstanceProperty")]
        [TestCaseSource("InstanceMethod")]
        [TestCaseSource(typeof(SeparateClass), "InstanceField")]
        [TestCaseSource(typeof(SeparateClass), "InstanceProperty")]
        [TestCaseSource(typeof(SeparateClass), "InstanceMethod")]
        public void TestCaseSourceTest(int x) { }

        #endregion

        #region ValueSourceAttribute

        [Test]
        public void ValueSourceTest(
            [ValueSource("InstanceField")]
            [ValueSource("InstanceProperty")]
            [ValueSource("InstanceMethod")]
            [ValueSource(typeof(SeparateClass), "InstanceField")]
            [ValueSource(typeof(SeparateClass), "InstanceProperty")]
            [ValueSource(typeof(SeparateClass), "InstanceMethod")] int x) { }

        #endregion

        #region Other Attributes with Changed Behavior

        [Test, Ignore] // ISSUE
        public void IgnoredTestWithoutReason() { }

        [Test, STAThread] // ISSUE
        public void AnotherTestRequiringSTA() { }

        [Test, MTAThread] // ISSUE
        public void AnotherTestRequiringMTA() { }

        #endregion

        #region Async void test method

        [Test]
        public async void AsyncVoidTestMethod()
        {
        }

        #endregion

        #region Assertions

        [Test]
        public void IsNullOrEmpty()
        {
            Assert.IsNullOrEmpty("");
        }

        [Test]
        public void IsNotNullOrEmpty()
        {
            Assert.IsNotNullOrEmpty("TEST");
        }

        [Test]
        public void InstanceOfType()
        {
            Assert.That("Hello", Is.InstanceOfType<string>());
        }

        [Test]
        public void StringConstraintSyntax() // 4 ISSUES
        {
            string s = "Hello";

            Assert.That(s, Is.StringStarting("Hell"));
            Assert.That(s, Is.StringEnding("lo"));
            Assert.That(s, Is.StringContaining("ll"));
            Assert.That(s, Is.StringMatching("H?ll"));
        }

        [Test]
        public void TextSyntax() // 9 ISSUES
        {
            string s = "hello";

            Assert.That(s, Text.StartsWith("hell"));
            Assert.That(s, Text.EndsWith("lo"));
            Assert.That(s, Text.Contains("ll"));
            Assert.That(s, Text.Matches("H?ll"));

            Assert.That(s, Text.DoesNotStartWith("hill"));
            Assert.That(s, Text.DoesNotEndWith("hi"));
            Assert.That(s, Text.DoesNotContain("xx"));
            Assert.That(s, Text.DoesNotMatch("H?lp"));

            Assert.That(new string[] { "Hello!", "Hi!", "Hola!" }, Text.All.StartsWith("H"));
        }

        #endregion

        #region Data Sources

        int[] InstanceField = new int[] { 1, 2, 3 }; // 2 ISSUES

        int[] InstanceProperty { get { return InstanceField; } } // 2 ISSUES

        int[] InstanceMethod() { return InstanceField; } // 2 ISSUES

        static TestCaseData[] ExceptionSource = new TestCaseData[] {
            new TestCaseData(42).Throws(typeof(ArgumentException)) }; // ISSUE

        static TestCaseData[] IgnoredSource = new TestCaseData[] {
            new TestCaseData(42).Ignore() };

        #region Nested Data Source Class

        internal class SeparateClass
        {
            int[] InstanceField = new int[] { 1, 2, 3 }; // 2 ISSUES

            int[] InstanceProperty { get { return InstanceField; } } // 2 ISSUES

            int[] InstanceMethod() { return InstanceField; } // 2 ISSUES
        }

        #endregion

        #endregion

        #region Nested Ignored Fixture Class

        [TestFixture(Ignore = true)] // ISSUE
        public class NestedFixture
        {

        }

        #endregion
    }

    #region Legacy Suite Class

    public class ClassContainingSuite
    {
        [Suite] // ISSUE
        public object[] MySuite
        {
            get { return new object[0]; }
        }
    }

    #endregion

    #region AssertionHelperDerivedClass

    [TestFixture]
    public class AssertionHelperDerivedClass : AssertionHelper
    {
        // This test is here to demonstrate that there is no error due to
        // calling the constructor at test discovery time.
        [TestCaseSource("DATA")]
        public void Test1(int x)
        {
        }

        int[] DATA = new int[] { 1, 2, 3 };
    }

    #endregion

    #region Addin Class

    // Do-nothing addin used to test RequiredAddinAttribute and NUnitAddinAttribute
    [NUnitAddin(Name = "SomeAddin", Description = "Does nothing", Type = ExtensionType.Core)]
    public class SomeAddin : IAddin, EventListener
    {
        public bool Install(IExtensionHost host)
        {
            host.GetExtensionPoint("EventListeners").Install(this);
            return true;
        }

        public void RunFinished(TestResult result)
        {
        }

        public void RunFinished(Exception exception)
        {
        }

        public void RunStarted(string name, int testCount)
        {
        }

        public void SuiteFinished(TestResult result)
        {
        }

        public void SuiteStarted(TestName testName)
        {
        }

        public void TestFinished(TestResult result)
        {
        }

        public void TestOutput(TestOutput testOutput)
        {
        }

        public void TestStarted(TestName testName)
        {
        }

        public void UnhandledException(Exception exception)
        {
        }
    }

    #endregion
}