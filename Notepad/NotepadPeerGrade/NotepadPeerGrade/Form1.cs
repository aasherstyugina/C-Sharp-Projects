using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FastColoredTextBoxNS;

namespace NotepadApp
{
    public partial class Form1 : Form
    {
        // ПРИМЕЧАНИЕ: в диалоговых окнах при открытии и при сохранении файла можно выбирать расширение для фильтра (по умолчинию стоит *.txt).

        // Приватные поля, используемые в коде: счетчики вкладок, флаг для контроля наличия несохраненных изменений, диалоговые окна.
        private int pageCounter = 0;
        private int createdPageCounter = 0;
        private List<int> flagOfChages = new List<int>();
        private List<string> pathOfOpenFiles = new List<string>();
        private OpenFileDialog openDialog;
        private SaveFileDialog saveDialog;
        private FontDialog fontDialog;
        private ColorDialog colorDialog;
        private Color backgroungColor;
        private Color fontColor;

        /// <summary>
        /// Сама форма, элементы контекстного меню и обработчики событий.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            menuStrip1.ShowItemToolTips = true;
            ToolStripMenuItem copy = new ToolStripMenuItem("Copy");
            ToolStripMenuItem paste = new ToolStripMenuItem("Paste");
            ToolStripMenuItem cut = new ToolStripMenuItem("Cut");
            ToolStripMenuItem selectAll = new ToolStripMenuItem("Select all");
            ToolStripMenuItem setFormat = new ToolStripMenuItem("Set format of selected text");
            ToolStripMenuItem[] contextMenu = new[] { copy, paste, cut, selectAll, setFormat };
            contextMenuStrip1.Items.AddRange(contextMenu);
            copy.Click += CopyToolStripMenuItem_Click;
            paste.Click += PasteToolStripMenuItem_Click;
            cut.Click += СutToolStripMenuItem_Click;
            selectAll.Click += SelectAllTextToolStripMenuItem_Click;
            setFormat.Click += SetFormatOfSelectedTextToolStripMenuItem_Click;
        }

        /// <summary>
        /// Создание новой вкладки.
        /// </summary>
        private void AddNewPage()
        {
            pageCounter++;
            flagOfChages.Add(0);
            TabPage newPage = new TabPage();
            RichTextBox newRichTextBox = new RichTextBox();
            newRichTextBox.Dock = DockStyle.Fill;
            // Прикрепление контекстного меню к текстовому полю.
            newRichTextBox.ContextMenuStrip = contextMenuStrip1;
            // Прикрепление текстового поля к вкладке.
            newPage.Controls.Add(newRichTextBox);
            // Добавление вкладки в коллекцию TabControl.
            this.tabControl1.Controls.Add(newPage);
        }

        /// <summary>
        /// Создать вкладку для файлов с кодом C#.
        /// </summary>
        private void AddFastColoredTextBox()
        {
            pageCounter++;
            flagOfChages.Add(0);
            TabPage newPage = new TabPage();
            FastColoredTextBox newFastColoredTextBox = new FastColoredTextBox();
            newFastColoredTextBox.Dock = DockStyle.Fill;
            newFastColoredTextBox.Language = FastColoredTextBoxNS.Language.CSharp;
            // Прикрепление контекстного меню.
            newFastColoredTextBox.ContextMenuStrip = contextMenuStrip1;
            // Прикрепление текстового поля к вкладке.
            newPage.Controls.Add(newFastColoredTextBox);
            // Добавление вкладки в коллекцию TabControl.
            this.tabControl1.Controls.Add(newPage);
        }

        /// <summary>
        /// При наличии несохраненных изменений в текстовом поле флаг с индексом данной вкладки принимает значение 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeFlag(object sender, EventArgs e)
        {
            flagOfChages[tabControl1.SelectedIndex] = 1;
        }

