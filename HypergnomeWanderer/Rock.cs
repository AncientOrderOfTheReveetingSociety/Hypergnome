using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HypergnomeWanderer
{
    public partial class Rock : Form
    {
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }
        public Krandlebob Krandlebob { get; set; }
        public Point StartPoint { get; set; }
        public int Expiration { get; set; }

        public Rock()
        {
            InitializeComponent();
        }

        private void Rock_Load(object sender, EventArgs e)
        {
            this.Location = StartPoint;
        }

        private void Throwing_Tick(object sender, EventArgs e)
        {
            if (VelocityY == 0 && VelocityX == 0)
            {
                Expiration++;

                if (Expiration > 100)
                    this.Close();
            }
            else
            {

                this.Location = new Point(
                    this.Location.X + VelocityX,
                    this.Location.Y + VelocityY
                    );

                //if (VelocityY < 32)
                VelocityY++;

                if ((this.Location.X <= 0
                    && VelocityX < 0) ||
                    (this.Location.X >= Krandlebob.ScreenResolution.Width - 6
                    && VelocityX > 0))
                    VelocityX = -VelocityX;

                if (this.Location.Y >= Krandlebob.ScreenResolution.Height - 46)
                {
                    this.Location = new Point(this.Location.X,
                        Krandlebob.ScreenResolution.Height - 46);
                    VelocityY = -(int)Math.Floor((decimal)VelocityY / (decimal)2);
                    if (VelocityY >= -1)
                    {
                        VelocityY = 0;
                        VelocityX = 0;
                    }
                }
            }

            if (GetHitbox().IntersectsWith(Krandlebob.GetHitbox()))
            {
                if (Math.Abs(VelocityY) >= 6 || Math.Abs(VelocityX) >= 10)
                    Krandlebob.Behavior = GnomeBehaviors.Sleeping;

                this.Close();
            }


        }



        public Rectangle GetHitbox()
        {
            return new Rectangle(
                Location.X,
                Location.Y,
                6,
                6
                );
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Expiration = 0;
            VelocityX = -20 + Krandlebob.Random.Next(41);
            VelocityY = -1 - Krandlebob.Random.Next(20);
        }
    }
}
