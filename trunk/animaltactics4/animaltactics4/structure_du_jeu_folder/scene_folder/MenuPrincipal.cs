using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    //Coldman
    class MenuPrincipal : Scene
    {
        public MenuPrincipal()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 300, new Rectangle(0, 0, 800, 300), new MenuJouer(), 0));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 400, new Rectangle(0, 0, 800, 300), new MenuEditer(), 1));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), new MenuBonus(), 2));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), new MenuOption(), 3));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 4));
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
