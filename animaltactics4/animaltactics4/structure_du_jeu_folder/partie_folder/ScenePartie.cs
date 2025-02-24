﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class ScenePartie : Scene
    {
        public Partie p;
        public bool estEnPause, transition;

        public ScenePartie(int map_width_, int map_height_)
            : base()
        {
            p = new Partie(map_width_, map_height_);
            estEnPause = false;
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), null, 5, false));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 400, new Rectangle(0, 0, 800, 300), new MenuOption(), 3, false));
            boutons.Add(new BoutonPause(Divers.X / 2 - 200, 300, 69, false));
            boutons.Add(new BoutonPause(0, 0, 68, true));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 750, new Rectangle(0, 0, 800, 300), null, 5, false));
            boutons.Add(new BoutonPret(Divers.X / 2 - 200, 300, 154, false));
            transition = false;
        }

        public override void UpdateScene(GameTime gameTime)
        {
            //base.UpdateScene(gameTime);
            if (!estEnPause && !p.Jackman.Victory_ && !transition)
            {
                p.Update(gameTime, ref transition);
                ((BoutonPause)boutons[3]).UpdatePause(ref estEnPause);
            }
            else
            {
                if (estEnPause)
                {
                    boutons[0].Update(gameTime);
                    boutons[1].Update(gameTime);
                    ((BoutonPause)boutons[2]).UpdatePause(ref estEnPause);
                }
                else
                {
                    if (transition)
                    {
                        ((BoutonPret)boutons[5]).UpdateTransition(ref transition);
                        ((BoutonPause)boutons[3]).UpdatePause(ref estEnPause);
                    }
                    else
                    {
                        boutons[4].Update(gameTime);
                    }
                }
            }
        }

        public override void DrawScene()
        {
            //base.DrawScene();
            p.Draw();
            if (!estEnPause && !p.Jackman.Victory_)
                boutons[3].Draw();
            if (p.Jackman.Victory_)
            {
                boutons[4].Draw();
            }
            if (transition)
            {
                p.gameplay.clic = false;
                if (p.earthPenguin.fog != e_brouillardDeGuerre.ToutVisible)
                Contents.Draw("porte", fond);
                ((BoutonPret)boutons[5]).DrawColor(p.gameplay.listeDesJoueurs[p.gameplay.tourencours].couleur);
            }
            if (estEnPause)
            {
                Contents.Draw("px", new Rectangle(0, 0, 1200, 900), new Color(0, 0, 0, 0.5f));
                for (int i = 0; i < 3; i++)
                {
                    boutons[i].Draw();
                }
            }
        }
    }
}
