namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void tmUpdateInterface_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentTextBox != null && openFilesTabs.Items.Count > 0)
                {
                    var textBox = CurrentTextBox;
                    buttonUndoStrip.Enabled = undoToolStripMenuItem.Enabled = textBox.UndoEnabled;
                    buttonRedoStrip.Enabled = redoToolStripMenuItem.Enabled = textBox.RedoEnabled;
                    saveToolStripButton.Enabled = saveToolStripMenuItem.Enabled = textBox.IsChanged;
                    saveAsToolStripMenuItem.Enabled = true;
                    pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled = true;
                    cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled =
                    copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled = !textBox.Selection.IsEmpty;
                    printToolStripButton.Enabled = true;
                    commentCodeStripButton.Enabled = true;
                    uncommentCodeStripButton.Enabled = true;
                    buttonBookmarkMinus.Enabled = true;
                    buttonBookmarkPlus.Enabled = true;
                    buttonRedoStrip.Enabled = true;
                    buttonUndoStrip.Enabled = true;
                    buttonGotoBookmark.Enabled = true;
                    buttonForwardStrip.Enabled = true;
                    buttonBackwardStrip.Enabled = true;
                    buttonInvisibleSymbols.Enabled = true;
                    buttonShowFoldingLines.Enabled = true;
                    buttonHighlightCurrentLine.Enabled = true;

                    runToolStripMenuItem.Enabled = true;
                    languageToolStripMenuItem.Enabled = true;
                }
                else
                {
                    saveToolStripButton.Enabled = saveToolStripMenuItem.Enabled = false;
                    saveAsToolStripMenuItem.Enabled = false;
                    cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled =
                    copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled = false;
                    pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled = false;
                    printToolStripButton.Enabled = false;
                    buttonUndoStrip.Enabled = undoToolStripMenuItem.Enabled = false;
                    buttonRedoStrip.Enabled = redoToolStripMenuItem.Enabled = false;
                    datagridviewerObjectExplorer.RowCount = 0;
                    commentCodeStripButton.Enabled = false;
                    uncommentCodeStripButton.Enabled = false;
                    buttonBookmarkMinus.Enabled = false;
                    buttonBookmarkPlus.Enabled = false;
                    buttonRedoStrip.Enabled = false;
                    buttonUndoStrip.Enabled = false;
                    buttonGotoBookmark.Enabled = false;
                    buttonForwardStrip.Enabled = false;
                    buttonBackwardStrip.Enabled = false;
                    buttonInvisibleSymbols.Enabled = false;
                    buttonShowFoldingLines.Enabled = false;
                    buttonHighlightCurrentLine.Enabled = false;

                    runToolStripMenuItem.Enabled = false;
                    languageToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}