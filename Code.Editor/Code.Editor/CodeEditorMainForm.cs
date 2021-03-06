using Analyzer.Run.Base;
using Analyzer.Tokenization.Base.Information;
using Code.Editor.Merge;
using Code.Editor.Terminal;
using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using Grammar.Core.Functions.BuiltIn;
using System.ComponentModel;

namespace Code.Editor
{
    public partial class CodeEditorMainForm : Form
    {
        private List<string> keywords = new List<string>();
        private List<string> builtInFunctions = new List<string>();

        private string[] snippets = {
            "if(^)\n{\n\n}", "if(^)\n{\n\n}\nElse\n{\n\n}",
            "arrayName = array ( ^ )",

            "for (i = 0; i < ^; i = i + 1)\n{\n\n}",
            "while(^)\n{\n\n}",
            "do\n{\n^\n} while()",
            "def public ^()\n{\n}",
            "def private ^()\n{\n}",

            "usefile \"^.txt\"",
            "usefile \"^\"// namespace-name",

            "namespace \"^\"\n\nendnamespace",
            "Echo (^)",
            "@region ^ \n @endregion",
            "accessFile = file (\"^\")",

            "namespace \"^\"\n\n\t object public *\n \t\t field public * = &" +
                "\n\n\t\tmethod public *()\n{\n\t\t\treturn &\n}\nendobject\nendnamespace",

             "namespace \"^\"\n\n\tobject public *\n \t field public * = &" +
                "\n\n\tmethod public *()\n { \n\t\t return & \n}\n\n" +
                "\t\t\tmethod public *()\n{\n\t\t variable = & \n" +
                "Print * \n}\nendobject\nendnamespace",

             "\nobject public ^\n \t field public * = &" +
                "\n\n\tmethod public *() \n {\n\t\t return * \n}\n\n" +
                "\t\t\tmethod public *() \n {\n\t\t variable = & \n" +
                "Print * \n } \n endobject \n",

             "\n/// <summary>\n/// ^\n /// </summary>\n",
    };

        /// <summary>
        /// 
        /// </summary>
        private string[] declarationSnippets = {
                "object public ^\n\nendobject", "object private ^\n\nendobject",
                "field public ^ = \n", "field private ^ = \n",
                "method public ^()\n{\n\n}", "method private ^()\n{\n\n}",
                "def ^() \n {\n}","def ^(a, b) \n {\n\t return a + b\n}",
                "namespace \"^\"\nendnamespace",
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

        private LoggingTerminal loggingTerminal;
        public LoggingTerminal LoggingTerminal
        {
            get
            {
                if (loggingTerminal != null)
                {
                    return loggingTerminal;
                }
                return new LoggingTerminal();
            }
            set
            {
                loggingTerminal = value;
            }
        }

        public CodeEditorMainForm(LoggingTerminal loggingTerminal)
        {
            InitializeComponent();
            foreach (var keyword in KeywordsTokensInfo.Keywords)
            {
                keywords.Add(keyword.Key);
            }

            foreach (var function in GlobalFunctionsRegister.BuiltInFunctionsList)
            {
                builtInFunctions.Add(function);
            }

            LoggingTerminal = loggingTerminal;

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
            LoggingTerminal.Show();
            // new LoggingTerminal().Show();
        }

        private void ExecuteCode_Click(object sender, EventArgs e)
        {
            var assemblyPath = @"G:\DeskTop\grammar-analyzer\GrammarAnalyzer\04.Samples.CodePlace\Code";
            Action<string> printStream = LoggingTerminal.loggingTerminalArea.AppendText;
            Action<string> loggingStream = Console.Write;
            Action<string> exceptionsStream = Console.Write;

            IExecutionDirectory executionContext = new Analyzer.Run.Base.ExecutionContext(assemblyPath, printStream, loggingStream, exceptionsStream);
            executionContext.ValidateFiles()
                .Tokenize()
                .Parse()
                .ExecuteSynchronously();
        }
    }
}