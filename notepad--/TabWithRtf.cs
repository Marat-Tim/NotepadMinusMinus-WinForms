using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".rtf")]
    class TabWithRtf : TabWithFile
    {
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
            Controls.Add(richTextBox);
        }

        public override void LoadFile(string path)
        {
            ((RichTextBox)Controls[0]).LoadFile(path);
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
                ((RichTextBox)Controls[0]).SaveFile(Path);
                IsSave = true;
            }
        }
    }
}
