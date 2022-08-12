using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    public class CochCurve : Fractal
    {
        public CochCurve(int length, int recursionDepth) : base(length, recursionDepth)
        {

        }
        // Отрисовка фрактала.
        public override void Draw(Graphics graphics, PictureBox pictureBox, PointF p, int recursion, float len)
        {
            Pen pen = new Pen(Enumerable.ElementAt(this.colors, recursion - 1));
            graphics.DrawLine(pen, p, new PointF(p.X + len, p.Y));

            DrawCoch(graphics, pictureBox, p, new PointF(p.X + len, p.Y), new PointF(p.X + len / 2, (float)(p.Y + Math.Sqrt(5) * len / 2)), recursion);
        }
        /// <summary>
        /// Отрисовка.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pictureBox"></param>
        /// <param name="p1"> Точка, делящая отрезок в отношении 1 к 3. </param>
        /// <param name="p2"> Точка, делящая отрезок в отношении 2 к 3. </param>
        /// <param name="p3"> Точка, дополняющая до равностороннего треугольника. </param>
        /// <param name="recursion"> Итерация. </param>
        public void DrawCoch(Graphics graphics, PictureBox pictureBox, PointF p1, PointF p2, PointF p3, int recursion)
        {
            if (recursion > 0)
            {
                // Получаем цвет текущей итерации.
                Pen pen = new Pen(Enumerable.ElementAt(this.colors, recursion - 1));
                // Вычисляем необходимые точки (делящие отрезок на трети, дополняющие до равностороннего треугольника и т.д.
                PointF pp1 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                PointF pp2 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                PointF mid = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                PointF pp3 = new PointF((4 * mid.X - p3.X) / 3, (4 * mid.Y - p3.Y) / 3);
                // Отрисовка текущей итерации.
                graphics.DrawLine(pen, pp1, pp3);
                graphics.DrawLine(pen, pp2, pp3);
                // Закрашиваем одну из сторон.
                graphics.DrawLine(new Pen(pictureBox.BackColor), pp2, pp1);
                // Рекурсивно вызываем метод.
                DrawCoch(graphics, pictureBox, pp1, pp3, pp2, recursion - 1);
                DrawCoch(graphics, pictureBox, pp3, pp2, pp1, recursion - 1);
                DrawCoch(graphics, pictureBox, p1, pp1, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), recursion - 1);
                DrawCoch(graphics, pictureBox, pp2, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), recursion - 1);
            }
        }
    }
}
