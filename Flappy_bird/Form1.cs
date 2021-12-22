using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappybird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score; 

            if (pipeBottom.Left < -750)
            {
                pipeBottom.Left = 600;
                score++;
                pipeSpeed++;
            }
            if (pipeTop.Left < -80)
            {
                pipeTop.Left =550;
                score++;
                pipeSpeed++;
            }
            if(flappybird.Bounds.IntersectsWith(pipeBottom.Bounds)||
                flappybird.Bounds.IntersectsWith(pipeTop.Bounds)||
                flappybird.Bounds.IntersectsWith(ground.Bounds)||
                flappybird.Top < 25)
            {
                Gameover();
            }
          
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void Gameover()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over";
        }
    }
}
