namespace Code.Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.richTextBox1.MouseWheel += Mause_MouseWheel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        void Mause_MouseWheel(object sender, MouseEventArgs e)
        {
            float fontSize = richTextBox1.Font.Size;
            if (e.Delta > 0)
            {
                fontSize += 1f;
                richTextBox1.Font = new Font(richTextBox1.Font.Name, fontSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
            }
            else
            {
                if (fontSize > (float)1)
                {
                    fontSize -= 1f;
                    richTextBox1.Font = new Font(richTextBox1.Font.Name, fontSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
                }
            }
        }

        private void dataTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now.ToString();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            saveFileDialog.Filter = "text document(*.txt)|.txt|all files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveFileDialog.FileName;
            }
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open";
            openFileDialog.Filter = "text document(*.txt)|.txt|all files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = openFileDialog.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            saveFileDialog.Filter = "text document(*.txt)|.txt|all files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveFileDialog.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog.Color;
            }
        }

        private void blackThemeModeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.White;
            richTextBox1.BackColor = Color.Black;
        }

        private void whiteThemeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.BackColor = Color.White;
        }

        private void cutKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            richTextBox1.Text = richTextBox1.Text.Replace(text1, text2);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPagePreviewDialog.Document = printDocument;
            printPagePreviewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 12, 10);
        }
    }
}