// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.IO;
using System.Windows.Forms;
using NUnit.Core;
using NUnit.Util;

namespace NUnit.UiKit
{
	/// <summary>
	/// Summary description for TextDisplayTabPage.
	/// </summary>
	public class TextDisplayTabPage : TabPage
	{
		private TextBoxDisplay display;

		public TextDisplayTabPage()
		{
			this.display = new TextBoxDisplay();
			this.display.Dock = DockStyle.Fill;		
			this.Controls.Add( display );
		}

		public System.Drawing.Font DisplayFont
		{
			get { return display.Font; }
			set { display.Font = value; }
		}

		public TextDisplayTabPage( TextDisplayTabSettings.TabInfo tabInfo ) : this()
		{
			this.Name = tabInfo.Name;
			this.Text = tabInfo.Title;
			this.Display.Content = tabInfo.Content;
		}

		public TextDisplay Display
		{
			get { return this.display; }
		}
	}
}
