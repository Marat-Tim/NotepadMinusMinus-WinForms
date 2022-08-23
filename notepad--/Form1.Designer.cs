
namespace NotepadMinusMinus
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFiles = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopiedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.AnotherItemToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.AnotherItemToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFiles
            // 
            this.OpenFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFiles.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.OpenFiles.ItemSize = new System.Drawing.Size(200, 25);
            this.OpenFiles.Location = new System.Drawing.Point(0, 36);
            this.OpenFiles.Name = "OpenFiles";
            this.OpenFiles.SelectedIndex = 0;
            this.OpenFiles.Size = new System.Drawing.Size(1328, 708);
            this.OpenFiles.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.OpenFiles.TabIndex = 1;
            this.OpenFiles.TabStop = false;
            this.OpenFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OpenFiles_DrawItem);
            this.OpenFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenFiles_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.MenuItemSaveFile,
            this.MenuItemSaveAll,
            this.AnotherItemToolStripMenuItem2,
            this.AnotherItemToolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1328, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.FolderToolStripMenuItem,
            this.NewFileToolStripMenuItem,
            this.CopiedImageToolStripMenuItem});
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.OpenToolStripMenuItem.Text = "&Открыть";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.Image = global::NotepadMinusMinus.Properties.Resources.File;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.FileToolStripMenuItem.Text = "Файл";
            this.FileToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenFile_Click);
            // 
            // FolderToolStripMenuItem
            // 
            this.FolderToolStripMenuItem.Image = global::NotepadMinusMinus.Properties.Resources.Folder;
            this.FolderToolStripMenuItem.Name = "FolderToolStripMenuItem";
            this.FolderToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.FolderToolStripMenuItem.Text = "Папку";
            this.FolderToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenDirectory_Click);
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Image = global::NotepadMinusMinus.Properties.Resources.Plus;
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            this.NewFileToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.NewFileToolStripMenuItem.Text = "Новый файл";
            this.NewFileToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenNewFile_Click);
            // 
            // CopiedImageToolStripMenuItem
            // 
            this.CopiedImageToolStripMenuItem.Image = global::NotepadMinusMinus.Properties.Resources.Image;
            this.CopiedImageToolStripMenuItem.Name = "CopiedImageToolStripMenuItem";
            this.CopiedImageToolStripMenuItem.Size = new System.Drawing.Size(292, 34);
            this.CopiedImageToolStripMenuItem.Text = "Скопированное фото";
            this.CopiedImageToolStripMenuItem.Click += new System.EventHandler(this.CopiedImageToolStripMenuItem_Click);
            // 
            // MenuItemSaveFile
            // 
            this.MenuItemSaveFile.Name = "MenuItemSaveFile";
            this.MenuItemSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSaveFile.Size = new System.Drawing.Size(114, 29);
            this.MenuItemSaveFile.Text = "&Сохранить";
            this.MenuItemSaveFile.Click += new System.EventHandler(this.MenuItemSaveFile_Click);
            // 
            // MenuItemSaveAll
            // 
            this.MenuItemSaveAll.Name = "MenuItemSaveAll";
            this.MenuItemSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MenuItemSaveAll.Size = new System.Drawing.Size(146, 29);
            this.MenuItemSaveAll.Text = "&Сохранить всё";
            this.MenuItemSaveAll.Click += new System.EventHandler(this.MenuItemSaveAll_Click);
            // 
            // AnotherItemToolStripMenuItem2
            // 
            this.AnotherItemToolStripMenuItem2.Name = "AnotherItemToolStripMenuItem2";
            this.AnotherItemToolStripMenuItem2.Size = new System.Drawing.Size(132, 29);
            this.AnotherItemToolStripMenuItem2.Text = "Еще условие";
            // 
            // AnotherItemToolStripMenuItem3
            // 
            this.AnotherItemToolStripMenuItem3.Name = "AnotherItemToolStripMenuItem3";
            this.AnotherItemToolStripMenuItem3.Size = new System.Drawing.Size(132, 29);
            this.AnotherItemToolStripMenuItem3.Text = "Еще условие";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 744);
            this.Controls.Add(this.OpenFiles);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Notepad--";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl OpenFiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAll;
        private System.Windows.Forms.ToolStripMenuItem AnotherItemToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem AnotherItemToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopiedImageToolStripMenuItem;
    }
}

