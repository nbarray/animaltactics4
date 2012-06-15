using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuOption : Scene
    {
        public MenuOption() : base()
        {
            boutons.Add(new BoutonLien(new Rectangle(Divers.X/2 - 200, 500, 400, 75), new Rectangle(0, 0, 800, 300), null, "Retour"));
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
