using FastColoredTextBoxNS;
using Range = FastColoredTextBoxNS.Range;

namespace Code.Editor.Merge
{
    public partial class DiffMergeForm : Form
    {
        int updating;
        Style greenStyle;
        Style redStyle;

        public DiffMergeForm()
        {
            InitializeComponent();

            greenStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Lime)));
            redStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Red)));
        }

        private void btSecond_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbSecondFile.Text = openFileDialog.FileName;
            }
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFirstFile.Text = openFileDialog.FileName;
            }
        }

        void tb_VisibleRangeChanged(object sender, EventArgs e)
        {
            if (updating > 0)
            {
                return;
            }

            var vPos = (sender as FastColoredTextBox).VerticalScroll.Value;
            var curLine = (sender as FastColoredTextBox).Selection.Start.iLine;

            if (sender == secondTextBox)
            {
                UpdateScroll(firstTextBox, vPos, curLine);
            }
            else
            {
                UpdateScroll(secondTextBox, vPos, curLine);
            }

            firstTextBox.Refresh();
            secondTextBox.Refresh();
        }

        void UpdateScroll(FastColoredTextBox tb, int vPos, int curLine)
        {
            if (updating > 0)
            {
                return;
            }

            BeginUpdate();

            if (vPos <= tb.VerticalScroll.Maximum)
            {
                tb.VerticalScroll.Value = vPos;
                tb.UpdateScrollbars();
            }

            if (curLine < tb.LinesCount)
            {
                tb.Selection = new Range(tb, 0, curLine, 0, curLine);
            }
            EndUpdate();
        }

        private void EndUpdate()
        {
            updating--;
        }

        private void BeginUpdate()
        {
            updating++;
        }

        private void btCompare_Click(object sender, EventArgs e)
        {
            if (!File.Exists(tbFirstFile.Text) && !File.Exists(tbSecondFile.Text))
            {
                MessageBox.Show(this, "Please select a valid file", "Invalid file");
                return;
            }

            firstTextBox.Clear();
            secondTextBox.Clear();

            Cursor = Cursors.WaitCursor;

            if (Path.GetExtension(tbFirstFile.Text).ToLower() == ".cs")
                firstTextBox.Language = secondTextBox.Language = Language.CSharp;
            else
                firstTextBox.Language = secondTextBox.Language = Language.Custom;

            var source1 = Lines.Load(tbFirstFile.Text);
            var source2 = Lines.Load(tbSecondFile.Text);

            source1.Merge(source2);

            BeginUpdate();
            Process(source1);
            EndUpdate();

            Cursor = Cursors.Default;
        }

        private void Process(Lines lines)
        {
            foreach (var line in lines)
            {
                switch (line.state)
                {
                    case DiffType.None:
                        {
                            firstTextBox.AppendText(line.line + Environment.NewLine);
                            secondTextBox.AppendText(line.line + Environment.NewLine);
                            break;
                        }
                    case DiffType.Inserted:
                        {
                            firstTextBox.AppendText(Environment.NewLine);
                            secondTextBox.AppendText(line.line + Environment.NewLine, greenStyle);
                            break;
                        }
                    case DiffType.Deleted:
                        {
                            firstTextBox.AppendText(line.line + Environment.NewLine, redStyle);
                            secondTextBox.AppendText(Environment.NewLine);
                            break;
                        }
                }
                if (line.subLines != null)
                {
                    Process(line.subLines);
                }
            }
        }
    }
}
