using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    class Wallala : Scene
    {
        Partie p;

        public Wallala()
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
            Contents.DrawString(Client.received, new Rectangle(100, 100, 100, 100));
        }

        int time = 10;
        public override void UpdateScene(GameTime gameTime)
        {
            if (!Client.sock.Connected)
            {
                if (time > 0)
                {
                    Client.Connecter();
                    Console.WriteLine(time);
                    time--;
                    Thread.Sleep(1000);
                }
                else
                {
                    Client.ArreterLeClient();
                    Engine.scenes.Pop();
                }
            }
            else
            {
                Client.Update(p);

                if (Client.Etape1_connection_du_client && 
                    !Client.Etape2_synchronisation_des_joueurs)
                {
                    
                }

                base.UpdateScene(gameTime);
            }

        }
    }
}
