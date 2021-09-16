using BrBr2.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace BrBr2
{
    public partial class GameScene : Form
    {
        // Initialize basic elements
        Ball ball = new Ball(5,new Point(300,600),7.5f);
        Platform platform = new Platform(60,5,new PointF(500,580));
        PlatformMoveDirection platformMoveDirection;

        public GameScene()
        {
            InitializeComponent();
            this.timer1.Interval = 30;
            timer1.Start();
            ball.container = pictureBox1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawBall(e);
            DrawPlatform(e);
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

        private void GameScene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                if (e.KeyCode == Keys.Right)
                {
                    platformMoveDirection = PlatformMoveDirection.Right;
                }
                if (e.KeyCode == Keys.Left)
                {
                    platformMoveDirection = PlatformMoveDirection.Left;
                }
            }
        }

        private void GameScene_KeyUp(object sender, KeyEventArgs e)
        {
            platformMoveDirection = PlatformMoveDirection.None;
        }
    }
}
