
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
            this.components = new System.ComponentModel.Container();
            this.OpenFiles = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.папкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ещеУсловиеToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ещеУсловиеToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.скопироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
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
            this.открытьToolStripMenuItem,
            this.MenuItemSaveFile,
            this.MenuItemSaveAll,
            this.ещеУсловиеToolStripMenuItem2,
            this.ещеУсловиеToolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1328, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.папкуToolStripMenuItem,
            this.новыйФайлToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(98, 29);
            this.открытьToolStripMenuItem.Text = "&Открыть";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenFile_Click);
            // 
            // папкуToolStripMenuItem
            // 
            this.папкуToolStripMenuItem.Name = "папкуToolStripMenuItem";
            this.папкуToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.папкуToolStripMenuItem.Text = "Папку";
            this.папкуToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenDirectory_Click);
            // 
            // новыйФайлToolStripMenuItem
            // 
            this.новыйФайлToolStripMenuItem.Name = "новыйФайлToolStripMenuItem";
            this.новыйФайлToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.новыйФайлToolStripMenuItem.Text = "Новый файл";
            this.новыйФайлToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpenNewFile_Click);
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
            // ещеУсловиеToolStripMenuItem2
            // 
            this.ещеУсловиеToolStripMenuItem2.Name = "ещеУсловиеToolStripMenuItem2";
            this.ещеУсловиеToolStripMenuItem2.Size = new System.Drawing.Size(132, 29);
            this.ещеУсловиеToolStripMenuItem2.Text = "Еще условие";
            // 
            // ещеУсловиеToolStripMenuItem3
            // 
            this.ещеУсловиеToolStripMenuItem3.Name = "ещеУсловиеToolStripMenuItem3";
            this.ещеУсловиеToolStripMenuItem3.Size = new System.Drawing.Size(132, 29);
            this.ещеУсловиеToolStripMenuItem3.Text = "Еще условие";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скопироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(241, 101);
            // 
            // скопироватьToolStripMenuItem
            // 
            this.скопироватьToolStripMenuItem.Name = "скопироватьToolStripMenuItem";
            this.скопироватьToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.скопироватьToolStripMenuItem.Text = "Скопировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(240, 32);
            this.вставитьToolStripMenuItem.Text = "Вставить";
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
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl OpenFiles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAll;
        private System.Windows.Forms.ToolStripMenuItem ещеУсловиеToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ещеУсловиеToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem папкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйФайлToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem скопироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
    }
}

