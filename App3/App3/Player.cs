using App3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace App2.classes
{
    public class Player : MovableActor
    {
        private bool right = false;
        private bool left = false;
        private bool up = false;
        private bool down = false;
        private bool pressed = false;
        private bool falling = false;

        public Player(Image rect, World world) : base(rect, world){
        }
        public override void update()
        {
            if (right == true)
            {
                this.move(10);
            }
            if (left == true)
            {
                this.move(-10);
            }
            if (up == true)
            {
                up = this.jump();

            }
            if(world.checkCollisionWithFloor(this) == null)
            {
                if (!up)
                {
                    up = true;
                    force = 0;
                }
            }
            if(world.checkCollisionWithGoal(this) != null)
            {
                throw new GoalException();
            }
            Tuple<double, double> tupla;
            tupla = this.world.checkCollisionWithActors(this);
            if (tupla != null)
            {
                if (this.getY() < tupla.Item2)
                {
                    Actor del = this.world.getActorAt(tupla.Item1, tupla.Item2, this);
                    if (del != this)
                    {
                        this.world.removeActor(del);
                        this.startJump(15);
                    }
                }
                else
                    throw new DieException();
            }
        }
        /*
         * moves some pixels to the right
         * @param pix the amount of pixels that the actor will be moved to the right
         * **/
        public void move(double pix)
        {
            base.move(pix);// me muevo pix pixeles hacia el lado que sea
            this.getWorld().move(-pix);// muevo al mundo pix pixeles en el sentido opuesto
        }

        internal void keyDown(KeyEventArgs args)
        {
            if (pressed == false)
            {
                pressed = true;
            }
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Right))
            {
                if (right != true) right = true;
            }
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Left))
            {
                if (left != true) left = true;
            }
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Up))
            {
                if (up != true)
                {
                    up = true;
                    this.startJump(this.gravity - 5);
                    /* force = gravity;*/
                }
            }
        }

        internal void keyUp(KeyEventArgs args)
        {
            pressed = false;
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Right)) right = false;
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Left)) left = false;
            if (args.VirtualKey.Equals(Windows.System.VirtualKey.Down)) down = false;
        }
    }
}
