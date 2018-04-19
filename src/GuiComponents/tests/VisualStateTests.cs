// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using NUnit.Framework;

namespace NUnit.UiKit.Tests
{
	/// <summary>
	/// Summary description for VisualStateTests.
	/// </summary>
	[TestFixture]
	public class VisualStateTests
	{
		[Test]
		public void SaveAndRestoreVisualState()
		{
			VisualState state = new VisualState();
			state.ShowCheckBoxes = true;
			state.TopNode = "ABC.Test.dll";
			state.SelectedNode = "NUnit.Tests.MyFixture.MyTest";
			state.SelectedCategories = "A,B,C";
			state.ExcludeCategories = true;

			StringWriter writer = new StringWriter();
			state.Save( writer );

			string output = writer.GetStringBuilder().ToString();

			StringReader reader = new StringReader( output );
			VisualState newState = VisualState.LoadFrom( reader );

			Assert.AreEqual( state.ShowCheckBoxes, newState.ShowCheckBoxes, "ShowCheckBoxes" );
			Assert.AreEqual( state.TopNode, newState.TopNode, "TopNode" );
			Assert.AreEqual( state.SelectedNode, newState.SelectedNode, "SelectedNode" );
			Assert.AreEqual( state.SelectedCategories, newState.SelectedCategories, "SelectedCategories" );
			Assert.AreEqual( state.ExcludeCategories, newState.ExcludeCategories, "ExcludeCategories" );
		}
	}
}
