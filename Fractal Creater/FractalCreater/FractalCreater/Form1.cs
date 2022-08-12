using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace FractalCreater
{
    public partial class Form1 : Form
    {
        // Для сохранения изображения.
        private Bitmap drawnBitmap;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            drawnBitmap = null;
        }

        /// <summary>
        /// Вывод текущего значения глубины рекурсии при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void recursionTrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar1.Text = String.Format("Текущее значение: {0}", recursionTrackBar.Value);
        }

        /// <summary>
        /// Вывод текущего значения длины отрезка при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lengthTrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar2.Text = String.Format("Текущее значение: {0}", lengthTrackBar.Value);
        }

        /// <summary>
        /// Вывод текущего значения угла наклона первого отрезка в дереве при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angle1TrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar3.Text = String.Format("Текущее значение: {0}", angle1TrackBar.Value);
        }

        /// <summary>
        /// Вывод текущего значения угла наклона второго отрезка в дереве при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void angle2TrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar4.Text = String.Format("Текущее значение: {0}", angle2TrackBar.Value);
        }

        /// <summary>
        /// Вывод текущего значения коэффициента отношения соседних ветвей в дереве при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coefficientTrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar5.Text = String.Format("Текущее значение: {0}", 1 + coefficientTrackBar.Value / 10.0);
        }

        /// <summary>
        /// Выбор вида фрактала для отрисовки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kindOfFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kindOfFractal.Text)
            {
                // Делаем видимыми и изменяем необходимые параметры, остальные скрываем.
                case "Обдуваемое ветром дерево":
                    lengthTrackBar.Maximum = 200;
                    angle1Label1.Visible = true;
                    angle1Label2.Visible = true;
                    angle1TrackBar.Visible = true;
                    currentTrackBar3.Visible = true;
                    angle2Label1.Visible = true;
                    angle2Label2.Visible = true;
                    angle2TrackBar.Visible = true;
                    currentTrackBar4.Visible = true;
                    coefficientLabel.Visible = true;
                    coefficientTrackBar.Visible = true;
                    currentTrackBar5.Visible = true;
                    distanceLabel.Visible = false;
                    distanceTrackBar.Visible = false;
                    currentTrackBar6.Visible = false;
                    break;
                // Делаем видимыми и изменяем необходимые параметры, остальные скрываем.
                case "Множество Кантора":
                    lengthTrackBar.Maximum = 800;
                    angle1Label1.Visible = false;
                    angle1Label2.Visible = false;
                    angle1TrackBar.Visible = false;
                    currentTrackBar3.Visible = false;
                    angle2Label1.Visible = false;
                    angle2Label2.Visible = false;
                    angle2TrackBar.Visible = false;
                    currentTrackBar4.Visible = false;
                    coefficientLabel.Visible = false;
                    coefficientTrackBar.Visible = false;
                    currentTrackBar5.Visible = false;
                    distanceLabel.Visible = true;
                    distanceTrackBar.Visible = true;
                    currentTrackBar6.Visible = true;
                    break;
                // Делаем видимыми и изменяем необходимые параметры, остальные скрываем.
                default:
                    lengthTrackBar.Maximum = 800;
                    angle1Label1.Visible = false;
                    angle1Label2.Visible = false;
                    angle1TrackBar.Visible = false;
                    currentTrackBar3.Visible = false;
                    angle2Label1.Visible = false;
                    angle2Label2.Visible = false;
                    angle2TrackBar.Visible = false;
                    currentTrackBar4.Visible = false;
                    coefficientLabel.Visible = false;
                    coefficientTrackBar.Visible = false;
                    currentTrackBar5.Visible = false;
                    distanceLabel.Visible = false;
                    distanceTrackBar.Visible = false;
                    currentTrackBar6.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Выбор стартового цвета и соответственное изменение цвета кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startColorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Внимание! По умолчанию будет выбран черный цвет.");
            startColorDialog.ShowDialog();
            startColorButton.BackColor = startColorDialog.Color;
            checkStart.Text = "0";
        }

        /// <summary>
        /// Выбор конечного цвета и соответственное изменение цвета кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endColorButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Внимание! По умолчанию будет выбран черный цвет.");
            endColorDialog.ShowDialog();
            endColorButton.BackColor = endColorDialog.Color;
            checkEnd.Text = "0";
        }

        /// <summary>
        /// Алгоритм для создания коллекции градиентных цветов.
        /// </summary>
        /// <param name="start"> Стартовый цвет. </param>
        /// <param name="end"> Конечный цвет. </param>
        /// <param name="steps"> Глубина рекурсии. </param>
        /// <returns></returns>
        public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
        {
            // Если глубина рекурсии больше одного, то получаем градиентные цвета.
            if (steps > 1)
            {
                int stepA = ((end.A - start.A) / (steps - 1));
                int stepR = ((end.R - start.R) / (steps - 1));
                int stepG = ((end.G - start.G) / (steps - 1));
                int stepB = ((end.B - start.B) / (steps - 1));

                for (int i = 0; i < steps; i++)
                {
                    yield return Color.FromArgb(start.A + (stepA * i),
                                                start.R + (stepR * i),
                                                start.G + (stepG * i),
                                                start.B + (stepB * i));
                }
            }
            // Если меньше, то красим все в конечный цвет.
            else
            {
                yield return start;
                yield return end;
            }
        }

        /// <summary>
        /// Действие кнопки Применить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Для сохранения изображения.
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.FillRectangle(new SolidBrush(pictureBox1.BackColor), 0, 0, pictureBox1.Width, pictureBox1.Height);
            switch (kindOfFractal.SelectedItem)
            {
                case "Обдуваемое ветром дерево":
                    // Проверяем, что все параметры выбраны.
                    if ((currentTrackBar1.Text == "") || (currentTrackBar2.Text == "") || (currentTrackBar3.Text == "") ||
                        (currentTrackBar4.Text == "") || (currentTrackBar5.Text == "") || (checkStart.Text == "") || (checkEnd.Text == ""))
                    {
                        MessageBox.Show("Внимание! Не все параметры выбраны.");
                    }
                    else
                    {
                        // Создаём экземпляр класса.
                        Tree fractalTree = new Tree(lengthTrackBar.Value, recursionTrackBar.Value, angle1TrackBar.Value,
                            angle2TrackBar.Value, 1 + coefficientTrackBar.Value / 10.0);
                        // Создаём коллекцию цветов.
                        fractalTree.colors = GetGradients(endColorButton.BackColor, startColorButton.BackColor, recursionTrackBar.Value);
                        // Рисуем фрактал.
                        fractalTree.Draw(g, pictureBox1, new Point(pictureBox1.Width / 2, pictureBox1.Height), recursionTrackBar.Value, lengthTrackBar.Value);
                        // Сохраняем изображение.
                        drawnBitmap = new Bitmap(pictureBox1.Image);
                    }
                    break;
                case "Кривая Коха":
                    // Проверяем, что все параметры выбраны.
                    if ((currentTrackBar1.Text == "") || (currentTrackBar2.Text == "") || (checkStart.Text == "") || (checkEnd.Text == ""))
                    {
                        MessageBox.Show("Внимание! Не все параметры выбраны.");
                    }
                    else
                    {
                        // Создаём экземпляр класса.
                        CochCurve fractalCochCurve = new CochCurve(lengthTrackBar.Value, recursionTrackBar.Value);
                        // Создаём коллекцию цветов.
                        fractalCochCurve.colors = GetGradients(endColorButton.BackColor, startColorButton.BackColor, recursionTrackBar.Value);
                        // Рисуем фрактал.
                        fractalCochCurve.Draw(g, pictureBox1, new PointF(pictureBox1.Width / 2 - lengthTrackBar.Value / 2, pictureBox1.Height * 3 / 4), recursionTrackBar.Value, lengthTrackBar.Value);
                        // Сохраняем изображение.
                        drawnBitmap = new Bitmap(pictureBox1.Image);
                    }
                    break;
                case "Ковер Серпинского":
                    // Проверяем, что все параметры выбраны.
                    if ((currentTrackBar1.Text == "") || (currentTrackBar2.Text == "") || (checkStart.Text == "") || (checkEnd.Text == ""))
                    {
                        MessageBox.Show("Внимание! Не все параметры выбраны.");
                    }
                    else
                    {
                        // Создаём экземпляр класса.
                        Carpet fractalCarpet = new Carpet(lengthTrackBar.Value, recursionTrackBar.Value);
                        // Создаём коллекцию цветов.
                        fractalCarpet.colors = GetGradients(endColorButton.BackColor, startColorButton.BackColor, recursionTrackBar.Value);
                        // Рисуем фрактал.
                        fractalCarpet.Draw(g, pictureBox1, new PointF(pictureBox1.Width / 2 - lengthTrackBar.Value / 2, 10), recursionTrackBar.Value, lengthTrackBar.Value);
                        // Сохраняем изображение.
                        drawnBitmap = new Bitmap(pictureBox1.Image);
                    }
                    break;
                case "Треугольник Серпинского":
                    // Проверяем, что все параметры выбраны.
                    if ((currentTrackBar1.Text == "") || (currentTrackBar2.Text == "") || (checkStart.Text == "") || (checkEnd.Text == ""))
                    {
                        MessageBox.Show("Внимание! Не все параметры выбраны.");
                    }
                    else
                    {
                        // Создаём экземпляр класса.
                        Triangle fractalTriangle = new Triangle(lengthTrackBar.Value, recursionTrackBar.Value);
                        // Создаём коллекцию цветов.
                        fractalTriangle.colors = GetGradients(endColorButton.BackColor, startColorButton.BackColor, recursionTrackBar.Value);
                        // Рисуем фрактал.
                        fractalTriangle.Draw(g, pictureBox1, new PointF(pictureBox1.Width / 2, 10), recursionTrackBar.Value, lengthTrackBar.Value);
                        // Сохраняем изображение.
                        drawnBitmap = new Bitmap(pictureBox1.Image);
                    }
                    break;
                case "Множество Кантора":
                    // Проверяем, что все параметры выбраны.
                    if ((currentTrackBar1.Text == "") || (currentTrackBar2.Text == "") || (currentTrackBar6.Text == "")
                        || (checkStart.Text == "") || (checkEnd.Text == ""))
                    {
                        MessageBox.Show("Внимание! Не все параметры выбраны.");
                    }
                    else
                    {
                        // Создаём экземпляр класса.
                        Kantor fractalKantor = new Kantor(lengthTrackBar.Value, recursionTrackBar.Value, distanceTrackBar.Value);
                        // Создаём коллекцию цветов.
                        fractalKantor.colors = GetGradients(endColorButton.BackColor, startColorButton.BackColor, recursionTrackBar.Value);
                        // Рисуем фрактал.
                        fractalKantor.Draw(g, pictureBox1, new PointF(pictureBox1.Width / 2 - lengthTrackBar.Value / 2, 20), recursionTrackBar.Value, lengthTrackBar.Value);
                        // Сохраняем изображение.
                        drawnBitmap = new Bitmap(pictureBox1.Image);
                    }
                    break;
                // Если не выбран вид фрактала.
                default:
                    MessageBox.Show("Внимание! Не выбран вид фрактала.");
                    break;
            }
            g.Dispose();
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Вывод текущего значения промежутка между отрезками в множестве Кантора при его изменении.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distanceTrackBar_Scroll(object sender, EventArgs e)
        {
            currentTrackBar6.Text = String.Format("Текущее значение: 1/{0}", distanceTrackBar.Value);
        }

        /// <summary>
        /// Действие кнопки Сохранить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            // Формат файла.
            sfd.DefaultExt = "jpeg";
            sfd.Filter = "All files (*.*)|*.*|jpg files (*.jpg)|*.jpg";
            try
            {
                // Сохранение изображения в файл.
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    drawnBitmap.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }
            catch
            {
                MessageBox.Show("Внимание, ошибка при сохранении изображения!");
            }
        }
    }
}
