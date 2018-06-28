// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Framework
{
    /// <summary>
    /// Summary description for SetCultureAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method|AttributeTargets.Assembly, AllowMultiple=false, Inherited=true)]
    public class SetCultureAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct given the name of a culture
        /// </summary>
        /// <param name="culture"></param>
        public SetCultureAttribute( string culture ) : base( "_SETCULTURE", culture ) { }
    }
}
