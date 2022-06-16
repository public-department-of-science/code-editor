namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.Custom;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
        }
    }
}
