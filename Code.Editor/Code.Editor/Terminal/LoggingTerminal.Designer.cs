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
            this.btnStopLogging = new System.Windows.Forms.Button();
            this.btnStartLoggin = new System.Windows.Forms.Button();
            this.txtBoxFilterLogsText = new System.Windows.Forms.TextBox();
            this.lblFilteringText = new System.Windows.Forms.Label();
            this.chkBoxIsCaseSensitive = new System.Windows.Forms.CheckBox();
            this.buttonsTerminalSplitter = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.loggingTerminalArea)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGotToEnd
            // 
            this.btnGotToEnd.Location = new System.Drawing.Point(13, 520);
            this.btnGotToEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGotToEnd.Name = "btnGotToEnd";
            this.btnGotToEnd.Size = new System.Drawing.Size(124, 49);
            this.btnGotToEnd.TabIndex = 6;
            this.btnGotToEnd.Text = "Move to the bottom";
            this.btnGotToEnd.UseVisualStyleBackColor = true;
            this.btnGotToEnd.Click += new System.EventHandler(this.btGotToEnd_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // loggingTerminalArea
            // 
            this.loggingTerminalArea.AllowMacroRecording = false;
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
            this.loggingTerminalArea.Location = new System.Drawing.Point(241, 0);
            this.loggingTerminalArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loggingTerminalArea.Name = "loggingTerminalArea";
            this.loggingTerminalArea.Paddings = new System.Windows.Forms.Padding(0);
            this.loggingTerminalArea.ReadOnly = true;
            this.loggingTerminalArea.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.loggingTerminalArea.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("loggingTerminalArea.ServiceColors")));
            this.loggingTerminalArea.Size = new System.Drawing.Size(670, 583);
            this.loggingTerminalArea.TabIndex = 5;
            this.loggingTerminalArea.Zoom = 100;
            // 
            // btnEmptyTerminalWindow
            // 
            this.btnEmptyTerminalWindow.Location = new System.Drawing.Point(13, 461);
            this.btnEmptyTerminalWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEmptyTerminalWindow.Name = "btnEmptyTerminalWindow";
            this.btnEmptyTerminalWindow.Size = new System.Drawing.Size(124, 49);
            this.btnEmptyTerminalWindow.TabIndex = 7;
            this.btnEmptyTerminalWindow.Text = "Empty terminal";
            this.btnEmptyTerminalWindow.UseVisualStyleBackColor = true;
            this.btnEmptyTerminalWindow.Click += new System.EventHandler(this.btnEmptifyWindow_Click);
            // 
            // btnSaveLogs
            // 
            this.btnSaveLogs.Location = new System.Drawing.Point(13, 401);
            this.btnSaveLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveLogs.Name = "btnSaveLogs";
            this.btnSaveLogs.Size = new System.Drawing.Size(124, 50);
            this.btnSaveLogs.TabIndex = 8;
            this.btnSaveLogs.Text = "Save logging information";
            this.btnSaveLogs.UseVisualStyleBackColor = true;
            // 
            // checkListFilterBoxParams
            // 
            this.checkListFilterBoxParams.CheckOnClick = true;
            this.checkListFilterBoxParams.Enabled = false;
            this.checkListFilterBoxParams.FormattingEnabled = true;
            this.checkListFilterBoxParams.Items.AddRange(new object[] {
            "Trace",
            "Info",
            "Debug",
            "Warning",
            "Error"});
            this.checkListFilterBoxParams.Location = new System.Drawing.Point(13, 32);
            this.checkListFilterBoxParams.Name = "checkListFilterBoxParams";
            this.checkListFilterBoxParams.Size = new System.Drawing.Size(124, 114);
            this.checkListFilterBoxParams.TabIndex = 9;
            this.checkListFilterBoxParams.SelectedValueChanged += new System.EventHandler(this.filterBoxParams_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filter options";
            // 
            // btnStopLogging
            // 
            this.btnStopLogging.Location = new System.Drawing.Point(13, 325);
            this.btnStopLogging.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopLogging.Name = "btnStopLogging";
            this.btnStopLogging.Size = new System.Drawing.Size(124, 50);
            this.btnStopLogging.TabIndex = 11;
            this.btnStopLogging.Text = "Stop logging";
            this.btnStopLogging.UseVisualStyleBackColor = true;
            this.btnStopLogging.Click += new System.EventHandler(this.btnStopLogging_Click);
            // 
            // btnStartLoggin
            // 
            this.btnStartLoggin.Location = new System.Drawing.Point(13, 265);
            this.btnStartLoggin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartLoggin.Name = "btnStartLoggin";
            this.btnStartLoggin.Size = new System.Drawing.Size(124, 50);
            this.btnStartLoggin.TabIndex = 12;
            this.btnStartLoggin.Text = "Start logging";
            this.btnStartLoggin.UseVisualStyleBackColor = true;
            this.btnStartLoggin.Click += new System.EventHandler(this.btnStartLogging_Click);
            // 
            // txtBoxFilterLogsText
            // 
            this.txtBoxFilterLogsText.Enabled = false;
            this.txtBoxFilterLogsText.Location = new System.Drawing.Point(13, 191);
            this.txtBoxFilterLogsText.Name = "txtBoxFilterLogsText";
            this.txtBoxFilterLogsText.Size = new System.Drawing.Size(121, 27);
            this.txtBoxFilterLogsText.TabIndex = 13;
            this.txtBoxFilterLogsText.TextChanged += new System.EventHandler(this.txtBoxFilterLogsText_TextChanged);
            // 
            // lblFilteringText
            // 
            this.lblFilteringText.AutoSize = true;
            this.lblFilteringText.Location = new System.Drawing.Point(13, 163);
            this.lblFilteringText.Name = "lblFilteringText";
            this.lblFilteringText.Size = new System.Drawing.Size(92, 20);
            this.lblFilteringText.TabIndex = 14;
            this.lblFilteringText.Text = "Filtering text";
            // 
            // chkBoxIsCaseSensitive
            // 
            this.chkBoxIsCaseSensitive.AutoSize = true;
            this.chkBoxIsCaseSensitive.Enabled = false;
            this.chkBoxIsCaseSensitive.Location = new System.Drawing.Point(16, 233);
            this.chkBoxIsCaseSensitive.Name = "chkBoxIsCaseSensitive";
            this.chkBoxIsCaseSensitive.Size = new System.Drawing.Size(122, 24);
            this.chkBoxIsCaseSensitive.TabIndex = 15;
            this.chkBoxIsCaseSensitive.Text = "Case sensitive";
            this.chkBoxIsCaseSensitive.UseVisualStyleBackColor = true;
            this.chkBoxIsCaseSensitive.CheckedChanged += new System.EventHandler(this.txtBoxFilterLogsText_TextChanged);
            // 
            // buttonsTerminalSplitter
            // 
            this.buttonsTerminalSplitter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonsTerminalSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonsTerminalSplitter.Location = new System.Drawing.Point(237, 0);
            this.buttonsTerminalSplitter.Name = "buttonsTerminalSplitter";
            this.buttonsTerminalSplitter.Size = new System.Drawing.Size(4, 583);
            this.buttonsTerminalSplitter.TabIndex = 16;
            this.buttonsTerminalSplitter.TabStop = false;
            // 
            // LoggingTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 583);
            this.Controls.Add(this.buttonsTerminalSplitter);
            this.Controls.Add(this.chkBoxIsCaseSensitive);
            this.Controls.Add(this.lblFilteringText);
            this.Controls.Add(this.txtBoxFilterLogsText);
            this.Controls.Add(this.btnStartLoggin);
            this.Controls.Add(this.btnStopLogging);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkListFilterBoxParams);
            this.Controls.Add(this.btnSaveLogs);
            this.Controls.Add(this.btnEmptyTerminalWindow);
            this.Controls.Add(this.loggingTerminalArea);
            this.Controls.Add(this.btnGotToEnd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(440, 630);
            this.Name = "LoggingTerminal";
            this.Text = "Logging terminal";
            this.Shown += new System.EventHandler(this.LoggingTerminal_Shown);
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
        private Button btnStopLogging;
        private Button btnStartLoggin;
        private TextBox txtBoxFilterLogsText;
        private Label lblFilteringText;
        private CheckBox chkBoxIsCaseSensitive;
        private Splitter buttonsTerminalSplitter;
    }
}