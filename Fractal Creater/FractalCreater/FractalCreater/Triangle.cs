using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    public class Triangle : Fractal
    {
        public Triangle(int length, int recursionDepth) : base(length, recursionDepth)
        {

        }
        // Отрисовка фрактала.
        public override void Draw(Graphics graphics, PictureBox pictureBox, PointF p1, int recursion, float len)
        {
            PointF p2 = new PointF(p1.X - len / 2, p1.Y + (float)(len * Math.Cos(Math.PI / 3)));
            PointF p3 = new PointF(p1.X + len / 2, p1.Y + (float)(len * Math.Cos(Math.PI / 3)));
            graphics.FillPolygon(new SolidBrush(Enumerable.ElementAt(this.colors, recursion - 1)), new PointF[] { p1, p2, p3 });
            DrawTriangle(graphics, p1, p2, p3, recursion, len);
        }
        /// <summary>
        /// Отрисовка.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="p1"> Вершина треугольника. </param>
        /// <param name="p2"> Вершина треугольника. </param>
        /// <param name="p3"> Вершина треугольника. </param>
        /// <param name="recursion"> Итерация. </param>
        /// <param name="len"> Длина стороны. </param>
        public void DrawTriangle(Graphics graphics, PointF p1, PointF p2, PointF p3, int recursion, float len)
        {
            if (recursion > 0)
            {
                // Вычисление середин сторон треугольника.
                PointF pp3 = new PointF((p2.X + p1.X) / 2, (p1.Y + p2.Y) / 2);
                PointF pp2 = new PointF((p3.X + p1.X) / 2, (p1.Y + p3.Y) / 2);
                PointF pp1 = new PointF((p3.X + p2.X) / 2, (p3.Y + p2.Y) / 2);
                // Закрашиваем треугольник в цвет текущей итерации.
                graphics.FillPolygon(new SolidBrush(Enumerable.ElementAt(this.colors, recursion - 1)), new PointF[] { pp1, pp2, pp3 });
                // Рекурсивно выполняем алгоритм для образовавшихся треугольников.
                DrawTriangle(graphics, p1, pp3, pp2, recursion - 1, len / 3);
                DrawTriangle(graphics, pp1, p3, pp2, recursion - 1, len / 3);
                DrawTriangle(graphics, pp1, pp3, p2, recursion - 1, len / 3);
            }

        }
    }
}
