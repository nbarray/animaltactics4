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
            boutons.Add(new BoutonChoix(new Rectangle(325, 200, 100, 100), new Rectangle(0, 0, 80, 80), 3, "fog"));
            boutons.Add(new BoutonChoix(new Rectangle(200, 200, 100, 100), new Rectangle(0, 0, 100, 100), 4, "mod"));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), new ScenePartie(32, 32), 0));
        }

        public override void UpdateScene(GameTime gameTime_)
        {
            base.UpdateScene(gameTime_);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            Rectangle acwl = new Rectangle(100, 500, 475,(int)Contents.MeasureString("S").Y);
            foreach (string item in Engine.files.listeDesMaps)
            {
                Contents.DrawString(item, acwl);
                acwl.Y += acwl.Height+3;
            }
            acwl.X += acwl.Width + 50;
        }
    }
}
