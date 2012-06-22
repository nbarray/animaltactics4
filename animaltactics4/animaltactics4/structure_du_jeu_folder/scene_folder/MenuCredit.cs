using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuCredit : Scene
    {
        public CreditBox credits;
        public MenuCredit()
            : base()
        {

            boutons.Add(new BoutonLien(0, 800, new Rectangle(0, 0, 800, 300), null, 5, true));
            credits = new CreditBox(new Rectangle(100, -15, 1000, 950));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            credits.Update();
        }

        public override void DrawScene()
        {
          //base.DrawScene();
            credits.Draw();
            boutons[0].Draw();
        }
    }
}
