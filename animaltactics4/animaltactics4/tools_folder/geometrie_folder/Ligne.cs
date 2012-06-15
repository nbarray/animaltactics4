using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class Ligne
    {
        private Point p1;
        public Point getP1
        {
            get { return p1; }
            set
            {
                if (value.X >= 0 && value.Y >= 0)
                {
                    p1 = value;
                    a = (((float)p2.Y - (float)p1.Y) / ((float)p2.X - (float)p1.X));
                    b = p1.Y - a * p1.X;
                }
            }
        }

        private Point p2;
        public Point getP2
        {
            get { return p2; }
            set
            {
                if (value.X >= 0 && value.Y >= 0)
                {
                    p2 = value;
                    a = (((float)p2.Y - (float)p1.Y) / ((float)p2.X - (float)p1.X));
                    b = p1.Y - a * p1.X;
                }
            }
        }

        private Vector2 segment;
        public Vector2 getSegment
        {
            get { return segment; }
        }

        //"constante" de l'equation de la droite;
        float a, b;

        public Ligne()
        {
            p1 = Point.Zero;
            p2 = p1;
            segment = Vector2.Zero;
            a = 0;
            b = a;

        }
        public Ligne(Point p_)
        {
            p1 = p_;
            p2 = p1;
            segment = new Vector2(p_.X, p_.Y);
            a = (p2.Y - p1.Y) / (p2.X - p1.X);
            b = p1.Y - a * p1.X;
        }
        public Ligne(Point p1_, Point p2_)
        {
            p1 = p1_;
            p2 = p2_;
            segment = new Vector2(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            a = (((float)p2.Y - (float)p1.Y) / ((float)p2.X - (float)p1.X));
            b = p1.Y - a * p1.X;
        }

        //Fonction de la droite P1P2
        public float YfctX(int x_)
        {
            return a * x_ + b;
        }
        public bool AuDessus(int x_, int y_)
        {
            return y_ < YfctX(x_);
        }
        public bool EnDessous(int x_, int y_)
        {
            return y_ > YfctX(x_);
        }
    }
}
