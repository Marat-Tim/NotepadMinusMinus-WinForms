using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="KeyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Tab:
                    MainRichTextBox.SelectedText = new string(' ', 4);
                    return true;
            }
            return base.ProcessCmdKey(ref message, keys);
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
    }
}
