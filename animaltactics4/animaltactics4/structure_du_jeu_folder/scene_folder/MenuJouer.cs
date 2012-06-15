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
            boutons.Add(new BoutonLien(new Rectangle(100, 100, 200, 75), new Rectangle(0, 0, 800, 300), null, "Retour"));
            boutons.Add(new BoutonLien(new Rectangle(100, 100, 200, 75), new Rectangle(0, 0, 800, 300), null, "Retour"));
            boutons.Add(new BoutonLien(new Rectangle(100, 100, 200, 75), new Rectangle(0, 0, 800, 300), null, "Retour"));
            boutons.Add(new BoutonLien(new Rectangle(100, 100, 200, 75), new Rectangle(0, 0, 800, 300), null, "Retour"));
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
