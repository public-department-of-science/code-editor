﻿using System;


namespace Code.Editor
{

    public partial class CodeEditorMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditorMainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.labelWordUnderMouse = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
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
            this.buttonBackStrip = new System.Windows.Forms.ToolStripButton();
            this.buttonForwardStrip = new System.Windows.Forms.ToolStripButton();
            this.textboxFind = new System.Windows.Forms.ToolStripTextBox();
            this.labelFindStrip = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonBookmarkPlus = new System.Windows.Forms.ToolStripButton();
            this.buttonBookmarkMinus = new System.Windows.Forms.ToolStripButton();
            this.buttonGoto = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFilesTabs = new FarsiLibrary.Win.FATabStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.autoIndentSelectedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncommentSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneLinesAndCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmUpdateInterface = new System.Windows.Forms.Timer(this.components);
            this.datagridviewerObjectExplorer = new System.Windows.Forms.DataGridView();
            this.datagridviewerImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.datagridviewerTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageListAutocomplete = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openFilesTabs)).BeginInit();
            this.cmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewerObjectExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1025, 30);
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
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(241, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelWordUnderMouse,
            this.buttonZoom});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 480);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1025, 26);
            this.mainStatusStrip.TabIndex = 2;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // labelWordUnderMouse
            // 
            this.labelWordUnderMouse.AutoSize = false;
            this.labelWordUnderMouse.ForeColor = System.Drawing.Color.Gray;
            this.labelWordUnderMouse.Name = "labelWordUnderMouse";
            this.labelWordUnderMouse.Size = new System.Drawing.Size(937, 20);
            this.labelWordUnderMouse.Spring = true;
            this.labelWordUnderMouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonZoom
            // 
            this.buttonZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripMenuItem10,
            this.toolStripMenuItem9,
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6});
            this.buttonZoom.Image = ((System.Drawing.Image)(resources.GetObject("buttonZoom.Image")));
            this.buttonZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(68, 24);
            this.buttonZoom.Text = "Zoom";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem11.Tag = "300";
            this.toolStripMenuItem11.Text = "300%";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem10.Tag = "200";
            this.toolStripMenuItem10.Text = "200%";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem9.Tag = "150";
            this.toolStripMenuItem9.Text = "150%";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem8.Tag = "100";
            this.toolStripMenuItem8.Text = "100%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem7.Tag = "50";
            this.toolStripMenuItem7.Text = "50%";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(128, 26);
            this.toolStripMenuItem6.Tag = "25";
            this.toolStripMenuItem6.Text = "25%";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.Zoom_click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
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
            this.buttonBackStrip,
            this.buttonForwardStrip,
            this.textboxFind,
            this.labelFindStrip,
            this.toolStripSeparator6,
            this.buttonBookmarkPlus,
            this.buttonBookmarkMinus,
            this.buttonGoto});
            this.toolStripMain.Location = new System.Drawing.Point(0, 30);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1025, 27);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
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
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // cutToolStripButton
            // 
            this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
            this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton.Name = "cutToolStripButton";
            this.cutToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.cutToolStripButton.Text = "C&ut";
            this.cutToolStripButton.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripButton
            // 
            this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
            this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripButton.Name = "copyToolStripButton";
            this.copyToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.copyToolStripButton.Text = "&Copy";
            this.copyToolStripButton.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripButton
            // 
            this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
            this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripButton.Name = "pasteToolStripButton";
            this.pasteToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.pasteToolStripButton.Text = "&Paste";
            this.pasteToolStripButton.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
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
            this.buttonShowFoldingLines.Image = ((System.Drawing.Image)(resources.GetObject("buttonShowFoldingLines.Image")));
            this.buttonShowFoldingLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonShowFoldingLines.Name = "buttonShowFoldingLines";
            this.buttonShowFoldingLines.Size = new System.Drawing.Size(29, 24);
            this.buttonShowFoldingLines.Text = "Show folding lines";
            this.buttonShowFoldingLines.Click += new System.EventHandler(this.btShowFoldingLines_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonUndoStrip
            // 
            this.buttonUndoStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUndoStrip.Image = global::Code.Editor.Properties.Resources.undo_16x16;
            this.buttonUndoStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUndoStrip.Name = "buttonUndoStrip";
            this.buttonUndoStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonUndoStrip.Text = "Undo (Ctrl+Z)";
            this.buttonUndoStrip.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // buttonRedoStrip
            // 
            this.buttonRedoStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRedoStrip.Image = global::Code.Editor.Properties.Resources.redo_16x16;
            this.buttonRedoStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRedoStrip.Name = "buttonRedoStrip";
            this.buttonRedoStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonRedoStrip.Text = "Redo (Ctrl+R)";
            this.buttonRedoStrip.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // buttonBackStrip
            // 
            this.buttonBackStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBackStrip.Image = global::Code.Editor.Properties.Resources.backward0_16x16;
            this.buttonBackStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBackStrip.Name = "buttonBackStrip";
            this.buttonBackStrip.Size = new System.Drawing.Size(29, 24);
            this.buttonBackStrip.Text = "Navigate Backward (Ctrl+ -)";
            this.buttonBackStrip.Click += new System.EventHandler(this.backStripButton_Click);
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
            // textboxFind
            // 
            this.textboxFind.AcceptsReturn = true;
            this.textboxFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.textboxFind.Name = "textboxFind";
            this.textboxFind.Size = new System.Drawing.Size(132, 27);
            this.textboxFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            // 
            // labelFindStrip
            // 
            this.labelFindStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelFindStrip.Name = "labelFindStrip";
            this.labelFindStrip.Size = new System.Drawing.Size(44, 24);
            this.labelFindStrip.Text = "Find: ";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
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
            // buttonGoto
            // 
            this.buttonGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonGoto.Image = ((System.Drawing.Image)(resources.GetObject("buttonGoto.Image")));
            this.buttonGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonGoto.Name = "buttonGoto";
            this.buttonGoto.Size = new System.Drawing.Size(65, 24);
            this.buttonGoto.Text = "Goto...";
            this.buttonGoto.DropDownOpening += new System.EventHandler(this.gotoButton_DropDownOpening);
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
            // openFilesTabs
            // 
            this.openFilesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFilesTabs.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openFilesTabs.Location = new System.Drawing.Point(233, 57);
            this.openFilesTabs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openFilesTabs.Name = "openFilesTabs";
            this.openFilesTabs.Padding = new System.Windows.Forms.Padding(1, 20, 1, 1);
            this.openFilesTabs.Size = new System.Drawing.Size(792, 423);
            this.openFilesTabs.TabIndex = 0;
            this.openFilesTabs.Text = "faTabStrip1";
            this.openFilesTabs.TabStripItemClosing += new FarsiLibrary.Win.TabStripItemClosingHandler(this.tsFiles_TabStripItemClosing);
            this.openFilesTabs.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.tsFiles_TabStripItemSelectionChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(229, 57);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 423);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // sfdMain
            // 
            this.sfdMain.DefaultExt = "cs";
            this.sfdMain.Filter = "C# file(*.cs)|*.cs|All files|*.*";
            // 
            // ofdMain
            // 
            this.ofdMain.DefaultExt = "cs";
            this.ofdMain.Filter = "C# file(*.cs)|*.cs|All files|*.*";
            // 
            // cmMain
            // 
            this.cmMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripMenuItem4,
            this.autoIndentSelectedTextToolStripMenuItem,
            this.commentSelectedToolStripMenuItem,
            this.uncommentSelectedToolStripMenuItem,
            this.cloneLinesToolStripMenuItem,
            this.cloneLinesAndCommentToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(257, 334);
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
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(253, 6);
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
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(253, 6);
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
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(253, 6);
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
            // datagridviewerObjectExplorer
            // 
            this.datagridviewerObjectExplorer.AllowUserToAddRows = false;
            this.datagridviewerObjectExplorer.AllowUserToDeleteRows = false;
            this.datagridviewerObjectExplorer.AllowUserToResizeColumns = false;
            this.datagridviewerObjectExplorer.AllowUserToResizeRows = false;
            this.datagridviewerObjectExplorer.BackgroundColor = System.Drawing.Color.White;
            this.datagridviewerObjectExplorer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datagridviewerObjectExplorer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewerObjectExplorer.ColumnHeadersVisible = false;
            this.datagridviewerObjectExplorer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datagridviewerImageColumn,
            this.datagridviewerTextBoxColumn});
            this.datagridviewerObjectExplorer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datagridviewerObjectExplorer.Dock = System.Windows.Forms.DockStyle.Left;
            this.datagridviewerObjectExplorer.GridColor = System.Drawing.Color.White;
            this.datagridviewerObjectExplorer.Location = new System.Drawing.Point(0, 57);
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
            this.datagridviewerObjectExplorer.Size = new System.Drawing.Size(229, 423);
            this.datagridviewerObjectExplorer.TabIndex = 6;
            this.datagridviewerObjectExplorer.VirtualMode = true;
            this.datagridviewerObjectExplorer.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvObjectExplorer_CellMouseDoubleClick);
            this.datagridviewerObjectExplorer.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dgvObjectExplorer_CellValueNeeded);
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
            // imageListAutocomplete
            // 
            this.imageListAutocomplete.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListAutocomplete.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListAutocomplete.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CodeEditorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 506);
            this.Controls.Add(this.openFilesTabs);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.datagridviewerObjectExplorer);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mainStatusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CodeEditorMainForm";
            this.Text = "Code editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PowerfulCSharpEditor_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openFilesTabs)).EndInit();
            this.cmMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewerObjectExplorer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private FarsiLibrary.Win.FATabStrip openFilesTabs;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.Timer tmUpdateInterface;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.DataGridView datagridviewerObjectExplorer;
        private System.Windows.Forms.ToolStripButton buttonBackStrip;
        private System.Windows.Forms.ToolStripButton buttonForwardStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.DataGridViewImageColumn datagridviewerImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datagridviewerTextBoxColumn;
        private System.Windows.Forms.ToolStripStatusLabel labelWordUnderMouse;
        private System.Windows.Forms.ImageList imageListAutocomplete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
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
        private System.Windows.Forms.ToolStripDropDownButton buttonGoto;
        private System.Windows.Forms.ToolStripButton buttonShowFoldingLines;
        private System.Windows.Forms.ToolStripSplitButton buttonZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
    }
}
