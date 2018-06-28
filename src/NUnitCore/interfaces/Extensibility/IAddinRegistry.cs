// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;

namespace NUnit.Core.Extensibility
{
    /// <summary>
    /// The IAddinRegistry interface allows registering addins
    /// and retrieving information about them. It is also used
    ///  to record the load status of an addin.
    /// </summary>
    public interface IAddinRegistry
    {
        /// <summary>
        /// Gets a list of all addins as Addin objects
        /// </summary>
        System.Collections.IList Addins { get; }

        /// <summary>
        /// Registers an addin
        /// </summary>
        /// <param name="addin">The addin to be registered</param>
        void Register( Addin addin );

        /// <summary>
        /// Returns true if an addin of a given name is registered
        /// </summary>
        /// <param name="name">The name of the addin</param>
        /// <returns>True if an addin of that name is registered, otherwise false</returns>
        bool IsAddinRegistered(string name);

        /// <summary>
        ///  Sets the load status of an addin
        /// </summary>
        /// <param name="name">The name of the addin</param>
        /// <param name="status">The status to be set</param>
        /// <param name="message">An optional message explaining the status</param>
        void SetStatus( string name, AddinStatus status, string message );
    }
}
