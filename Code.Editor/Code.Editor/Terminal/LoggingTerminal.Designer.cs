namespace Code.Editor.Terminal
{
    partial class LoggingTerminal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggingTerminal));
            this.btnGotToEnd = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.loggingTerminalArea = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnEmptyTerminalWindow = new System.Windows.Forms.Button();
            this.btnSaveLogs = new System.Windows.Forms.Button();
            this.checkListFilterBoxParams = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loggingTerminalArea)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGotToEnd
            // 
            this.btnGotToEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGotToEnd.Location = new System.Drawing.Point(13, 511);
            this.btnGotToEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGotToEnd.Name = "btnGotToEnd";
            this.btnGotToEnd.Size = new System.Drawing.Size(123, 49);
            this.btnGotToEnd.TabIndex = 6;
            this.btnGotToEnd.Text = "Move to the bottom";
            this.btnGotToEnd.UseVisualStyleBackColor = true;
            this.btnGotToEnd.Click += new System.EventHandler(this.btGotToEnd_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // loggingTerminalArea
            // 
            this.loggingTerminalArea.AutoCompleteBracketsList = new char[] {
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
            this.loggingTerminalArea.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.loggingTerminalArea.AutoScrollMinSize = new System.Drawing.Size(29, 19);
            this.loggingTerminalArea.BackBrush = null;
            this.loggingTerminalArea.CharHeight = 19;
            this.loggingTerminalArea.CharWidth = 9;
            this.loggingTerminalArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.loggingTerminalArea.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.loggingTerminalArea.Dock = System.Windows.Forms.DockStyle.Right;
            this.loggingTerminalArea.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loggingTerminalArea.IsReplaceMode = false;
            this.loggingTerminalArea.Location = new System.Drawing.Point(144, 0);
            this.loggingTerminalArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loggingTerminalArea.Name = "loggingTerminalArea";
            this.loggingTerminalArea.Paddings = new System.Windows.Forms.Padding(0);
            this.loggingTerminalArea.ReadOnly = true;
            this.loggingTerminalArea.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.loggingTerminalArea.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("loggingTerminalArea.ServiceColors")));
            this.loggingTerminalArea.Size = new System.Drawing.Size(540, 574);
            this.loggingTerminalArea.TabIndex = 5;
            this.loggingTerminalArea.Zoom = 100;
            // 
            // btn_EmptifyTerminalWindow
            // 
            this.btnEmptyTerminalWindow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmptyTerminalWindow.Location = new System.Drawing.Point(13, 452);
            this.btnEmptyTerminalWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEmptyTerminalWindow.Name = "btnEmptyTerminalWindow";
            this.btnEmptyTerminalWindow.Size = new System.Drawing.Size(123, 49);
            this.btnEmptyTerminalWindow.TabIndex = 7;
            this.btnEmptyTerminalWindow.Text = "Empty terminal";
            this.btnEmptyTerminalWindow.UseVisualStyleBackColor = true;
            this.btnEmptyTerminalWindow.Click += new System.EventHandler(this.btnEmptifyWindow_Click);
            // 
            // btnSaveLogs
            // 
            this.btnSaveLogs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveLogs.Location = new System.Drawing.Point(13, 393);
            this.btnSaveLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveLogs.Name = "btnSaveLogs";
            this.btnSaveLogs.Size = new System.Drawing.Size(123, 49);
            this.btnSaveLogs.TabIndex = 8;
            this.btnSaveLogs.Text = "Save logging information";
            this.btnSaveLogs.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkListFilterBoxParams.FormattingEnabled = true;
            this.checkListFilterBoxParams.Items.AddRange(new object[] {
            "Info",
            "Debug",
            "Warning",
            "Error",
            "All"});
            this.checkListFilterBoxParams.Location = new System.Drawing.Point(13, 32);
            this.checkListFilterBoxParams.Name = "checkedListBox1";
            this.checkListFilterBoxParams.Size = new System.Drawing.Size(123, 114);
            this.checkListFilterBoxParams.TabIndex = 9;
            this.checkListFilterBoxParams.SelectedValueChanged += new System.EventHandler(this.filterBoxParams_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filter options";
            // 
            // LoggingTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 574);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkListFilterBoxParams);
            this.Controls.Add(this.btnSaveLogs);
            this.Controls.Add(this.btnEmptyTerminalWindow);
            this.Controls.Add(this.loggingTerminalArea);
            this.Controls.Add(this.btnGotToEnd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoggingTerminal";
            this.Text = "Logging terminal";
            ((System.ComponentModel.ISupportInitialize)(this.loggingTerminalArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FastColoredTextBoxNS.FastColoredTextBox loggingTerminalArea;
        private System.Windows.Forms.Button btnGotToEnd;
        private System.Windows.Forms.Timer timer;
        private Button btnEmptyTerminalWindow;
        private Button btnSaveLogs;
        private CheckedListBox checkListFilterBoxParams;
        private Label label1;
    }
}