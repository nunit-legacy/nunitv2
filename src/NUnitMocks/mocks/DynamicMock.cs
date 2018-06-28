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
    /// Summary description for DynamicMock.
    /// </summary>
    [Obsolete("NUnit now uses NSubstitute")]
    public class DynamicMock : Mock
    {
        private Type type;

        private object mockInstance;

        public object MockInstance
        {
            get 
            { 
                if ( mockInstance == null )
                {
                    MockInterfaceHandler handler = new MockInterfaceHandler( type, this );
                    mockInstance = handler.GetTransparentProxy();
                }

                return mockInstance; 
            }
        }

        #region Constructors

        public DynamicMock( Type type ) : this( "Mock" + type.Name, type ) { }

        public DynamicMock( string name, Type type ) : base( name )
        {
//			if ( !type.IsInterface )
//				throw new VerifyException( "DynamicMock constructor requires an interface type" );
            this.type = type;
        }

        #endregion
    }
}
