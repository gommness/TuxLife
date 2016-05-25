using App2.classes;
using App3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuxLife;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace App2
{
    public class World
    {
        public static int currentLevel;
        private Grid grid;
        private LinkedList<Actor> actors = new LinkedList<Actor>();
        private LinkedList<Floor> floors = new LinkedList<Floor>();
        private Goal goal;

        public World(Grid grid)
        {
            this.grid = grid;
        }

        public void addActor(Actor actor)
        {
            this.actors.AddLast(actor);
        }

        public void addFloor(Floor floor)
        {
            this.floors.AddLast(floor);
        }

        public void move(double pix)
        {
            /*foreach (Actor a in actors)
                a.move(pix);*/
        }

        public Tuple<double, double> checkCollisionWithFloor(Actor actor)
        {
            foreach (Floor f in this.floors)
            {
                if (actor.collideWith(f) == true)
                    return new Tuple<double, double>(f.getX(), f.getY());
            }
            return null;
        }
        public Tuple<double, double> checkCollisionWithActors(Actor actor)
        {
            foreach (Actor a in this.actors)
            {
                if (a != actor && actor.collideWith(a) == true)
                    return new Tuple<double, double>(a.getX(), a.getY());
            }
            return null;
        }
        public Goal checkCollisionWithGoal(Actor actor)
        {
            if (this.goal != null && actor.collideWith(this.goal) == true)
                return goal;
            return null;
        }

        public void setGoal(Goal goal)
        {
            this.goal = goal;
        }

        internal void removeActor(Actor actor)
        {
            actor.getHitBox().Opacity = 0;
            this.actors.Remove(actor);
        }

        public void update()
        {
            int i;
            for(i = this.actors.Count-1;i>=0;i--)
                this.actors.ElementAt(i).update();
            foreach (Floor a in floors)
                a.update();
        }

        public Actor getActorAt(double x, double y)
        {
            foreach (Actor a in this.actors)
                if (a.getX() == x && a.getY() == y)
                    return a;
            return null;
        }
        public Actor getActorAt(double x, double y, Actor notMe)
        {
            foreach (Actor a in this.actors)
                if (a.getX() == x && a.getY() == y && a != notMe)
                    return a;
            return null;
        }

        public  static void refreshScreen()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            switch (World.currentLevel)
            {
                case 1:
                    rootFrame.Navigate(typeof(Level1_1), null);
                    break;
                case 2:
                    rootFrame.Navigate(typeof(Level1_2), null);
                    break;
                case 3:
                    rootFrame.Navigate(typeof(Level1_3), null);
                    break;
                case 4:
                    rootFrame.Navigate(typeof(Level1_4), null);
                    break;
                case 5:
                    rootFrame.Navigate(typeof(Level1_5), null);
                    break;
                case 6:
                    rootFrame.Navigate(typeof(Level2_1), null);
                    break;
                case 7:
                    rootFrame.Navigate(typeof(Level2_2), null);
                    break;
                case 8:
                    rootFrame.Navigate(typeof(Level2_3), null);
                    break;
                case 9:
                    rootFrame.Navigate(typeof(Level2_4), null);
                    break;
                case 10:
                    rootFrame.Navigate(typeof(Level2_5), null);
                    break;
                default:
                    Musicplay();
                    rootFrame.Navigate(typeof(Level1_1), null);
                    break;
            }
        }
        private async static void Musicplay()
        {
            await Music.playMusic();
        }

        public static void updateLevel()
        {
            currentLevel++;
            refreshScreen();
        }
    }
}
