using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.classes
{
    class View
    {
        private Windows.UI.Xaml.Controls.Page screen;
        private World world;

        public View(Windows.UI.Xaml.Controls.Page screen, World world)
        {
            this.screen = screen;
            this.world = world;
        }

    }
}
