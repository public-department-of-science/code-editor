using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Code.Editor.Snippet
{
    internal class InsertSpaceSnippet : AutocompleteItem
    {
        string pattern;

        public InsertSpaceSnippet(string pattern) : base("")
        {
            this.pattern = pattern;
        }

        public override CompareResult Compare(string fragmentText)
        {
            if (Regex.IsMatch(fragmentText, pattern))
            {
                Text = InsertSpaces(fragmentText);
                if (Text != fragmentText)
                {
                    return CompareResult.Visible;
                }
            }
            return CompareResult.Hidden;
        }

        public string InsertSpaces(string fragment)
        {
            var match = Regex.Match(fragment, pattern);
            if (match == null)
            {
                return fragment;
            }
            if (match.Groups[1].Value == "" && match.Groups[3].Value == "")
            {
                return fragment;
            }
            return (match.Groups[1].Value + " " + match.Groups[2].Value + " " + match.Groups[3].Value).Trim();
        }

        public override string ToolTipTitle
        {
            get
            {
                return Text;
            }
        }
    }
}