// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
    /// <summary>
    /// Helper class with static methods used to supply constraints
    /// that operate on strings.
    /// </summary>
    [Obsolete("Use Is class for string constraints")]
    public class Text
    {
        #region All
        
        /// <summary>
        /// Returns a ConstraintExpression, which will apply
        /// the following constraint to all members of a collection,
        /// succeeding if all of them succeed.
        /// </summary>
        [Obsolete("Use Is.All or Has.All")]
        public static ConstraintExpression All
        {
            get
            {
                Incompatible("All", "Is.All or Has.All");
                return new ConstraintExpression().All;
            }
        }
        
        #endregion
        
        #region Contains
        
        /// <summary>
        /// Returns a constraint that succeeds if the actual
        /// value contains the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Contain")]
        public static SubstringConstraint Contains(string expected)
        {
            Incompatible("Contains", "Does.Contain");
            return new SubstringConstraint(expected);
        }
        
        #endregion
        
        #region DoesNotContain
        
        /// <summary>
        /// Returns a constraint that fails if the actual
        /// value contains the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Not.Contain")]
        public static SubstringConstraint DoesNotContain(string expected)
        {
            Incompatible("DoesNotContain", "Does.Not.Contain");
            return new ConstraintExpression().Not.ContainsSubstring(expected);
        }
        
        #endregion
        
        #region StartsWith
        
        /// <summary>
        /// Returns a constraint that succeeds if the actual
        /// value starts with the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.StartWith")]
        public static StartsWithConstraint StartsWith(string expected)
        {
            Incompatible("StartsWith", "Does.StartWith");
            return new StartsWithConstraint(expected);
        }
        
        #endregion
        
        #region DoesNotStartWith
        
        /// <summary>
        /// Returns a constraint that fails if the actual
        /// value starts with the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Not.StartWith")]
        public static StartsWithConstraint DoesNotStartWith(string expected)
        {
            Incompatible("DoesNotStartWith", "Does.Not.StartWith");
            return new ConstraintExpression().Not.StartsWith(expected);
        }

        #endregion

        #region EndsWith

        /// <summary>
        /// Returns a constraint that succeeds if the actual
        /// value ends with the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.EndWith")]
        public static EndsWithConstraint EndsWith(string expected)
        {
            Incompatible("EndsWith", "Does.EndWith");
            return new EndsWithConstraint(expected);
        }

        #endregion

        #region DoesNotEndWith

        /// <summary>
        /// Returns a constraint that fails if the actual
        /// value ends with the substring supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Not.EndWith")]
        public static EndsWithConstraint DoesNotEndWith(string expected)
        {
            Incompatible("DoesNotEndWith", "Does.Not.EndWith");
            return new ConstraintExpression().Not.EndsWith(expected);
        }
        
        #endregion
        
        #region Matches
        
        /// <summary>
        /// Returns a constraint that succeeds if the actual
        /// value matches the Regex pattern supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Match")]
        public static RegexConstraint Matches(string pattern)
        {
            Incompatible("Matches", "Does.Match");
            return new RegexConstraint(pattern);
        }
        
        #endregion
        
        #region DoesNotMatch
        
        /// <summary>
        /// Returns a constraint that fails if the actual
        /// value matches the pattern supplied as an argument.
        /// </summary>
        [Obsolete("Use Does.Not.Match")]
        public static RegexConstraint DoesNotMatch(string pattern)
        {
            Incompatible("DoesNotMatch", "Does.Not.Match");
            return new ConstraintExpression().Not.Matches(pattern);
        }

        #endregion

        #region Compatibility Error Message Helper

        private static void Incompatible(string name, string replace)
        {
            TestContext.Compatibility.Error("Text." + name + " is not supported in NUnit 3. Use " + replace);
        }

        #endregion
    }
}
