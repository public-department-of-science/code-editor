using FastColoredTextBoxNS;

namespace Code.Editor
{
    public class KeywordsAutocomplete : AutocompleteItem
    {
        public KeywordsAutocomplete(string item) : base(item)
        {
        }

        private Color backColor;
        public override Color BackColor
        {
            get
            {
                if (backColor != Color.Transparent)
                {
                    return backColor;
                }
                return Color.Transparent;
            }
            set
            {
                backColor = value;
            }
        }

        private Color foreColor;
        public override Color ForeColor
        {
            get
            {
                if (foreColor != Color.Transparent)
                {
                    return foreColor;
                }
                return Color.Transparent;
            }
            set
            {
                foreColor = value;
            }
        }
    }
}
