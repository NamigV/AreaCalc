using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Geometric_Shape
    {
        public Point centre { get; set; }
        public Color color { get; set; }
        public int size { get; set; }
        public string shapeName { get; set; }

        protected Geometric_Shape(Point centre, Color color, int size)
        {
            this.centre = centre;
            this.color = color;
            this.size = size;
        }

        public virtual float FigureArea()
        {
            return -1;
        }

        public virtual void Drawing_a_Shape(Graphics graphics)
        {
            return;
        }

        public virtual void HitCheck(float x, float y, Color color)
        {
            return;
        }

        public virtual void Selecting_a_Shape(Color color)
        {
            return;
        }
    }
}
