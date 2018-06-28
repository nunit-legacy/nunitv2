// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;

namespace NUnit.Mocks
{
    /// <summary>
    /// Summary description for MockSignature.
    /// </summary>
    [Obsolete("NUnit now uses NSubstitute")]
    public class MethodSignature
    {
        public readonly string typeName;
        public readonly string methodName;
        public readonly Type[] argTypes;

        public MethodSignature( string typeName, string methodName, Type[] argTypes )
        {
            this.typeName = typeName;
            this.methodName = methodName;
            this.argTypes = argTypes; 
        }

        public bool IsCompatibleWith( object[] args )
        {
            if ( args.Length != argTypes.Length )
                return false;

            for( int i = 0; i < args.Length; i++ )
                if ( !argTypes[i].IsAssignableFrom( args[i].GetType() ) )
                    return false;

            return true;
        }

        public static Type[] GetArgTypes( object[] args )
        {
            if ( args == null )
                return new Type[0];

            Type[] argTypes = new Type[args.Length];
            for (int i = 0; i < argTypes.Length; ++i)
            {
                if (args[i] == null)
                    argTypes[i] = typeof(object);
                else
                    argTypes[i] = args[i].GetType();
            }

            return argTypes;
        }
    }
}
