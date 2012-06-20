using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Net.Sockets;
using System.Threading;

namespace animaltactics4
{
    class TraitementConnectionClient : Scene
    {
        bool een, b, c, d;
        TextBox output;
        Thread updateThread;

        public TraitementConnectionClient()
            : base()
        {
            een = false;
            b = false;
            c = false;
            d = false;
            output = new TextBox(new Rectangle(200, 200, 800, 400));
            output.Add("Patientez ...");
            updateThread = new Thread(UpdateThread);
            boutons.Add(new BoutonLien2(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), 2, 5));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            output.Update();
            if (!een)
            {
                een = true;
                Client.Init();
                updateThread.Start();
            }
        }

        private void UpdateThread()
        {
            if (!b)
            {
                b = Client.ConnectTo(Divers.ip);
                output.Add(Client.info1);
            }
            else
            {
                if (!c)
                {
                    c = WaitforAccuse();
                    output.Add(Client.info2);
                }
                else
                {
                    if (!d)
                    {
                        d = SendPseudo();
                    }
                    else
                    {
                        Engine.scenes.Push(new MenuSalon());
                    }
                }
            }
        }

        public override void DrawScene()
        {
            base.DrawScene();
            output.Draw();
        }

        private bool WaitforAccuse()
        {
            string msg = "";
            
            char chiotte;
            if ((chiotte = Client.ReceiveFrom()) != '0')
            {

            }
            return false;
        }

        private bool SendPseudo()
        {
            return true;
        }
    }
}
