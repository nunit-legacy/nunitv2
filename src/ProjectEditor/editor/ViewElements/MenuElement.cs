// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************

using System;
using System.Windows.Forms;

namespace NUnit.ProjectEditor.ViewElements
{
    /// <summary>
    /// MenuItemWrapper is the implementation of MenuItem 
    /// used in the actual application.
    /// </summary>
    public class MenuElement : ICommand
    {
        private ToolStripMenuItem menuItem;

        public MenuElement(ToolStripMenuItem menuItem)
        {
            this.menuItem = menuItem;

            menuItem.Click += delegate 
                { if (Execute != null) Execute(); };
        }

        public event CommandDelegate Execute;

        public string Name
        {
            get { return menuItem.Name; }
        }

        public bool Enabled
        {
            get { return menuItem.Enabled; }
            set { menuItem.Enabled = value; }
        }

        public string Text
        {
            get { return menuItem.Text; }
            set { menuItem.Text = value; }
        }
    }
}
