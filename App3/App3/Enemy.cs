using App2.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2;
using Windows.UI.Xaml.Controls;

namespace App3
{
    class Enemy : MovableActor
    {
        private int moveCounter = 0;
        private int jumpCounter = 0;
        private double mov = 0;
        private bool up = false;
        public Enemy(Image rect, World world) : base(rect, world)
        {
        }

        public override void update()
        {
            ++moveCounter;
            ++jumpCounter;
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 1 && !up && jumpCounter >= 45)
            {
                jumpCounter = 0;
                this.startJump(20);
                up = jump();
            }
            move(mov);
            if (moveCounter >= 30)
            {
                moveCounter = 0;
                mov = rnd.Next(-3, 4);
            }
            if (up)
            {
                up=jump();
            }
            else if (world.checkCollisionWithFloor(this) == null)
            {
                if (!up)
                {
                    up = true;
                    force = 0;
                }
            }
        }
    }
}
