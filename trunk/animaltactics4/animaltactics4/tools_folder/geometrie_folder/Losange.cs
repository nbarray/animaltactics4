using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    [Serializable]
    class Losange
    {
        public Ligne c1, c2, c3, c4;
        public int x, y, hauteur, largeur;

        public Losange()
        {
            c1 = new Ligne();
            c2 = c1;
            c3 = c1;
            c4 = c1;
            x = 0;
            y = x;
            hauteur = 0;
            largeur = hauteur;
        }
        public Losange(int x_, int y_, int largeur_, int hauteur_)
        {
            x = x_;
            y = y_;
            c1 = new Ligne(new Point(x_, y_ + hauteur_ / 2), new Point(x_ + largeur_ / 2, y_));
            c2 = new Ligne(c1.p2, new Point(x_ + largeur_, y_ + hauteur_ / 2));
            c3 = new Ligne(c2.p2, new Point(x_ + largeur_ / 2, y_ + hauteur_));
            c4 = new Ligne(c3.p2, c1.p1);
            hauteur = hauteur_;
            largeur = largeur_;
        }
        public void Update(int x_, int y_)
        {
            x = x_;
            y = y_;

            c1.p1 = new Point(x_, y_ + hauteur / 2); c1.p2 = new Point(x_ + largeur / 2, y_);
            c2.p1 = c1.p2; c2.p2 = new Point(x_ + largeur, y_ + hauteur / 2);
            c3.p1 = c2.p2; c3.p2 = new Point(x_ + largeur / 2, y_ + hauteur);
            c4.p1 = c3.p2; c4.p2 = c1.p1;
            CalculerTout();
        }

        public void CalculerTout()
        {
            Contents.Calculs(c1);
            Contents.Calculs(c2);
            Contents.Calculs(c3);
            Contents.Calculs(c4);
        }
    }
}
