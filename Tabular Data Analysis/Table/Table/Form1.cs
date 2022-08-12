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
using NReco.Csv;
using System.Windows.Forms.DataVisualization.Charting;

namespace Table
{
    public partial class Form1 : Form
    {
        // Диалоговое окно, чтобы открыть файл.
        private OpenFileDialog openFileDialog;
        // Счетчик сохраняемых графиков.
        public static int counter = 0;

        // Конструктор.
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открыть csv файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            // Настройки фильтра только для csv файлов.
            openFileDialog.Filter = "Csv files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Парсим csv файл для отображения в DataGridView.
                    ParseCsv(openFileDialog.FileName);
                }
                catch(Exception error)
                {
                    MessageBox.Show($"Ошибка при открытии файла:\n{error.Message}");
                }
            }
        }

        /// <summary>
        /// Парсим csv файл для отображения в DataGridView.
        /// </summary>
        /// <param name="path"> Путь к выбранному csv файлу. </param>
        private void ParseCsv(string path)
        {
            // Очищаем таблицу.
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            using (StreamReader streamReader = new StreamReader(path))
            {
                // Устанавливаем запятую в качестве разделителя.
                CsvReader csvReader = new CsvReader(streamReader, ",");
                // Создаем колонки и считываем их названия.
                csvReader.Read();
                for (int i = 0; i < csvReader.FieldsCount; i++)
                {
                    DataGridViewColumn newColumn = new DataGridViewButtonColumn();
                    // Устанавливаем режим сортировки, имя и размер столбца, затем добавляем его в таблицу.
                    newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    newColumn.Name = csvReader[i];
                    newColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView.Columns.Add(newColumn);
                }
                // Заполняем колонки.
                while (csvReader.Read())
                {
                    // Создаем строчки, заполняем их и добавляем в таблицу.
                    DataGridViewRow newRow = new DataGridViewRow();
                    for (int i = 0; i < csvReader.FieldsCount; i++)
                    {
                        DataGridViewTextBoxCell newCell = new DataGridViewTextBoxCell();
                        newCell.Value = csvReader[i];
                        newRow.Cells.Add(newCell);
                    }
                    dataGridView.Rows.Add(newRow);
                }
            }
        }

        /// <summary>
        /// Построение гистограммы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 newChart = new Form2();
                // Проверяем, что выбран ровно один столбец.
                if (dataGridView.SelectedColumns.Count == 1)
                {
                    int flag = 0;
                    // Создаем списки для элементов гистограммы и для частоты их встречаемости.
                    List<double> dataArray = new List<double>();
                    List<int> amountArray = new List<int>();
                    // Проверяем каждый элемент выбранного столбца. Если он != null и парсится к double, то добавляем его в списки.
                    foreach (DataGridViewCell item in dataGridView.SelectedCells)
                    {
                        if ((item.Value != null))
                        {
                            if (double.TryParse(item.Value.ToString().Replace(".", ","), out double number))
                            { 
                                // В dataArray храним только уникальный значения.
                                if (!dataArray.Contains(number))
                                {
                                    dataArray.Add(number);
                                    amountArray.Add(0);
                                }
                                amountArray[dataArray.IndexOf(number)]++;
                            }
                            else
                            {
                                flag++;
                            }
                        }
                    }
                    // Если все элементы в выбранном столбце количественные, то составляем гистограмму.
                    if (flag == 0)
                    {
                        Chart chart = newChart.Controls[1] as Chart;
                        foreach (double item in dataArray)
                        {
                            chart.Series[0].Points.AddXY(item, amountArray[dataArray.IndexOf(item)]);
                        }
                        // Выводим гистограмму пользователю.
                        newChart.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Для построения гистограммы выберите один столбик с числовыми значениями.");
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Построение графика.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DependencyGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newChart = new Form3();
            // Проверяем, что выделено ровно два столбца.
            if (dataGridView.SelectedColumns.Count == 2)
            {
                int flag = 0;
                // Создаем списки cellArray для хранения выделенных ячеек каждого столбца и dataArray для хранения значений ячеек в double каждого столбца.
                List<double> dataArray1 = new List<double>();
                List<double> dataArray2 = new List<double>();
                List<DataGridViewCell> cellArray1 = new List<DataGridViewCell>();
                List<DataGridViewCell> cellArray2 = new List<DataGridViewCell>();
                // Заполняем списки cellArray.
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    cellArray1.Add(row.Cells[dataGridView.SelectedColumns[0].Index]);
                    cellArray2.Add(row.Cells[dataGridView.SelectedColumns[1].Index]);
                }
                // Парсим значения ячеек первого столбца в double.
                foreach (DataGridViewCell item in cellArray1)
                {
                    if ((item.Value != null))
                    {
                        if (double.TryParse(item.Value.ToString().Replace(".", ","), out double number))
                        {
                            dataArray1.Add(number);
                        }
                        else
                        {
                            flag++;
                        }
                    }
                }
                // Парсим значения ячеек второго столбца в double.
                foreach (DataGridViewCell item in cellArray2)
                {
                    if ((item.Value != null))
                    {
                        if (double.TryParse(item.Value.ToString().Replace(".", ","), out double number))
                        {
                            dataArray2.Add(number);
                        }
                        else
                        {
                            flag++;
                        }
                    }
                }
                // Если выбраны столбцы с количественными данными, то строим график.
                if (flag == 0)
                {
                    // Сортируем dataArray1 по возрастанию методом пузырька, а элементы dataArray2 меняем с соответственными индексами для сохранения зависимости.
                    double temp;
                    for (int i = 0; i < dataArray1.Count; i++)
                    {
                        for (int j = i + 1; j < dataArray1.Count; j++)
                        {
                            if (dataArray1[i] > dataArray1[j])
                            {
                                temp = dataArray1[i];
                                dataArray1[i] = dataArray1[j];
                                dataArray1[j] = temp;
                                if ((i < dataArray2.Count) && (j < dataArray2.Count))
                                {
                                    temp = dataArray2[i];
                                    dataArray2[i] = dataArray2[j];
                                    dataArray2[j] = temp;
                                }
                            }
                        }
                    }
                    // Строим график зависимости.
                    Chart chart = newChart.Controls[0] as Chart;
                    for(int i=0;i<Math.Min(dataArray1.Count,dataArray2.Count);i++)
                    {
                        chart.Series[0].Points.AddXY(dataArray1[i],dataArray2[i]);
                    }
                    newChart.Show();
                }
            }
            else
            {
                MessageBox.Show("Для построения графика зависимости выберите два столбика с числовыми значениями.");
            }
        }
    }
}

