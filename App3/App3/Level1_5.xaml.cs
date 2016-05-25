using App2;
using App2.classes;
using App3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TuxLife
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Level1_5 : Page
    {

        private Player ply;
        private World world;
        DispatcherTimer dtClock;

        public Level1_5()
        {
            this.InitializeComponent();
            dtClock = new DispatcherTimer();
            dtClock.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dtClock.Tick += DtClock_Tick;
            dtClock.Start();
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

            world = new World(borders);
            world.addFloor(new Floor(floor, world));
            world.addFloor(new Floor(floor_Copy, world));
            world.addFloor(new Floor(floor_Copy1, world));
            world.addFloor(new Floor(floor_Copy2, world));
            world.addFloor(new Floor(floor_Copy3, world));
            world.addFloor(new Floor(floor_Copy4, world));
            world.addFloor(new Floor(floor_Copy5, world));
            ply = new Player(player, world);
            world.addActor(ply);
            world.addActor(new Enemy(Malo, world));
            world.addActor(new Enemy(Malo_Copy, world));
            world.addActor(new Enemy(Malo_Copy1, world));
            world.addActor(new Enemy(Malo_Copy2, world));
            world.addActor(new Enemy(Malo_Copy3, world));
            new Goal(goal, world);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dtClock.Stop();
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Pause), null);
        }

        private async void DtClock_Tick(object sender, object e)
        {
            Random rnd = new Random();
            try
            {
                world.update();
            }
            catch (GoalException gex)
            {
                dtClock.Stop();
                World.updateLevel();
                return;
            }
            catch (DieException exc)
            {
                dtClock.Stop();
                await Task.Delay(1000);
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(ScorePage), null);
            }
            if (ply.getY() > this.ActualHeight)
            {
                dtClock.Stop();
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(ScorePage), null);
            }
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            ply.keyUp(args);
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            ply.keyDown(args);
        }
    }
}
