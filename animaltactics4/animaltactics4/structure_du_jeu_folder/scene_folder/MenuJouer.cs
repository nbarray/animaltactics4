using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuJouer : Scene
    {
        public MenuJouer() : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 400, new Rectangle(0, 0, 800, 300), new MenuClassique(), 6));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), new MenuCampagne(), 7));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), new MenuReseau(), 8));
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
