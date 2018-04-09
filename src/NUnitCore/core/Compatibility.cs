using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace NUnit.Core
{
    public static class Compatibility
    {
        private const string WORK_FILE = "COMPATIBILITY.TXT";
        private const string REPORT_FORMAT = "{0}:{1}:{2}";
        private const BindingFlags ALL_MEMBERS = 
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        private static string _workFilePath;
        private static StreamWriter _writer;

        #region Initialization and Cleanup

        /// <summary>
        /// This method initializes the working directory and file path
        /// for compatibility reporting without starting collection.
        /// It should only be called by the console runner itself in
        /// the primary AppDomain.
        /// </summary>
        public static void Initialize(string workDirectory)
        {
            _workFilePath = Path.Combine(workDirectory, WORK_FILE);
            File.Create(_workFilePath);
        }

        /// <summary>
        /// This method is called once in each test AppDomain to
        /// begin collecting data.
        /// </summary>
        /// <param name="workDirectory"></param>
        public static void BeginCollection(string workDirectory)
        {
            _workFilePath = Path.Combine(workDirectory, WORK_FILE);

            _writer = new StreamWriter(_workFilePath, true)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// This method is called in each test AppDomain after all
        /// collection is complete.
        /// </summary>
        public static void EndCollection()
        {
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
        }

        #endregion

        #region Log Issues

        public static TextWriter Writer { get { return _writer; } }

        public static void Error(string location, string message)
        {
            Report("Error", location, message);
        }

        public static void Warning(string location, string message)
        {
            Report("Warning", location, message);
        }

        public static void Note(string location, string message)
        {
            Report("Note", location, message);
        }

        #endregion

        #region Get Issues for Reporting

        public static IEnumerable<Issue> Issues
        {
            get
            {
                if (_workFilePath == null)
                    throw new InvalidOperationException("Compatibility work file path not initialized");

                var records = new List<string>();

                StreamReader reader = new StreamReader(_workFilePath);
                while (!reader.EndOfStream)
                {
                    var record = reader.ReadLine();

                    // Remove duplicates created in some cases
                    if (!records.Contains(record))
                        records.Add(record);
                }

                foreach (string record in records)
                    yield return Issue.FromRecord(record);
            }
        }

        #endregion

        #region Compatibility Checks

        public static void CheckAttributes(Assembly assembly)
        {
            CheckAttributes(assembly, Path.GetFileName(assembly.Location));

            foreach (Type type in assembly.GetExportedTypes())
            {
                CheckAttributes(type, type.FullName);

                foreach (MemberInfo member in type.GetMembers())
                {
                    CheckAttributes(member);
                    var method = member as MethodInfo;
                    if (method != null)
                        foreach (var parameter in method.GetParameters())
                            CheckAttributes(parameter, LocationOf(method));
                }
            }
        }

        public static void CheckAttributes(MemberInfo member)
        {
            CheckAttributes(member, LocationOf(member));
        }

        public static void CheckAttributes(ICustomAttributeProvider provider, string location)
        {
            foreach (Attribute attribute in provider.GetCustomAttributes(true))
            {
                Type attributeType = attribute.GetType();
                string attributeName = attributeType.Name;
                string attributeFullName = attributeType.FullName;

                switch (attributeFullName)
                {
                    case "NUnit.Framework.ExpectedExceptionAttribute":
                        Error(location, "ExpectedExceptionAttribute is not supported in NUnit 3. Use Assert.Throws or ThrowsConstraint.");
                        break;
                    case "NUnit.Framework.IgnoreAttribute":
                        var reason = (string)Reflect.GetPropertyValue(attribute, "Reason");
                        if (string.IsNullOrEmpty(reason))
                            Error(location, "IgnoreAttribute requires a reason to be specified in NUnit 3.");
                        break;
                    case "NUnit.Framework.RequiresSTAAttribute":
                    case "NUnit.Framework.RequiresMTAAttribute":
                        Error(location, attributeName + " is not supported in NUnit 3. Use ApartmentAttribute.");
                        break;
                    case "NUnit.Core.Extensibility.NUnitAddinAttribute":
                    case "NUnit.Framework.RequiredAddinAttribute":
                    case "NUnit.Framework.SuiteAttribute":
                        Error(location, attributeName + " is not supported in NUnit 3.");
                        break;
                    case "NUnit.Framework.TestCaseAttribute":
                        string expectedExceptionName = (string)Reflect.GetPropertyValue(attribute, "ExpectedExceptionName");
                        if (!string.IsNullOrEmpty(expectedExceptionName))
                            Error(location, "TestCaseAttribute does not support ExpectedException in NUnit 3. Use Assert.Throws or ThrowsConstraint.");
                        bool legacyResultUsed = (bool)Reflect.GetPropertyValue(attribute, "LegacyResultUsed", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (legacyResultUsed)
                            Error(location, "TestCaseAttribute no longer supports Result property in NUnit 3. Use ExpectedResult.");
                        bool ignoreUsed = (bool)Reflect.GetPropertyValue(attribute, "Ignore");
                        if (ignoreUsed)
                            Error(location, "TestCaseAttribute Ignore property has a string value in NUnit 3.");
                        break;
                    case "NUnit.Framework.TestCaseSourceAttribute":
                        string sourceName = (string)Reflect.GetPropertyValue(attribute, "SourceName");
                        if (!string.IsNullOrEmpty(sourceName))
                        {
                            Type sourceType = (Type)Reflect.GetPropertyValue(attribute, "SourceType");
                            if (sourceType == null)
                            {
                                var methodInfo = provider as MethodInfo;
                                if (methodInfo != null)
                                    sourceType = methodInfo.ReflectedType;
                            }
                            if (sourceType != null)
                            {
                                var members = sourceType.GetMember(sourceName, ALL_MEMBERS);
                                if (members.Length > 0 && !IsStaticMember(members[0]))
                                    Error(sourceType + "." + members[0].Name, "TestCaseSourceAttribute must reference a static member.");
                            }
                        }
                        break;
                    case "NUnit.Framework.TestFixtureAttribute":
                        bool ignore = (bool)Reflect.GetPropertyValue(attribute, "Ignore");
                        if (ignore)
                            Error(location, "TestFixtureAttribute Ignore property has a string value in NUnit 3.");
                        break;
                    case "NUnit.Framework.TestFixtureSetUpAttribute":
                        Error(location, "TestFixtureSetUpAttribute is not supported in NUnit 3. Use OneTimeSetUpAttribute.");
                        break;
                    case "NUnit.Framework.TestFixtureTearDownAttribute":
                        Error(location, "TestFixtureTearDownAttribute is not supported in NUnit 3. Use OneTimeTearDownAttribute.");
                        break;
                    case "NUnit.Framework.ValueSourceAttribute":
                        sourceName = (string)Reflect.GetPropertyValue(attribute, "SourceName");
                        if (!string.IsNullOrEmpty(sourceName))
                        {
                            Type sourceType = (Type)Reflect.GetPropertyValue(attribute, "SourceType");
                            if (sourceType == null)
                            {
                                var parameterInfo = provider as ParameterInfo;
                                if (parameterInfo != null)
                                    sourceType = parameterInfo.Member.ReflectedType;
                            }
                            if (sourceType != null)
                            {
                                var members = sourceType.GetMember(sourceName, ALL_MEMBERS);
                                if (members.Length > 0 && !IsStaticMember(members[0]))
                                    Error(sourceType + "." + members[0].Name, "ValueSourceAttribute mst reference a static member.");
                            }
                        }
                        break;

                    case "System.STAThreadAttribute":
                    case "System.MTAThreadAttribute":
                        Warning(location, attributeFullName + " has no effect in NUnit 3. Use ApartmentAttribute.");
                        break;
                }
            }
        }

        #endregion

        #region Helper Methods

        private static bool IsStaticMember(MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)member).IsStatic;
                case MemberTypes.Property:
                    return ((PropertyInfo)member).GetGetMethod().IsStatic;
                case MemberTypes.Method:
                    return ((MethodInfo)member).IsStatic;
                default:
                    return false;
            }
        }

        private static void Report(string level, string location, string message)
        {
            if (_writer != null)
                _writer.WriteLine(string.Format(REPORT_FORMAT, level, location, message));
        }

        private static string LocationOf(MemberInfo member)
        {
            return member.ReflectedType + "." + member.Name;
        }

        #endregion

        #region Nested Issue Class

        public class Issue
        {
            public string Level { get; private set; }
            public string Location { get; private set; }
            public string Message { get; private set; }

            public Issue(string level, string category, string message)
            {
                Level = level;
                Location = category;
                Message = message;
            }

            public static Issue FromRecord(string record)
            {
                int delim1 = record.IndexOf(':');
                int delim2 = record.IndexOf(':', delim1 + 1);

                return new Issue(record.Substring(0, delim1), record.Substring(delim1 + 1, delim2 - delim1 - 1), record.Substring(delim2 + 1));
            }
        }

        #endregion
    }
}
