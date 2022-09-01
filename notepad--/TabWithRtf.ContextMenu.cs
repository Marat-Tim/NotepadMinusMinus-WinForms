using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    partial class TabWithRtf
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
        /// - Выбрать стиль текста(набор стилей есть в классе Constants);
        /// - Выбрать цвет текста(набор цветов есть в классе Constants);
        /// - Выбрать размер щрифта(набор размеров есть в классе Constants);
        /// - Скопировать выделенный текст;
        /// - Вставить текст;
        /// - Скопировать весь текст;
        /// - Удалить выделеный текст.
        /// </summary>
        /// <returns>Контекстное меню.</returns>
        private ContextMenuStrip CreateContextMenu()
        {
            #region Выбор стиля.
            var menuItemFont = new ToolStripMenuItem
            {
                Text = "Стиль",
                Image = Properties.Resources.Font
            };
            foreach (var (style, shortcutKeys) in Constants.StylesForRtf)
            {
                menuItemFont.DropDownItems.Add(
                    CreateMenuItem(
                        style.ToString(),
                        null,
                        FontClick(style),
                        style,
                        shortcutKeys: shortcutKeys));
            }
            menuItemFont.DropDownItems.Add(
                CreateMenuItem("Regular", null, ReturnFontAndColorToDefault,
                shortcutKeys: Keys.Control | Keys.R));
            menuItemFont.DropDownItems.Add(
                CreateMenuItem("Продвинутое меню", Properties.Resources.Menu, OpenSuperFontMenu));
            menuItemFont.DropDownOpened += DetectStyle;
            #endregion

            #region Выбор цвета.
            var menuItemColor = new ToolStripMenuItem
            {
                Text = "Цвет",
                Image = Properties.Resources.ColorPicker
            };
            foreach (var (color, shortcutKeys) in Constants.ColorsForRtf)
            {
                Bitmap image = new Bitmap(1, 1);
                using (Graphics gfx = Graphics.FromImage(image))
                using (SolidBrush brush = new SolidBrush(color))
                {
                    gfx.FillRectangle(brush, 0, 0, 1, 1);
                }
                menuItemColor.DropDownItems.Add(
                    CreateMenuItem(color.Name, image, ColorClick(color), 
                    color: color,
                    shortcutKeys: shortcutKeys));
            }
            menuItemColor.DropDownItems.Add(
                CreateMenuItem("Продвинутое меню", Properties.Resources.Menu, OpenSuperColorMenu));
            #endregion\

            #region Выбор размера шрифта.
            var menuItemFontSize = new ToolStripComboBox();
            menuItemFontSize.Items.AddRange(Constants.FontSizesForRtf);
            menuItemFontSize.SelectedIndexChanged += ChangeSelectionFontSizeByClick;
            menuItemFontSize.KeyUp += ChangeSelectionFontSize;
            #endregion

            #region Само меню.
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                menuItemColor,
                menuItemFont,
                menuItemFontSize,
                new ToolStripSeparator(),
                CreateMenuItem("Скопировать", Properties.Resources.Copy, CopyClick),
                CreateMenuItem("Вставить", Properties.Resources.Paste, PasteClick),
                CreateMenuItem("Выделить всё", null, SelectAllClick),
                CreateMenuItem("Удалить", Properties.Resources.Delete, DeleteClick)
            });
            contextMenu.Opened += DetectFontSize;
            #endregion

            return contextMenu;
        }

        /// <summary>
        /// Меняет цвет и шрифт выдленного текста к состоянию по умолчанию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnFontAndColorToDefault(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionFont != null)
            {
                MainRichTextBox.SelectionFont = Constants.DefaultFontForRtf;
                MainRichTextBox.SelectionColor = Color.Black;
            }
        }

        /// <summary>
        /// Определяет размер выделенного текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void DetectFontSize(object sender, EventArgs e)
        {
            ((ToolStripComboBox)((ContextMenuStrip)sender).Items[2]).Text =
                MainRichTextBox.SelectionFont?.Size.ToString();
        }

        /// <summary>
        /// Меняет размер шрифта выделенного текста при выборе размера из списка доступных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSelectionFontSizeByClick(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionFont != null)
            {
                MainRichTextBox.SelectionFont =
                    new Font(MainRichTextBox.SelectionFont.FontFamily,
                    (int)(((ToolStripComboBox)sender).SelectedItem));
                ((ToolStripComboBox)sender).Control.Parent.Hide();
            }
        }

        /// <summary>
        /// Меняет размер шрифта выделенного текста при ручном вводе размера и нажатии enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeSelectionFontSize(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int size;
                if (MainRichTextBox.SelectionFont != null && int.TryParse(((ToolStripComboBox)sender).Text, out size))
                {
                    MainRichTextBox.SelectionFont =
                        new Font(MainRichTextBox.SelectionFont.FontFamily,
                        size);
                    ((ToolStripComboBox)sender).Control.Parent.Hide();   
                }
            }
        }

        /// <summary>
        /// Изменяет стиль текста на жирный.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoldFontClick(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionFont != null)
            {
                MainRichTextBox.SelectionFont =
                    new Font(MainRichTextBox.SelectionFont, MainRichTextBox.SelectionFont.Style | FontStyle.Bold);
            }
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
                MainRichTextBox.SelectionColor = dialog.Color;
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
                MainRichTextBox.SelectionFont = dialog.Font;
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
                MainRichTextBox.SelectionColor = color;
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
                    MainRichTextBox.SelectionFont != null &&
                    MainRichTextBox.SelectionFont.Style.HasFlag(Constants.StylesForRtf[i].style);
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
                if (MainRichTextBox.SelectionFont != null)
                {
                    MainRichTextBox.SelectionFont =
                        new Font(MainRichTextBox.SelectionFont, MainRichTextBox.SelectionFont.Style ^ style);
                }
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