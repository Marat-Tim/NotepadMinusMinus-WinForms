using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    [ExtensionOfFile(".png")]
    class TabWithPng : TabWithFile
    {
        public TabWithPng() : base("Конспект.png")
        {
            PictureBox pictureBox = new PictureBox()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Controls.Add(pictureBox);
            isSave = true;
        }

        public override void LoadFile(string path)
        {
            ((PictureBox)Controls[0]).Load(path);
            base.LoadFile(path);
        }

        public override void SaveFile()
        {
            base.SaveFile();
            if (!IsSave)
            {
                IsSave = true;
            }
        }
    }
}
