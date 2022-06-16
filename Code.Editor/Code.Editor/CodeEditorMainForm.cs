using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.ComponentModel;

namespace Code.Editor
{
    public partial class CodeEditorMainForm : Form
    {
        private string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char",
            "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else",
            "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach",
            "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
            "new", "null", "object", "operator", "out", "override", "params", "private", "protected",
            "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc",
            "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint",
            "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while",
            "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into",
            "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where",
            "yield" };

        private string[] methods = { "Equals()", "GetHashCode()", "GetType()", "ToString()" };

        private string[] snippets = { "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}",
            "for(^;;)\n{\n;\n}",
            "while(^)\n{\n;\n}",
            "do\n{\n^;\n}while();",
            "switch(^)\n{\ncase : break;\n}" };

        private string[] declarationSnippets = {
                "public class ^\n{\n}",
                "private class ^\n{\n}",
                "internal class ^\n{\n}",
                "public struct ^\n{\n;\n}",
                "private struct ^\n{\n;\n}",
                "internal struct ^\n{\n;\n}",
                "public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}",
                "internal void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
                "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }",
                "protected ^{ get; set; }"
               };

        private Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.Gray);
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

            //init menu images
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CodeEditorMainForm));
            copyToolStripMenuItem.Image = ((Image)(resources.GetObject("copyToolStripButton.Image")));
            cutToolStripMenuItem.Image = ((Image)(resources.GetObject("cutToolStripButton.Image")));
            pasteToolStripMenuItem.Image = ((Image)(resources.GetObject("pasteToolStripButton.Image")));
        }

        private Style sameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Red)));

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
               // CurrentTextBox.Language;
                string text = CurrentTextBox.Text;
                ThreadPool.QueueUserWorkItem(obj => ReBuildObjectExplorer(text));
            }
        }

        private bool Save(FATabStripItem selectedTab)
        {
            var tb = (selectedTab.Controls[0] as FastColoredTextBox);
            if (string.IsNullOrWhiteSpace(selectedTab.Tag.ToString()))
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
    }
}