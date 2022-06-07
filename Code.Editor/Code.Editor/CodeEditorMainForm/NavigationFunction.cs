using FarsiLibrary.Win;
using FastColoredTextBoxNS;

namespace Code.Editor
{
    public partial class CodeEditorMainForm
    {
        private void backStripButton_Click(object sender, EventArgs e)
        {
            NavigateBackward();
        }

        private void forwardStripButton_Click(object sender, EventArgs e)
        {
            NavigateForward();
        }

        private bool NavigateBackward()
        {
            DateTime max = new DateTime();
            int lineIndex = -1;
            FastColoredTextBox textBoxLocal = null;
            for (int tabIndex = 0; tabIndex < openFilesTabs.Items.Count; tabIndex++)
            {
                var tempTextBoxValue = (openFilesTabs.Items[tabIndex].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < tempTextBoxValue.LinesCount; i++)
                {
                    if (tempTextBoxValue[i].LastVisit < lastNavigatedDateTime && tempTextBoxValue[i].LastVisit > max)
                    {
                        max = tempTextBoxValue[i].LastVisit;
                        lineIndex = i;
                        textBoxLocal = tempTextBoxValue;
                    }
                }
            }

            if (lineIndex >= 0)
            {
                openFilesTabs.SelectedItem = (textBoxLocal.Parent as FATabStripItem);
                textBoxLocal.Navigate(lineIndex);
                lastNavigatedDateTime = textBoxLocal[lineIndex].LastVisit;
                Console.WriteLine("Backward: " + lastNavigatedDateTime);
                textBoxLocal.Focus();
                textBoxLocal.Invalidate();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool NavigateForward()
        {
            DateTime min = DateTime.Now;
            int lineIndex = -1;
            FastColoredTextBox textBoxLocal = null;
            for (int tabIndex = 0; tabIndex < openFilesTabs.Items.Count; tabIndex++)
            {
                var textBoxTemp = (openFilesTabs.Items[tabIndex].Controls[0] as FastColoredTextBox);
                for (int i = 0; i < textBoxTemp.LinesCount; i++)
                {
                    if (textBoxTemp[i].LastVisit > lastNavigatedDateTime && textBoxTemp[i].LastVisit < min)
                    {
                        min = textBoxTemp[i].LastVisit;
                        lineIndex = i;
                        textBoxLocal = textBoxTemp;
                    }
                }
            }
            if (lineIndex >= 0)
            {
                openFilesTabs.SelectedItem = (textBoxLocal.Parent as FATabStripItem);
                textBoxLocal.Navigate(lineIndex);
                lastNavigatedDateTime = textBoxLocal[lineIndex].LastVisit;
                Console.WriteLine("Forward: " + lastNavigatedDateTime);
                textBoxLocal.Focus();
                textBoxLocal.Invalidate();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
