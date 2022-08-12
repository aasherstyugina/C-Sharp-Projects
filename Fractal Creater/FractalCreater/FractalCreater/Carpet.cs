using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    public class Carpet : Fractal
    {
        // Для раскраски.
        private int i = 0, z = 0;
        public Carpet(int length, int recursionDepth) : base(length, recursionDepth)
        {

        }
        /// <summary>
        /// Метод отрисовки.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pictureBox"></param>
        /// <param name="p"> Левая верхняя вершина текущего квадрата. </param>
        /// <param name="recursion"> Итерация. </param>
        /// <param name="len"> Длина стороны текущего квадрата. </param>
        public override void Draw(Graphics graphics, PictureBox pictureBox, PointF p, int recursion, float len)
        {
            if (recursion == 0)
            {
                // Отрисовка и получаение цвета.
                graphics.FillRectangle(new SolidBrush(Enumerable.ElementAt(this.colors, i)), new RectangleF(p, new SizeF(len, len)));
                if (i == this.RecursionDepth - 1)
                {
                    z = -1;
                }
                if (i == 0)
                {
                    z = 1;
                }
                i += z;
            }
            else
            {
                // Получаем координаты для всех левых верхних вершин квадратов, после разделения текущего на девять частей.
                float size = len / 3;
                float x1 = p.X;
                float x2 = x1 + size;
                float x3 = x2 + size;
                float y1 = p.Y;
                float y2 = y1 + size;
                float y3 = y2 + size;
                // Рекурсивно вызываем метод для каждого всех полученных квадратов, кроме центрального.
                Draw(graphics, pictureBox, new PointF(x1, y1), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x2, y1), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x3, y1), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x1, y2), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x3, y2), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x1, y3), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x2, y3), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(x3, y3), recursion - 1, size);
            }
        }
    }
}
