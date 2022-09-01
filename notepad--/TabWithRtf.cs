using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".rtf")]
    partial class TabWithRtf : TabWithFile
    {
        /// <summary>
        /// Основной элемент данного класса, в котором хранятся данные из файла.
        /// </summary>
        public readonly RichTextBox MainRichTextBox;

        public TabWithRtf() : base("Конспект.rtf")
        {
            var richTextBox = new RichTextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill,
                Font = Constants.DefaultFontForRtf,
                AcceptsTab = true
            };
            richTextBox.TextChanged += Changed;
            richTextBox.LinkClicked += LinkClicked;
            richTextBox.KeyDown += OpenContextMenu;
            richTextBox.ContextMenuStrip = CreateContextMenu();
            Controls.Add(richTextBox);
            MainRichTextBox = richTextBox;
        }

        /// <summary>
        /// Обрабатывает нажатие на клавиши:
        /// 1. При нажатии на Tab пишет 4 пробела вместо табуляции.
        /// 2. При вводе \up, \down, ->, <- превращает их в соответствующие стрелочки.
        /// 3. При вводе !=, >=, <= превращает их в соответсвующие математические символы.
        /// 4. При вводе решетки выделяет ее красным жирным цветом.
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="KeyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            if (ReplaceControlTextWithValue(keys, @"\up", "\u2191") ||
                ReplaceControlTextWithValue(keys, @"\down", "\u2193") ||
                ReplaceControlTextWithValue(keys, @"->", "\u2192") ||
                ReplaceControlTextWithValue(keys, @"<-", "\u2190") ||
                ReplaceControlTextWithValue(keys, @"!=", "\u2260") ||
                ReplaceControlTextWithValue(keys, @">=", "\u2265") ||
                ReplaceControlTextWithValue(keys, @"<=", "\u2264") ||
                ReplaceControlTextWithValue(keys, @"#", "#", FontStyle.Bold, Color.Red)
                )
            {
                return true;
            }
            switch (keys)
            {
                case Keys.Tab:
                    MainRichTextBox.SelectedText = new string(' ', 4);
                    return true;
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        /// <summary>
        /// Заменяет управляющий текст на значение этого управляющего текста.
        /// </summary>
        /// <param name="keys">Нажатые клавиши.</param>
        /// <param name="controlText">Управляющий текст.</param>
        /// <param name="value">На что должен заменяться управляющий текст.</param>
        /// <returns>Истина, если замена произошла, иначе ложь.</returns>
        private bool ReplaceControlTextWithValue(
            Keys keys,
            string controlText,
            string value,
            FontStyle style = FontStyle.Regular,
            Color color = default)
        {
            if (WinApi.KeyCodeToUnicode(keys) == controlText[^1].ToString() &&
                MainRichTextBox.SelectionStart >= controlText.Length - 1 &&
                MainRichTextBox.Text[
                    (MainRichTextBox.SelectionStart - controlText.Length + 1)..(MainRichTextBox.SelectionStart)] == 
                    controlText[..^1])
            {
                MainRichTextBox.Select(MainRichTextBox.SelectionStart - controlText.Length + 1, 
                    controlText.Length - 1);
                MainRichTextBox.SelectedText = controlText;
                MainRichTextBox.Select(MainRichTextBox.SelectionStart - controlText.Length, controlText.Length);
                MainRichTextBox.SelectionFont = new Font(MainRichTextBox.SelectionFont,
                    MainRichTextBox.SelectionFont.Style | style);
                MainRichTextBox.SelectionColor = color;
                MainRichTextBox.SelectedText = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Открывает ссылку из файла в интернете.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("explorer", e.LinkText);
        }

        public override void LoadFile(string path)
        {
            MainRichTextBox.LoadFile(path);
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
                MainRichTextBox.SaveFile(Path);
                IsSave = true;
            }
        }

        public override void AutoFormatting()
        {
            HighlightExamplesInItalics();
            base.AutoFormatting();
        }

        /// <summary>
        /// Выделяет слова "пример", "например" и похожие курсивом.
        /// </summary>
        private void HighlightExamplesInItalics()
        {
            var matches = Regex.Matches(MainRichTextBox.Text, "([Вв] )?([Нн]а)?[Пп]ример:?");
            if (matches.Count > 0)
            {
                var selectionStart = MainRichTextBox.SelectionStart;
                var selectionLength = MainRichTextBox.SelectionLength;
                IsSave = false;
                foreach (Match match in matches)
                {
                    MainRichTextBox.Select(match.Index, match.Length);
                    MainRichTextBox.SelectionFont =
                        new Font(MainRichTextBox.SelectionFont, MainRichTextBox.SelectionFont.Style | FontStyle.Italic);
                }
                MainRichTextBox.Select(selectionStart, selectionLength);
            }
        }
    }
}
