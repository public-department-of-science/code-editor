namespace Code.Editor.Merge
{
    partial class DiffMergeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiffMergeForm));
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSecondFile = new System.Windows.Forms.TextBox();
            this.btSecond = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstFile = new System.Windows.Forms.TextBox();
            this.btFirst = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btCompare = new System.Windows.Forms.Button();
            this.firstTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.secondTextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.firstTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(181, 638);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "Deleted lines";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.Location = new System.Drawing.Point(157, 638);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = " ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 638);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Inserted lines";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.PaleGreen;
            this.label4.Location = new System.Drawing.Point(16, 638);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Second file";
            // 
            // tbSecondFile
            // 
            this.tbSecondFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSecondFile.Location = new System.Drawing.Point(105, 57);
            this.tbSecondFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSecondFile.Name = "tbSecondFile";
            this.tbSecondFile.Size = new System.Drawing.Size(661, 27);
            this.tbSecondFile.TabIndex = 19;
            // 
            // btSecond
            // 
            this.btSecond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSecond.Location = new System.Drawing.Point(776, 52);
            this.btSecond.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btSecond.Name = "btSecond";
            this.btSecond.Size = new System.Drawing.Size(40, 35);
            this.btSecond.TabIndex = 18;
            this.btSecond.Text = "...";
            this.btSecond.UseVisualStyleBackColor = true;
            this.btSecond.Click += new System.EventHandler(this.btSecond_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "First file";
            // 
            // tbFirstFile
            // 
            this.tbFirstFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFirstFile.Location = new System.Drawing.Point(105, 17);
            this.tbFirstFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFirstFile.Name = "tbFirstFile";
            this.tbFirstFile.Size = new System.Drawing.Size(661, 27);
            this.tbFirstFile.TabIndex = 16;
            // 
            // btFirst
            // 
            this.btFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFirst.Location = new System.Drawing.Point(776, 12);
            this.btFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btFirst.Name = "btFirst";
            this.btFirst.Size = new System.Drawing.Size(40, 35);
            this.btFirst.TabIndex = 15;
            this.btFirst.Text = "...";
            this.btFirst.UseVisualStyleBackColor = true;
            this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            this.openFileDialog.ShowReadOnly = true;
            // 
            // btCompare
            // 
            this.btCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCompare.Location = new System.Drawing.Point(716, 97);
            this.btCompare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btCompare.Name = "btCompare";
            this.btCompare.Size = new System.Drawing.Size(100, 35);
            this.btCompare.TabIndex = 25;
            this.btCompare.Text = "Compare";
            this.btCompare.UseVisualStyleBackColor = true;
            this.btCompare.Click += new System.EventHandler(this.btCompare_Click);
            // 
            // firstTextBox
            // 
            this.firstTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.firstTextBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.firstTextBox.AutoScrollMinSize = new System.Drawing.Size(131, 18);
            this.firstTextBox.BackBrush = null;
            this.firstTextBox.CharHeight = 18;
            this.firstTextBox.CharWidth = 10;
            this.firstTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.firstTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.firstTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstTextBox.IsReplaceMode = false;
            this.firstTextBox.Location = new System.Drawing.Point(0, 0);
            this.firstTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstTextBox.Name = "firstTextBox";
            this.firstTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.firstTextBox.ReadOnly = true;
            this.firstTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.firstTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("firstTextBox.ServiceColors")));
            this.firstTextBox.Size = new System.Drawing.Size(456, 478);
            this.firstTextBox.TabIndex = 26;
            this.firstTextBox.Text = "First file";
            this.firstTextBox.Zoom = 100;
            this.firstTextBox.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.firstTextBox.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // secondTextBox
            // 
            this.secondTextBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.secondTextBox.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.secondTextBox.AutoScrollMinSize = new System.Drawing.Size(141, 18);
            this.secondTextBox.BackBrush = null;
            this.secondTextBox.CharHeight = 18;
            this.secondTextBox.CharWidth = 10;
            this.secondTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.secondTextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.secondTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondTextBox.IsReplaceMode = false;
            this.secondTextBox.Location = new System.Drawing.Point(0, 0);
            this.secondTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.secondTextBox.Name = "secondTextBox";
            this.secondTextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.secondTextBox.ReadOnly = true;
            this.secondTextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.secondTextBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("secondTextBox.ServiceColors")));
            this.secondTextBox.Size = new System.Drawing.Size(470, 478);
            this.secondTextBox.TabIndex = 27;
            this.secondTextBox.Text = "Second file";
            this.secondTextBox.Zoom = 100;
            this.secondTextBox.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.secondTextBox.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(16, 142);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.firstTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.secondTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(931, 478);
            this.splitContainer1.SplitterDistance = 456;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 28;
            // 
            // DiffMergeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btCompare);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSecondFile);
            this.Controls.Add(this.btSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFirstFile);
            this.Controls.Add(this.btFirst);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DiffMergeForm";
            this.Text = "DiffMerge";
            ((System.ComponentModel.ISupportInitialize)(this.firstTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondTextBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSecondFile;
        private System.Windows.Forms.Button btSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstFile;
        private System.Windows.Forms.Button btFirst;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btCompare;
        private FastColoredTextBoxNS.FastColoredTextBox firstTextBox;
        private FastColoredTextBoxNS.FastColoredTextBox secondTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}