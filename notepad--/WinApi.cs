using System.Runtime.InteropServices;

namespace NotepadMinusMinus
{
    public class WinApi
    {
        [DllImport("user32.dll")]
        public static extern bool GetCaretPos(out System.Drawing.Point lpPoint);
    }
}
