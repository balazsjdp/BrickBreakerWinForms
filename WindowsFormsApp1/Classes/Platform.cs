using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    class Platform
    {
        private int width;
        private int height;
        private Pen blackPen = new Pen(Color.Black, 3);
        private SolidBrush brush = new SolidBrush(Color.Black);
        PointF coordinates;
        private float v = 15;

        public Platform(int w, int h, PointF initialCoords)
        {
            width = w;
            height = h;
            coordinates = initialCoords;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(blackPen, coordinates.X, coordinates.Y, width, height);
            e.Graphics.FillRectangle(brush, coordinates.X, coordinates.Y, width, height);
        }

        public void Move(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                if (e.KeyCode == Keys.Right)
                {
                    coordinates.X = coordinates.X + 1.0f * v;
                }
                if (e.KeyCode == Keys.Left)
                {
                    coordinates.X = coordinates.X - 1.0f * v;
                }
            }
        }
    }
}
