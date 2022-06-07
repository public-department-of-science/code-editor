namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void bookmarkPlusButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox == null)
            {
                return;
            }
            CurrentTextBox.BookmarkLine(CurrentTextBox.Selection.Start.iLine);
        }

        private void bookmarkMinusButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox == null)
            {
                return;
            }
            CurrentTextBox.UnbookmarkLine(CurrentTextBox.Selection.Start.iLine);
        }
    }
}
