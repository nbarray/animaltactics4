using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    class Enfer : Scene
    {
        public Partie p;

        public Enfer()
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

        }

        public override void DrawScene()
        {
            
            base.DrawScene();
            p.Draw();
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (Serveur.client != null)
            {
                Serveur.UpdateServer();
                if (Serveur.Etape2_synchronisation_des_joueurs)
                {
                    p.Update(gameTime);
                }
                
            }

            ((BoutonLien)boutons[0]).Update(gameTime, new Func<bool>(Serveur.ArreterLeServer));
        }
    }
}
