namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Selection.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.UndoEnabled)
            {
                CurrentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.RedoEnabled)
            {
                CurrentTextBox.Redo();
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.ShowReplaceDialog();
        }

        private void autoIndentSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.DoAutoIndent();
        }

        private void commentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.InsertLinePrefix("//");
        }

        private void uncommentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.RemoveLinePrefix("//");
        }

        private void cloneLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //expand selection
            CurrentTextBox.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTextBox.Selection.Text;
            //move caret to end of selected lines
            CurrentTextBox.Selection.Start = CurrentTextBox.Selection.End;
            //insert text
            CurrentTextBox.InsertText(text);
        }

        private void cloneLinesAndCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start autoUndo block
            CurrentTextBox.BeginAutoUndo();
            //expand selection
            CurrentTextBox.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTextBox.Selection.Text;
            //comment lines
            CurrentTextBox.InsertLinePrefix("//");
            //move caret to end of selected lines
            CurrentTextBox.Selection.Start = CurrentTextBox.Selection.End;
            //insert text
            CurrentTextBox.InsertText(text);
            //end of autoUndo block
            CurrentTextBox.EndAutoUndo();
        }
    }
}
