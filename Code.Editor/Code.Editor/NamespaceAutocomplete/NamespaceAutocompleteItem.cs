using FastColoredTextBoxNS;

namespace Code.Editor.NamespaceAutocomplete
{
    /// <summary>
    /// This autocomplete item appears after dot
    /// </summary>
    public class NamespaceAutocompleteItem : MethodAutocompleteItem
    {
        private string firstPart;
        private string lastPart;

        public NamespaceAutocompleteItem(string text) : base(text)
        {
            var i = text.LastIndexOf('.');
            if (i < 0)
            {
                firstPart = text;
            }
            else
            {
                firstPart = text.Substring(0, i);
                lastPart = text.Substring(i + 1);
            }
        }

        public override CompareResult Compare(string fragmentText)
        {
            int i = fragmentText.LastIndexOf('.');

            if (i < 0)
            {
                if (firstPart.StartsWith(fragmentText) && string.IsNullOrEmpty(lastPart))
                {
                    return CompareResult.VisibleAndSelected;
                }
            }
            else
            {
                var fragmentFirstPart = fragmentText.Substring(0, i);
                var fragmentLastPart = fragmentText.Substring(i + 1);

                if (firstPart != fragmentFirstPart)
                {
                    return CompareResult.Hidden;
                }
                if (lastPart != null && lastPart.StartsWith(fragmentLastPart))
                {
                    return CompareResult.VisibleAndSelected;
                }
                if (lastPart != null && lastPart.ToLower().Contains(fragmentLastPart.ToLower()))
                {
                    return CompareResult.Visible;
                }
            }

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            if (string.IsNullOrWhiteSpace(lastPart))
            {
                return firstPart;
            }

            return firstPart + "." + lastPart;
        }

        public override string ToString()
        {
            if (lastPart == null)
            {
                return firstPart;
            }

            return lastPart;
        }
    }
}