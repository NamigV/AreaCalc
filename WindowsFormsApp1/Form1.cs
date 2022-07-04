using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Geometric_Shape> gS = new List<Geometric_Shape>();
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < gS.Count; i++)
            {
                gS[i].Drawing_a_Shape(e.Graphics);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < gS.Count; i++)
            {
                gS[i].HitCheck(e.X, e.Y, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            }
            Invalidate();
        }

        private void CreateNew_Click(object sender, EventArgs e)
        {
            switch (rnd.Next(1, 4))
            {
                case 1:
                    gS.Add(new Circle(new Point(rnd.Next(200, this.Width - 100), rnd.Next(200, this.Height - 100)), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)), rnd.Next(50, 200)));
                    break;
                case 2:
                    gS.Add(new Triangle(new Point(rnd.Next(200, this.Width - 100), rnd.Next(200, this.Height - 100)), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)), rnd.Next(50, 200)));
                    break;
                case 3:
                    gS.Add(new Square(new Point(rnd.Next(200, this.Width - 100), rnd.Next(200, this.Height - 100)), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)), rnd.Next(50, 200)));
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        private void SaveToFile_Click(object sender, EventArgs e)
        {
            string[] t = new string[gS.Count];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = $"{(gS[i].shapeName == "Круг" ? 1 : gS[i].shapeName == "Треугольник" ? 2 : 3)}:{gS[i].centre.X}:{gS[i].centre.Y}:{gS[i].color.R}:{gS[i].color.G}:{gS[i].color.B}:{gS[i].size}";
            }
            File.WriteAllLines("db.txt", t);
            MessageBox.Show("Файл сохранен", "ЧаВо", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            gS.Clear();
            string[] t = File.ReadAllLines("db.txt");
            for (int i = 0; i < t.Length; i++)
            {
                switch (t[i][0])
                {
                    case '1':
                        gS.Add(new Circle(
                            new Point(int.Parse(t[i].Split(':')[1]), int.Parse(t[i].Split(':')[2])), 
                            Color.FromArgb(int.Parse(t[i].Split(':')[3]), int.Parse(t[i].Split(':')[4]), int.Parse(t[i].Split(':')[5])), 
                            int.Parse(t[i].Split(':')[6])));
                        break;
                    case '2':
                        gS.Add(new Triangle(
                            new Point(int.Parse(t[i].Split(':')[1]), int.Parse(t[i].Split(':')[2])),
                            Color.FromArgb(int.Parse(t[i].Split(':')[3]), int.Parse(t[i].Split(':')[4]), int.Parse(t[i].Split(':')[5])),
                            int.Parse(t[i].Split(':')[6])));
                        break;
                    case '3':
                        gS.Add(new Square(
                            new Point(int.Parse(t[i].Split(':')[1]), int.Parse(t[i].Split(':')[2])),
                            Color.FromArgb(int.Parse(t[i].Split(':')[3]), int.Parse(t[i].Split(':')[4]), int.Parse(t[i].Split(':')[5])),
                            int.Parse(t[i].Split(':')[6])));
                        break;
                    default:
                        break;
                }
            }
            Invalidate();
        }
    }
}
