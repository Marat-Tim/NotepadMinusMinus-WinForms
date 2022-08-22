using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadMinusMinus
{
    /// <summary>
    /// Константы, используемые в приложении.
    /// </summary>
    static class Constants
    {
        /// <summary>
        /// Папка в которой открывается FileDialog.
        /// </summary>
        public static readonly string InitialDirectory = Directory.Exists(@"C:\Users\User\Desktop\Мои уроки") ?
            @"C:\Users\User\Desktop\Мои уроки" :
            Directory.GetCurrentDirectory();

        /// <summary>
        /// Шрифт по умолчанию для rtf файлов.
        /// </summary>
        public static readonly Font FontForRtf = new Font("Segoe UI", 10f);

        /// <summary>
        /// Максимальная отображаемая длина названия файла в меню выбора вкладок.
        /// Если название файла больше чем данное число, то оно сокращается таким образом: 
        /// "{оставшееся количество символов}... {расширение полностью}" 
        /// </summary>
        public const int MaxNumberOfSymbolsInFileName = 20;

        /// <summary>
        /// Все стили текста, которые используются в контекстноем меню в rtf файлах.
        /// </summary>
        public static readonly FontStyle[] StylesForRtf = new FontStyle[]
        {
            FontStyle.Bold,
            FontStyle.Italic,
            FontStyle.Underline,
            FontStyle.Strikeout
        };

        /// <summary>
        /// Все цвета, которые используются в контекстноем меню в rtf файлах.
        /// </summary>
        public static readonly Color[] ColorsForRtf = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.LimeGreen,
            Color.Magenta,
            Color.Black,
        };
    }
}
