namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void customLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = FastColoredTextBoxNS.Language.Custom;
            customLangToolStripMenuItem.Checked = true;
        }

        private void cSharpLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            cSharpLangToolStripMenuItem.Checked = true;
        }

        private void hTMLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.HTML;
            hTMLLangToolStripMenuItem.Checked = true;
        }

        private void xMLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.XML;
            xMLLangToolStripMenuItem.Checked = true;
        }

        private void sQLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.SQL;
            sQLLangToolStripMenuItem.Checked = true;
        }

        private void pHPLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.PHP;
            pHPLangToolStripMenuItem.Checked = true;
        }

        private void jSLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();
            
            CurrentTextBox.Language = FastColoredTextBoxNS.Language.JS;
            jSLangToolStripMenuItem.Checked = true;
        }

        private void lUALangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = FastColoredTextBoxNS.Language.Lua;
            lUALangToolStripMenuItem.Checked = true;
        }

        private void jSONLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = FastColoredTextBoxNS.Language.JSON;
            jSONLangToolStripMenuItem.Checked = true;
        }

        private void vBLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = FastColoredTextBoxNS.Language.VB;
            vBToolStripMenuItem.Checked = true;
        }

        private void ClearLanguageCheckMark()
        {
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }
    }
}