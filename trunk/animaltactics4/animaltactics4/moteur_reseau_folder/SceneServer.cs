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
        public SceneServer()
            : base()
        {
            p = new Partie(32, 32);
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            
            Serveur.Initialiser(p);
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (Serveur.client != null)
            {
                Serveur.UpdateServer(p, gameTime);
            }
            else
            {
                Netools.UpdateTransition(gameTime);
            }

            ((BoutonLien)boutons[0]).Update(gameTime, new Func<bool>(Serveur.ArreterLeServer));
        }
    }
}
