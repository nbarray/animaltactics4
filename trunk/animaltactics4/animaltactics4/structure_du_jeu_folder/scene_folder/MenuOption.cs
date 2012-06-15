using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuOption : Scene
    {
        public MenuOption()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 400, new Rectangle(0, 0, 800, 300), new MenuOptionJeu(), 14));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), new MenuOptionGraphisme(), 13));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), new MenuOptionSon(), 15));
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
