using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    partial class TabWithTxt
    {
        /// <summary>
        /// Открывает контекстное меню при нажатии на Ctrl+M.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenContextMenu(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.M)
            {
                Point position;
                WinApi.GetCaretPos(out position);
                MainRichTextBox.ContextMenuStrip.Show(position);
            }
        }

        /// <summary>
        /// Создает контекстное меню, со следующими действиями:
        /// 1. Скопировать выделенный текст;
        /// 2. Вставить текст;
        /// 3. Скопировать весь текст;
        /// 4. Удалить выделеный текст.
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                CreateMenuItem("Скопировать", Properties.Resources.Copy, CopyClick),
                CreateMenuItem("Вставить", Properties.Resources.Paste, PasteClick),
                CreateMenuItem("Выделить всё", null, SelectAllClick),
                CreateMenuItem("Удалить", Properties.Resources.Delete, DeleteClick)
            });
            return contextMenu;
        }

        /// <summary>
        /// Удаляет выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClick(object sender, EventArgs e)
        {
            MainRichTextBox.SelectedRtf = string.Empty;
        }

        /// <summary>
        /// Выделить весь текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllClick(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        /// <summary>
        /// Скопировать выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyClick(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, MainRichTextBox.SelectedRtf);
        }

        /// <summary>
        /// Вставить выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteClick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                MainRichTextBox.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
    }
}
