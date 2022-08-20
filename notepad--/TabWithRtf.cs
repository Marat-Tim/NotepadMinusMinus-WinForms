using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".rtf")]
    partial class TabWithRtf : TabWithFile
    {
        public readonly RichTextBox RichTextBox;

        public TabWithRtf() : base("Конспект.rtf")
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
            this.RichTextBox = richTextBox;
        }

        public override void LoadFile(string path)
        {
            RichTextBox.LoadFile(path);
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
                RichTextBox.SaveFile(Path);
                IsSave = true;
            }
        }
    }
}
