using FastColoredTextBoxNS;

namespace Code.Editor.MethodsAutocomplete
{
    public partial class AutocompleteSample3 : Form
    {
        AutocompleteMenu popupMenu;

        public AutocompleteSample3()
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
