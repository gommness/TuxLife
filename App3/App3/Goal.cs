using App2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace App3
{
    public class Goal : Actor
    {
        public Goal(Image ima, World world) : base(ima, world)
        {
            this.world.setGoal(this);
        }

        public override void update()
        {

        }
    }
}
