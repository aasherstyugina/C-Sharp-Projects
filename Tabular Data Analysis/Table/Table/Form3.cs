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
    public partial class Form3 : Form
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        public Form3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Сохранение графика.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Chart chart = this.Controls[0] as Chart;
                ChartImageFormat format = new ChartImageFormat();
                // Увеличиваем значение счетчика сохраняемых графиков.
                Form1.counter++;
                // Сохраняем график.
                chart.SaveImage($"newImage{Form1.counter}.jpeg", format);
                MessageBox.Show($"Изображение сохранено в bin\\Debug\\newImage{Form1.counter}");
            }
            catch
            {
                MessageBox.Show("График не удалось сохранить.");
            }
        }
    }
}
