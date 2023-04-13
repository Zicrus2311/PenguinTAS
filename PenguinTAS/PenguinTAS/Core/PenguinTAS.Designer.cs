namespace PenguinTAS {
    partial class PenguinTAS {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenguinTAS));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.redoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutButton = new System.Windows.Forms.ToolStripMenuItem();
            this.copyButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuSeperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllButton = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.discordButton = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuSeperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpInfo = new System.Windows.Forms.ToolStripTextBox();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tempBox = new System.Windows.Forms.RichTextBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.toolStripMenuItem1,
            this.editMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.fileMenuSeperator1,
            this.saveButton,
            this.saveAsButton,
            this.fileMenuSeperator2,
            this.exitButton});
            this.fileMenu.ForeColor = System.Drawing.Color.White;
            this.fileMenu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // newButton
            // 
            this.newButton.Name = "newButton";
            this.newButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newButton.Size = new System.Drawing.Size(195, 22);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.Menu_New);
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openButton.Size = new System.Drawing.Size(195, 22);
            this.openButton.Text = "Open...";
            this.openButton.Click += new System.EventHandler(this.Menu_Open);
            // 
            // fileMenuSeperator1
            // 
            this.fileMenuSeperator1.Name = "fileMenuSeperator1";
            this.fileMenuSeperator1.Size = new System.Drawing.Size(192, 6);
            // 
            // saveButton
            // 
            this.saveButton.Name = "saveButton";
            this.saveButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveButton.Size = new System.Drawing.Size(195, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.Menu_Save);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsButton.Size = new System.Drawing.Size(195, 22);
            this.saveAsButton.Text = "Save As...";
            this.saveAsButton.Click += new System.EventHandler(this.Menu_SaveAs);
            // 
            // fileMenuSeperator2
            // 
            this.fileMenuSeperator2.Name = "fileMenuSeperator2";
            this.fileMenuSeperator2.Size = new System.Drawing.Size(192, 6);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(195, 22);
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.Menu_Exit);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.redoButton,
            this.editMenuSeperator1,
            this.cutButton,
            this.copyButton,
            this.pasteButton,
            this.duplicateButton,
            this.editMenuSeperator2,
            this.selectAllButton});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem1.Text = "Edit";
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoButton.Size = new System.Drawing.Size(166, 22);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.Menu_Undo);
            // 
            // redoButton
            // 
            this.redoButton.Name = "redoButton";
            this.redoButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoButton.Size = new System.Drawing.Size(166, 22);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.Menu_Redo);
            // 
            // editMenuSeperator1
            // 
            this.editMenuSeperator1.Name = "editMenuSeperator1";
            this.editMenuSeperator1.Size = new System.Drawing.Size(163, 6);
            // 
            // cutButton
            // 
            this.cutButton.Name = "cutButton";
            this.cutButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutButton.Size = new System.Drawing.Size(166, 22);
            this.cutButton.Text = "Cut";
            this.cutButton.Click += new System.EventHandler(this.Menu_Cut);
            // 
            // copyButton
            // 
            this.copyButton.Name = "copyButton";
            this.copyButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyButton.Size = new System.Drawing.Size(166, 22);
            this.copyButton.Text = "Copy";
            this.copyButton.Click += new System.EventHandler(this.Menu_Copy);
            // 
            // pasteButton
            // 
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteButton.Size = new System.Drawing.Size(166, 22);
            this.pasteButton.Text = "Paste";
            this.pasteButton.Click += new System.EventHandler(this.Menu_Paste);
            // 
            // duplicateButton
            // 
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateButton.Size = new System.Drawing.Size(166, 22);
            this.duplicateButton.Text = "Duplicate";
            this.duplicateButton.Click += new System.EventHandler(this.Menu_Duplicate);
            // 
            // editMenuSeperator2
            // 
            this.editMenuSeperator2.Name = "editMenuSeperator2";
            this.editMenuSeperator2.Size = new System.Drawing.Size(163, 6);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllButton.Size = new System.Drawing.Size(166, 22);
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.Click += new System.EventHandler(this.Menu_SelectAll);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationButton,
            this.discordButton,
            this.helpMenuSeperator1,
            this.helpInfo});
            this.editMenu.ForeColor = System.Drawing.Color.White;
            this.editMenu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(44, 20);
            this.editMenu.Text = "Help";
            // 
            // documentationButton
            // 
            this.documentationButton.Name = "documentationButton";
            this.documentationButton.Size = new System.Drawing.Size(160, 22);
            this.documentationButton.Text = "Documentation";
            this.documentationButton.Click += new System.EventHandler(this.Menu_Documentation);
            // 
            // discordButton
            // 
            this.discordButton.Name = "discordButton";
            this.discordButton.Size = new System.Drawing.Size(160, 22);
            this.discordButton.Text = "Discord";
            this.discordButton.Click += new System.EventHandler(this.Menu_Discord);
            // 
            // helpMenuSeperator1
            // 
            this.helpMenuSeperator1.Name = "helpMenuSeperator1";
            this.helpMenuSeperator1.Size = new System.Drawing.Size(157, 6);
            // 
            // helpInfo
            // 
            this.helpInfo.BackColor = System.Drawing.Color.White;
            this.helpInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpInfo.Enabled = false;
            this.helpInfo.Font = new System.Drawing.Font("Segoe UI", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.helpInfo.Name = "helpInfo";
            this.helpInfo.Size = new System.Drawing.Size(100, 13);
            this.helpInfo.Text = "Ping @Zicrus for help";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(394, 385);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "";
            this.textBox1.WordWrap = false;
            this.textBox1.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.TextBox_ContentsResized);
            this.textBox1.VScroll += new System.EventHandler(this.TextBox_Scroll);
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(403, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(394, 385);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "";
            this.textBox2.WordWrap = false;
            this.textBox2.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.TextBox_ContentsResized);
            this.textBox2.VScroll += new System.EventHandler(this.TextBox_Scroll);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.textBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 391);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tempBox
            // 
            this.tempBox.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tempBox.ForeColor = System.Drawing.Color.White;
            this.tempBox.Location = new System.Drawing.Point(0, 0);
            this.tempBox.Name = "tempBox";
            this.tempBox.Size = new System.Drawing.Size(10, 10);
            this.tempBox.TabIndex = 4;
            this.tempBox.TabStop = false;
            this.tempBox.Text = "";
            this.tempBox.Visible = false;
            this.tempBox.WordWrap = false;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoLabel.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoLabel.Location = new System.Drawing.Point(0, 416);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Padding = new System.Windows.Forms.Padding(2, 0, 0, 4);
            this.infoLabel.Size = new System.Drawing.Size(53, 34);
            this.infoLabel.TabIndex = 5;
            this.infoLabel.Text = "Info";
            // 
            // PenguinTAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.tempBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PenguinTAS";
            this.Text = "Penguin TAS";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newButton;
        private ToolStripMenuItem openButton;
        private ToolStripMenuItem saveButton;
        private ToolStripMenuItem saveAsButton;
        private RichTextBox textBox1;
        private ToolStripSeparator fileMenuSeperator1;
        private ToolStripMenuItem exitButton;
        private ToolStripMenuItem editMenu;
        private RichTextBox textBox2;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox tempBox;
        private Label infoLabel;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem undoButton;
        private ToolStripMenuItem redoButton;
        private ToolStripSeparator editMenuSeperator1;
        private ToolStripMenuItem cutButton;
        private ToolStripMenuItem copyButton;
        private ToolStripMenuItem pasteButton;
        private ToolStripSeparator editMenuSeperator2;
        private ToolStripMenuItem selectAllButton;
        private ToolStripMenuItem documentationButton;
        private ToolStripMenuItem discordButton;
        private ToolStripTextBox helpInfo;
        private ToolStripSeparator helpMenuSeperator1;
        private ToolStripMenuItem duplicateButton;
        private ToolStripSeparator fileMenuSeperator2;
    }
}