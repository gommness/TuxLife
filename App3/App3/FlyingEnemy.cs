
using App2;
using App2.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace App3
{
    public class FlyingEnemy : MovableActor
    {
        private int moveCounter = 0;
        private double mov = 0;
        private bool up = false;

        public FlyingEnemy(Image ima, World world) : base(ima, world)
        {

        }

        public override void update()
        {
            ++moveCounter;
            Random rnd = new Random();
            move(mov);
            if (mov > 0)
                this.getHitBox().Source = new BitmapImage(new Uri("ms-appx:///Assets/Sebastian2.gif"));
            else if(mov < 0)
                this.getHitBox().Source = new BitmapImage(new Uri("ms-appx:///Assets/Sebastian.gif"));
            if (moveCounter >= 30)
            {
                moveCounter = 0;
                mov = rnd.Next(-3, 4);
            }
            if (this.world.checkCollisionWithFloor(this) != null)
                mov *= -1;
        }
    }
}
