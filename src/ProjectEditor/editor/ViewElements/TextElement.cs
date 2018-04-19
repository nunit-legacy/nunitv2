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
    public class TextElement : ControlElement, ITextElement
    {
        private TextBoxBase textBox;

        public TextElement(Label label) : base(label) { }

        public TextElement(TextBoxBase textBox) : base(textBox)
        {
            this.textBox = textBox;

            textBox.TextChanged += delegate
            {
                if (Changed != null)
                    Changed();
            };

            textBox.Validated += delegate
            {
                if (Validated != null)
                    Validated();
            };
        }

        public void Select(int offset, int length)
        {
            if (textBox == null)
                throw new InvalidOperationException("Cannot select text in a label");

            textBox.Select(offset, length);
        }

        public event ActionDelegate Changed;

        public event ActionDelegate Validated;
    }
}
