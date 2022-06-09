using FarsiLibrary.Win;
using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void cutButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Cut();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Paste();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.UndoEnabled)
            {
                CurrentTextBox.Undo();
            }
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.RedoEnabled)
            {
                CurrentTextBox.Redo();
            }
        }

        private void btInvisibleChars_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                HighlightInvisibleChars((tab.Controls[0] as FastColoredTextBox).Range);
            }
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Invalidate();
            }
        }

        private void btHighlightCurrentLine_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                if (buttonHighlightCurrentLine.Checked)
                {
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = currentLineColor;
                }
                else
                {
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = Color.Transparent;
                }
            }
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Invalidate();
            }
        }

        private void commentButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.InsertLinePrefix("//");
        }

        private void uncommentButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.RemoveLinePrefix("//");
        }
    }
}