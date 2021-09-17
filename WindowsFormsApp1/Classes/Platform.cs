using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Classes
{
    class Platform
    {
        private Pen blackPen = new Pen(Color.Black, 3);
        private SolidBrush brush = new SolidBrush(Color.Black);
        private float v = 20;
        private int correctionPixel = 22;
        private int width;
        private int height;
        PointF coordinates;
        public PictureBox container;

        private PlatformPosition position;
        
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

                    if(AtWall() == PlatformPositionWall.Right)
                    {
                        coordinates.X = coordinates.X;
                        return;
                    }
                    coordinates.X = coordinates.X + 1.0f * v;
                    break;
                case PlatformMoveDirection.Left:

                    if(AtWall() == PlatformPositionWall.Left)
                    {
                        coordinates.X = coordinates.X;
                        return;
                    }

                    coordinates.X = coordinates.X - 1.0f * v;
                    break;
                case PlatformMoveDirection.None:
                    coordinates.X = coordinates.X;
                    break;
            }

             position = new PlatformPosition(coordinates.X, coordinates.Y, width, height);
        }

        private PlatformPositionWall AtWall()
        {
            float left = container.Bounds.X;
            float right = container.Bounds.Width;

            if(coordinates.X + width + correctionPixel >= right )
            {
                return PlatformPositionWall.Right;
            }
            else if(coordinates.X <= left)
            {
                return PlatformPositionWall.Left;
            }
            else
            {
                return PlatformPositionWall.None;
            }
        }

        public PlatformPosition GetPosition()
        {
            return position;
        }
        //public PointF GetPosition
    }
    
    enum PlatformMoveDirection
    {
        None,
        Left,
        Right
    }

    enum PlatformPositionWall
    {
        None,
        Left,
        Right
    }

    // Class for reporting position of the platform
    class PlatformPosition
    {
        public float x { get; set; }
        public float y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public PlatformPosition(float X, float Y, int w, int h){
            x = X;
            y = Y;
            width = w;
            height = h;
        }

    }
}
