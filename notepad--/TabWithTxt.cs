using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".txt")]
    partial class TabWithTxt : TabWithFile
    {
        /// <summary>
        /// Основной элемент данного класса, в котором хранится информация о тексте в файле.
        /// </summary>
        public readonly RichTextBox MainRichTextBox;

        public TabWithTxt() : base("Конспект.txt")
        {
            var richTextBox = new RichTextBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill,
                Font = Constants.FontForRtf,
                AcceptsTab = true
            };
            richTextBox.TextChanged += Changed;
            richTextBox.ContextMenuStrip = CreateContextMenu();
            Controls.Add(richTextBox);
            MainRichTextBox = richTextBox;
        }

        public override void LoadFile(string path)
        {
            MainRichTextBox.Text = File.ReadAllText(path);
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
                File.WriteAllText(Path, MainRichTextBox.Text);
                IsSave = true;
            }
        }
    }
}
