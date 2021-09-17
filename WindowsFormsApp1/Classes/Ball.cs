using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace BrBr2.Classes
{
    class Ball
    {
        private Pen blackPen = new Pen(Color.Black, 3);
        private SolidBrush brush = new SolidBrush(Color.Black);
        private BallPosition ballPos;
        public float radius;
        private float initialVel;
        public float v;
        public PointF coordinates;
        public Vector2 direction = new Vector2(-1.0f, -1.0f);
        public PictureBox container;

        public Ball(float r, PointF initialCoords, float velocity)
        {
            coordinates = initialCoords;
            radius = r;
            v = velocity;
            initialVel = velocity;
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
            ballPos = new BallPosition(coordinates.X, coordinates.Y, radius);

            // Limit speed of the ball
            if (this.v > 10f) this.v = 10f;
            // If the ball has accelerated, start to decrease speed
            if (this.v > initialVel) DecreaseSpeed();
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

            //|| coordinates.Y >= bottom
        }

        public BallPosition GetPosition()
        {
            return ballPos;
        }

        public void DecreaseSpeed()
        {
            this.v = this.v - 0.01f;
        }
    }

    class BallPosition
    {
        public float x { get; set; }
        public float y { get; set; }
        public float r { get; set; }

        public BallPosition(float X, float Y, float rad)
        {
            x = X;
            y = Y;
            r = rad;
        }

    }
}
