using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuHeberger : Scene
    {
        Server s;

        public MenuHeberger()
            : base()
        {
           boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
           s = new Server();
        }

        public override void  UpdateScene(GameTime gameTime)
        {
            ((BoutonLien)boutons[0]).Update(gameTime, s.abort__);
             s.Start();
        }

        public override void DrawScene()
        {
            base.DrawScene();
            s.loremIpsum.Draw();
        }
    }
}
