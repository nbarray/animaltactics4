using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    [Serializable]
    class Ligne
    {
        public Point p1;

        public Point p2;

        public Vector2 segment;

        //"constante" de l'equation de la droite;
        public float a, b;
        public Ligne(Point p1_, Point p2_)
        {
            Contents.Calculs(this);
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
