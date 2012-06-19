using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class ScenePartie : Scene
    {
        public Partie p;

        public ScenePartie(int map_width_, int map_height_)
            : base()
        {
            p = new Partie(map_width_, map_height_);
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            p.Update(gameTime);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            p.Draw();
            boutons[0].Draw();
        }
    }
}
