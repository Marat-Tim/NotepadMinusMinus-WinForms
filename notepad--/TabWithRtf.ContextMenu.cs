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
        /// Создает контекстное меню, со следующими действиями:
        /// 1. Выбрать стиль текста(набор стилей есть в классе Constants);
        /// 2. Выбрать цвет текста(набор цветов есть в классе Constants);
        /// 3. Скопировать выделенный текст;
        /// 4. Вставить текст;
        /// 5. Скопировать весь текст;
        /// 6. Удалить выделеный текст.
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            // Выбор стиля.
            var menuItemFont = new ToolStripMenuItem
            {
                Text = "Стиль",
                Image = Properties.Resources.Font
            };
            foreach (var style in Constants.StylesForRtf)
            {
                menuItemFont.DropDownItems.Add(CreateMenuItem(style.ToString(), null, FontClick(style), style));
            }
            menuItemFont.DropDownItems.Add(
                CreateMenuItem("Продвинутое меню", Properties.Resources.Menu, OpenSuperFontMenu));
            menuItemFont.DropDownOpened += DetectStyle;

            // Выбор цвета.
            var menuItemColor = new ToolStripMenuItem
            {
                Text = "Цвет",
                Image = Properties.Resources.ColorPicker
            };
            foreach (var color in Constants.ColorsForRtf)
            {
                Bitmap image = new Bitmap(512, 512);
                using (Graphics gfx = Graphics.FromImage(image))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    gfx.FillRectangle(brush, 0, 0, 512, 512);
                }
                menuItemColor.DropDownItems.Add(
                    CreateMenuItem(color.Name, image, ColorClick(color), color: color));
            }
            menuItemColor.DropDownItems.Add(
                CreateMenuItem("Продвинутое меню", Properties.Resources.Menu, OpenSuperColorMenu));

            // Само меню.
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                menuItemFont,
                menuItemColor,
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
        /// Открывает продвинутое меню выбора цвета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSuperColorMenu(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBox.SelectionColor = dialog.Color;
            }
        }

        /// <summary>
        /// Открывает продвинутое меню выбора шрифта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSuperFontMenu(object sender, EventArgs e)
        {
            var dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBox.SelectionFont = dialog.Font;
            }
        }

        /// <summary>
        /// Создает функцию, которая меняет цвет выделенного текста на новый.
        /// </summary>
        /// <param name="color">Новый цвет.</param>
        /// <returns>Функция, котороя меняет цвет.</returns>
        private EventHandler ColorClick(Color color)
        {
            void ChangeColor(object sender, EventArgs e)
            {
                RichTextBox.SelectionColor = color;
            }
            return ChangeColor;
        }

        /// <summary>
        /// Проверяет какими стилями обладает выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetectStyle(object sender, EventArgs e)
        {
            for (int i = 0; i < Constants.StylesForRtf.Length; i++)
            {
                ((ToolStripMenuItem)((ToolStripMenuItem)sender).DropDownItems[i]).Checked =
                    RichTextBox.SelectionFont.Style.HasFlag(Constants.StylesForRtf[i]);
            }
        }

        /// <summary>
        /// Создает функцию, которая добавляет данный стиль к стилю выделенного текста, 
        /// если его не было, иначе удаляет его.
        /// </summary>
        /// <param name="style">Данный стиль.</param>
        /// <returns>Функция, котороя изменяет стиль.</returns>
        private EventHandler FontClick(FontStyle style)
        {
            void ChangeFont(object sender, EventArgs e)
            {
                RichTextBox.SelectionFont =
                    new Font(RichTextBox.SelectionFont, RichTextBox.SelectionFont.Style ^ style);
            }
            return ChangeFont;
        }

        /// <summary>
        /// Удаляет выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClick(object sender, EventArgs e)
        {
            RichTextBox.SelectedRtf = string.Empty;
        }

        /// <summary>
        /// Выделить весь текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllClick(object sender, EventArgs e)
        {
            RichTextBox.SelectAll();
        }

        /// <summary>
        /// Скопировать выделенный текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyClick(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, RichTextBox.SelectedRtf);
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
                RichTextBox.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }
    }
}
