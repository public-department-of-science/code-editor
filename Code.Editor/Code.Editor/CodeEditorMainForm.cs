using Analyzer.Tokenization.Base.Information;
using Code.Editor.Merge;
using Code.Editor.Terminal;
using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.ComponentModel;

namespace Code.Editor
{
    public partial class CodeEditorMainForm : Form
    {
        private List<string> keywords = new List<string>();
        private string[] methods = { "Equals()", "GetHashCode()", "GetType()", "ToString()" };
        private string[] snippets = {
            "If(^)\n{\n\n}", "If(^)\n{\n\n}\nElse\n{\n\n}",

            "For i = 0; i < ^; i = i + 1\n{\n\n}",
            "While(^)\n{\n\n}",
            "Do\n{\n^\n} While()",
            "def public ^()\n{\n\n}",
            "def private ^()\n{\n\n}",

            "usefile \"^.txt\"",
            "usefile \"^\"// namespace-name",

            "namespace \"^\" \n{ \n}",
            "Echo (^)",
            "@region ^ \n @endregion",
            "accessFile = file (\"^\")",

            "namespace \"^\"\n { \n\t public object Name\n \t\t field public N = 5" +
                "\n\n\t\tmethod public GetN()\n{\n\t\t\tReturn N\n}\nEND\n}\n}",

             "namespace \"^\"\n { \n\tpublic object Name\n \t field public N = 5" +
                "\n\n\tmethod public GetN()\n { \n\t\t Return N \n}\n\n" +
                "\t\t\tmethod public Method()\n{\n\t\t a = 1 \n" +
                "Print \"a = \" + a \n}\nEND\n}",

             "\npublic object Name\n \t field public N = 5" +
                "\n\n\tmethod public GetN() \n {\n\t\t Return N \n}\n\n" +
                "\t\t\tmethod public Method() \n {\n\t\t a = 1 \n" +
                "Print \"a = \" + a \n } \n END \n",

             "\n/// <summary>\n/// ^\n /// </summary>\n",
    };

        /// <summary>
        /// 
        /// </summary>
        private string[] declarationSnippets = {
                //"public class ^\n{\n}",
                //"private class ^\n{\n}",
                //"internal class ^\n{\n}",
                //"public struct ^\n{\n;\n}",
                //"private struct ^\n{\n;\n}",
                //"internal struct ^\n{\n;\n}",
                //"public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}",
                //"internal void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
                //"public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }",
                //"protected ^{ get; set; }"
               };

        private Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.Gray);
        private Style sameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Red)));
        private Color currentLineColor = Color.FromArgb(100, 210, 210, 255);
        private Color changedLineColor = Color.FromArgb(255, 230, 230, 255);

        private DateTime lastNavigatedDateTime = DateTime.Now;

        FastColoredTextBox CurrentTextBox
        {
            get
            {
                if (openFilesTabs.SelectedItem == null)
                {
                    return null;
                }
                return (openFilesTabs.SelectedItem.Controls[0] as FastColoredTextBox);
            }
            set
            {
                openFilesTabs.SelectedItem = (value.Parent as FATabStripItem);
                value.Focus();
            }
        }

        public CodeEditorMainForm()
        {
            InitializeComponent();
            foreach (var keyword in KeywordsTokensInfo.Keywords)
            {
                keywords.Add(keyword.Key);
            }

            ComponentResourceManager resources = new ComponentResourceManager(typeof(CodeEditorMainForm));
            copyToolStripMenuItem.Image = ((Image)(resources.GetObject("copyToolStripButton.Image")));
            cutToolStripMenuItem.Image = ((Image)(resources.GetObject("cutToolStripButton.Image")));
            pasteToolStripMenuItem.Image = ((Image)(resources.GetObject("pasteToolStripButton.Image")));
        }

        private void tsFiles_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if ((e.Item.Controls[0] as FastColoredTextBox).IsChanged)
            {
                switch (MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        {
                            if (!Save(e.Item))
                            {
                                e.Cancel = true;
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            break;
                        }
                }
            }
        }

        private void tsFiles_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Focus();
                UpdateSelectedLanguageButtonByCurrentTab();
                string text = CurrentTextBox.Text;
                ThreadPool.QueueUserWorkItem(obj => ReBuildObjectExplorer(text));
            }
        }

        /// <summary>
        /// Save text information the file
        /// </summary>
        /// <param name="selectedTab"></param>
        /// <returns>True - if saved; False - if not saved</returns>
        private bool Save(FATabStripItem selectedTab)
        {
            var tb = (selectedTab.Controls[0] as FastColoredTextBox);
            if (string.IsNullOrWhiteSpace(selectedTab?.Tag?.ToString()))
            {
                if (saveFileDialogMain.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
                selectedTab.Title = Path.GetFileName(saveFileDialogMain.FileName);
                selectedTab.Tag = saveFileDialogMain.FileName;
            }

            try
            {
                File.WriteAllText(selectedTab.Tag.ToString(), tb.Text);
                tb.IsChanged = false;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return Save(selectedTab);
                }
                else
                {
                    return false;
                }
            }

            tb.Invalidate();
            return true;
        }

        private void CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<FATabStripItem> list = new List<FATabStripItem>();
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                list.Add(tab);
            }
            foreach (var tab in list)
            {
                TabStripItemClosingEventArgs args = new TabStripItemClosingEventArgs(tab);
                tsFiles_TabStripItemClosing(args);
                if (args.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                openFilesTabs.RemoveTab(tab);
            }
        }

        private void OpenFilesTabs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.N))
            {
                newTabButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void compareTwoFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DiffMergeForm().Show();
        }

        private void loggingTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LoggingTerminal().Show();
        }
    }
}