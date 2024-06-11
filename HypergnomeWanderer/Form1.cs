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
    public partial class Krandlebob : Form
    {
        public bool FaceRight { get; set; }
        public bool AltImage { get; set; }
        public GnomeBehaviors Behavior { get; set; }
        public Rectangle ScreenResolution { get; set; }
        public int FallingVelocity { get; set; }
        public int FallingHorizontalVelocity { get; set; }
        public int DanceStance { get; set; }
        public Random Random { get; set; }
        public int Erraticness { get; set; }
        public int Speed { get; set; }
        public int Cooldown { get; set; }
        public Point GnomeLocation { get; set; }

        public Krandlebob()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FaceRight = false;
            AltImage = false;
            ScreenResolution = Screen.PrimaryScreen.Bounds;
            Behavior = GnomeBehaviors.Standing;
            Random = new Random();
            Erraticness = 25;
            Speed = 6;
            GnomeLocation = this.Location;
        }

        private void GnomeMove_Tick(object sender, EventArgs e)
        {
            //Behavior Changes
            if (GnomeLocation.Y < ScreenResolution.Height - 32 - 40)
                Behavior = GnomeBehaviors.Falling;
            else
            {
                FallingVelocity = 0;
                FallingHorizontalVelocity = 0;
                switch (Behavior)
                {
                    case GnomeBehaviors.Falling:
                        Behavior = GnomeBehaviors.Standing;
                        break;
                    case GnomeBehaviors.Standing:
                        if (Random.Next(Erraticness * 3) == 0)
                            Behavior = GnomeBehaviors.Walking;
                        else if (Random.Next(Erraticness * 3) == 0)
                            Behavior = GnomeBehaviors.RitualDancing;
                        else if (Random.Next(Erraticness) == 0)
                        {
                            Behavior = Random.Next(2) == 0 
                                ? GnomeBehaviors.ThrowRocks 
                                : GnomeBehaviors.ThrowRocksAtCursor;
                            Cooldown = 0;
                        }
                        else if (Random.Next(Erraticness * 5) == 0)
                            Behavior = GnomeBehaviors.Sleeping;
                        if (Random.Next(Erraticness) == 0)
                            FaceRight = !FaceRight;
                        break;
                    case GnomeBehaviors.Walking:
                        if (Random.Next(Erraticness * 2) == 0)
                            Behavior = GnomeBehaviors.Standing;
                        if (Random.Next(Erraticness * 2) == 0)
                            FaceRight = !FaceRight;
                        break;
                    case GnomeBehaviors.RitualDancing:
                        if (Random.Next(Erraticness * 10) == 0)
                            Behavior = GnomeBehaviors.Standing;
                        FaceRight = Random.Next(2) == 0;
                        break;
                    case GnomeBehaviors.Sleeping:
                        if (Random.Next(Erraticness * 20) == 0)
                            Behavior = GnomeBehaviors.Standing;
                        break;
                    case GnomeBehaviors.ThrowRocks:
                        if (Random.Next(Erraticness) == 0)
                            Behavior = GnomeBehaviors.Standing;
                        else if (Random.Next(Erraticness) == 0)
                            Behavior = GnomeBehaviors.ThrowRocksAtCursor;
                        break;
                    case GnomeBehaviors.ThrowRocksAtCursor:
                        if (Random.Next(Erraticness) == 0)
                            Behavior = GnomeBehaviors.Standing;
                        else if (Random.Next(Erraticness) == 0)
                            Behavior = GnomeBehaviors.ThrowRocks;
                        break;
                }

            }

            //Movements
            switch (Behavior)
            {
                case GnomeBehaviors.Falling:
                    if(FallingVelocity < 32)
                        FallingVelocity++;
                    GnomeLocation = new Point(
                        GnomeLocation.X + FallingHorizontalVelocity,
                        GnomeLocation.Y + FallingVelocity
                        );
                    if (GnomeLocation.Y > ScreenResolution.Height - 32 - 40)
                        GnomeLocation = new Point(
                            GnomeLocation.X,
                            ScreenResolution.Height - 32 - 40
                            );
                    if (FallingHorizontalVelocity > 0 &&
                        GnomeLocation.X >= ScreenResolution.Width - 10)
                        GnomeLocation = new Point(
                            -20,
                            GnomeLocation.Y
                            );
                    if (FallingHorizontalVelocity < 0 &&
                        GnomeLocation.X <= -20)
                        GnomeLocation = new Point(
                            ScreenResolution.Width - 10,
                            GnomeLocation.Y
                            );
                    break;
                case GnomeBehaviors.Walking:
                    if(FaceRight)
                    {
                        GnomeLocation = new Point(
                            GnomeLocation.X + Speed,
                            GnomeLocation.Y
                            );
                        if(GnomeLocation.X >= ScreenResolution.Width - 10)
                            GnomeLocation = new Point(
                                -20,
                                GnomeLocation.Y
                                );
                    }
                    else
                    {
                        GnomeLocation = new Point(
                            GnomeLocation.X - Speed,
                            GnomeLocation.Y
                            );
                        if (GnomeLocation.X <= -20)
                            GnomeLocation = new Point(
                                ScreenResolution.Width - 10,
                                GnomeLocation.Y
                                );
                    }
                    break;
                case GnomeBehaviors.RitualDancing:
                    GnomeLocation = new Point(
                        GnomeLocation.X - 2 + (2 * Random.Next(3)),
                        GnomeLocation.Y
                        );
                    break;
                case GnomeBehaviors.ThrowRocksAtCursor:
                    if (Control.MousePosition.X < GnomeLocation.X + 16)
                        FaceRight = false;
                    else if (Control.MousePosition.X > GnomeLocation.X + 24)
                        FaceRight = true;
                    break;
            }

            //Animations
            AltImage = !AltImage;
            switch (Behavior)
            {
                case GnomeBehaviors.Falling:
                    Spritesheet.Location = new Point(
                        FaceRight ? -32 : 0,
                        AltImage ? -32 * 2 : -32 * 3
                        );
                    break;
                case GnomeBehaviors.Standing:
                    Spritesheet.Location = new Point(
                        FaceRight ? -32 : 0,
                        0
                        );
                    break;
                case GnomeBehaviors.Walking:
                    Spritesheet.Location = new Point(
                        FaceRight ? -32 : 0,
                        AltImage ? -32 : 0
                        );
                    break;
                case GnomeBehaviors.RitualDancing:
                    int newDanceStance = DanceStance;
                    while (newDanceStance == DanceStance)
                        newDanceStance = Random.Next(4);
                    DanceStance = newDanceStance;
                    Spritesheet.Location = new Point(
                        FaceRight ? -32 : 0,
                        AltImage ? -32 * DanceStance : 0
                        );
                    break;
                case GnomeBehaviors.Sleeping:
                    Spritesheet.Location = new Point(
                        FaceRight ? -32 : 0,
                        AltImage ? -32 * 4 : -32 * 5
                        );
                    break;
                case GnomeBehaviors.ThrowRocks:
                case GnomeBehaviors.ThrowRocksAtCursor:
                    if (Cooldown == 0)
                    {
                        Spritesheet.Location = new Point(
                            FaceRight ? -32 : 0,
                            -32 * 2
                            );

                        int rockStartX = GnomeLocation.X + (FaceRight ? 20 : 6);
                        int rockStartY = GnomeLocation.Y + 14;

                        //Heroka Breathings
                        Point aim = Behavior == GnomeBehaviors.ThrowRocksAtCursor
                            ? HerokaBreathings(rockStartX, rockStartY)
                            : AimRandomlyForGLORY();

                        Rock rock = new Rock();
                        rock.StartPoint = new Point(rockStartX,rockStartY);
                        rock.VelocityX = FaceRight ? aim.X : -aim.X;
                        rock.VelocityY = aim.Y;
                        rock.Krandlebob = this;
                        rock.Show();

                        Cooldown = 1 + Random.Next(10);
                    }
                    else
                    {
                        Spritesheet.Location = new Point(
                            FaceRight ? -32 : 0,
                            0
                            );
                        Cooldown--;
                    }

                    break;
            }

            this.Location = GnomeLocation;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Behavior = GnomeBehaviors.Falling;
            GnomeLocation = new Point(
                GnomeLocation.X,
                GnomeLocation.Y - 1
                );
            FallingVelocity = -10 - Random.Next(22);
            FallingHorizontalVelocity = -10 + Random.Next(23);
        }

        public Rectangle GetHitbox()
        {
            return new Rectangle(
                GnomeLocation.X + 12,
                GnomeLocation.Y + 14,
                8,
                18
                );
        }

        public Point HerokaBreathings(int rockStartX, int rockStartY)
        {
            double horizontalVelocity = 4;
            int horizontalDistance = Math.Abs(rockStartX - Control.MousePosition.X);
            int i = 20;
            while (i > 5 && horizontalVelocity == 4)
            {
                if (horizontalDistance % i == 0)
                    horizontalVelocity = i;
                i--;
            }
            double y = Control.MousePosition.Y - rockStartY;
            double t = horizontalDistance / horizontalVelocity;

            double vy0 = (y / t) + (-0.5 * t);

            return new Point((int)horizontalVelocity, (int)vy0);
        }

        public Point AimRandomlyForGLORY()
        {
            FaceRight = Random.Next(2) == 0;

            return new Point(1 + Random.Next(16), -1 - Random.Next(30));
        }

    }
}
