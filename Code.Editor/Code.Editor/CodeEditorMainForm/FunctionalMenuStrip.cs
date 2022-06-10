using FarsiLibrary.Win;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
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

        #endregion
        
        #region Commenting code buttons

        private void commentButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.InsertLinePrefix("//");
        }

        private void uncommentButton_Click(object sender, EventArgs e)
        {
            CurrentTextBox.RemoveLinePrefix("//");
        }

        #endregion

        #region New tab funtionality
        
        private void newTabButton_Click(object sender, EventArgs e)
        {
            CreateTab(string.Empty);
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

        #endregion
    }
}