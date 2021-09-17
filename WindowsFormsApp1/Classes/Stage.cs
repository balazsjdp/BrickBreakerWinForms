using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrBr2.Classes
{
    class Stage
    {

        private PointF startingPoint = new PointF(20, 20);
        private int spacing = 15;
        private string[] stageContent;
        public List<Brick> bricks = new List<Brick>();


        public void Load(int stageId)
        {
            try
            {
                stageContent = System.IO.File.ReadAllLines($"Stages/{stageId}.level");
                float brickX = startingPoint.X;
                float brickY = startingPoint.Y;


                foreach (string line in stageContent)
                {
                    foreach (char chunk in line)
                    {
                        Brick simpleBrick = new Brick(new PointF(brickX, brickY));
                        if (chunk == '*')
                        {
                            bricks.Add(simpleBrick);
                        }

                        brickX = brickX + spacing + Brick.width;
                    }
                    brickX = startingPoint.X;
                    brickY = brickY + spacing + Brick.height;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading stage...");
            }
            
        }


        public void Draw(PaintEventArgs e)
        {
            if (stageContent is null) return;

            // Create stage line by line
            foreach (Brick b in bricks)
            {
                b.Draw(e);
            }
        }

        public List<Brick> GetBricks()
        {
            return bricks;
        }
    }
}
