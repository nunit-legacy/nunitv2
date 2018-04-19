// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;
using System.Reflection;
using NUnit.Core.Extensibility;

namespace NUnit.Core.Builders
{
    public abstract class CombiningStrategy
    {
        protected IDataPointProvider dataPointProvider =
            (IDataPointProvider)CoreExtensions.Host.GetExtensionPoint("DataPointProviders");

        private IEnumerable[] sources;
        private IEnumerator[] enumerators;

        public CombiningStrategy(IEnumerable[] sources)
        {
            this.sources = sources;
        }

        public IEnumerable[] Sources
        {
            get { return sources; }
        }

        public IEnumerator[] Enumerators
        {
            get
            {
                if (enumerators == null)
                {
                    enumerators = new IEnumerator[Sources.Length];
                    for (int i = 0; i < Sources.Length; i++)
                        enumerators[i] = Sources[i].GetEnumerator();
                }

                return enumerators;
            }
        }

        public abstract IEnumerable GetTestCases();
    }
}
