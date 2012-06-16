using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuClassique : Scene
    {
        public MenuClassique()
            : base()
        {

            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonChoix(new Rectangle(200, 200, 100, 100), new Rectangle(0, 0, 80, 80), 3, "fog"));
            boutons.Add(new BoutonChoix(new Rectangle(325, 200, 100, 100), new Rectangle(0, 0, 100, 100), 4, "dif"));
            boutons.Add(new BoutonChoix(new Rectangle(450, 200, 100, 100), new Rectangle(0, 0, 100, 100), 4, "mod"));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }
    }
}
