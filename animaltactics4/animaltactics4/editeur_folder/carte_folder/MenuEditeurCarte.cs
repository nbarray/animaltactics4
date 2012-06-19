using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuEditeurCarte : Scene
    {
        public MenuEditeurCarte()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), new EditeurCarte(), 16));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), null, 17));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
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
