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
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnGotToEnd = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.loggingTerminalArea = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loggingTerminalArea)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo.Location = new System.Drawing.Point(0, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(473, 62);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Logging information sample";
            // 
            // btnGotToEnd
            // 
            this.btnGotToEnd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGotToEnd.Location = new System.Drawing.Point(0, 445);
            this.btnGotToEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGotToEnd.Name = "btnGotToEnd";
            this.btnGotToEnd.Size = new System.Drawing.Size(473, 35);
            this.btnGotToEnd.TabIndex = 6;
            this.btnGotToEnd.Text = "Go to end";
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
            this.loggingTerminalArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggingTerminalArea.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loggingTerminalArea.IsReplaceMode = false;
            this.loggingTerminalArea.Location = new System.Drawing.Point(0, 62);
            this.loggingTerminalArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loggingTerminalArea.Name = "loggingTerminalArea";
            this.loggingTerminalArea.Paddings = new System.Windows.Forms.Padding(0);
            this.loggingTerminalArea.ReadOnly = true;
            this.loggingTerminalArea.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.loggingTerminalArea.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("loggingTerminalArea.ServiceColors")));
            this.loggingTerminalArea.Size = new System.Drawing.Size(473, 383);
            this.loggingTerminalArea.TabIndex = 5;
            this.loggingTerminalArea.Zoom = 100;
            // 
            // LoggingTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 480);
            this.Controls.Add(this.loggingTerminalArea);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnGotToEnd);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LoggingTerminal";
            this.Text = "LoggerSample";
            ((System.ComponentModel.ISupportInitialize)(this.loggingTerminalArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private FastColoredTextBoxNS.FastColoredTextBox loggingTerminalArea;
        private System.Windows.Forms.Button btnGotToEnd;
        private System.Windows.Forms.Timer timer;
    }
}