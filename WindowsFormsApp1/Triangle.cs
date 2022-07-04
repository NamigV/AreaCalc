using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Triangle : Geometric_Shape
    {
        PointF[] pointFs = new PointF[3];
        bool hitCheckFlag;

        public Triangle(Point centre, Color color, int size) : base(centre, color, size)
        {
            shapeName = "Треугольник";
            float R = 2 * size / 3;
            float r = size / 3;
            float K = (float)(Math.Sqrt(Math.Pow(R, 2) - Math.Pow(r, 2)));
            pointFs[0].X = centre.X;
            pointFs[0].Y = centre.Y - R;
            pointFs[1].X = centre.X + K;
            pointFs[1].Y = centre.Y + r;
            pointFs[2].X = centre.X - K;
            pointFs[2].Y = centre.Y + r;
        }

        public override float FigureArea()
        {
            return (float)(Math.Pow(size, 2) / Math.Sqrt(3));
        }

        public override void Drawing_a_Shape(Graphics graphics)
        {
            graphics.FillPolygon(new SolidBrush(color), pointFs);
            if (hitCheckFlag)
                graphics.DrawString($"Имя: {shapeName}\n S: {FigureArea()}", new Font("Arial", 10), Brushes.Black, centre.X, centre.Y);
        }

        public override void Selecting_a_Shape(Color color) => this.color = color;

        public override void HitCheck(float x, float y, Color color)
        {
            bool d1 = ((x - pointFs[2].X) * (pointFs[0].Y - pointFs[2].Y) - (y - pointFs[2].Y) * (pointFs[0].X - pointFs[2].X)) <= 0;
            bool d2 = ((x - pointFs[1].X) * (pointFs[0].Y - pointFs[1].Y) - (y - pointFs[1].Y) * (pointFs[0].X - pointFs[1].X)) >= 0;

            if (d1 && d2 && y <= pointFs[2].Y)
            {
                hitCheckFlag = hitCheckFlag ? false : true;
                Selecting_a_Shape(color);
            }
        }
    }
}