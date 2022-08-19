﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadMinusMinus
{
    /// <summary>
    /// Вкладка с файлом.
    /// </summary>
    abstract class TabWithFile : TabPage
    {
        /// <summary>
        /// Задает изначально название вкладки.
        /// </summary>
        /// <param name="text">Название вкладки.</param>
        public TabWithFile(string text) : base($"*{text}") { }

        /// <summary>
        /// Название файла на панели выбора файлов. 
        /// В сеттере автоматически сокращается до нужных размеров.
        /// </summary>
        public override string Text
        {
            get => base.Text;
            set
            {
                if (value != null)
                {
                    var fileInfo = new FileInfo(value);
                    if (value.Length > Constants.MaxNumberOfSymbolsInFileName)
                    {
                        base.Text =
                            $"{value[0..(Constants.MaxNumberOfSymbolsInFileName - fileInfo.Extension.Length - 4)]}" +
                            $"... {fileInfo.Extension}";
                        return;
                    }
                }
                base.Text = value;
            }
        }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Расширение файла.
        /// </summary>
        public string Extension => new FileInfo(Path ?? Text).Extension;

        /// <summary>
        /// Сохранен ли файл.
        /// В сеттере автоматически добавляет или убирает звездочку в зависимоти от того, сохранен ли файл.
        /// </summary>
        public bool IsSave
        {
            get => isSave;
            set
            {
                if (!isSave && value)
                {
                    Text = Text[1..];
                    ((Control)Parent).Refresh();
                }
                if (isSave && !value)
                {
                    Text = $"*{Text}";
                    ((Control)Parent).Refresh();
                }
                isSave = value;
            }
        }
        protected bool isSave = false;

        /// <summary>
        /// Загружает файл на вкладку.
        /// </summary>
        /// <param name="path">Путь к загружаемому файлу.</param>
        public virtual void LoadFile(string path)
        {
            var fileInfo = new FileInfo(path);
            Path = path;
            Text = fileInfo.Name;
            isSave = true;
        }

        /// <summary>
        /// Сохраняет или создает файл с вкладки в памяти компьютера.
        /// </summary>
        /// <param name="instructionsForSavingFile">
        /// Действия для непосредственного сохранения файла в памяти.
        /// </param>
        public virtual void SaveFile()
        {
            if (Path == null)
            {
                GetPathByDialog();
                if (Path == null)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Если файл не сохранен, то предлагает пользователю сохранить файл.
        /// </summary>
        public virtual void Close()
        {
            if (!IsSave)
            {
                var dialog = MessageBox.Show($"Хотите сохранить изменения в файле {Path ?? Text[1..]}",
                    "Сохранить изменения?", MessageBoxButtons.YesNoCancel);
                if (dialog == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
            ((TabControl)Parent).TabPages.Remove(this);
        }

        /// <summary>
        /// Получает от пользователя путь, по которому нужно сохранить файл.
        /// </summary>
        protected void GetPathByDialog()
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = Constants.InitialDirectory,
                Filter = $"Файл с конспектом|{Extension}",
                FileName = Text[1..]
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path = dialog.FileName;
            }
        }

        /// <summary>
        /// Добавляет звездочку в начало название вкладки при изменении содержимого файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Changed(object sender, EventArgs e)
        {
            if (IsSave)
            {
                IsSave = false;
            }
        }
    }
}