        /// <summary>
        /// Открыть новый документ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Настройки диалогового окна для открытия файла.
            openDialog = new OpenFileDialog();
            openDialog.DefaultExt = ".txt";
            openDialog.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf|Cs files (*.cs)|*.cs";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Если файл *.rtf, то создаем новую вкладку и загружаем файл с сохранением форматирования.
                    if (Path.GetExtension(openDialog.FileName) == ".rtf")
                    {
                        AddNewPage();
                        // Отображаем имя файла на вкладке.
                        this.tabControl1.Controls[pageCounter - 1].Text = Path.GetFileNameWithoutExtension(openDialog.FileName);
                        RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.Controls[pageCounter - 1].Controls[0];
                        currentRichTextBox.LoadFile(openDialog.FileName);
                        currentRichTextBox.TextChanged += ChangeFlag;
                    }
                    // Если файл *.txt, то создаем новую вкладку и загружаем содержимое файла как текст.
                    else
                    {
                        if (Path.GetExtension(openDialog.FileName) == ".txt")
                        {
                            string text = File.ReadAllText(openDialog.FileName);
                            // Создаем новую вкладку с RichTextBox.
                            AddNewPage();
                            // Отображаем имя файла на вкладке.
                            this.tabControl1.Controls[pageCounter - 1].Text = Path.GetFileNameWithoutExtension(openDialog.FileName);
                            this.tabControl1.Controls[pageCounter - 1].Controls[0].Text = text;
                            this.tabControl1.Controls[pageCounter - 1].Controls[0].TextChanged += ChangeFlag;
                        }
                        else
                        {
                            string text = File.ReadAllText(openDialog.FileName);
                            // Создаем новую вкладку с FastColoredTextBox.
                            AddFastColoredTextBox();
                            // Отображаем имя файла на вкладке.
                            this.tabControl1.Controls[pageCounter - 1].Text = Path.GetFileNameWithoutExtension(openDialog.FileName);
                            this.tabControl1.Controls[pageCounter - 1].Controls[0].Text = text;
                            this.tabControl1.Controls[pageCounter - 1].Controls[0].TextChanged += ChangeFlag;
                        }
                    }
                    pathOfOpenFiles.Add(openDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Ошибка! Невозможно открыть документ.");
                }
            }
        }

        /// <summary>
        /// Создать файл в новой вкладке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInANewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createdPageCounter++;
            // Создаем новую вкладку с именем "Untitled{порядковый номер}" и пустым содержимым.
            AddNewPage();
            this.tabControl1.Controls[pageCounter - 1].Text = $"Untitled{createdPageCounter}";
            this.tabControl1.Controls[pageCounter - 1].Controls[0].Text = "";
            this.tabControl1.Controls[pageCounter - 1].Controls[0].TextChanged += ChangeFlag;
            pathOfOpenFiles.Add(null);
        }

        /// <summary>
        /// Сохранить текущий документ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCurrentDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            // Проверяем, что текущий документ существует (открытых документов не 0).
            if (pageCounter != 0)
            {
                // Настройки диалогового окна для сохранения файла.
                saveDialog = new SaveFileDialog();
                saveDialog.FileName = this.tabControl1.SelectedTab.Text;
                saveDialog.DefaultExt = ".txt";
                saveDialog.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf|Cs files (*.cs)|*.cs";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Если файл *.rtf, то сохраняем его с учетом форматирования.
                        if (Path.GetExtension(saveDialog.FileName) == ".rtf")
                        {
                            RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                            currentRichTextBox.SaveFile(saveDialog.FileName);
                            // Несохраненных изменений нет, флаг принимает значение 0.
                            flagOfChages[tabControl1.SelectedIndex] = 0;
                            this.tabControl1.SelectedTab.Text = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                        }
                        // Если файл *.txt, то сохраняем его содержимое в файл как текст.
                        else
                        {
                            File.WriteAllText(saveDialog.FileName, this.tabControl1.SelectedTab.Controls[0].Text);
                            // Несохраненных изменений нет, флаг принимает значение 0.
                            flagOfChages[tabControl1.SelectedIndex] = 0;
                            this.tabControl1.SelectedTab.Text = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно сохранить документ.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Нет открытых или созданных документов.");
            }
        }

        /// <summary>
        /// Копировать.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что вкладок не 0.
                if (pageCounter != 0)
                {
                    // Копируем выделенный фрагмент текста в буфер обмена.
                    RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                    Clipboard.SetText(currentRichTextBox.SelectedText);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Не удалось скопировать выделенный фрагмент.\nВозможно, ничего не выделено.");
            }
        }

        /// <summary>
        /// Вставить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // проверяем, что открытых вкладок не 0.
                if (pageCounter != 0)
                {
                    // Вставляем содержимое буфера обмена.
                    RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                    currentRichTextBox.Paste();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Не удалось вставить содержимое из буфера обмена.");
            }
        }

        /// <summary>
        /// Вырезать.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что открытых вкладок не 0.
                if (pageCounter != 0)
                {
                    // Копируем выделенный фрагмент текста в буфер обмена и заменяем этот фрагмент на пустую строку, тем самым вырезаем текст.
                    RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                    Clipboard.SetText(currentRichTextBox.SelectedText);
                    currentRichTextBox.SelectedText = "";
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Не удалось вырезать выделенный фрагмент.\nВозможно, ничего не выделено.");
            }
        }

        /// <summary>
        /// Выбрать весь текст.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, что открытых вкладок не 0.
            if (pageCounter != 0)
            {
                // Выделяем весь текст.
                RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                currentRichTextBox.SelectAll();
            }
        }

        /// <summary>
        /// Выбор основного шрифта для всех открытых вкладок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, что открытых вкладок не 0.
            if (pageCounter != 0)
            {
                fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Для каждой вкладки применяем выбранный шрифт.
                        foreach (TabPage page in this.tabControl1.TabPages)
                        {
                            page.Controls[0].Font = fontDialog.Font;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно изменить стиль текста.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Нет открытых или созданных документов.");
            }
        }

        /// <summary>
        /// Форматирование выбранного текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetFormatOfSelectedTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, что открытых вкладок не 0.
            if (pageCounter != 0)
            {
                fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Устанавливаем выбранный шрифт для выбранного текста.
                        RichTextBox currentRichTextBox = (RichTextBox)this.tabControl1.SelectedTab.Controls[0];
                        currentRichTextBox.SelectionFont = fontDialog.Font;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно изменить стиль выбранного текста.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Нет открытых или созданных документов.");
            }
        }

        /// <summary>
        /// Цвет шрифта для всех вкладок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, что открытых вкладок не 0.
            if (pageCounter != 0)
            {
                colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Для каждой вкладки устанавливаем выбранный цвет шрифта.
                        foreach (TabPage page in this.tabControl1.TabPages)
                        {
                            page.Controls[0].ForeColor = colorDialog.Color;
                        }
                        fontColor = colorDialog.Color;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно изменить цвет текста.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Нет открытых или созданных документов.");
            }
        }

        /// <summary>
        /// Цвет фона для каждой вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, что открытых вкладок не 0.
            if (pageCounter != 0)
            {
                colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Для каждой вкладки устанавливаем выбранный цвет фона.
                        foreach (TabPage page in this.tabControl1.TabPages)
                        {
                            page.Controls[0].BackColor = colorDialog.Color;
                        }
                        backgroungColor = colorDialog.Color;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно изменить цвет фона текстового поля.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Нет открытых или созданных документов.");
            }
        }

        /// <summary>
        /// Сохранить все документы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохраняем каждый открытый файл.
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                // Настройки диалогового окна сохранения для каждого файла.
                saveDialog = new SaveFileDialog();
                saveDialog.FileName = tabControl1.TabPages[i].Text;
                saveDialog.DefaultExt = ".txt";
                saveDialog.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf|Cs files (*.cs)|*.cs";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Если файл *.rtf, то сохраняем его с учетом форматирования.
                        if (Path.GetExtension(saveDialog.FileName) == ".rtf")
                        {
                            RichTextBox currentRichTextBox = (RichTextBox)tabControl1.TabPages[i].Controls[0];
                            currentRichTextBox.SaveFile(saveDialog.FileName);
                            // Несохраненных изменений нет, флаг принимает значение 0.
                            flagOfChages[i] = 0;
                            tabControl1.TabPages[i].Text = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                        }
                        // Если файл *.txt, то сохраняем его содержимое в файл как текст.
                        else
                        {
                            File.WriteAllText(saveDialog.FileName, tabControl1.TabPages[i].Controls[0].Text);
                            // Несохраненных изменений нет, флаг принимает значение 0.
                            flagOfChages[i] = 0;
                            tabControl1.TabPages[i].Text = Path.GetFileNameWithoutExtension(saveDialog.FileName);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка! Невозможно сохранить документ.");
                    }
                }
            }
        }

        /// <summary>
        /// Выход из приложения при нажатии кнопки в меню или горячей клавиши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Событие при закрытии формы (нажатие на крестик).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int i;
            string question = "There are unsaved changes in the file. Do you want to save it before closing the application?";
            // Для каждого открытого файла проверяем, есть ли несохраненные изменения.
            for (i = 0; i < tabControl1.TabPages.Count; i++)
            {
                if (flagOfChages[i] == 1)
                {
                    // Если есть, то спрашиваем у пользователя, хочет ли он сохранить файл перед закрытием формы.
                    var answer = MessageBox.Show(question, "Closing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (answer == DialogResult.Yes)
                    {
                        SaveFile();
                    }
                    // Отмена закрытия.
                    if (answer == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        /// <summary>
        /// Таймер для автосохранения через каждые 30 секунд.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThirtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 30000;
            timer1.Enabled = true;
        }

        /// <summary>
        /// Таймер для автосохранения через каждую минуту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 60000;
            timer1.Enabled = true;
        }

        /// <summary>
        /// Таймер для автосохранения через каждые две минуты.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 120000;
            timer1.Enabled = true;
        }

        /// <summary>
        /// Выключение таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NeverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        /// <summary>
        /// По истечении времени на таймере сохраняем последнюю версию каждого открытого файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                try
                {
                    if (pathOfOpenFiles[i] != null)
                    {
                        File.WriteAllText(pathOfOpenFiles[i], tabControl1.TabPages[i].Controls[0].Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка автосохранения");
                }
            }
        }

        /// <summary>
        /// Событие при нажатии CTRL+Z или CTRL+SHIFT+Z - отмена или повтор предудщего действия соответственно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Shift && e.Control && e.KeyCode == Keys.Z)
                {
                    RichTextBox currentRichTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                    currentRichTextBox.Redo();
                }
                else
                {
                    if (e.Control && e.KeyCode == Keys.Z)
                    {
                        RichTextBox currentRichTextBox = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                        currentRichTextBox.Undo();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Невозможна отмена/повторение предыдущего действия.");
            }
        }

        /// <summary>
        /// Создать документ в новом окне.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInANewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаем новую форму.
            Form1 newForm = new Form1();
            newForm.Show();
            newForm.createdPageCounter++;
            // Создаем новую вкладку с именем "Untitled{порядковый номер}" и пустым содержимым.
            newForm.AddNewPage();
            newForm.tabControl1.Controls[newForm.pageCounter - 1].Text = $"Untitled{newForm.createdPageCounter}";
            newForm.tabControl1.Controls[newForm.pageCounter - 1].Controls[0].Text = "";
            newForm.tabControl1.Controls[newForm.pageCounter - 1].Controls[0].TextChanged += newForm.ChangeFlag;
            newForm.pathOfOpenFiles.Add(null);
        }
    }
}
