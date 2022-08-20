using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    partial class TabWithRtf
    {
        /// <summary>
        /// Создает контекстное меню, состоящее из кнопок, которые
        /// 1. Копируют выделенный текст;
        /// 2. Вставляют скопированный текст в выделенное место;
        /// 3. Копируют весь текст весь в файле;
        /// 4. Удаляют выделенный текст;
        /// 5. Изменяют стиль текста на
        ///     5.1. Жирный;
        ///     5.2. Курсивный;
        ///     5.1. Подчеркнутый;
        ///     5.1. Зачеркнутый;
        /// 6. Изменяют цвет текста;
        /// 7. Открывают продвинутое меню выбора шрифта.
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                CreateMenuItem("Скопировать", notepad__.Properties.Resources.Copy, CopyClick),
                CreateMenuItem("Вставить", notepad__.Properties.Resources.Paste, PasteClick),
                CreateMenuItem("Выделить всё", null, SelectAllClick),
                CreateMenuItem("Удалить", notepad__.Properties.Resources.Delete, DeleteClick),
                //CreateMenuItem("Формат", FontClick),
            });
            return contextMenu;
        }

        private ToolStripMenuItem CreateMenuItem(string text, Bitmap bitmap, EventHandler eventHandler)
        {
            var menuItem = new ToolStripMenuItem()
            {
                Text = text,
                Image = bitmap
            };
            menuItem.Click += eventHandler;
            return menuItem;
        }

        private void FontClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
            RichTextBox.SelectedRtf = string.Empty;
        }

        private void SelectAllClick(object sender, EventArgs e)
        {
            RichTextBox.SelectAll();
        }

        private void CopyClick(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, RichTextBox.SelectedRtf);
        }

        private void PasteClick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                RichTextBox.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
    }
}
