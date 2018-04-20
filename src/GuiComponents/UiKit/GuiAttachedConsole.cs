// ****************************************************************
// Copyright 2002-2018, Charlie Poole
// This is free software licensed under the NUnit license, a copy
// of which should be included with this software. If not, you may
// obtain a copy at https://github.com/nunit-legacy/nunitv2.
// ****************************************************************
using System;
using System.Runtime.InteropServices;

namespace NUnit.UiKit
{
	/// <summary>
	/// Summary description for GuiAttachedConsole.
	/// </summary>
	public class GuiAttachedConsole
	{
		public GuiAttachedConsole()
		{
			AllocConsole();
		}

		public void Close()
		{
			FreeConsole();
		}

		[DllImport("Kernel32.dll")]
		static extern bool AllocConsole();

		[DllImport("Kernel32.dll")]
		static extern bool FreeConsole();
	}
}
