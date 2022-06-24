using FastColoredTextBoxNS;

namespace Code.Editor.MethodsAutocomplete
{
    public partial class MethodsAutocomplete
    {
        private AutocompleteMenu popupMenu;

        public MethodsAutocomplete()
        {
            //create autocomplete popup menu
            popupMenu = new AutocompleteMenu(null);
            popupMenu.ForeColor = Color.White;
            popupMenu.BackColor = Color.Gray;
            popupMenu.SelectedColor = Color.Purple;
            popupMenu.SearchPattern = @"[\w\.]";
            popupMenu.AllowTabKey = true;
            popupMenu.AlwaysShowTooltip = true;

            popupMenu.Items.SetAutocompleteItems(new DynamicCollection(popupMenu, null));
        }
    }
}
