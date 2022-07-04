using FastColoredTextBoxNS;
using System.Text;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        #region Code highlighting

        TextStyle BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle BoldStyle = new TextStyle(null, null, FontStyle.Bold | FontStyle.Underline);
        TextStyle UnderLineStyle = new TextStyle(null, null, FontStyle.Underline);
        TextStyle GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        TextStyle MagentaStyle = new TextStyle(Brushes.Magenta, null, FontStyle.Regular);
        TextStyle GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Italic);
        TextStyle MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        MarkerStyle SameWordsStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(40, Color.Gray)));

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrentTextBox.LeftBracket = '(';
            CurrentTextBox.RightBracket = ')';
            CurrentTextBox.LeftBracket2 = '{';
            CurrentTextBox.RightBracket2 = '}';
            //clear style of changed range
            e.ChangedRange.ClearStyle(BlueStyle, BoldStyle, GrayStyle, MagentaStyle, GreenStyle, BrownStyle, UnderLineStyle);

            //string highlighting
            e.ChangedRange.SetStyle(BrownStyle, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline);
            e.ChangedRange.SetStyle(GreenStyle, @"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            //number highlighting
            e.ChangedRange.SetStyle(MagentaStyle, @"\b\d+[\.]?\d*([eE]\-?\d+)?[lLdDfF]?\b|\b0x[a-fA-F\d]+\b");
            //attribute highlighting
            e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);
            //class name highlighting
            e.ChangedRange.SetStyle(BoldStyle, @"\b(object|class)\s+(?<range>\w+?)\b");
            e.ChangedRange.SetStyle(UnderLineStyle, @"\b(method|field)\s+(?<range>\w+?)\b");

            //keyword highlighting
            var reservedKeywords = new StringBuilder();
            reservedKeywords.Append(@"\b(");
            foreach (string keyword in keywords)
            {
                reservedKeywords.Append(keyword);
                reservedKeywords.Append("|");
            }
            reservedKeywords.Append(@")\b");

            e.ChangedRange.SetStyle(BlueStyle, reservedKeywords.ToString());

            //clear folding markers
            e.ChangedRange.ClearFoldingMarkers();

            //set folding markers
            e.ChangedRange.SetFoldingMarkers("method", "}");//allow to collapse brackets block
            e.ChangedRange.SetFoldingMarkers("object", "END");//allow to collapse object definitions
            e.ChangedRange.SetFoldingMarkers(@"@region\b", @"@endregion\b");
        }
        #endregion
    }
}
