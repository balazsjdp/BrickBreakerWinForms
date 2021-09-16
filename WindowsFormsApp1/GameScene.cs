using BrBr2.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;

namespace BrBr2
{
    public partial class GameScene : Form
    {
        Ball ball = new Ball(5,new Point(300,600),7.5f);
        Platform platform = new Platform(60,5,new PointF(500,580));
     
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
            platform.Draw(e);
        }

        private void GameScene_KeyDown(object sender, KeyEventArgs e)
        {
            platform.Move(e);
            Console.WriteLine(e.KeyCode);
        }
    }
}
