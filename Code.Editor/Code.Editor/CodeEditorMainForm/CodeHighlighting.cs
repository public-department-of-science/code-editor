using FastColoredTextBoxNS;
using System.Text;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private const string namespaceKeyword = "namespace";
        private const string endNamespaceKeyword = "endnamespace";
        private const string ifKeyword = "if";
        private const string elseKeyword = "else";
        private const string defKeyword = "def";
        private const string methodKeyword = "method";
        private const string fieldKeyword = "field";
        private const string objectKeyword = "object";
        private const string endObjectKeyword = "endobject";
        private const string regionKeyword = "@region";
        private const string endRegionKeyword = "@endregion";
        private const string rBraceSymbol = "}";
        private const string lBraceSymbol = "{";
        private const string forKeyword = "for";
        private const string whileKeyword = "while";
        private const string doKeyword = "do";

        private const string publicKeyword = "public";
        private const string privateKeyword = "private";

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
            // e.ChangedRange.SetStyle(GrayStyle, @"^\s*(?<range>\[.+?\])\s*$", RegexOptions.Multiline);

            //object and that members name highlighting
            e.ChangedRange.SetStyle(BoldStyle, $@"\b({objectKeyword})\s+\b({publicKeyword}|{privateKeyword})\s+(?<range>\w+?)\b");
            e.ChangedRange.SetStyle(UnderLineStyle, $@"\b({methodKeyword}|{fieldKeyword})\s+\b({publicKeyword}|{privateKeyword})\s+(?<range>\w+?)\b");

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
            e.ChangedRange.SetFoldingMarkers(ifKeyword, rBraceSymbol);
            e.ChangedRange.SetFoldingMarkers(elseKeyword, rBraceSymbol);
            e.ChangedRange.SetFoldingMarkers(defKeyword, rBraceSymbol);
            e.ChangedRange.SetFoldingMarkers(methodKeyword, rBraceSymbol);
            e.ChangedRange.SetFoldingMarkers(objectKeyword, endObjectKeyword);
            e.ChangedRange.SetFoldingMarkers(regionKeyword, endRegionKeyword);
            e.ChangedRange.SetFoldingMarkers(namespaceKeyword, endNamespaceKeyword);
        }
        #endregion
    }
}
