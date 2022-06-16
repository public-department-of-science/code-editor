using FastColoredTextBoxNS;

namespace Code.Editor.Snippet
{
    /// <summary>
    /// Inerts line break after '}'
    /// </summary>
    internal class InsertEnterSnippet : AutocompleteItem
    {
        Place enterPlace = Place.Empty;

        public InsertEnterSnippet() : base("[Line break]")
        {
        }

        public override CompareResult Compare(string fragmentText)
        {
            var range = Parent.Fragment.Clone();
            while (range.Start.iChar > 0)
            {
                if (range.CharBeforeStart == '}')
                {
                    enterPlace = range.Start;
                    return CompareResult.Visible;
                }

                range.GoLeftThroughFolded();
            }

            return CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            //extend range
            FastColoredTextBoxNS.Range range = Parent.Fragment;
            Place end = range.End;
            range.Start = enterPlace;
            range.End = range.End;
            //insert line break
            return Environment.NewLine + range.Text;
        }

        public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
        {
            base.OnSelected(popupMenu, e);
            if (Parent.Fragment.tb.AutoIndent)
            {
                Parent.Fragment.tb.DoAutoIndent();
            }
        }

        public override string ToolTipTitle
        {
            get
            {
                return "Insert line break after '}'";
            }
        }
    }
}