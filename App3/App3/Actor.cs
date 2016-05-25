using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace App2
{
    public abstract class Actor
    {

        protected Image hitBox;
        protected World world;
        protected double x;
        protected double y;
        protected double xPrev;
        protected double yPrev;
        protected int force = 0;
        protected int gravity = 30;


        /*
         * Constructor of Actor objects 
         * @param rect the rectangle that represents the actor
         * @param x the REAL x position of the actor
         * @param y the REAL y position of the actor
         * **/
        public Actor(Image rect, World world)
        {
            this.hitBox = rect;
            this.world = world;
            this.x = rect.Margin.Left;
            this.y = rect.Margin.Top;
            this.xPrev = x;
            this.yPrev = y;
        }

        public World getWorld()
        {
            return this.world;
        }

        /*
         * retrieves the REAL value of the x position
         * **/
        public double getX()
        {
            return this.hitBox.Margin.Left;
        }

        /* 
         * retrieves the REAL value of the y position
         * **/
        public double getY()
        {
            return this.hitBox.Margin.Top;
        }

        /* 
         * retrieves the REAL position of the bottom of the actor
         * **/
        public double getBottom()
        {
            return this.getY() + this.getHeight();
        }

        /*
         * retrieves the REAL position of the furthest right side of the actor. its right side's x position
         * **/
        public double getSide()
        {
            return this.getX() + this.getWidth();
        }

        /*
         * retrieves the width of the actor
         * **/
        public double getWidth()
        {
            return this.hitBox.ActualWidth;
        }

        /*
         * retrieves the height of the actor
         * **/
        public double getHeight()
        {
            return this.hitBox.ActualHeight;
        }

        public void setPos(double x, double y)
        {
            Thickness margin = this.hitBox.Margin;
            margin.Left = x;
            margin.Top = y;
            this.hitBox.Margin = margin;
            this.x = x;
            this.y = y;
        }

        public Image getHitBox()
        {
            return this.hitBox;
        }

        /*
         * checks if the actor is collidin with other
         * @param actor the actor to check collision with
         * **/
        public bool collideWith(Actor other)
        {
            // check if the respective y positions are within range of each other
            if ((this.getY() >= other.getY() && this.getY() <= other.getBottom()) || (other.getY() >= this.getY() && other.getY() <= this.getBottom()))
                if ((this.getX() >= other.getX() && this.getX() <= other.getSide()) || (this.getSide() >= other.getX() && this.getSide() <= other.getSide()))
                    return true;
            return false;
        }
        public abstract void update();


    }
}
