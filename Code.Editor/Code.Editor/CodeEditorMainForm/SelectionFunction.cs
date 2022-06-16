using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void tb_SelectionChangedDelayed(object sender, EventArgs e)
        {
           var textBox = sender as FastColoredTextBox;
            //remember last visit time
            if (textBox.Selection.IsEmpty && textBox.Selection.Start.iLine < textBox.LinesCount)
            {
                if (lastNavigatedDateTime != textBox[textBox.Selection.Start.iLine].LastVisit)
                {
                    textBox[textBox.Selection.Start.iLine].LastVisit = DateTime.Now;
                    lastNavigatedDateTime = textBox[textBox.Selection.Start.iLine].LastVisit;
                }
            }

            //highlight same words
            textBox.VisibleRange.ClearStyle(sameWordsStyle);
            if (!textBox.Selection.IsEmpty)
            {
                return;//user selected diapason
            }
            //get fragment around caret
            var fragment = textBox.Selection.GetFragment(@"\w");
            string text = fragment.Text;
            if (text.Length == 0)
            {
                return;
            }
            //highlight same words
            FastColoredTextBoxNS.Range[] ranges = textBox.VisibleRange.GetRanges("\\b" + text + "\\b").ToArray();

            if (ranges.Length > 1)
            {
                foreach (var r in ranges)
                {
                    r.SetStyle(sameWordsStyle);
                }
            }
        }
    }
}