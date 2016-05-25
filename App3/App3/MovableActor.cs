using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2.classes
{
    public abstract class MovableActor : Actor
    {

        public MovableActor(Image rect, World world) : base(rect, world)
        {

        }

        public void move(double pix)
        {
            Thickness margin = this.hitBox.Margin;
            margin.Left += pix;
            this.hitBox.Margin = margin;
            this.xPrev = this.x;
            this.x += pix;
        }

        public void startJump()
        {
            this.force = this.gravity;
        }
        public void startJump(int jump)
        {
            this.force = jump;
        }

        /*
         * this methods return a boolean meaning that the actor keeps falling (true) or doesn't (false)
         * **/
        public bool jump()
        {
            Thickness margin = this.hitBox.Margin;
            margin.Top -= this.force;
            this.force -= 1;
            this.hitBox.Margin = margin;
            Tuple<double, double> tupla = this.world.checkCollisionWithFloor(this);
            if (tupla != null)
            {
                this.setPos(this.x, tupla.Item2 - this.getHeight());
                return false;
            }
            else
            {
                margin.Top += 5;
                this.hitBox.Margin = margin;
            }
            return true;
        }
    }
}
