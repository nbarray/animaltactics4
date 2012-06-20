using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Net.Sockets;

namespace animaltactics4
{
    class TraitementConnectionClient : Scene
    {
        bool een, b, c;

        public TraitementConnectionClient()
            : base()
        {
            een = false;
            b = false;
            c = false;
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (!een)
            {
                een = true;
                Client.Init();
            }

            if (!b)
            {
                b = Client.ConnectTo(Divers.ip);
            }
            else
            {
                if (!c)
                {
                    c = WaitforAccuse();
                }
                else
                {
                    // Send pseudo
                }
            }
            

            
               
            
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }

        private bool WaitforAccuse()
        {
            string msg = "";
            
            char chiotte;
            if ((chiotte = Client.ReceiveFrom()) != '0')
            {

            }
            return true;
        }
    }
}
