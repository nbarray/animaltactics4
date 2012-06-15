using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class Losange
    {
        private Ligne c1, c2, c3, c4;
        private int x, y, hauteur, largeur;

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
            c2 = new Ligne(c1.getP2, new Point(x_ + largeur_, y_ + hauteur_ / 2));
            c3 = new Ligne(c2.getP2, new Point(x_ + largeur_ / 2, y_ + hauteur_));
            c4 = new Ligne(c3.getP2, c1.getP1);
            hauteur = hauteur_;
            largeur = largeur_;
        }

        public bool Intersect(Point p_)
        {
            return (c1.EnDessous(p_.X, p_.Y) && c2.EnDessous(p_.X, p_.Y) &&
                    c4.AuDessus(p_.X, p_.Y) && c3.AuDessus(p_.X, p_.Y));
        }

        public void Update(int x_, int y_)
        {
            x = x_;
            y = y_;

            c1.getP1 = new Point(x_, y_ + hauteur / 2); c1.getP2 = new Point(x_ + largeur / 2, y_);
            c2.getP1 = c1.getP2; c2.getP2 = new Point(x_ + largeur, y_ + hauteur / 2);
            c3.getP1 = c2.getP2; c3.getP2 = new Point(x_ + largeur / 2, y_ + hauteur);
            c4.getP1 = c3.getP2; c4.getP2 = c1.getP1;
        }
    }
}
