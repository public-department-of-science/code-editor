using Code.Editor.Settings;
using FastColoredTextBoxNS;

namespace Code.Editor
{

    public partial class CodeEditorMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private static ReadOnlyStyle readOnlyStyle = new ReadOnlyStyle();
        private static TextStyle hyperLinksStyle = new TextStyle(Brushes.Blue, null, FontStyle.Underline);
        private static CodeEditorSettings codeEditorSettings = new CodeEditorSettings();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditorMainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSharpLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pHPLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lUALangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONLangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeCodeAreaHotKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeareaBgColorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.documentMapBgColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectexplorerBgColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opentabPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsTerminalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTwoFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentMap = new FastColoredTextBoxNS.DocumentMap();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.labelWordUnderMouse = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.zoom300Item = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom200Item = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom150Item = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom100Item = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom50Item = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom25Item = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.newTabToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.buttonInvisibleSymbols = new System.Windows.Forms.ToolStripButton();
            this.buttonHighlightCurrentLine = new System.Windows.Forms.ToolStripButton();
            this.buttonShowFoldingLines = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonUndoStrip = new System.Windows.Forms.ToolStripButton();
            this.buttonRedoStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBackwardStrip = new System.Windows.Forms.ToolStripButton();
            this.buttonForwardStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.labelFindStrip = new System.Windows.Forms.ToolStripLabel();
            this.textboxFind = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBookmarkPlus = new System.Windows.Forms.ToolStripButton();
            this.buttonBookmarkMinus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonGotoBookmark = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.commentCodeStripButton = new System.Windows.Forms.ToolStripButton();
            this.uncommentCodeStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.documentMapStripButton = new System.Windows.Forms.ToolStripButton();
            this.wordWrapToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.justForTest1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecuteCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.codeAreaContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeAreaContextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeAreaContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeAreaContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.markAsReadonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsWriteableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.autoIndentSelectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesAndCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmUpdateInterface = new System.Windows.Forms.Timer(this.components);
            this.imageListAutocomplete = new System.Windows.Forms.ImageList(this.components);
            this.documentMapSplitter = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datagridviewerObjectExplorer = new System.Windows.Forms.DataGridView();
            this.datagridviewerImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.datagridviewerTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFilesTabs = new FarsiLibrary.Win.FATabStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmBoxMembers = new System.Windows.Forms.ComboBox();
            this.cmBoxNamespaces = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.toolStripMenu.SuspendLayout();
            this.codeAreaContextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewerObjectExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openFilesTabs)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(964, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuSeparator,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.saveAsToolStripMenuItem.Text = "Save as ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuSeparator
            // 
            this.toolStripMenuSeparator.Name = "toolStripMenuSeparator";
            this.toolStripMenuSeparator.Size = new System.Drawing.Size(241, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customLangToolStripMenuItem,
            this.cSharpLangToolStripMenuItem,
            this.hTMLLangToolStripMenuItem,
            this.xMLLangToolStripMenuItem,
            this.sQLLangToolStripMenuItem,
            this.pHPLangToolStripMenuItem,
            this.jSLangToolStripMenuItem,
            this.lUALangToolStripMenuItem,
            this.jSONLangToolStripMenuItem,
            this.vBToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // customLangToolStripMenuItem
            // 
            this.customLangToolStripMenuItem.Name = "customLangToolStripMenuItem";
            this.customLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.customLangToolStripMenuItem.Tag = "Custom";
            this.customLangToolStripMenuItem.Text = "Custom";
            this.customLangToolStripMenuItem.Click += new System.EventHandler(this.customLangToolStripMenuItem_Click);
            // 
            // cSharpLangToolStripMenuItem
            // 
            this.cSharpLangToolStripMenuItem.Name = "cSharpLangToolStripMenuItem";
            this.cSharpLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.cSharpLangToolStripMenuItem.Tag = "C#";
            this.cSharpLangToolStripMenuItem.Text = "C#";
            this.cSharpLangToolStripMenuItem.Click += new System.EventHandler(this.cSharpLangToolStripMenuItem_Click);
            // 
            // hTMLLangToolStripMenuItem
            // 
            this.hTMLLangToolStripMenuItem.Name = "hTMLLangToolStripMenuItem";
            this.hTMLLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.hTMLLangToolStripMenuItem.Tag = "HTML";
            this.hTMLLangToolStripMenuItem.Text = "HTML";
            this.hTMLLangToolStripMenuItem.Click += new System.EventHandler(this.hTMLLangToolStripMenuItem_Click);
            // 
            // xMLLangToolStripMenuItem
            // 
            this.xMLLangToolStripMenuItem.Name = "xMLLangToolStripMenuItem";
            this.xMLLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.xMLLangToolStripMenuItem.Tag = "XML";
            this.xMLLangToolStripMenuItem.Text = "XML";
            this.xMLLangToolStripMenuItem.Click += new System.EventHandler(this.xMLLangToolStripMenuItem_Click);
            // 
            // sQLLangToolStripMenuItem
            // 
            this.sQLLangToolStripMenuItem.Name = "sQLLangToolStripMenuItem";
            this.sQLLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.sQLLangToolStripMenuItem.Tag = "SQL";
            this.sQLLangToolStripMenuItem.Text = "SQL";
            this.sQLLangToolStripMenuItem.Click += new System.EventHandler(this.sQLLangToolStripMenuItem_Click);
            // 
            // pHPLangToolStripMenuItem
            // 
            this.pHPLangToolStripMenuItem.Name = "pHPLangToolStripMenuItem";
            this.pHPLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.pHPLangToolStripMenuItem.Tag = "PHP";
            this.pHPLangToolStripMenuItem.Text = "PHP";
            this.pHPLangToolStripMenuItem.Click += new System.EventHandler(this.pHPLangToolStripMenuItem_Click);
            // 
            // jSLangToolStripMenuItem
            // 
            this.jSLangToolStripMenuItem.Name = "jSLangToolStripMenuItem";
            this.jSLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.jSLangToolStripMenuItem.Tag = "JS";
            this.jSLangToolStripMenuItem.Text = "JS";
            this.jSLangToolStripMenuItem.Click += new System.EventHandler(this.jSLangToolStripMenuItem_Click);
            // 
            // lUALangToolStripMenuItem
            // 
            this.lUALangToolStripMenuItem.Name = "lUALangToolStripMenuItem";
            this.lUALangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.lUALangToolStripMenuItem.Tag = "LUA";
            this.lUALangToolStripMenuItem.Text = "LUA";
            this.lUALangToolStripMenuItem.Click += new System.EventHandler(this.lUALangToolStripMenuItem_Click);
            // 
            // jSONLangToolStripMenuItem
            // 
            this.jSONLangToolStripMenuItem.Name = "jSONLangToolStripMenuItem";
            this.jSONLangToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.jSONLangToolStripMenuItem.Tag = "JSON";
            this.jSONLangToolStripMenuItem.Text = "JSON";
            this.jSONLangToolStripMenuItem.Click += new System.EventHandler(this.jSONLangToolStripMenuItem_Click);
            // 
            // vBToolStripMenuItem
            // 
            this.vBToolStripMenuItem.Name = "vBToolStripMenuItem";
            this.vBToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.vBToolStripMenuItem.Tag = "VB";
            this.vBToolStripMenuItem.Text = "VB";
            this.vBToolStripMenuItem.Click += new System.EventHandler(this.vBLangToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotKeysToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // hotKeysToolStripMenuItem
            // 
            this.hotKeysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeCodeAreaHotKeysToolStripMenuItem,
            this.restoreDefaultToolStripMenuItem});
            this.hotKeysToolStripMenuItem.Name = "hotKeysToolStripMenuItem";
            this.hotKeysToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.hotKeysToolStripMenuItem.Text = "HotKeys - Binding";
            // 
            // customizeCodeAreaHotKeysToolStripMenuItem
            // 
            this.customizeCodeAreaHotKeysToolStripMenuItem.Name = "customizeCodeAreaHotKeysToolStripMenuItem";
            this.customizeCodeAreaHotKeysToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.customizeCodeAreaHotKeysToolStripMenuItem.Text = "Code-area";
            this.customizeCodeAreaHotKeysToolStripMenuItem.Click += new System.EventHandler(this.customizeCodeAreaHotKeysToolStripMenuItem_Click);
            // 
            // restoreDefaultToolStripMenuItem
            // 
            this.restoreDefaultToolStripMenuItem.Name = "restoreDefaultToolStripMenuItem";
            this.restoreDefaultToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.restoreDefaultToolStripMenuItem.Text = "Restore default";
            this.restoreDefaultToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultCodeAreaHotKeysToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codeareaBgColorToolStripMenuItem1,
            this.documentMapBgColorToolStripMenuItem,
            this.objectexplorerBgColorToolStripMenuItem,
            this.opentabPanelToolStripMenuItem,
            this.restoreDefaultColorsToolStripMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.backgroundToolStripMenuItem.Text = "Background-Color";
            // 
            // codeareaBgColorToolStripMenuItem1
            // 
            this.codeareaBgColorToolStripMenuItem1.Name = "codeareaBgColorToolStripMenuItem1";
            this.codeareaBgColorToolStripMenuItem1.Size = new System.Drawing.Size(237, 26);
            this.codeareaBgColorToolStripMenuItem1.Text = "Code-area";
            this.codeareaBgColorToolStripMenuItem1.Click += new System.EventHandler(this.codeareaColorToolStripMenuItem1_Click);
            // 
            // documentMapBgColorToolStripMenuItem
            // 
            this.documentMapBgColorToolStripMenuItem.Name = "documentMapBgColorToolStripMenuItem";
            this.documentMapBgColorToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.documentMapBgColorToolStripMenuItem.Text = "Document-Map";
            this.documentMapBgColorToolStripMenuItem.Click += new System.EventHandler(this.documentMapColorToolStripMenuItem_Click);
            // 
            // objectexplorerBgColorToolStripMenuItem
            // 
            this.objectexplorerBgColorToolStripMenuItem.Name = "objectexplorerBgColorToolStripMenuItem";
            this.objectexplorerBgColorToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.objectexplorerBgColorToolStripMenuItem.Text = "Object-explorer";
            this.objectexplorerBgColorToolStripMenuItem.Click += new System.EventHandler(this.objectexplorerColorToolStripMenuItem_Click);
            // 
            // opentabPanelToolStripMenuItem
            // 
            this.opentabPanelToolStripMenuItem.Name = "opentabPanelToolStripMenuItem";
            this.opentabPanelToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.opentabPanelToolStripMenuItem.Text = "Open-files tabs";
            this.opentabPanelToolStripMenuItem.Click += new System.EventHandler(this.opentabColorPanelToolStripMenuItem_Click);
            // 
            // restoreDefaultColorsToolStripMenuItem
            // 
            this.restoreDefaultColorsToolStripMenuItem.Name = "restoreDefaultColorsToolStripMenuItem";
            this.restoreDefaultColorsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.restoreDefaultColorsToolStripMenuItem.Text = "Restore default colors";
            this.restoreDefaultColorsToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultColorsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminalToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // terminalToolStripMenuItem
            // 
            this.terminalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.outputTerminalToolStripMenuItem,
            this.loggingTerminalToolStripMenuItem,
            this.errorsTerminalToolStripMenuItem});
            this.terminalToolStripMenuItem.Name = "terminalToolStripMenuItem";
            this.terminalToolStripMenuItem.Size = new System.Drawing.Size(149, 26);
            this.terminalToolStripMenuItem.Text = "Terminal";
            // 
            // outputTerminalToolStripMenuItem
            // 
            this.outputTerminalToolStripMenuItem.Name = "outputTerminalToolStripMenuItem";
            this.outputTerminalToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.outputTerminalToolStripMenuItem.Text = "Output terminal";
            // 
            // loggingTerminalToolStripMenuItem
            // 
            this.loggingTerminalToolStripMenuItem.Name = "loggingTerminalToolStripMenuItem";
            this.loggingTerminalToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.loggingTerminalToolStripMenuItem.Text = "Logging terminal";
            this.loggingTerminalToolStripMenuItem.Click += new System.EventHandler(this.loggingTerminalToolStripMenuItem_Click);
            // 
            // errorsTerminalToolStripMenuItem
            // 
            this.errorsTerminalToolStripMenuItem.Name = "errorsTerminalToolStripMenuItem";
            this.errorsTerminalToolStripMenuItem.Size = new System.Drawing.Size(206, 26);
            this.errorsTerminalToolStripMenuItem.Text = "Errors terminal";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareTwoFilesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // compareTwoFilesToolStripMenuItem
            // 
            this.compareTwoFilesToolStripMenuItem.Name = "compareTwoFilesToolStripMenuItem";
            this.compareTwoFilesToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.compareTwoFilesToolStripMenuItem.Text = "Merge Files";
            this.compareTwoFilesToolStripMenuItem.Click += new System.EventHandler(this.compareTwoFilesToolStripMenuItem_Click);
            // 
            // documentMap
            // 
            this.documentMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.documentMap.ForeColor = System.Drawing.Color.Maroon;
            this.documentMap.Location = new System.Drawing.Point(964, 0);
            this.documentMap.Margin = new System.Windows.Forms.Padding(4);
            this.documentMap.MaximumSize = new System.Drawing.Size(200, 0);
            this.documentMap.MinimumSize = new System.Drawing.Size(75, 0);
            this.documentMap.Name = "documentMap";
            this.documentMap.Size = new System.Drawing.Size(200, 653);
            this.documentMap.TabIndex = 1;
            this.documentMap.Target = null;
            this.documentMap.Text = "documentMap";
            this.documentMap.Visible = false;
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelWordUnderMouse,
            this.buttonZoom});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 627);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(964, 26);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // labelWordUnderMouse
            // 
            this.labelWordUnderMouse.AutoSize = false;
            this.labelWordUnderMouse.ForeColor = System.Drawing.Color.Gray;
            this.labelWordUnderMouse.Name = "labelWordUnderMouse";
            this.labelWordUnderMouse.Size = new System.Drawing.Size(876, 20);
            this.labelWordUnderMouse.Spring = true;
            this.labelWordUnderMouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonZoom
            // 
            this.buttonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom300Item,
            this.zoom200Item,
            this.zoom150Item,
            this.zoom100Item,
            this.zoom50Item,
            this.zoom25Item});
            this.buttonZoom.Image = ((System.Drawing.Image)(resources.GetObject("buttonZoom.Image")));
            this.buttonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(68, 24);
            this.buttonZoom.Text = "Zoom";
            // 
            // zoom300Item
            // 
            this.zoom300Item.Name = "zoom300Item";
            this.zoom300Item.Size = new System.Drawing.Size(128, 26);
            this.zoom300Item.Tag = "300";
            this.zoom300Item.Text = "300%";
            this.zoom300Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // zoom200Item
            // 
            this.zoom200Item.Name = "zoom200Item";
            this.zoom200Item.Size = new System.Drawing.Size(128, 26);
            this.zoom200Item.Tag = "200";
            this.zoom200Item.Text = "200%";
            this.zoom200Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // zoom150Item
            // 
            this.zoom150Item.Name = "zoom150Item";
            this.zoom150Item.Size = new System.Drawing.Size(128, 26);
            this.zoom150Item.Tag = "150";
            this.zoom150Item.Text = "150%";
            this.zoom150Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // zoom100Item
            // 
            this.zoom100Item.Name = "zoom100Item";
            this.zoom100Item.Size = new System.Drawing.Size(128, 26);
            this.zoom100Item.Tag = "100";
            this.zoom100Item.Text = "100%";
            this.zoom100Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // zoom50Item
            // 
            this.zoom50Item.Name = "zoom50Item";
            this.zoom50Item.Size = new System.Drawing.Size(128, 26);
            this.zoom50Item.Tag = "50";
            this.zoom50Item.Text = "50%";
            this.zoom50Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // zoom25Item
            // 
            this.zoom25Item.Name = "zoom25Item";
            this.zoom25Item.Size = new System.Drawing.Size(128, 26);
            this.zoom25Item.Tag = "25";
            this.zoom25Item.Text = "25%";
            this.zoom25Item.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator3,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.buttonInvisibleSymbols,
            this.buttonHighlightCurrentLine,
            this.buttonShowFoldingLines,
            this.toolStripSeparator4,
            this.buttonUndoStrip,
            this.buttonRedoStrip,
            this.toolStripSeparator5,
            this.buttonBackwardStrip,
            this.buttonForwardStrip,
            this.toolStripSeparator11,
            this.labelFindStrip,
            this.textboxFind,
            this.toolStripSeparator6,
            this.buttonBookmarkPlus,
            this.buttonBookmarkMinus,
            this.toolStripSeparator7,
            this.buttonGotoBookmark,
            this.toolStripSeparator8,
            this.commentCodeStripButton,
            this.uncommentCodeStripButton,
            this.toolStripSeparator10,
            this.documentMapStripButton,
            this.wordWrapToolStripButton,
            this.toolStripDropDownButton1,
            this.ExecuteCode});
            this.toolStripMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripMenu.Location = new System.Drawing.Point(0, 30);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(964, 54);
            this.toolStripMenu.TabIndex = 3;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // newTabToolStripButton
            // 
            this.newTabToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTabToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newTabToolStripButton.Image")));
            this.newTabToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTabToolStripButton.Name = "newTabToolStripButton";
            this.newTabToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.newTabToolStripButton.Text = "&New";
            this.newTabToolStripButton.Click += new System.EventHandler(this.newTabButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openButtonMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutButton_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // buttonInvisibleSymbols
            // 
            this.buttonInvisibleSymbols.CheckOnClick = true;
            this.buttonInvisibleSymbols.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonInvisibleSymbols.Image = ((System.Drawing.Image)(resources.GetObject("buttonInvisibleSymbols.Image")));
            this.buttonInvisibleSymbols.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonInvisibleSymbols.Name = "buttonInvisibleSymbols";
            this.buttonInvisibleSymbols.Size = new System.Drawing.Size(29, 24);
            this.buttonInvisibleSymbols.Text = "¶";
            this.buttonInvisibleSymbols.ToolTipText = "Show invisible chars";
            this.buttonInvisibleSymbols.Click += new System.EventHandler(this.btInvisibleChars_Click);
            // 
            // buttonHighlightCurrentLine
            // 
            this.buttonHighlightCurrentLine.CheckOnClick = true;
            this.buttonHighlightCurrentLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonHighlightCurrentLine.Image = global::Code.Editor.Properties.Resources.edit_padding_top;
            this.buttonHighlightCurrentLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonHighlightCurrentLine.Name = "buttonHighlightCurrentLine";
            this.buttonHighlightCurrentLine.Size = new System.Drawing.Size(29, 24);
            this.buttonHighlightCurrentLine.Text = "Highlight current line";
            this.buttonHighlightCurrentLine.ToolTipText = "Highlight current line";
            this.buttonHighlightCurrentLine.Click += new System.EventHandler(this.btHighlightCurrentLine_Click);
            // 
            // buttonShowFoldingLines
            // 
            this.buttonShowFoldingLines.Checked = true;
            this.buttonShowFoldingLines.CheckOnClick = true;
            this.buttonShowFoldingLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonShowFoldingLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonShowFoldingLines.Image = global::Code.Editor.Properties.Resources.btShowFoldingLines_Image;
            this.buttonShowFoldingLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowFoldingLines.Name = "buttonShowFoldingLines";
            this.buttonShowFoldingLines.Size = new System.Drawing.Size(29, 24);
            this.buttonShowFoldingLines.Text = "Show folding lines";
            this.buttonShowFoldingLines.Click += new System.EventHandler(this.btShowFoldingLines_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonUndoStrip
            // 
            this.buttonUndoStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUndoStrip.Image = global::Code.Editor.Properties.Resources.undo_16x16;
            this.buttonUndoStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUndoStrip.Name = "buttonUndoStrip";
            this.buttonUndoStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonUndoStrip.Text = "Undo (Ctrl+Z)";
            this.buttonUndoStrip.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // buttonRedoStrip
            // 
            this.buttonRedoStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRedoStrip.Image = global::Code.Editor.Properties.Resources.redo_16x16;
            this.buttonRedoStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRedoStrip.Name = "buttonRedoStrip";
            this.buttonRedoStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonRedoStrip.Text = "Redo (Ctrl+R)";
            this.buttonRedoStrip.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonBackwardStrip
            // 
            this.buttonBackwardStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBackwardStrip.Image = global::Code.Editor.Properties.Resources.backward0_16x16;
            this.buttonBackwardStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackwardStrip.Name = "buttonBackwardStrip";
            this.buttonBackwardStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonBackwardStrip.Text = "Navigate Backward (Ctrl+ -)";
            this.buttonBackwardStrip.Click += new System.EventHandler(this.backStripButton_Click);
            // 
            // buttonForwardStrip
            // 
            this.buttonForwardStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonForwardStrip.Image = global::Code.Editor.Properties.Resources.forward_16x16;
            this.buttonForwardStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonForwardStrip.Name = "buttonForwardStrip";
            this.buttonForwardStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonForwardStrip.Text = "Navigate Forward (Ctrl+Shift+ -)";
            this.buttonForwardStrip.Click += new System.EventHandler(this.forwardStripButton_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 23);
            // 
            // labelFindStrip
            // 
            this.labelFindStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelFindStrip.Name = "labelFindStrip";
            this.labelFindStrip.Size = new System.Drawing.Size(44, 20);
            this.labelFindStrip.Text = "Find: ";
            // 
            // textboxFind
            // 
            this.textboxFind.AcceptsReturn = true;
            this.textboxFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.textboxFind.Name = "textboxFind";
            this.textboxFind.Size = new System.Drawing.Size(132, 27);
            this.textboxFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonBookmarkPlus
            // 
            this.buttonBookmarkPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBookmarkPlus.Image = global::Code.Editor.Properties.Resources.layer__plus;
            this.buttonBookmarkPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBookmarkPlus.Name = "buttonBookmarkPlus";
            this.buttonBookmarkPlus.Size = new System.Drawing.Size(29, 24);
            this.buttonBookmarkPlus.Text = "Add bookmark (Ctrl-B)";
            this.buttonBookmarkPlus.Click += new System.EventHandler(this.bookmarkPlusButton_Click);
            // 
            // buttonBookmarkMinus
            // 
            this.buttonBookmarkMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBookmarkMinus.Image = global::Code.Editor.Properties.Resources.layer__minus;
            this.buttonBookmarkMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBookmarkMinus.Name = "buttonBookmarkMinus";
            this.buttonBookmarkMinus.Size = new System.Drawing.Size(29, 24);
            this.buttonBookmarkMinus.Text = "Remove bookmark (Ctrl-Shift-B)";
            this.buttonBookmarkMinus.Click += new System.EventHandler(this.bookmarkMinusButton_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonGotoBookmark
            // 
            this.buttonGotoBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonGotoBookmark.Image = ((System.Drawing.Image)(resources.GetObject("buttonGotoBookmark.Image")));
            this.buttonGotoBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGotoBookmark.Name = "buttonGotoBookmark";
            this.buttonGotoBookmark.Size = new System.Drawing.Size(131, 24);
            this.buttonGotoBookmark.Text = "Go to bookmark";
            this.buttonGotoBookmark.DropDownOpening += new System.EventHandler(this.gotoButton_DropDownOpening);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // commentCodeStripButton
            // 
            this.commentCodeStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.commentCodeStripButton.Image = global::Code.Editor.Properties.Resources.commentCode;
            this.commentCodeStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.commentCodeStripButton.Name = "commentCodeStripButton";
            this.commentCodeStripButton.Size = new System.Drawing.Size(29, 24);
            this.commentCodeStripButton.Tag = "Comment selected code lines";
            this.commentCodeStripButton.Text = "Comment selected code lines";
            this.commentCodeStripButton.Click += new System.EventHandler(this.commentCodeLinesButton_Click);
            // 
            // uncommentCodeStripButton
            // 
            this.uncommentCodeStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.uncommentCodeStripButton.Image = global::Code.Editor.Properties.Resources.uncommentCode;
            this.uncommentCodeStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uncommentCodeStripButton.Name = "uncommentCodeStripButton";
            this.uncommentCodeStripButton.Size = new System.Drawing.Size(29, 24);
            this.uncommentCodeStripButton.Tag = "Uncomment selected code lines";
            this.uncommentCodeStripButton.Text = "Uncomment selected code lines";
            this.uncommentCodeStripButton.Click += new System.EventHandler(this.uncommentCodeLinesButton_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // documentMapStripButton
            // 
            this.documentMapStripButton.CheckOnClick = true;
            this.documentMapStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.documentMapStripButton.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.documentMapStripButton.Image = global::Code.Editor.Properties.Resources.documentMapImage;
            this.documentMapStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.documentMapStripButton.Name = "documentMapStripButton";
            this.documentMapStripButton.Size = new System.Drawing.Size(29, 24);
            this.documentMapStripButton.Text = "Document map";
            this.documentMapStripButton.Click += new System.EventHandler(this.documentMapStripButton_Click);
            // 
            // wordWrapToolStripButton
            // 
            this.wordWrapToolStripButton.Checked = true;
            this.wordWrapToolStripButton.CheckOnClick = true;
            this.wordWrapToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wordWrapToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wordWrapToolStripButton.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.wordWrapToolStripButton.Image = global::Code.Editor.Properties.Resources.word_wrap_image;
            this.wordWrapToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wordWrapToolStripButton.Name = "wordWrapToolStripButton";
            this.wordWrapToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.wordWrapToolStripButton.Text = "Word wrap";
            this.wordWrapToolStripButton.Click += new System.EventHandler(this.wordWrapToolStripButton_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.justForTest1ToolStripMenuItem,
            this.test2ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // justForTest1ToolStripMenuItem
            // 
            this.justForTest1ToolStripMenuItem.CheckOnClick = true;
            this.justForTest1ToolStripMenuItem.Name = "justForTest1ToolStripMenuItem";
            this.justForTest1ToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.justForTest1ToolStripMenuItem.Text = "Just for test 1";
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.test2ToolStripMenuItem.Text = "test 2";
            // 
            // ExecuteCode
            // 
            this.ExecuteCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExecuteCode.Image = ((System.Drawing.Image)(resources.GetObject("ExecuteCode.Image")));
            this.ExecuteCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExecuteCode.Name = "ExecuteCode";
            this.ExecuteCode.Size = new System.Drawing.Size(29, 24);
            this.ExecuteCode.Text = "Execute program code";
            this.ExecuteCode.Click += new System.EventHandler(this.ExecuteCode_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 84);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 543);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // saveFileDialogMain
            // 
            this.saveFileDialogMain.DefaultExt = "cs";
            this.saveFileDialogMain.Filter = "C# file(*.cs)|*.cs|All files|*.*";
            // 
            // openFileDialogMain
            // 
            this.openFileDialogMain.DefaultExt = "cs";
            this.openFileDialogMain.Filter = "C# file(*.cs)|*.cs|All files|*.*";
            // 
            // codeAreaContextMenu
            // 
            this.codeAreaContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.codeAreaContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.codeAreaContextMenuSeparator,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.codeAreaContextMenuSeparator1,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.codeAreaContextMenuSeparator2,
            this.markAsReadonlyToolStripMenuItem,
            this.markAsWriteableToolStripMenuItem,
            this.toolStripSeparator9,
            this.autoIndentSelectedTextToolStripMenuItem,
            this.commentSelectedToolStripMenuItem,
            this.uncommentSelectedToolStripMenuItem,
            this.cloneLinesToolStripMenuItem,
            this.cloneLinesAndCommentToolStripMenuItem});
            this.codeAreaContextMenu.Name = "cmMain";
            this.codeAreaContextMenu.Size = new System.Drawing.Size(257, 388);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // codeAreaContextMenuSeparator
            // 
            this.codeAreaContextMenuSeparator.Name = "codeAreaContextMenuSeparator";
            this.codeAreaContextMenuSeparator.Size = new System.Drawing.Size(253, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // codeAreaContextMenuSeparator1
            // 
            this.codeAreaContextMenuSeparator1.Name = "codeAreaContextMenuSeparator1";
            this.codeAreaContextMenuSeparator1.Size = new System.Drawing.Size(253, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // codeAreaContextMenuSeparator2
            // 
            this.codeAreaContextMenuSeparator2.Name = "codeAreaContextMenuSeparator2";
            this.codeAreaContextMenuSeparator2.Size = new System.Drawing.Size(253, 6);
            // 
            // markAsReadonlyToolStripMenuItem
            // 
            this.markAsReadonlyToolStripMenuItem.Name = "markAsReadonlyToolStripMenuItem";
            this.markAsReadonlyToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.markAsReadonlyToolStripMenuItem.Text = "Mark text as \'read-only\'";
            this.markAsReadonlyToolStripMenuItem.Click += new System.EventHandler(this.markAsReadonlyToolStripMenuItem_Click);
            // 
            // markAsWriteableToolStripMenuItem
            // 
            this.markAsWriteableToolStripMenuItem.Name = "markAsWriteableToolStripMenuItem";
            this.markAsWriteableToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.markAsWriteableToolStripMenuItem.Text = "Mark text as \'writable\'";
            this.markAsWriteableToolStripMenuItem.Click += new System.EventHandler(this.markAsWriteableToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(253, 6);
            // 
            // autoIndentSelectedTextToolStripMenuItem
            // 
            this.autoIndentSelectedTextToolStripMenuItem.Name = "autoIndentSelectedTextToolStripMenuItem";
            this.autoIndentSelectedTextToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.autoIndentSelectedTextToolStripMenuItem.Text = "AutoIndent selected text";
            this.autoIndentSelectedTextToolStripMenuItem.Click += new System.EventHandler(this.autoIndentSelectedTextToolStripMenuItem_Click);
            // 
            // commentSelectedToolStripMenuItem
            // 
            this.commentSelectedToolStripMenuItem.Name = "commentSelectedToolStripMenuItem";
            this.commentSelectedToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.commentSelectedToolStripMenuItem.Text = "Comment selected";
            this.commentSelectedToolStripMenuItem.Click += new System.EventHandler(this.commentSelectedToolStripMenuItem_Click);
            // 
            // uncommentSelectedToolStripMenuItem
            // 
            this.uncommentSelectedToolStripMenuItem.Name = "uncommentSelectedToolStripMenuItem";
            this.uncommentSelectedToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.uncommentSelectedToolStripMenuItem.Text = "Uncomment selected";
            this.uncommentSelectedToolStripMenuItem.Click += new System.EventHandler(this.uncommentSelectedToolStripMenuItem_Click);
            // 
            // cloneLinesToolStripMenuItem
            // 
            this.cloneLinesToolStripMenuItem.Name = "cloneLinesToolStripMenuItem";
            this.cloneLinesToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.cloneLinesToolStripMenuItem.Text = "Clone line(s)";
            this.cloneLinesToolStripMenuItem.Click += new System.EventHandler(this.cloneLinesToolStripMenuItem_Click);
            // 
            // cloneLinesAndCommentToolStripMenuItem
            // 
            this.cloneLinesAndCommentToolStripMenuItem.Name = "cloneLinesAndCommentToolStripMenuItem";
            this.cloneLinesAndCommentToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.cloneLinesAndCommentToolStripMenuItem.Text = "Clone line(s) and comment";
            this.cloneLinesAndCommentToolStripMenuItem.Click += new System.EventHandler(this.cloneLinesAndCommentToolStripMenuItem_Click);
            // 
            // tmUpdateInterface
            // 
            this.tmUpdateInterface.Enabled = true;
            this.tmUpdateInterface.Interval = 400;
            this.tmUpdateInterface.Tick += new System.EventHandler(this.tmUpdateInterface_Tick);
            // 
            // imageListAutocomplete
            // 
            this.imageListAutocomplete.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListAutocomplete.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListAutocomplete.ImageStream")));
            this.imageListAutocomplete.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListAutocomplete.Images.SetKeyName(0, "box.png");
            this.imageListAutocomplete.Images.SetKeyName(1, "backward0_16x16.png");
            this.imageListAutocomplete.Images.SetKeyName(2, "bookmark--plus.png");
            // 
            // documentMapSplitter
            // 
            this.documentMapSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.documentMapSplitter.Location = new System.Drawing.Point(960, 84);
            this.documentMapSplitter.Name = "documentMapSplitter";
            this.documentMapSplitter.Size = new System.Drawing.Size(4, 543);
            this.documentMapSplitter.TabIndex = 7;
            this.documentMapSplitter.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.datagridviewerObjectExplorer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.openFilesTabs, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(956, 543);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // datagridviewerObjectExplorer
            // 
            this.datagridviewerObjectExplorer.AllowUserToAddRows = false;
            this.datagridviewerObjectExplorer.AllowUserToDeleteRows = false;
            this.datagridviewerObjectExplorer.AllowUserToResizeColumns = false;
            this.datagridviewerObjectExplorer.AllowUserToResizeRows = false;
            this.datagridviewerObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewerObjectExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewerObjectExplorer.ColumnHeadersVisible = false;
            this.datagridviewerObjectExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datagridviewerImageColumn,
            this.datagridviewerTextBoxColumn});
            this.datagridviewerObjectExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datagridviewerObjectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datagridviewerObjectExplorer.Location = new System.Drawing.Point(4, 39);
            this.datagridviewerObjectExplorer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.datagridviewerObjectExplorer.MultiSelect = false;
            this.datagridviewerObjectExplorer.Name = "datagridviewerObjectExplorer";
            this.datagridviewerObjectExplorer.ReadOnly = true;
            this.datagridviewerObjectExplorer.RowHeadersVisible = false;
            this.datagridviewerObjectExplorer.RowHeadersWidth = 51;
            this.datagridviewerObjectExplorer.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridviewerObjectExplorer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.datagridviewerObjectExplorer.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Green;
            this.datagridviewerObjectExplorer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagridviewerObjectExplorer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridviewerObjectExplorer.Size = new System.Drawing.Size(231, 499);
            this.datagridviewerObjectExplorer.TabIndex = 7;
            this.datagridviewerObjectExplorer.VirtualMode = true;
            // 
            // datagridviewerImageColumn
            // 
            this.datagridviewerImageColumn.HeaderText = "Column2";
            this.datagridviewerImageColumn.MinimumWidth = 32;
            this.datagridviewerImageColumn.Name = "datagridviewerImageColumn";
            this.datagridviewerImageColumn.ReadOnly = true;
            this.datagridviewerImageColumn.Width = 32;
            // 
            // datagridviewerTextBoxColumn
            // 
            this.datagridviewerTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.datagridviewerTextBoxColumn.HeaderText = "Column1";
            this.datagridviewerTextBoxColumn.MinimumWidth = 6;
            this.datagridviewerTextBoxColumn.Name = "datagridviewerTextBoxColumn";
            this.datagridviewerTextBoxColumn.ReadOnly = true;
            // 
            // openFilesTabs
            // 
            this.openFilesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFilesTabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openFilesTabs.Location = new System.Drawing.Point(243, 39);
            this.openFilesTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openFilesTabs.Name = "openFilesTabs";
            this.openFilesTabs.Padding = new System.Windows.Forms.Padding(1, 20, 1, 1);
            this.openFilesTabs.Size = new System.Drawing.Size(709, 499);
            this.openFilesTabs.TabIndex = 1;
            this.openFilesTabs.Text = "faTabStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmBoxMembers);
            this.panel1.Controls.Add(this.cmBoxNamespaces);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(242, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 28);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(230, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 28);
            this.panel2.TabIndex = 3;
            // 
            // cmBoxMembers
            // 
            this.cmBoxMembers.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmBoxMembers.FormattingEnabled = true;
            this.cmBoxMembers.Items.AddRange(new object[] {
            "Method1",
            "Method2"});
            this.cmBoxMembers.Location = new System.Drawing.Point(464, 0);
            this.cmBoxMembers.Name = "cmBoxMembers";
            this.cmBoxMembers.Size = new System.Drawing.Size(247, 28);
            this.cmBoxMembers.TabIndex = 2;
            // 
            // cmBoxNamespaces
            // 
            this.cmBoxNamespaces.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmBoxNamespaces.FormattingEnabled = true;
            this.cmBoxNamespaces.Items.AddRange(new object[] {
            "Object1",
            "Object2"});
            this.cmBoxNamespaces.Location = new System.Drawing.Point(0, 0);
            this.cmBoxNamespaces.Name = "cmBoxNamespaces";
            this.cmBoxNamespaces.Size = new System.Drawing.Size(230, 28);
            this.cmBoxNamespaces.TabIndex = 0;
            // 
            // CodeEditorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 653);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.documentMapSplitter);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.documentMap);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "CodeEditorMainForm";
            this.Text = "Code editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeEditor_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.codeAreaContextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewerObjectExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openFilesTabs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogMain;
        private System.Windows.Forms.ContextMenuStrip codeAreaContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator codeAreaContextMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Timer tmUpdateInterface;
        private System.Windows.Forms.ToolStripButton newTabToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton cutToolStripButton;
        private System.Windows.Forms.ToolStripButton copyToolStripButton;
        private System.Windows.Forms.ToolStripButton pasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonUndoStrip;
        private System.Windows.Forms.ToolStripButton buttonRedoStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox textboxFind;
        private System.Windows.Forms.ToolStripLabel labelFindStrip;
        private System.Windows.Forms.ToolStripSeparator codeAreaContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton buttonBackwardStrip;
        private System.Windows.Forms.ToolStripButton buttonForwardStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel labelWordUnderMouse;
        private System.Windows.Forms.ImageList imageListAutocomplete;
        private System.Windows.Forms.ToolStripSeparator codeAreaContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem autoIndentSelectedTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton buttonInvisibleSymbols;
        private System.Windows.Forms.ToolStripButton buttonHighlightCurrentLine;
        private System.Windows.Forms.ToolStripMenuItem commentSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncommentSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneLinesAndCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton buttonBookmarkPlus;
        private System.Windows.Forms.ToolStripButton buttonBookmarkMinus;
        private System.Windows.Forms.ToolStripDropDownButton buttonGotoBookmark;
        private System.Windows.Forms.ToolStripButton buttonShowFoldingLines;
        private System.Windows.Forms.ToolStripSplitButton buttonZoom;
        private System.Windows.Forms.ToolStripMenuItem zoom300Item;
        private System.Windows.Forms.ToolStripMenuItem zoom200Item;
        private System.Windows.Forms.ToolStripMenuItem zoom150Item;
        private System.Windows.Forms.ToolStripMenuItem zoom100Item;
        private System.Windows.Forms.ToolStripMenuItem zoom50Item;
        private System.Windows.Forms.ToolStripMenuItem zoom25Item;
        private ToolStripButton commentCodeStripButton;
        private ToolStripButton uncommentCodeStripButton;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem customLangToolStripMenuItem;
        private ToolStripMenuItem cSharpLangToolStripMenuItem;
        private ToolStripMenuItem hTMLLangToolStripMenuItem;
        private ToolStripMenuItem xMLLangToolStripMenuItem;
        private ToolStripMenuItem sQLLangToolStripMenuItem;
        private ToolStripMenuItem pHPLangToolStripMenuItem;
        private ToolStripMenuItem jSLangToolStripMenuItem;
        private ToolStripMenuItem lUALangToolStripMenuItem;
        private ToolStripMenuItem jSONLangToolStripMenuItem;
        private ToolStripMenuItem vBToolStripMenuItem;
        private ToolStripMenuItem markAsReadonlyToolStripMenuItem;
        private ToolStripMenuItem markAsWriteableToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton documentMapStripButton;
        private FastColoredTextBoxNS.DocumentMap documentMap;
        private Splitter documentMapSplitter;
        private ToolStripButton wordWrapToolStripButton;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem hotKeysToolStripMenuItem;
        private ToolStripMenuItem customizeCodeAreaHotKeysToolStripMenuItem;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem codeareaBgColorToolStripMenuItem1;
        private ToolStripMenuItem documentMapBgColorToolStripMenuItem;
        private ToolStripMenuItem objectexplorerBgColorToolStripMenuItem;
        private ToolStripMenuItem opentabPanelToolStripMenuItem;
        private ToolStripMenuItem restoreDefaultColorsToolStripMenuItem;
        private ToolStripMenuItem restoreDefaultToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem windowsToolStripMenuItem;
        private ToolStripMenuItem terminalToolStripMenuItem;
        private ToolStripMenuItem outputTerminalToolStripMenuItem;
        private ToolStripMenuItem loggingTerminalToolStripMenuItem;
        private ToolStripMenuItem errorsTerminalToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem compareTwoFilesToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem justForTest1ToolStripMenuItem;
        private ToolStripMenuItem test2ToolStripMenuItem;
        private ToolStripButton ExecuteCode;
        private TableLayoutPanel tableLayoutPanel1;
        private FarsiLibrary.Win.FATabStrip openFilesTabs;
        private Panel panel1;
        private ComboBox cmBoxNamespaces;
        private ComboBox cmBoxMembers;
        private DataGridView datagridviewerObjectExplorer;
        private DataGridViewImageColumn datagridviewerImageColumn;
        private DataGridViewTextBoxColumn datagridviewerTextBoxColumn;
        private Panel panel2;
    }
}
