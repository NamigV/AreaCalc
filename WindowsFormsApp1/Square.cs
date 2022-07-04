using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Square : Geometric_Shape
    {
        bool hitCheckFlag;

        public Square(Point centre, Color color, int size) : base(centre, color, size) => shapeName = "Квадрат";

        public override float FigureArea()
        {
            return size * size;
        }

        public override void Drawing_a_Shape(Graphics graphics)
        {
            Brush brush = new SolidBrush(color);
            Size size = new Size(this.size, this.size);
            Point point = new Point(centre.X - this.size / 2, centre.Y - this.size / 2);
            Rectangle rectangle = new Rectangle(point, size);
            graphics.FillRectangle(brush, rectangle);

            if (hitCheckFlag)
                graphics.DrawString($"Имя = {shapeName}\nS = {FigureArea()}\n", new Font("Arial", 10), Brushes.Black, centre.X, centre.Y);
        }

        public override void Selecting_a_Shape(Color color) => this.color = color;

        public override void HitCheck(float x, float y, Color color)
        {
            if (x > centre.X - size / 2 && x < centre.X + size / 2 && y > centre.Y - size / 2 && y < centre.Y + size / 2)
            {
                hitCheckFlag = hitCheckFlag ? false : true;
                Selecting_a_Shape(color);
            }
        }
    }
}
