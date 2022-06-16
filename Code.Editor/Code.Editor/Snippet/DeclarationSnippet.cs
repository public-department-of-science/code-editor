using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace Code.Editor.Snippet
{
    /// <summary>
    /// This item appears when any part of snippet text is typed
    /// </summary>
    internal class DeclarationSnippet : SnippetAutocompleteItem
    {
        public DeclarationSnippet(string snippet) : base(snippet)
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var pattern = Regex.Escape(fragmentText);
            if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
            {
                return CompareResult.Visible;
            }
            return CompareResult.Hidden;
        }
    }
}