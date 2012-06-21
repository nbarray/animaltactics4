using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    class SceneServer : Scene
    {
        public Partie p;
        private bool unique;

        public SceneServer()
            : base()
        {
            p = new Partie(32, 32);
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            p.Initialize("carte reseau",
                                  new List<string>() { "Pandawan01", "Pingvin01" },
                                  new List<int>() { 0, 0 },
                                  new List<int>() { 0, 1 },
                                  new List<Color>() { Color.Blue, Color.Red },
                                  e_typeDePartie.Joute,
                                  e_brouillardDeGuerre.Normal,
                                  42);
            unique = false;
        }

        public override void DrawScene()
        {
            if (Serveur.Etape3_partie_en_cours)
            {
                p.DrawServer();
            }
            else
            {
                Netools.DrawTransition();
                boutons[0].Draw();
            }
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (Serveur.client != null)
            {
                Serveur.UpdateServer();
                if (Serveur.Etape2_synchronisation_des_joueurs)
                {
                    p.UpdateServeur(gameTime);
                }
                else
                {
                    
                }
            }
            else
            {
                Netools.UpdateTransition(gameTime);
                if (!unique)
                {
                    Serveur.Initialiser();
                    unique = true;
                }
                
            }

            ((BoutonLien)boutons[0]).Update(gameTime, new Func<bool>(Serveur.ArreterLeServer));
        }
    }
}
