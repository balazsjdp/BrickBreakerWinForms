using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrBr2.Classes
{
    class Brick
    {
        private Pen redPen = new Pen(Color.DarkGray, 3);
        private SolidBrush brush = new SolidBrush(Color.OrangeRed);
        public PointF coordinates;

        public static int width = 40;
        public static int height = 10;

        public Brick(PointF coords)
        {
            coordinates = coords;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(redPen, coordinates.X, coordinates.Y, width, height);
            e.Graphics.FillRectangle(brush, coordinates.X, coordinates.Y, width, height);
        }
    }
}
