namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void Zoom_click(object sender, EventArgs e)
        {
            if (CurrentTextBox != null)
            {
                CurrentTextBox.Zoom = int.Parse((sender as ToolStripItem).Tag.ToString());
            }
        }
    }
}
