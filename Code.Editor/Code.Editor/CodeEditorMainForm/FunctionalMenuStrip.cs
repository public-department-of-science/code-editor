using Code.Editor.Snippet;
using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.ComponentModel;
using System.Diagnostics;
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

            HighlightHyperLinks(e.ChangedRange);
        }

        private void HighlightHyperLinks(FastColoredTextBoxNS.Range changedRange)
        {
            changedRange.ClearStyle(hyperLinksStyle);
            changedRange.SetStyle(hyperLinksStyle, @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?");
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
                if (codeEditorSettings != null)
                {
                    if (string.IsNullOrWhiteSpace(codeEditorSettings.HotKeys) == false)
                    {
                        var hotKeysMapping = HotkeysMapping.Parse(codeEditorSettings.HotKeys);
                        newTextBox.HotkeysMapping = hotKeysMapping;
                    }
                    newTextBox.BackColor = codeEditorSettings.codeAreaBackGround;
                }
                documentMap.Target = newTextBox;
                newTextBox.WordWrap = true;
                newTextBox.ShowCaretWhenInactive = true;
                newTextBox.Font = new Font("Consolas", 9.75f);
                newTextBox.ContextMenuStrip = codeAreaContextMenu;
                newTextBox.Dock = DockStyle.Fill;
                newTextBox.BorderStyle = BorderStyle.Fixed3D;
                newTextBox.LeftPadding = 17;
                var selectedLanguage = GetCurrentLanguageByTag();
                newTextBox.Language = selectedLanguage;
                newTextBox.AutoCompleteBrackets = true;
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

                newTextBox.Tag = new TextBoxInfo();
                openFilesTabs.AddTab(newFileTab);
                openFilesTabs.SelectedItem = newFileTab;
                newTextBox.Focus();
                newTextBox.DelayedTextChangedInterval = 1000;
                newTextBox.DelayedEventsInterval = 500;
                newTextBox.AutoIndentChars = true;
                newTextBox.CustomAction += closeOpenTabByHotKey_CustomAction;
                newTextBox.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(tb_TextChangedDelayed);
                newTextBox.SelectionChangedDelayed += new EventHandler(tb_SelectionChangedDelayed);
                newTextBox.KeyDown += new KeyEventHandler(tb_KeyDown);
                newTextBox.MouseMove += new MouseEventHandler(tb_MouseMove);
                newTextBox.MouseDown += new MouseEventHandler(tb_MouseDown);
                newTextBox.TextChanged += new EventHandler<TextChangedEventArgs>(tb_TextChanged);
                newTextBox.ToolTipNeeded += new EventHandler<ToolTipNeededEventArgs>(tb_ToolTipNeeded);
                newTextBox.AutoIndentNeeded += new EventHandler<AutoIndentEventArgs>(tb_AutoIndentNeeded);
                newTextBox.ChangedLineColor = changedLineColor;
                if (buttonHighlightCurrentLine.Checked)
                {
                    newTextBox.CurrentLineColor = currentLineColor;
                }
                newTextBox.ShowFoldingLines = buttonShowFoldingLines.Checked;
                newTextBox.HighlightingRangeType = HighlightingRangeType.VisibleRange;

                //create autocomplete syntax members popup menu
                AutocompleteMenu popupMenu = new AutocompleteMenu(newTextBox)
                {
                    SelectedColor = Color.Purple,
                    BackColor = Color.NavajoWhite,
                    ForeColor = Color.Blue,
                };

                popupMenu.Items.ImageList = imageListAutocomplete;
                popupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
                BuildAutocompleteMenu(popupMenu);
                (newTextBox.Tag as TextBoxInfo).syntaxMembersPopupMenu = popupMenu;

                //create autocomplete for random words menu
                AutocompleteMenu randomWordsPopupMenu = new AutocompleteMenu(newTextBox)
                {
                    SelectedColor = Color.Green,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };

                randomWordsPopupMenu.Items.ImageList = imageListAutocomplete;
                randomWordsPopupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
                BuildAutocompleteRandomWordsMenu(randomWordsPopupMenu);
                (newTextBox.Tag as TextBoxInfo).randomWordsPopupMenu = randomWordsPopupMenu;

                //create autocomplete for registered functions menu
                AutocompleteMenu builtInFunctionsWordsPopupMenu = new AutocompleteMenu(newTextBox)
                {
                    SelectedColor = Color.Green,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };

                builtInFunctionsWordsPopupMenu.Items.ImageList = imageListAutocomplete;
                builtInFunctionsWordsPopupMenu.Opening += new EventHandler<CancelEventArgs>(popupMenu_Opening);
                BuildAutocompleteBuiltInFunctionsMenu(builtInFunctionsWordsPopupMenu);
                (newTextBox.Tag as TextBoxInfo).builtInFunctionMenu = builtInFunctionsWordsPopupMenu;
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

        private void tb_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            if (e.LineText.Contains(@$"{lBraceSymbol}"))
            //&& Regex.IsMatch(e.PrevLineText, @$"\b{ifKeyword}|{elseKeyword}|{namespaceKeyword}|{defKeyword}|{methodKeyword}|{whileKeyword}|{forKeyword}|{doKeyword}\b"))
            {
                e.ShiftNextLines += e.TabLength;
                return;
            }
            if (e.LineText.Contains(rBraceSymbol))
            {
                e.Shift -= e.TabLength;
                e.ShiftNextLines -= e.TabLength;
                return;
            }

            if ((e.LineText.Contains(@$"{fieldKeyword}") || e.LineText.Contains(@$"{methodKeyword}"))
                && Regex.IsMatch(e.PrevLineText, @$"\b{objectKeyword}\b"))
            {
                e.Shift += e.TabLength;
                e.ShiftNextLines += e.TabLength;
                return;
            }

            if (e.LineText.Contains(endObjectKeyword)// || e.LineText.Contains(endRegionKeyword))
                && e.PrevLineText.Contains(rBraceSymbol))
            {
                e.Shift -= e.TabLength;
            }
            // ending constructions must be as first cause used 'contains' method for define shifting way
            if (e.LineText.Contains(endObjectKeyword))
            {
                e.ShiftNextLines -= e.TabLength;
                return;
            }

            if (e.LineText.Contains(endNamespaceKeyword))
            {
                e.Shift = 0;
                e.ShiftNextLines = 0;
                return;
            }
            if (e.LineText.Contains(namespaceKeyword))
            {
                e.ShiftNextLines += e.TabLength;
                return;
            }
        }

        private void tb_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.HoveredWord))
            {
                e.ToolTipTitle = e.HoveredWord;
                e.ToolTipText = "Howered word: '" + e.HoveredWord + "'";
                e.ToolTipIcon = ToolTipIcon.Info;
            }
        }

        private void closeOpenTabByHotKey_CustomAction(object? sender, CustomActionEventArgs eventHappend)
        {
            if (CurrentTextBox.IsChanged)
            {
                switch (MessageBox.Show("Do you want to save " + CurrentTextBox.Name + " ?",
                    "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
                {
                    case DialogResult.Yes:
                        {
                            if (Save(openFilesTabs.SelectedItem) == true)
                            {
                                openFilesTabs.RemoveTab(openFilesTabs.SelectedItem);
                                return;
                            }
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            break;
                        }
                    case DialogResult.No:
                        {
                            openFilesTabs.RemoveTab(openFilesTabs.SelectedItem);
                            break;
                        }
                }
            }
            else
            {
                openFilesTabs.RemoveTab(openFilesTabs.SelectedItem);
            }
        }

        private void tb_MouseDown(object sender, MouseEventArgs e)
        {
            var p = CurrentTextBox.PointToPlace(e.Location);
            if (CharIsHyperlink(p))
            {
                var url = CurrentTextBox.GetRange(p, p).GetFragment(@"[\S]").Text.ToString();
                if ((url.StartsWith("http:") || url.StartsWith("https:")) == false)
                {
                    throw new Exception("The hyper link must starts with the protocol to use symbols.");
                }

                var processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = true;
                processStartInfo.FileName = url;
                Process.Start(processStartInfo);
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
                items.Add(new SnippetAutocompleteItem(item)
                {
                    ImageIndex = 1,
                    ToolTipTitle = "Test tool tip title",
                    ToolTipText = "Tool tip text",
                    // BackColor = Color.Green,
                    //ForeColor = Color.Red,
                    //SelectedColor = Color.Purple;
                    //MenuText = "Menu text show here",
                });
            }
            foreach (var item in declarationSnippets)
            {
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
            }
            foreach (var item in keywords)
            {
                items.Add(new KeywordsAutocomplete(item)
                {
                    ForeColor = Color.Black,
                    ImageIndex = 1,
                    BackColor = Color.White,
                });
            }

            items.Add(new InsertSpaceSnippet(digitsDividePattern));
            items.Add(new InsertSpaceSnippet(constructionsDividePattern));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            popupMenu.Items.SetAutocompleteItems(items);
            popupMenu.SearchPattern = @"[\w\.:=!<>]";
        }

        private void BuildAutocompleteBuiltInFunctionsMenu(AutocompleteMenu popupMenu)
        {
            //create autocomplete popup menu
            popupMenu.MinFragmentLength = 2;

            //generate 456976 words
            var builtInFunctionsMenuWords = new List<string>();

            foreach (var item in builtInFunctions)
            {
                builtInFunctionsMenuWords.Add(item);
            }

            //set words as autocomplete source
            popupMenu.Items.SetAutocompleteItems(builtInFunctionsMenuWords);
            //size of popupmenu
            popupMenu.Items.MaximumSize = new System.Drawing.Size(200, 300);
            popupMenu.Items.Width = 200;
        }

        private void BuildAutocompleteRandomWordsMenu(AutocompleteMenu popupMenu)
        {
            //create autocomplete popup menu
            popupMenu.MinFragmentLength = 2;

            //generate 456976 words
            var randomWords = new List<string>();
            int codeA = Convert.ToInt32('a');
            for (int i = 0; i < 26; i++)
                for (int j = 0; j < 26; j++)
                    for (int k = 0; k < 26; k++)
                        for (int l = 0; l < 26; l++)
                            randomWords.Add(
                                new string(new char[] { Convert.ToChar(i + codeA), Convert.ToChar(j + codeA), Convert.ToChar(k + codeA), Convert.ToChar(l + codeA) }));

            //set words as autocomplete source
            popupMenu.Items.SetAutocompleteItems(randomWords);
            //size of popupmenu
            popupMenu.Items.MaximumSize = new System.Drawing.Size(200, 300);
            popupMenu.Items.Width = 200;
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

            tb_MouseMoveCursorChangeOnHyperLink(sender, e);
        }

        private void tb_MouseMoveCursorChangeOnHyperLink(object sender, MouseEventArgs e)
        {
            var p = CurrentTextBox.PointToPlace(e.Location);
            if (CharIsHyperlink(p))
            {
                CurrentTextBox.Cursor = Cursors.Hand;
            }
            else
            {
                CurrentTextBox.Cursor = Cursors.IBeam;
            }
        }

        private bool CharIsHyperlink(Place place)
        {
            var mask = CurrentTextBox.GetStyleIndexMask(new Style[] { hyperLinksStyle });
            if (place.iChar < CurrentTextBox.GetLineLength(place.iLine))
            {
                if ((CurrentTextBox[place].style & mask) != 0)
                {
                    return true;
                }
            }
            return false;
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

            if (e.KeyData == (Keys.Control | Keys.K))
            {
                //forced show (MinFragmentLength will be ignored)
                (CurrentTextBox.Tag as TextBoxInfo).syntaxMembersPopupMenu.Show(true);
                e.Handled = true;
            }

            if (e.KeyData == (Keys.Control | Keys.R))
            {
                //forced show (MinFragmentLength will be ignored)
                (CurrentTextBox.Tag as TextBoxInfo).randomWordsPopupMenu.Show(true);
                e.Handled = true;
            }

            if (e.KeyData == (Keys.Control | Keys.J))
            {
                //forced show (MinFragmentLength will be ignored)
                (CurrentTextBox.Tag as TextBoxInfo).builtInFunctionMenu.Show(true);
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
                tbFindChanged = true;
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

            if (documentMapStripButton.Checked == true)
            {
                documentMapStripButton.ForeColor = Color.AliceBlue;
            }
            else
            {
                documentMapStripButton.ForeColor = menuStrip.BackColor;
            }
        }

        #endregion

        #region Word wrap

        private void wordWrapToolStripButton_Click(object sender, EventArgs e)
        {
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