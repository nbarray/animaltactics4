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
        public Wallala()
            : base()
        {
            
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
                Client.Update();
                base.UpdateScene(gameTime);
            }
           
        }
    }
}
