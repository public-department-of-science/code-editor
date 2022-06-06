namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        internal class ExplorerItemComparer : IComparer<ExplorerItem>
        {
            public int Compare(ExplorerItem x, ExplorerItem y)
            {
                return x.title.CompareTo(y.title);
            }
        }
    }
}
