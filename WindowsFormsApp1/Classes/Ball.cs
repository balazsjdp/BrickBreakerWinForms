using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrBr2.Classes
{
    class Ball
    {
        private Graphics g;
        private float radius;
        public float v;
        public PointF coordinates;
        public Vector2 direction = new Vector2(-2, -1);
        public PictureBox container;

        public Ball(float r, PointF initialCoords, float velocity)
        {
            coordinates = initialCoords;
            radius = r;
            v = velocity;
        }


        public void Draw(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush brush = new SolidBrush(Color.Black);
            e.Graphics.DrawEllipse(blackPen, coordinates.X - radius, coordinates.Y - radius, radius + radius, radius + radius);
            e.Graphics.FillEllipse(brush, coordinates.X - radius, coordinates.Y - radius,radius + radius, radius + radius);
        }

        public void Move()
        {
            HittingWall();
            coordinates.X = coordinates.X + direction.X * v;
            coordinates.Y = coordinates.Y + direction.Y * v;
        }


        public void HittingWall()
        {
            float top = container.Bounds.Y;
            float bottom = container.Bounds.Height;
            float left = container.Bounds.X;
            float right = container.Bounds.Width;


            if(coordinates.X <= left || coordinates.X >= right)
            {
                float oldX = direction.X;
                float oldY = direction.Y;


                Vector2 newDirection = new Vector2(oldX * -1, oldY);
                direction = newDirection;
            }

            if(coordinates.Y <= top || coordinates.Y >= bottom)
            {
                float oldX = direction.X;
                float oldY = direction.Y;


                Vector2 newDirection = new Vector2(oldX, oldY * -1 );
                direction = newDirection;
            }

        }
    }
}
