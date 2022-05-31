namespace Code.Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.codeArea.MouseWheel += Mause_MouseWheel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        void Mause_MouseWheel(object sender, MouseEventArgs e)
        {
            float fontSize = codeArea.Font.Size;
            if (e.Delta > 0)
            {
                fontSize += 1f;
                codeArea.Font = new Font(codeArea.Font.Name, fontSize, codeArea.Font.Style, codeArea.Font.Unit);
            }
            else
            {
                if (fontSize > (float)1)
                {
                    fontSize -= 1f;
                    codeArea.Font = new Font(codeArea.Font.Name, fontSize, codeArea.Font.Style, codeArea.Font.Unit);
                }
            }
        }

        private void dataTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Text += DateTime.Now.ToString();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save";
            saveFileDialog.Filter = "text document(*.txt)|.txt|all files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                codeArea.SaveToFile(saveFileDialog.FileName, System.Text.Encoding.Unicode);
                //.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveFileDialog.FileName;
            }
            codeArea.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open";
            openFileDialog.Filter = "text document(*.txt)|.txt|all files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                codeArea.OpenFile(openFileDialog.FileName, System.Text.Encoding.Unicode);
                // .LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
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
                codeArea.SaveToFile(saveFileDialog.FileName, System.Text.Encoding.Unicode);
                // .SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveFileDialog.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Paste();
        }

        private void selectallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                codeArea.Font = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                codeArea.SelectionColor = colorDialog.Color;
            }
        }

        private void blackThemeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.ForeColor = Color.White;
            codeArea.BackColor = Color.Black;
        }

        private void whiteThemeModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.ForeColor = Color.Black;
            codeArea.BackColor = Color.White;
        }

        private void lightBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.ForeColor = Color.White;
            codeArea.BackColor = Color.AliceBlue;
        }

        private void cutKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Cut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            codeArea.Text = codeArea.Text.Replace(text1, text2);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPagePreviewDialog.Document = printDocument;
            printPagePreviewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(codeArea.Text, codeArea.Font, Brushes.Black, 12, 10);
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.Custom;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.XML;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            codeArea.Language = FastColoredTextBoxNS.Language.Lua;
        }
    }
}