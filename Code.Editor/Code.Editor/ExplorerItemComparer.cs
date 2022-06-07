using static Code.Editor.CodeEditorMainForm;

namespace Code.Editor
{
    internal class ExplorerItemComparer : IComparer<ExplorerItem>
    {
        public int Compare(ExplorerItem x, ExplorerItem y)
        {
            return x.title.CompareTo(y.title);
        }
    }
}
