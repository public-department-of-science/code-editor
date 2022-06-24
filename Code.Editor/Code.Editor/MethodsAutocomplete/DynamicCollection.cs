using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Code.Editor.MethodsAutocomplete
{
    internal class DynamicCollection : IEnumerable<AutocompleteItem>
    {
        private AutocompleteMenu menu;
        private FastColoredTextBox tb;

        public DynamicCollection(AutocompleteMenu menu, FastColoredTextBox tb)
        {
            this.menu = menu;
            this.tb = tb;
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            //get current fragment of the text
            var text = menu.Fragment.Text;

            //extract class name (part before dot)
            var parts = text.Split('.');
            if (parts.Length < 2)
                yield break;
            var className = parts[parts.Length - 2];

            //find type for given className
            var type = FindTypeByName(className);

            if (type == null)
                yield break;

            //return static methods of the class
            foreach (var methodName in type.GetMethods().AsEnumerable().Select(mi => mi.Name).Distinct())
                yield return new MethodAutocompleteItem(methodName + "()")
                {
                    ToolTipTitle = methodName,
                    ToolTipText = "Description of method " + methodName + " goes here.",
                };

            //return static properties of the class
            foreach (var pi in type.GetProperties())
                yield return new MethodAutocompleteItem(pi.Name)
                {
                    ToolTipTitle = pi.Name,
                    ToolTipText = "Description of property " + pi.Name + " goes here.",
                };
        }

        private Type FindTypeByName(string name)
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type type = null;
            foreach (var a in assemblies)
            {
                foreach (var t in a.GetTypes())
                    if (t.Name == name)
                    {
                        return t;
                    }
            }

            return null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
