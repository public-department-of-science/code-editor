using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm : Form
    {
        string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char",
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

        string[] methods = { "Equals()", "GetHashCode()", "GetType()", "ToString()" };

        string[] snippets = { "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}",
            "for(^;;)\n{\n;\n}",
            "while(^)\n{\n;\n}",
            "do\n{\n^;\n}while();",
            "switch(^)\n{\ncase : break;\n}" };

        string[] declarationSnippets = {
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

        Style invisibleCharsStyle = new InvisibleCharsRenderer(Pens.Gray);
        Color currentLineColor = Color.FromArgb(100, 210, 210, 255);
        Color changedLineColor = Color.FromArgb(255, 230, 230, 255);

        public CodeEditorMainForm()
        {
            InitializeComponent();

            //init menu images
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CodeEditorMainForm));
            copyToolStripMenuItem.Image = ((Image)(resources.GetObject("copyToolStripButton.Image")));
            cutToolStripMenuItem.Image = ((Image)(resources.GetObject("cutToolStripButton.Image")));
            pasteToolStripMenuItem.Image = ((Image)(resources.GetObject("pasteToolStripButton.Image")));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTab(string.Empty);
        }

        private Style sameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Gray)));

        private void CreateTab(string fileName)
        {
            try
            {
                var newTextBox = new FastColoredTextBox();
                newTextBox.Font = new Font("Consolas", 9.75f);
                newTextBox.ContextMenuStrip = cmMain;
                newTextBox.Dock = DockStyle.Fill;
                newTextBox.BorderStyle = BorderStyle.Fixed3D;
                //tb.VirtualSpace = true;
                newTextBox.LeftPadding = 17;
                newTextBox.Language = Language.CSharp;
                newTextBox.AddStyle(sameWordsStyle);//same words style
                var newFileTab = new FATabStripItem(
                    String.IsNullOrWhiteSpace(fileName) == false
                    ? Path.GetFileName(fileName)
                    : "[new]", newTextBox);

                newFileTab.Tag = fileName;
                if (string.IsNullOrEmpty(fileName) == false)
                {
                    newTextBox.OpenFile(fileName);
                }

                newTextBox.Tag = new TbInfo();
                openFilesTabs.AddTab(newFileTab);
                openFilesTabs.SelectedItem = newFileTab;
                newTextBox.Focus();
                newTextBox.DelayedTextChangedInterval = 1000;
                newTextBox.DelayedEventsInterval = 500;
                newTextBox.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(tb_TextChangedDelayed);
                newTextBox.SelectionChangedDelayed += new EventHandler(tb_SelectionChangedDelayed);
                newTextBox.KeyDown += new KeyEventHandler(tb_KeyDown);
                newTextBox.MouseMove += new MouseEventHandler(tb_MouseMove);
                newTextBox.ChangedLineColor = changedLineColor;
                if (buttonHighlightCurrentLine.Checked)
                {
                    newTextBox.CurrentLineColor = currentLineColor;
                }
                newTextBox.ShowFoldingLines = buttonShowFoldingLines.Checked;
                newTextBox.HighlightingRangeType = HighlightingRangeType.VisibleRange;

                //create autocomplete popup menu
                AutocompleteMenu popupMenu = new AutocompleteMenu(newTextBox);
                popupMenu.Items.ImageList = imageListAutocomplete;
                popupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
                BuildAutocompleteMenu(popupMenu);

                (newTextBox.Tag as TbInfo).popupMenu = popupMenu;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    CreateTab(fileName);
                }
            }
        }

        private void popupMenu_Opening(object sender, CancelEventArgs e)
        {
            //---block autocomplete menu for comments
            //get index of green style (used for comments)
            var iGreenStyle = CurrentTextBox.GetStyleIndex(CurrentTextBox.SyntaxHighlighter.GreenStyle);
            if (iGreenStyle >= 0)
            {
                if (CurrentTextBox.Selection.Start.iChar > 0)
                {
                    //current char (before caret)
                    var c = CurrentTextBox[CurrentTextBox.Selection.Start.iLine][CurrentTextBox.Selection.Start.iChar - 1];
                    //green Style
                    var greenStyleIndex = FastColoredTextBoxNS.Range.ToStyleIndex(iGreenStyle);
                    //if char contains green style then block popup menu
                    if ((c.style & greenStyleIndex) != 0)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void BuildAutocompleteMenu(AutocompleteMenu popupMenu)
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();

            foreach (var item in snippets)
            {
                items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
            }
            foreach (var item in declarationSnippets)
            {
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
            }
            foreach (var item in methods)
            {
                items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
            }
            foreach (var item in keywords)
            {
                items.Add(new AutocompleteItem(item));
            }

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);
            popupMenu.SearchPattern = @"[\w\.:=!<>]";
        }

        private void tb_MouseMove(object sender, MouseEventArgs e)
        {
            var tb = sender as FastColoredTextBox;
            var place = tb.PointToPlace(e.Location);
            var r = new FastColoredTextBoxNS.Range(tb, place, place);

            string text = r.GetFragment("[a-zA-Z]").Text;
            labelWordUnderMouse.Text = text;
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.OemMinus)
            {
                NavigateBackward();
                e.Handled = true;
            }

            if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.OemMinus)
            {
                NavigateForward();
                e.Handled = true;
            }

            if (e.KeyData == (Keys.K | Keys.Control))
            {
                //forced show (MinFragmentLength will be ignored)
                (CurrentTextBox.Tag as TbInfo).popupMenu.Show(true);
                e.Handled = true;
            }
        }

        private void tb_SelectionChangedDelayed(object sender, EventArgs e)
        {
            var tb = sender as FastColoredTextBox;
            //remember last visit time
            if (tb.Selection.IsEmpty && tb.Selection.Start.iLine < tb.LinesCount)
            {
                if (lastNavigatedDateTime != tb[tb.Selection.Start.iLine].LastVisit)
                {
                    tb[tb.Selection.Start.iLine].LastVisit = DateTime.Now;
                    lastNavigatedDateTime = tb[tb.Selection.Start.iLine].LastVisit;
                }
            }

            //highlight same words
            tb.VisibleRange.ClearStyle(sameWordsStyle);
            if (!tb.Selection.IsEmpty)
            {
                return;//user selected diapason
            }
            //get fragment around caret
            var fragment = tb.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
            {
                return;
            }
            //highlight same words
            FastColoredTextBoxNS.Range[] ranges = tb.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();

            if (ranges.Length > 1)
            {
                foreach (var r in ranges)
                {
                    r.SetStyle(sameWordsStyle);
                }
            }
        }

        private void tb_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox tb = (sender as FastColoredTextBox);
            //rebuild object explorer
            string text = (sender as FastColoredTextBox).Text;
            ThreadPool.QueueUserWorkItem(obj => ReBuildObjectExplorer(text));

            //show invisible chars
            HighlightInvisibleChars(e.ChangedRange);
        }

        private void HighlightInvisibleChars(FastColoredTextBoxNS.Range range)
        {
            range.ClearStyle(invisibleCharsStyle);
            if (buttonInvisibleSymbols.Checked)
            {
                range.SetStyle(invisibleCharsStyle, @".$|.\r\n|\s");
            }
        }

        private List<ExplorerItem> explorerList = new List<ExplorerItem>();

        private void ReBuildObjectExplorer(string text)
        {
            try
            {
                List<ExplorerItem> list = new List<ExplorerItem>();
                int lastClassIndex = -1;
                //find classes, methods and properties
                Regex regex = new Regex(@"^(?<range>[\w\s]+\b(class|struct|enum|interface)\s+[\w<>,\s]+)|^\s*(public|private|internal|protected)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline);
                foreach (Match r in regex.Matches(text))
                {
                    try
                    {
                        string s = r.Value;
                        int i = s.IndexOfAny(new char[] { '=', '{', ';' });
                        if (i >= 0)
                        {
                            s = s.Substring(0, i);
                        }

                        s = s.Trim();

                        var item = new ExplorerItem() { title = s, position = r.Index };
                        if (Regex.IsMatch(item.title, @"\b(class|struct|enum|interface)\b"))
                        {
                            item.title = item.title.Substring(item.title.LastIndexOf(' ')).Trim();
                            item.type = ExplorerItemType.Class;
                            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), new ExplorerItemComparer());
                            lastClassIndex = list.Count;
                        }
                        else if (item.title.Contains(" event "))
                        {
                            int ii = item.title.LastIndexOf(' ');
                            item.title = item.title.Substring(ii).Trim();
                            item.type = ExplorerItemType.Event;
                        }
                        else if (item.title.Contains("("))
                        {
                            var parts = item.title.Split('(');
                            item.title = parts[0].Substring(parts[0].LastIndexOf(' ')).Trim() + "(" + parts[1];
                            item.type = ExplorerItemType.Method;
                        }
                        else if (item.title.EndsWith("]"))
                        {
                            var parts = item.title.Split('[');
                            if (parts.Length < 2) continue;
                            item.title = parts[0].Substring(parts[0].LastIndexOf(' ')).Trim() + "[" + parts[1];
                            item.type = ExplorerItemType.Method;
                        }
                        else
                        {
                            int ii = item.title.LastIndexOf(' ');
                            item.title = item.title.Substring(ii).Trim();
                            item.type = ExplorerItemType.Property;
                        }
                        list.Add(item);
                    }
                    catch { }
                }

                list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), new ExplorerItemComparer());

                BeginInvoke(
                    new Action(() =>
                    {
                        explorerList = list;
                        datagridviewerObjectExplorer.RowCount = explorerList.Count;
                        datagridviewerObjectExplorer.Invalidate();
                    })
                );
            }
            catch { }
        }

        private void tsFiles_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            if ((e.Item.Controls[0] as FastColoredTextBox).IsChanged)
            {
                switch (MessageBox.Show("Do you want save " + e.Item.Title + " ?", "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case System.Windows.Forms.DialogResult.Yes:
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

        private bool Save(FATabStripItem tab)
        {
            var tb = (tab.Controls[0] as FastColoredTextBox);
            if (tab.Tag == null)
            {
                if (sfdMain.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return false;
                }
                tab.Title = Path.GetFileName(sfdMain.FileName);
                tab.Tag = sfdMain.FileName;
            }

            try
            {
                File.WriteAllText(tab.Tag as string, tb.Text);
                tb.IsChanged = false;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return Save(tab);
                }
                else
                {
                    return false;
                }
            }

            tb.Invalidate();

            return true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                Save(openFilesTabs.SelectedItem);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                string oldFile = openFilesTabs.SelectedItem.Tag as string;
                openFilesTabs.SelectedItem.Tag = null;
                if (!Save(openFilesTabs.SelectedItem))
                {
                    if (oldFile != null)
                    {
                        openFilesTabs.SelectedItem.Tag = oldFile;
                        openFilesTabs.SelectedItem.Title = Path.GetFileName(oldFile);
                    }
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CreateTab(ofdMain.FileName);
            }
        }

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

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Selection.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.UndoEnabled)
            {
                CurrentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.RedoEnabled)
            {
                CurrentTextBox.Redo();
            }
        }

        private void tmUpdateInterface_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentTextBox != null && openFilesTabs.Items.Count > 0)
                {
                    var tb = CurrentTextBox;
                    buttonUndoStrip.Enabled = undoToolStripMenuItem.Enabled = tb.UndoEnabled;
                    buttonRedoStrip.Enabled = redoToolStripMenuItem.Enabled = tb.RedoEnabled;
                    saveToolStripButton.Enabled = saveToolStripMenuItem.Enabled = tb.IsChanged;
                    saveAsToolStripMenuItem.Enabled = true;
                    pasteToolStripButton.Enabled = pasteToolStripMenuItem.Enabled = true;
                    cutToolStripButton.Enabled = cutToolStripMenuItem.Enabled =
                    copyToolStripButton.Enabled = copyToolStripMenuItem.Enabled = !tb.Selection.IsEmpty;
                    printToolStripButton.Enabled = true;
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        bool tbFindChanged = false;

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r' && CurrentTextBox != null) || (e.KeyChar == '\n' && CurrentTextBox != null))
            {
                FastColoredTextBoxNS.Range r = tbFindChanged ? CurrentTextBox.Range.Clone() : CurrentTextBox.Selection.Clone();
                tbFindChanged = false;
                r.End = new Place(CurrentTextBox[CurrentTextBox.LinesCount - 1].Count, CurrentTextBox.LinesCount - 1);
                var pattern = Regex.Escape(textboxSearch.Text);
                foreach (var found in r.GetRanges(pattern))
                {
                    found.Inverse();
                    CurrentTextBox.Selection = found;
                    CurrentTextBox.DoSelectionVisible();
                    return;
                }
                MessageBox.Show("Not found.");
            }
            else
            {
                tbFindChanged = true;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.ShowFindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.ShowReplaceDialog();
        }

        private void PowerfulCSharpEditor_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvObjectExplorer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CurrentTextBox != null)
            {
                var item = explorerList[e.RowIndex];
                CurrentTextBox.GoEnd();
                CurrentTextBox.SelectionStart = item.position;
                CurrentTextBox.DoSelectionVisible();
                CurrentTextBox.Focus();
            }
        }

        private void dgvObjectExplorer_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                ExplorerItem item = explorerList[e.RowIndex];
                if (e.ColumnIndex == 1)
                    e.Value = item.title;
                else
                {
                    switch (item.type)
                    {
                        case ExplorerItemType.Class:
                            //   e.Value = global::Tester.Properties.Resources.class_libraries;
                            return;
                        case ExplorerItemType.Method:
                            //  e.Value = global::Tester.Properties.Resources.box;
                            return;
                        case ExplorerItemType.Event:
                            // e.Value = global::Code.Editor.Properties.Resources.lightning;
                            return;
                        case ExplorerItemType.Property:
                            //   e.Value = global::Tester.Properties.Resources.property;
                            return;
                    }
                }
            }
            catch { }
        }

        private void tsFiles_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Focus();
                string text = CurrentTextBox.Text;
                ThreadPool.QueueUserWorkItem(obj => ReBuildObjectExplorer(text));
            }
        }

        private void backStripButton_Click(object sender, EventArgs e)
        {
            NavigateBackward();
        }

        private void forwardStripButton_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

        DateTime lastNavigatedDateTime = DateTime.Now;

        private bool NavigateBackward()
        {
            DateTime max = new DateTime();
            int lineIndex = -1;
            FastColoredTextBox textBoxLocal = null;
            for (int tabIndex = 0; tabIndex < openFilesTabs.Items.Count; tabIndex++)
            {
                var tempTextBoxValue = (openFilesTabs.Items[tabIndex].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < tempTextBoxValue.LinesCount; i++)
                {
                    if (tempTextBoxValue[i].LastVisit < lastNavigatedDateTime && tempTextBoxValue[i].LastVisit > max)
                    {
                        max = tempTextBoxValue[i].LastVisit;
                        lineIndex = i;
                        textBoxLocal = tempTextBoxValue;
                    }
                }
            }

            if (lineIndex >= 0)
            {
                openFilesTabs.SelectedItem = (textBoxLocal.Parent as FATabStripItem);
                textBoxLocal.Navigate(lineIndex);
                lastNavigatedDateTime = textBoxLocal[lineIndex].LastVisit;
                Console.WriteLine("Backward: " + lastNavigatedDateTime);
                textBoxLocal.Focus();
                textBoxLocal.Invalidate();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NavigateForward()
        {
            DateTime min = DateTime.Now;
            int lineIndex = -1;
            FastColoredTextBox textBoxLocal = null;
            for (int tabIndex = 0; tabIndex < openFilesTabs.Items.Count; tabIndex++)
            {
                var textBoxTemp = (openFilesTabs.Items[tabIndex].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < textBoxTemp.LinesCount; i++)
                {
                    if (textBoxTemp[i].LastVisit > lastNavigatedDateTime && textBoxTemp[i].LastVisit < min)
                    {
                        min = textBoxTemp[i].LastVisit;
                        lineIndex = i;
                        textBoxLocal = textBoxTemp;
                    }
                }
            }
            if (lineIndex >= 0)
            {
                openFilesTabs.SelectedItem = (textBoxLocal.Parent as FATabStripItem);
                textBoxLocal.Navigate(lineIndex);
                lastNavigatedDateTime = textBoxLocal[lineIndex].LastVisit;
                Console.WriteLine("Forward: " + lastNavigatedDateTime);
                textBoxLocal.Focus();
                textBoxLocal.Invalidate();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void autoIndentSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.DoAutoIndent();
        }

        private void btInvisibleChars_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                HighlightInvisibleChars((tab.Controls[0] as FastColoredTextBox).Range);
            }
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Invalidate();
            }
        }

        private void btHighlightCurrentLine_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                if (buttonHighlightCurrentLine.Checked)
                {
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = currentLineColor;
                }
                else
                {
                    (tab.Controls[0] as FastColoredTextBox).CurrentLineColor = Color.Transparent;
                }
            }
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Invalidate();
            }
        }

        private void commentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.InsertLinePrefix("//");
        }

        private void uncommentSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentTextBox.RemoveLinePrefix("//");
        }

        private void cloneLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //expand selection
            CurrentTextBox.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTextBox.Selection.Text;
            //move caret to end of selected lines
            CurrentTextBox.Selection.Start = CurrentTextBox.Selection.End;
            //insert text
            CurrentTextBox.InsertText(text);
        }

        private void cloneLinesAndCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //start autoUndo block
            CurrentTextBox.BeginAutoUndo();
            //expand selection
            CurrentTextBox.Selection.Expand();
            //get text of selected lines
            string text = Environment.NewLine + CurrentTextBox.Selection.Text;
            //comment lines
            CurrentTextBox.InsertLinePrefix("//");
            //move caret to end of selected lines
            CurrentTextBox.Selection.Start = CurrentTextBox.Selection.End;
            //insert text
            CurrentTextBox.InsertText(text);
            //end of autoUndo block
            CurrentTextBox.EndAutoUndo();
        }

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

        private void gotoButton_DropDownOpening(object sender, EventArgs e)
        {
            buttonGoto.DropDownItems.Clear();
            foreach (Control tab in openFilesTabs.Items)
            {
                FastColoredTextBox tb = tab.Controls[0] as FastColoredTextBox;
                foreach (var bookmark in tb.Bookmarks)
                {
                    var item = buttonGoto.DropDownItems.Add(bookmark.Name + " [" + Path.GetFileNameWithoutExtension(tab.Tag as String) + "]");
                    item.Tag = bookmark;
                    item.Click += (o, a) =>
                    {
                        var b = (Bookmark)(o as ToolStripItem).Tag;
                        try
                        {
                            CurrentTextBox = b.TB;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        b.DoVisible();
                    };
                }
            }
        }

        private void btShowFoldingLines_Click(object sender, EventArgs e)
        {
            foreach (FATabStripItem tab in openFilesTabs.Items)
            {
                (tab.Controls[0] as FastColoredTextBox).ShowFoldingLines = buttonShowFoldingLines.Checked;
            }
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Invalidate();
            }
        }

        private void Zoom_click(object sender, EventArgs e)
        {
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Zoom = int.Parse((sender as ToolStripItem).Tag.ToString());
            }
        }
    }
}