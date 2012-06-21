using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    class SceneClient : Scene
    {
        Partie p;

        public SceneClient()
            : base()
        {
            p = new Partie(32, 32);
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
            if (Client.Etape3_partie_en_cours)
            {
                p.DrawClient();   
            }
            else
            {
                if (!Client.sock.Connected)
                {
                    Netools.DrawTentativeDeConnection();
                }
                else
                {
                    Netools.DrawTransition();
                }
            }
        }

        int attempt = 10;
        public override void UpdateScene(GameTime gameTime)
        {
            if (!Client.sock.Connected)
            {
                if (attempt > 0)
                {
                    Client.Connecter();
                    Console.WriteLine(attempt);
                    attempt--;
                    //Thread.Sleep(1000);
                }
                else
                {
                    Client.ArreterLeClient();
                    Engine.scenes.Pop();
                }
            }
            else
            {
                Client.Update(p, gameTime);
                
                base.UpdateScene(gameTime);
            }

        }
    }
}
