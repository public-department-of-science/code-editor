using Code.Editor.Snippet;
using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        /// <summary>
        /// Divides numbers and words: "123AND456" -> "123 AND 456"
        /// </summary>
        private const string digitsDividePattern = @"^(\d+)([a-zA-Z_]+)(\d*)$";

        /// <summary>
        /// Or "i=2" -> "i = 2"
        /// </summary>
        private const string constructionsDividePattern = @"^(\w+)\s([=<>!:]+)\s(\w+)$";

        #region General activity functions: cut, paste, copy

        private void cutButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Cut();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.Paste();
        }

        #endregion

        #region Actions step undo \ redo

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.UndoEnabled)
            {
                CurrentTextBox.Undo();
            }
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            if (CurrentTextBox.RedoEnabled)
            {
                CurrentTextBox.Redo();
            }
        }

        #endregion

        #region Highlighting functions

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

        #endregion

        #region Commenting code buttons

        private void commentCodeLinesButton_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                CurrentTextBox.InsertLinePrefix("//");
            }
        }

        private void uncommentCodeLinesButton_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                CurrentTextBox.RemoveLinePrefix("//");
            }
        }

        #endregion

        #region New tab funtionality

        private void newTabButton_Click(object sender, EventArgs e)
        {
            CreateTab(string.Empty);
        }

        private void CreateTab(string fileName)
        {
            try
            {
                var newTextBox = new FastColoredTextBox();
                documentMap.Target = newTextBox;
                newTextBox.WordWrap = true;
                newTextBox.Font = new Font("Consolas", 9.75f);
                newTextBox.ContextMenuStrip = codeAreaContextMenu;
                newTextBox.Dock = DockStyle.Fill;
                newTextBox.BorderStyle = BorderStyle.Fixed3D;
                //tb.VirtualSpace = true;
                newTextBox.LeftPadding = 17;
                var selectedLanguage = GetCurrentLanguageByTag();
                newTextBox.Language = selectedLanguage;
                newTextBox.AddStyle(sameWordsStyle);//same words style
                var newFileTab = new FATabStripItem(
                    string.IsNullOrWhiteSpace(fileName) == false
                    ? Path.GetFileName(fileName)
                    : "[new]", newTextBox);

                newFileTab.Tag = fileName;
                if (string.IsNullOrWhiteSpace(fileName) == false)
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

        private Language GetCurrentLanguageByTag()
        {
            ToolStripMenuItem selectedLenguageItem = null;
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    selectedLenguageItem = item;
                    break;
                }
            }

            if (selectedLenguageItem != null)
            {
                switch (selectedLenguageItem.Tag.ToString())
                {
                    case "Custom": return Language.Custom;
                    case "C#": return Language.CSharp;
                    case "HTML": return Language.HTML;
                    case "XML": return Language.XML;
                    case "SQL": return Language.SQL;
                    case "PHP": return Language.PHP;
                    case "JS": return Language.JS;
                    case "LUA": return Language.Lua;
                    case "JSON": return Language.JSON;
                    case "VB": return Language.VB;
                    default: return Language.Custom;
                }
            }
            else
            {
                return Language.Custom;
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

            items.Add(new InsertSpaceSnippet(digitsDividePattern));
            items.Add(new InsertSpaceSnippet(constructionsDividePattern));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);
            popupMenu.SearchPattern = @"[\w\.:=!<>]";
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

        private void tb_MouseMove(object sender, MouseEventArgs e)
        {
            var textBox = sender as FastColoredTextBox;
            var place = textBox.PointToPlace(e.Location);
            var range = new FastColoredTextBoxNS.Range(textBox, place, place);

            string text = range.GetFragment("[a-zA-Z]").Text;
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

        #endregion

        #region file dialogs actions

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                Save(openFilesTabs.SelectedItem);
            }
        }

        private void openButtonMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CreateTab(openFileDialogMain.FileName);
            }
        }

        #endregion

        #region Print current tab-window

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

        #endregion

        #region Show folding lines (+) button

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

        #endregion

        #region Navigation

        private void backStripButton_Click(object sender, EventArgs e)
        {
            NavigateBackward();
        }

        private void forwardStripButton_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

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

        #endregion

        #region Find

        private bool tbFindChanged = false;

        private void tbFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r' && CurrentTextBox != null) || (e.KeyChar == '\n' && CurrentTextBox != null))
            {
                FastColoredTextBoxNS.Range r = tbFindChanged ? CurrentTextBox.Range.Clone() : CurrentTextBox.Selection.Clone();
                tbFindChanged = false;
                r.End = new Place(CurrentTextBox[CurrentTextBox.LinesCount - 1].Count, CurrentTextBox.LinesCount - 1);
                var pattern = Regex.Escape(textboxFind.Text);
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

        #endregion

        #region Bookmarks navigation

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

        #endregion

        #region GoTo

        private void gotoButton_DropDownOpening(object sender, EventArgs e)
        {
            buttonGotoBookmark.DropDownItems.Clear();
            foreach (Control tab in openFilesTabs.Items)
            {
                FastColoredTextBox tb = tab.Controls[0] as FastColoredTextBox;
                foreach (var bookmark in tb.Bookmarks)
                {
                    var item = buttonGotoBookmark.DropDownItems.Add(bookmark.Name + " [" + Path.GetFileNameWithoutExtension(tab.Tag as String) + "]");
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

        #endregion

        #region Document map button

        private void documentMapStripButton_Click(object sender, EventArgs e)
        {
            documentMap.Visible = !documentMap.Visible;
            documentMapStripButton.Checked = !documentMapStripButton.Checked;
            if (documentMapStripButton.Checked == true)
            {
                documentMapStripButton.CheckState = CheckState.Checked;
            }
            else
            {
                documentMapStripButton.CheckState = CheckState.Unchecked;
            }
        }

        #endregion

        #region Word wrap

        private void wordWrapToolStripButton_Click(object sender, EventArgs e)
        {
            wordWrapToolStripButton.Checked = !wordWrapToolStripButton.Checked;

            CurrentTextBox.WordWrap = wordWrapToolStripButton.Checked;
            if (wordWrapToolStripButton.Checked)
            {
                wordWrapToolStripButton.ForeColor = Color.AliceBlue;
            }
            else
            {
                wordWrapToolStripButton.ForeColor = menuStrip.ForeColor;
            }
        }

        #endregion
    }
}