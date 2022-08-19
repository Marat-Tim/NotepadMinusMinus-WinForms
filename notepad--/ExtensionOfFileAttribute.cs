using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMinusMinus
{
    /// <summary>
    /// Атрибут указывающий расширение файлов, с которыми работает класс.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    sealed class ExtensionOfFileAttribute : Attribute
    {
        public string Extension;

        public ExtensionOfFileAttribute(string extension)
        {
            Extension = extension;
        }
    }
}
