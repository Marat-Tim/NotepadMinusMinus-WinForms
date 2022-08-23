using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    partial class TabWithPng
    {
        /// <summary>
        /// Создает контекстное меню, состоящее из
        /// 1. Кнопки для открытия картинки в Paint.
        /// 2. Кнопки для изменения SizeMode
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            // Изменить режим отображения.
            var changeSizeModeMenuItem = new ToolStripMenuItem()
            {
                Text = "Изменить режим отображения",
                Image = Properties.Resources.SizeMode
            };
            foreach (var (sizeMode, icon, name) in Constants.SizeModesForPng)
            {
                changeSizeModeMenuItem.DropDownItems.Add(
                    CreateMenuItem(name, icon, SizeModeClick(sizeMode)));
            }
            changeSizeModeMenuItem.DropDownOpened += DetectSizeMode;

            // Само меню.
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                CreateMenuItem("Открыть в Paint", Properties.Resources.Paint, OpenInPaint),
                changeSizeModeMenuItem
            });
            return contextMenu;
        }

        /// <summary>
        /// Проверяет какой режим отображения сейчас используется.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectSizeMode(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var (sizeMode, _, _) in Constants.SizeModesForPng)
            {
                ((ToolStripMenuItem)((ToolStripMenuItem)sender).DropDownItems[i]).Checked =
                    ((PictureBox)Controls[0]).SizeMode == sizeMode;
                i++;
            }
        }

        /// <summary>
        /// Создает функцию, которая меняет режим отображения картинки на новый.
        /// </summary>
        /// <param name="color">Новый режим отображения.</param>
        /// <returns>Функция, котороя меняет режим отображения.</returns>
        private EventHandler SizeModeClick(PictureBoxSizeMode sizeMode)
        {
            void ChangeSizeMode(object sender, EventArgs e)
            {
                ((PictureBox)Controls[0]).SizeMode = sizeMode;
            }
            return ChangeSizeMode;
        }

        /// <summary>
        /// Открывает изображение на вкладке с помощью Paint. После закрытия Paint отображает все изменения,
        /// сделанные в Paint.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenInPaint(object sender, EventArgs e)
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
    }
}
