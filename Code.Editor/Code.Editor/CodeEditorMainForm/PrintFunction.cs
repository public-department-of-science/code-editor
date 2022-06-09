using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox != null)
            {
                var settings = new PrintDialogSettings();
                settings.Title = openFilesTabs.SelectedItem.Title;
                settings.Header = "&b&w&b";
                settings.Footer = "&b&p";
                CurrentTextBox.Print(settings);
            }
        }
    }
}