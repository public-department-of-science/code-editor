using Code.Editor.Explorer;
using System.Text.RegularExpressions;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private List<ExplorerItem> explorerList = new List<ExplorerItem>();

        private void ReBuildObjectExplorer(string text)
        {
            try
            {
                List<ExplorerItem> list = new List<ExplorerItem>();
                int lastClassIndex = -1;
                //find objects, methods and field
                Regex regex = new Regex(@"^(?<range>[\w\s]+\b(object|field|method)\s+[\w<>,\s]+)|^\s*(public|private)[^\n]+(\n?\s*{|;)?", RegexOptions.Multiline);
                foreach (Match r in regex.Matches(text))
                {
                    try
                    {
                        string s = r.Value;
                        int i = s.IndexOfAny(new char[] { '=', '{', ';' });
                        if (i >= 0)
                        {
                            s = s.Substring(0, i);
                        }

                        s = s.Trim();

                        var item = new ExplorerItem() { title = s, position = r.Index };
                        if (Regex.IsMatch(item.title, @"\b(object|field|method)\b"))
                        {
                            item.title = item.title.Substring(item.title.LastIndexOf(' ')).Trim();
                            item.type = ExplorerItemType.Object;
                            list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), new ExplorerItemComparer());
                            lastClassIndex = list.Count;
                        }
                        else if (item.title.Contains("namespace"))
                        {
                            int ii = item.title.LastIndexOf(' ');
                            item.title = item.title.Substring(ii).Trim();
                            item.type = ExplorerItemType.Namespace;
                        }
                        else if (item.title.Contains("("))
                        {
                            var parts = item.title.Split('(');
                            item.title = parts[0].Substring(parts[0].LastIndexOf(' ')).Trim() + "(" + parts[1];
                            item.type = ExplorerItemType.Method;
                        }
                        else if (item.title.EndsWith("]"))
                        {
                            var parts = item.title.Split('[');
                            if (parts.Length < 2) continue;
                            item.title = parts[0].Substring(parts[0].LastIndexOf(' ')).Trim() + "[" + parts[1];
                            item.type = ExplorerItemType.Method;
                        }
                        else
                        {
                            int ii = item.title.LastIndexOf(' ');
                            item.title = item.title.Substring(ii).Trim();
                            item.type = ExplorerItemType.Field;
                        }
                        list.Add(item);
                    }
                    catch { }
                }

                list.Sort(lastClassIndex + 1, list.Count - (lastClassIndex + 1), new ExplorerItemComparer());

                BeginInvoke(
                    new Action(() =>
                    {
                        explorerList = list;
                        datagridviewerObjectExplorer.RowCount = explorerList.Count;
                        datagridviewerObjectExplorer.Invalidate();
                    })
                );
            }
            catch { }
        }

        private void dgvObjectExplorer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CurrentTextBox != null)
            {
                var item = explorerList[e.RowIndex];
                CurrentTextBox.GoEnd();
                CurrentTextBox.SelectionStart = item.position;
                CurrentTextBox.DoSelectionVisible();
                CurrentTextBox.Focus();
            }
        }

        private void dgvObjectExplorer_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            try
            {
                ExplorerItem item = explorerList[e.RowIndex];
                if (e.ColumnIndex == 1)
                {
                    e.Value = item.title;
                }
                else
                {
                    switch (item.type)
                    {
                        case ExplorerItemType.Object:
                            {
                                e.Value = Properties.Resources.class_libraries;
                                return;
                            }
                        case ExplorerItemType.Method:
                            {
                                e.Value = Properties.Resources.box;
                                return;
                            }
                        case ExplorerItemType.Namespace:
                            {
                                //e.Value = Properties.Resources.lightning;
                                e.Value = Properties.Resources.box;
                                return;
                            }
                        case ExplorerItemType.Field:
                            {
                                e.Value = Properties.Resources.property;
                                return;
                            }
                    }
                }
            }
            catch { }
        }
    }
}