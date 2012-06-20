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
            Contents.DrawString(Chaka.received, new Rectangle(100, 100, 100, 100));
        }

        int time = 10;
        public override void UpdateScene(GameTime gameTime)
        {
            if (!Chaka.chausettes_de_l_archiduchesse.Connected)
            {
                if (time > 0)
                {
                    Chaka._instramgram();
                    Console.WriteLine(time);
                    time--;
                    Thread.Sleep(1000);
                }
                else
                {
                    Chaka._feu_rouge();
                    Engine.scenes.Pop();
                }
                
            }
            else
            {
                Chaka._que_vois_tu_Louis();
                base.UpdateScene(gameTime);
            }
           
        }
    }
}
