using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuBonus : Scene
    {
        public MenuBonus()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 500, new Rectangle(0, 0, 800, 300), new MenuEncyclopedie(), 11));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), new MenuCredit(), 12));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            ((MenuCredit)(((BoutonLien)(boutons[1])).linkTo)).credits.offset = -950;
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }
    }
}
