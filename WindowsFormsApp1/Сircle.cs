using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Circle : Geometric_Shape
    {
        bool hitCheckFlag;

        public Circle(Point centre, Color color, int size) : base(centre, color, size) => shapeName = "Круг";

        public override float FigureArea()
        {
            return (float)(Math.PI*Math.Pow(size/2,2));
        }

        public override void Drawing_a_Shape(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(color), centre.X - size / 4, centre.Y - size / 4, size / 2, size / 2);
            if (hitCheckFlag)
                graphics.DrawString($"Имя: {shapeName}\n S: {FigureArea()}", new Font("Arial", 10), Brushes.Black, centre.X, centre.Y);
        }

        public override void Selecting_a_Shape(Color color) => this.color = color;

        public override void HitCheck(float x, float y, Color color)
        {
            if (Math.Sqrt(Math.Pow(centre.X - x, 2) + Math.Pow(centre.Y - y, 2)) <= size/2)
            {
                hitCheckFlag = hitCheckFlag ? false : true;
                Selecting_a_Shape(color);
            }
        }
    }
}
