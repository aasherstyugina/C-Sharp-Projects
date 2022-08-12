using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    public class Tree : Fractal
    {
        // Необходимые поля для класса дерево.
        public int Angle1 { get; set; }
        public int Angle2 { get; set; }
        public double Coefficient { get; set; }
        // Конструктор.
        public Tree(int length, int recursionDepth, int angle1, int angle2, double coefficient) : base(length, recursionDepth)
        {
            this.Angle1 = angle1;
            this.Angle2 = angle2;
            this.Coefficient = coefficient;
        }
        // Отрисовка фрактала.
        public override void Draw(Graphics graphics, PictureBox pictureBox, PointF p, int recursion, float len)
        {
            Pen pen = new Pen(Enumerable.ElementAt(this.colors, recursion - 1));
            graphics.DrawLine(pen, p.X, p.Y, p.X, pictureBox.Height - len);
            DrawTree(graphics, p, recursion, len, 0);
        }
        /// <summary>
        /// Отрисовка.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="p"> Точка начала текущей ветви. </param>
        /// <param name="recursion"> Итерация. </param>
        /// <param name="len"> Длина отрезка. </param>
        /// <param name="angle"> Текущий угол наклона отрезка. </param>
        public void DrawTree(Graphics graphics, PointF p, int recursion, double len, double angle)
        {
            if (recursion > 0)
            {
                // Получение цвета для текущей итерации.
                Pen pen = new Pen(Enumerable.ElementAt(this.colors, recursion - 1));
                // Вычисление конечной координаты отрезка.
                float x1, y1;
                x1 = (float)(p.X - len * Math.Sin(Math.PI * 2 * angle / 360));
                y1 = (float)(p.Y - len * Math.Cos(Math.PI * 2 * angle / 360));
                graphics.DrawLine(pen, p, new PointF(x1, y1));
                // Рекурсивная отрисовка правой и левой ветви.
                DrawTree(graphics, new PointF(x1, y1), recursion - 1, len / this.Coefficient, angle + this.Angle1);
                DrawTree(graphics, new PointF(x1, y1), recursion - 1, len / this.Coefficient, angle - this.Angle2);
            }

        }
    }
}
