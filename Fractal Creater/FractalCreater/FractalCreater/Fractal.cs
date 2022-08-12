using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace FractalCreater
{
    /// <summary>
    /// Абстрактный класс фракталов, от которого наследуются конкретные виды.
    /// </summary>
    public abstract class Fractal
    {
        // Поля базового класса.
        public int Length { get; set; }
        public int RecursionDepth { get; set; }
        public IEnumerable<Color> colors;
        // Конструктор.
        public Fractal(int length, int recursionDepth)
        {
            this.Length = length;
            this.RecursionDepth = recursionDepth;
        }
        // Абстрактный метод отрисовки.
        public abstract void Draw(Graphics graphics, PictureBox pictureBox, PointF p, int recursion, float len);
    }
}
