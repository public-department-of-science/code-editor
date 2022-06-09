namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTab(string.Empty);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                CreateTab(openFileDialogMain.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                Save(openFilesTabs.SelectedItem);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFilesTabs.SelectedItem != null)
            {
                string oldFile = openFilesTabs.SelectedItem.Tag as string;
                openFilesTabs.SelectedItem.Tag = null;
                if (!Save(openFilesTabs.SelectedItem))
                {
                    if (oldFile != null)
                    {
                        openFilesTabs.SelectedItem.Tag = oldFile;
                        openFilesTabs.SelectedItem.Title = Path.GetFileName(oldFile);
                    }
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}