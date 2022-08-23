using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    /// <summary>
    /// Главная форма в приложении.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Все классы, которые имеют атрибут ExtensionOfFile.
        /// </summary>
        private static readonly Type[] TypesWithExtensionOfFile =
            Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => (x.GetCustomAttribute<ExtensionOfFileAttribute>() != null)).ToArray();

        public MainForm(params string[] args)
        {
            InitializeComponent();

            // Если с помощью приложения открывается файл, то открывается вкладка с этим файлом.
            if (args != null && args.Length > 0)
            {
                CreateNewTab(args[0]);
            }
        }

        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Control | Keys.OemMinus:
                    if (OpenFiles.TabCount > 0)
                    {
                        ((TabWithFile)OpenFiles.SelectedTab).Close();
                    }
                    return true; 
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        /// <summary>
        /// Создает новую вкладку с файлом.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        private void CreateNewTab(string path)
        {
            // Проверяем, есть ли такой файл среди открытых
            foreach (TabWithFile tab in OpenFiles.TabPages)
            {
                if (path == tab.Path)
                {
                    OpenFiles.SelectedTab = tab;
                    return;
                }
            }

            // Создаем новую страницу в зависимости от расширения файла.
            var fileInfo = new FileInfo(path);
            foreach (var type in TypesWithExtensionOfFile)
            {
                if (type.GetCustomAttribute<ExtensionOfFileAttribute>().Extension == fileInfo.Extension)
                {
                    var tab = (TabWithFile)type.GetConstructors()[0].Invoke(null);
                    tab.LoadFile(path);
                    OpenFiles.TabPages.Add(tab);
                    OpenFiles.SelectedIndex = OpenFiles.TabCount - 1;
                    return;
                }
            }
        }

        /// <summary>
        /// Открывает существующий файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = Constants.InitialDirectory
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CreateNewTab(dialog.FileName);
            }
        }

        /// <summary>
        /// Открывает все файлы из папки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenDirectory_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog()
            {
                SelectedPath = Constants.InitialDirectory
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var path in Directory.GetFiles(dialog.SelectedPath))
                    {
                        CreateNewTab(path);
                    }
                }
            }
        }

        /// <summary>
        /// Открывает новый файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOpenNewFile_Click(object sender, EventArgs e)
        {
            OpenFiles.TabPages.Add(new TabWithRtf());
            OpenFiles.SelectedIndex = OpenFiles.TabCount - 1;
        }

        /// <summary>
        /// Отрисовывает вкладки tabControl'а с крестиком.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString(
                OpenFiles.TabPages[e.Index].Text,
                e.Font,
                new SolidBrush(Color.Black),
                e.Bounds.Left,
                e.Bounds.Top);

            e.Graphics.DrawString(
                "\u2715",
                e.Font,
                new SolidBrush(Color.Red),
                e.Bounds.Right - TextRenderer.MeasureText("\u2715", e.Font).Width,
                e.Bounds.Top);

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// Проверяет, не нажал ли пользователь на крестик.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFiles_MouseDown(object sender, MouseEventArgs e)
        {
            var r = OpenFiles.GetTabRect(OpenFiles.SelectedIndex);
            var closeButton = new Rectangle(
                            r.Right - TextRenderer.MeasureText("\u2715", OpenFiles.Font).Width,
                            r.Top,
                            TextRenderer.MeasureText("\u2715", OpenFiles.Font).Width,
                            TextRenderer.MeasureText("\u2715", OpenFiles.Font).Height);
            if (closeButton.Contains(e.Location))
            {
                ((TabWithFile)OpenFiles.SelectedTab).Close();
            }
        }

        /// <summary>
        /// Сохраняет текущую вкладку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSaveFile_Click(object sender, EventArgs e)
        {
            if (OpenFiles.TabCount > 0)
            {
                ((TabWithFile)OpenFiles.SelectedTab).SaveFile();
            }
        }

        /// <summary>
        /// Сохраняет все вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSaveAll_Click(object sender, EventArgs e)
        {
            foreach (TabWithFile tab in OpenFiles.TabPages)
            {
                tab.SaveFile();
            }
        }

        /// <summary>
        /// Предлагает сохранить файлы перед закрытием вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabWithFile tab in OpenFiles.TabPages)
            {
                tab.Close();
            }
        }

        /// <summary>
        /// Создает новую вкладку со скопированным изображениям.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopiedImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
#warning Некоторые фотографии не открываются здесь нормально, например https://img.icons8.com/ios/452/image.png. Я как понял это из за проблем ClipBoard'a
            if (Clipboard.ContainsImage())
            {
                var tab = new TabWithPng();
                ((PictureBox)tab.Controls[0]).Image = Clipboard.GetImage();
                OpenFiles.TabPages.Add(tab);
                OpenFiles.SelectedIndex = OpenFiles.TabCount - 1;
            }
        }
    }
}
