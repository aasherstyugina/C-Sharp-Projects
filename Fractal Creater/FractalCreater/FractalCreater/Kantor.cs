using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    public class Kantor : Fractal
    {
        // Поле равное промежтку между отрезками.
        public double Distance { get; set; }
        // Конструктор.
        public Kantor(int length, int recursionDepth, double distance) : base(length, recursionDepth)
        {
            this.Distance = distance;
        }
        /// <summary>
        /// Отрисовка фрактала.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pictureBox"></param>
        /// <param name="p"> Точка начала отрезка. </param>
        /// <param name="recursion"> Итерация. </param>
        /// <param name="len"> Длина текущего отрезка. </param>
        public override void Draw(Graphics graphics, PictureBox pictureBox, PointF p, int recursion, float len)
        {
            if (recursion > 0)
            {
                // Получаем цвет текущей итерации.
                Pen pen = new Pen(Enumerable.ElementAt(this.colors, recursion - 1), 8);
                // Рисуем отрезок и рекурсивно вызываем метод для двух отрезков "под ним".
                graphics.DrawLine(pen, p, new PointF(p.X + len, p.Y));
                float size = (float)((this.Distance - 1) / (2 * this.Distance) * len);
                Draw(graphics, pictureBox, new PointF(p.X, p.Y + 20), recursion - 1, size);
                Draw(graphics, pictureBox, new PointF(p.X + len - size, p.Y + 20), recursion - 1, size);
            }
        }
    }
}
