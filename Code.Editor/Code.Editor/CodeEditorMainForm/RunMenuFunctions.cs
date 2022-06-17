using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void customLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.Custom;
            customLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.Custom;
        }

        private void cSharpLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.CSharp;
            cSharpLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.CSharp;
        }

        private void hTMLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.HTML;
            hTMLLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.HTML;
        }

        private void xMLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.XML;
            xMLLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.XML;
        }

        private void sQLLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.SQL;
            sQLLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.SQL;
        }

        private void pHPLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.PHP;
            pHPLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.PHP;
        }

        private void jSLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.JS;
            jSLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.JS;
        }

        private void lUALangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.Lua;
            lUALangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.Lua;
        }

        private void jSONLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.JSON;
            jSONLangToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.JSON;
        }

        private void vBLangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLanguageCheckMark();

            CurrentTextBox.Language = Language.VB;
            vBToolStripMenuItem.Checked = true;
            CurrentTextBox.Language = Language.VB;
        }

        private void ClearLanguageCheckMark()
        {
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }

        private void UpdateSelectedLanguageButtonByCurrentTab()
        {
            switch (CurrentTextBox.Language)
            {
                case Language.Custom:
                    ClearLanguageCheckMark();
                    customLangToolStripMenuItem.Checked = true;
                    break;
                case Language.CSharp:
                    ClearLanguageCheckMark();
                    cSharpLangToolStripMenuItem.Checked = true;
                    break;
                case Language.VB:
                    ClearLanguageCheckMark();
                    vBToolStripMenuItem.Checked = true;
                    break;
                case Language.HTML:
                    ClearLanguageCheckMark();
                    hTMLLangToolStripMenuItem.Checked = true;
                    break;
                case Language.XML:
                    ClearLanguageCheckMark();
                    xMLLangToolStripMenuItem.Checked = true;
                    break;
                case Language.SQL:
                    ClearLanguageCheckMark();
                    sQLLangToolStripMenuItem.Checked = true;
                    break;
                case Language.PHP:
                    ClearLanguageCheckMark();
                    pHPLangToolStripMenuItem.Checked = true;
                    break;
                case Language.JS:
                    ClearLanguageCheckMark();
                    jSLangToolStripMenuItem.Checked = true;
                    break;
                case Language.Lua:
                    ClearLanguageCheckMark();
                    lUALangToolStripMenuItem.Checked = true;
                    break;
                case Language.JSON:
                    ClearLanguageCheckMark();
                    jSONLangToolStripMenuItem.Checked = true;
                    break;
                default:
                    break;
            }
        }
    }
}