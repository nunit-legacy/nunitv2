// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Collections;

namespace NUnit.Framework.Tests
{
	/// <summary>
	/// ICollectionAdapter is used in testing to wrap an array or
	/// ArrayList, ensuring that only methods of the ICollection
	/// interface are accessible.
	/// </summary>
	class ICollectionAdapter : ICollection
	{
		private readonly ICollection inner;

		public ICollectionAdapter(ICollection inner)
		{
			this.inner = inner;
		}

		public ICollectionAdapter(params object[] inner)
		{
			this.inner = inner;
		}

		#region ICollection Members

		public void CopyTo(Array array, int index)
		{
			inner.CopyTo(array, index);
		}

		public int Count
		{
			get { return inner.Count; }
		}

		public bool IsSynchronized
		{
			get { return  inner.IsSynchronized; }
		}

		public object SyncRoot
		{
			get { return inner.SyncRoot; }
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return inner.GetEnumerator();
		}

		#endregion
	}
}
