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
        /// Создает кнопку меню с заданными параметрами. 
        /// Данный метод нужен, чтобы создание элемента меню не занимало несколько строчек и для того, чтобы
        /// можно было создавать кнопки меню внутри методов AddRange и Add. 
        /// </summary>
        /// <param name="text">Текст на кнопке.</param>
        /// <param name="bitmap">Изображение в левой части кнопки.</param>
        /// <param name="eventHandler">Действие, происходящее при нажатии на кнопку.</param>
        /// <param name="style">Стиль текста на кнопке(нужен для меню выбора стиля).</param>
        /// <param name="color">Цвет текста на кнопке(нужен для меню выбора цвета).</param>
        /// <returns>Элемент меню.</returns>
        private ToolStripMenuItem CreateMenuItem(
            string text,
            Bitmap bitmap,
            EventHandler eventHandler,
            FontStyle style = FontStyle.Regular,
            Color color = default)
        {
            var menuItem = new ToolStripMenuItem()
            {
                Text = text,
                Font = new Font(DefaultFont, style),
                ForeColor = color,
                Image = bitmap
            };
            menuItem.Click += eventHandler;
            return menuItem;
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
