using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Table
{
    public partial class Form2 : Form
    {
        // Диалоговое окно, чтобы выбрать цвет.
        private ColorDialog colorDialog;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вычисление среднего значения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = 0;
                int count = 0;
                Chart chart = this.Controls[1] as Chart;
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    // Считаем сумму всех элементов.
                    sum += item.XValue * item.YValues[0];
                    // Считаем количество всех элементов.
                    count += int.Parse(item.YValues[0].ToString());
                }
                MessageBox.Show($"Среднее значение = {sum / count}");
            }
            catch
            {
                MessageBox.Show("Невозможно посчитать среднее значение.");
            }
        }

        /// <summary>
        /// Вычисление медианы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MedianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> dataArray = new List<double>();
                Chart chart = this.Controls[1] as Chart;
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    // Добавляем значения всех элементов гистограммы в список.
                    for (int i = 0; i < int.Parse(item.YValues[0].ToString()); i++)
                    {
                        dataArray.Add(item.XValue);
                    }
                }
                // Сортируем список.
                dataArray.Sort();
                // Вычисляем медиану ряда элементов исходя из четности кол-ва элементов.
                if (dataArray.Count % 2 != 0)
                {
                    MessageBox.Show($"Медиана = {dataArray[(dataArray.Count - 1) / 2]}");
                }
                else
                {
                    MessageBox.Show($"Медиана = {(dataArray[dataArray.Count / 2] + dataArray[dataArray.Count / 2 - 1]) / 2}");
                }
            }
            catch
            {
                MessageBox.Show("Невозможно посчитать медиану.");
            }
        }

        /// <summary>
        /// Вычисление среднеквадратичного отклонения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandardDeviationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = 0;
                int count = 0;
                Chart chart = this.Controls[1] as Chart;
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    // Считаем сумму всех элементов гистограммы.
                    sum += item.XValue * item.YValues[0];
                    // Считаем количество всех элементов гистограммы. 
                    count += int.Parse(item.YValues[0].ToString());
                }
                // Вычисляем среднее значение всех элементов.
                double average = sum / count;
                sum = 0;
                // Суммируем квадраты разности каждого элемента и среднего значения.
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    sum += Math.Pow((item.XValue - average), 2);
                }
                // Вычисляем среднеквадратичное отклонение.
                MessageBox.Show($"Среднеквадратичное отклонение = {Math.Sqrt(sum / count)}");
            }
            catch
            {
                MessageBox.Show("Невозможно посчитать среднеквадратичное отклонение.");
            }
        }

        /// <summary>
        /// Вычисление дисперсии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double sum = 0;
                int count = 0;
                Chart chart = this.Controls[1] as Chart;
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    // Считаем сумму всех элементов гистограммы.
                    sum += item.XValue * item.YValues[0];
                    // Считаем кол-во всех элементов гистограммы.
                    count += int.Parse(item.YValues[0].ToString());
                }
                // Вычисляем среднее значение.
                double average = sum / count;
                sum = 0;
                // Суммируем квадраты разности каждого элемента и среднего значения.
                foreach (DataPoint item in chart.Series[0].Points)
                {
                    sum += Math.Pow((item.XValue - average), 2);
                }
                // Вычисляем дисперсию.
                MessageBox.Show($"Дисперсия = {sum / count}");
            }
            catch
            {
                MessageBox.Show("Невозможно посчитать дисперсию.");
            }
        }

        /// <summary>
        /// Изменение ширины столбцов гистограммы с помощью NumericUpDown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Chart chart = this.Controls[1] as Chart;
                // Устанавливаем ширину столбцов в зависимости от текущего значения NumericUpDown.
                chart.Series["Series1"]["PixelPointWidth"] = $"{numericUpDown.Value}";
            }
            catch
            {
                MessageBox.Show("Нельзя изменить ширину столбцов гистограммы.");
            }
        }

        /// <summary>
        /// Изменение цвета колонки по нажатию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
            Chart chart = this.Controls[1] as Chart;
            // Получаем элемент гистограммы, на который нажал пользователь (по координатам).
            HitTestResult pointClick = chart.HitTest(e.X, e.Y);
            // Если этот элемент Data Point, то меняем его цвет.
            if (pointClick.ChartElementType == ChartElementType.DataPoint)
            {
                try
                {
                    // Выбор цвета через диалоговое окно.
                    colorDialog = new ColorDialog();
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Меняем цвет колонки, на которую нажал пользователь.
                        pointClick.Series.Points[pointClick.PointIndex].Color = colorDialog.Color;
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно изменить цвет.");
                }
            }
        }


    }
}
