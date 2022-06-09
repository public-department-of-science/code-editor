using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
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
    }
}