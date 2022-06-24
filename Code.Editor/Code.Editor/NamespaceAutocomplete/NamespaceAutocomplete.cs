using FastColoredTextBoxNS;

namespace Code.Editor.NamespaceAutocomplete
{
    public class NamespaceAutocomplete
    {
        private AutocompleteMenu popupMenu;
        private static readonly string[] sources = new string[]{
            "com",
            "com.company",
            "com.company.Class1",
            "com.company.Class1.Method1",
            "com.company.Class1.Method2",
            "com.company.Class2",
            "com.company.Class3",
            "com.example",
            "com.example.ClassX",
            "com.example.ClassX.Method1",
            "com.example.ClassY",
            "com.example.ClassY.Method1"
        };

        public NamespaceAutocomplete()
        {
            //create autocomplete popup menu
            popupMenu = new AutocompleteMenu(null);
            popupMenu.SearchPattern = @"[\w\.]";

            var items = new List<AutocompleteItem>();
            foreach (var item in sources)
            {
                items.Add(new NamespaceAutocompleteItem(item));
            }

            popupMenu.Items.SetAutocompleteItems(items);
        }
    }
}