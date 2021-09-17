using BrBr2.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using System.Numerics;
using System.Collections.Generic;

namespace BrBr2
{
    public partial class GameScene : Form
    {
        // Initialize basic elements
        Ball ball = new Ball(5,new Point(300,575),5.0f);
        Platform platform = new Platform(60,5,new PointF(500,580));
        PlatformMoveDirection platformMoveDirection;
        bool platformMoving = false;
        float speedMultiplier = 1.5f;
        Stage stage = new Stage();
       
        public GameScene()
        {
            InitializeComponent();
            this.timer1.Interval = 10;
            timer1.Start();
            ball.container = pictureBox1;
            platform.container = pictureBox1;
            stage.Load(2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            PlatformHit();
            BrickHit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawBall(e);
            DrawPlatform(e);
            DrawLevel(e);
        }

        private void DrawBall(PaintEventArgs e)
        {
            ball.Move();
            ball.Draw(e);
        }

        private void DrawPlatform(PaintEventArgs e)
        {
            platform.Move(platformMoveDirection);
            platform.Draw(e);
        }

        private void DrawLevel(PaintEventArgs e)
        {
            stage.Draw(e);
        }

        private void GameScene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                if (e.KeyCode == Keys.Right)
                {
                    platformMoving = true;
                    platformMoveDirection = PlatformMoveDirection.Right;
                }
                if (e.KeyCode == Keys.Left)
                {
                    platformMoving = true;
                    platformMoveDirection = PlatformMoveDirection.Left;
                }
            }
        }

        private void GameScene_KeyUp(object sender, KeyEventArgs e)
        {
            platformMoving = false;
            platformMoveDirection = PlatformMoveDirection.None;
        }
    
        private void PlatformHit()
        {
            PlatformPosition platformPos = platform.GetPosition();
            BallPosition ballPos = ball.GetPosition();

            Console.WriteLine($"Ball: {Math.Round(ballPos.y)} Platform: {Math.Round(platformPos.y)}");

            double distPlatformBall = Math.Round(ballPos.y) - Math.Round(platformPos.y);

            // When the ball hits the Y coordinate of the platform
            if (distPlatformBall > 0.2)
            {
                if (ballPos.x <= platformPos.x + platformPos.width)
                {
                    // If the platform is moving on collision, the ball should bounce differently
                    if (platformMoving)
                    {
                        // When moving right
                        if(platformMoveDirection == PlatformMoveDirection.Right)
                        {
                            if(ball.direction.X > 0)
                            {
                                ball.v = ball.v * speedMultiplier;
                                ball.direction = new Vector2(ball.direction.X - 2, ball.direction.Y * -1);
                            }
                            else
                            {
                                ball.v = ball.v * speedMultiplier;
                                ball.direction = new Vector2(ball.direction.X + 2, ball.direction.Y * -1);
                            }

                        }
                        // When moving left
                        else if(platformMoveDirection == PlatformMoveDirection.Left)
                        {

                            if (ball.direction.X > 0)
                            {
                                ball.v = ball.v * speedMultiplier;
                                ball.direction = new Vector2(ball.direction.X - 2, ball.direction.Y * -1);
                            }
                            else
                            {
                                ball.v = ball.v * speedMultiplier;
                                ball.direction = new Vector2(ball.direction.X + 2, ball.direction.Y * -1);
                            }

                        }
                    }
                    else
                    {
                        ball.direction = new Vector2(ball.direction.X, ball.direction.Y * -1);
                    }
                    
                }  
            }
        }
    
        private void BrickHit()
        {
            BallPosition ballPos = ball.GetPosition();
            List<Brick> bricks = stage.GetBricks();


            foreach (Brick brick in bricks)
            {
                double yDistTop = Math.Floor(ballPos.y + ball.radius - brick.coordinates.Y);
                double yDistBottom = Math.Floor(brick.coordinates.Y + Brick.height - ballPos.y + ball.radius);

                Console.WriteLine($"TOP: {Math.Abs(yDistTop)}, BOTTOM: {Math.Abs(yDistBottom)}");

                if (
                    (
                        ballPos.x + ball.radius >= brick.coordinates.X 
                    
                        && 
                        
                        ballPos.x + ball.radius <= brick.coordinates.X + Brick.width)
                    &&
                    (
                        Math.Abs(yDistTop) < 5 
                    
                        || 
                        
                        Math.Abs(yDistBottom) < 5
                    )
                )
                {
                    List<Brick> brickListHitRemoved = bricks;
                    brickListHitRemoved.Remove(brick);
                    stage.bricks = brickListHitRemoved;
                    ball.direction = new Vector2(ball.direction.X, ball.direction.Y * -1);


                    return;
                }
            }
        }
    }
}
