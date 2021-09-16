using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    class Platform
    {
        private Pen blackPen = new Pen(Color.Black, 3);
        private SolidBrush brush = new SolidBrush(Color.Black);

        private int width;
        private int height;
        PointF coordinates;
        private float v = 20;

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

        public void Move(PlatformMoveDirection dir)
        {
            switch (dir)
            {
                case PlatformMoveDirection.Right:
                    coordinates.X = coordinates.X + 1.0f * v;
                    break;
                case PlatformMoveDirection.Left:
                    coordinates.X = coordinates.X - 1.0f * v;
                    break;
                case PlatformMoveDirection.None:
                    coordinates.X = coordinates.X;
                    break;
            }
        }
    }
    
    enum PlatformMoveDirection
    {
        None,
        Left,
        Right
    }
}
