using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuPrincipal : Scene
    {
        public MenuPrincipal() : base()
        {
            boutons.Add(new BoutonLien(new Rectangle(100, 100, 200, 75), new Rectangle(0, 0, 800, 300), null, "Quitter"));
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
