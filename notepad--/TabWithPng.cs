using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".png")]
    class TabWithPng : TabWithFile
    {
        public TabWithPng() : base("Конспект.png")
        {
            var pictureBox = new PictureBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pictureBox.ContextMenuStrip = CreateContextMenu();
            Controls.Add(pictureBox);
            isSave = true;
        }

        /// <summary>
        /// Создает контекстное меню, состоящее из
        /// 1. Кнопки для открытия картинки в Paint.
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            var openInPaintMenuItem = new ToolStripMenuItem()
            {
                Text = "Открыть в Paint",
                Image = Properties.Resources.Paint
            };
            openInPaintMenuItem.Click += OpenWithPaint;
            contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                openInPaintMenuItem
            });
            return contextMenu;
        }

        /// <summary>
        /// Открывает изображение на вкладке с помощью Paint. После закрытия Paint отображает все изменения,
        /// сделанные в Paint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWithPaint(object sender, EventArgs e)
        {
            ((PictureBox)Controls[0]).Dispose();
            Controls.Clear();
            var process = Process.Start("mspaint.exe", $"\"{Path}\"");
            process.WaitForExit();
            var pictureBox = new PictureBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pictureBox.ContextMenuStrip = CreateContextMenu();
            Controls.Add(pictureBox);
            isSave = true;
            LoadFile(Path);
        }

        public override void LoadFile(string path)
        {
            ((PictureBox)Controls[0]).Load(path);
            base.LoadFile(path);
        }

        public override void SaveFile()
        {
            if (Path == null)
            {
                GetPathByDialog();
                if (Path == null)
                {
                    return;
                }
            }
            if (!IsSave)
            {
                IsSave = true;
            }
        }
    }
}
