using FarsiLibrary.Win;
using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void objectexplorerColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.FloralWhite;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                var selectedColor = colorDlg.Color;
                codeEditorSettings.objectExplorerBackGround = selectedColor;
                datagridviewerObjectExplorer.BackgroundColor = selectedColor;
                codeEditorSettings.Save();
            }
        }

        private void codeareaColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.FloralWhite;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                var selectedColor = colorDlg.Color;
                codeEditorSettings.codeAreaBackGround = selectedColor;
                if (CurrentTextBox != null)
                {
                    CurrentTextBox.BackColor = selectedColor;
                }
                codeEditorSettings.Save();
            }
        }

        private void documentMapColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.FloralWhite;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                var selectedColor = colorDlg.Color;
                codeEditorSettings.documentMapBackGround = selectedColor;
                documentMap.BackColor = selectedColor;

                codeEditorSettings.Save();
            }
        }

        private void opentabColorPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
            colorDlg.Color = Color.FloralWhite;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                var selectedColor = colorDlg.Color;
                codeEditorSettings.openFilesTabsBackColor = selectedColor;
                openFilesTabs.BackColor = selectedColor;

                codeEditorSettings.Save();
            }
        }

        private void restoreDefaultColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codeEditorSettings != null)
            {
                codeEditorSettings.codeAreaBackGround = codeEditorSettings.codeAreaBackGroundDefault;
                codeEditorSettings.documentMapBackGround = codeEditorSettings.documentMapBackGroundDefault;
                codeEditorSettings.openFilesTabsBackColor = codeEditorSettings.openFilesTabsBackColorDefault;
                codeEditorSettings.objectExplorerBackGround = codeEditorSettings.objectExplorerBackGroundDefault;

                codeEditorSettings.Save();

                if (CurrentTextBox != null)
                {
                    CurrentTextBox.BackColor = codeEditorSettings.codeAreaBackGroundDefault;
                }
                openFilesTabs.BackColor = codeEditorSettings.codeAreaBackGroundDefault;
                documentMap.BackColor = codeEditorSettings.documentMapBackGroundDefault;
                datagridviewerObjectExplorer.BackgroundColor = codeEditorSettings.objectExplorerBackGroundDefault;
            }
        }

        private void customizeCodeAreaHotKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(codeEditorSettings.HotKeys) == false)
            {
                var userKeysMapping = HotkeysMapping.Parse(codeEditorSettings.HotKeys);
                HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(userKeysMapping);
                if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
                {
                    codeEditorSettings.HotKeys = hotkeysEditorForm.GetHotkeys().ToString();
                    codeEditorSettings.Save();
                    UpdateOpenTabs(false);
                }
            }
            else
            {
                HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(new HotkeysMapping());
                if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
                {
                    codeEditorSettings.HotKeys = hotkeysEditorForm.GetHotkeys().ToString();
                    codeEditorSettings.Save();
                    UpdateOpenTabs(false);
                }
            }
        }

        private void restoreDefaultCodeAreaHotKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (codeEditorSettings != null)
            {
                codeEditorSettings.HotKeys = codeEditorSettings.HotKeysDefault;
            }
            UpdateOpenTabs(true);
        }

        private void UpdateOpenTabs(bool isDefault)
        {
            if (openFilesTabs.Items.Count > 0)
            {
                foreach (FATabStripItem item in openFilesTabs.Items)
                {
                    var tab = item.Controls[0] as FastColoredTextBox;
                    if (tab != null)
                    {
                        if (isDefault == true)
                        {
                            tab.HotkeysMapping = HotkeysMapping.Parse(codeEditorSettings.HotKeys);
                        }
                        else
                        {
                            tab.HotkeysMapping = HotkeysMapping.Parse(codeEditorSettings.HotKeysDefault);
                        }
                    }
                }
            }
        }
    }
}
