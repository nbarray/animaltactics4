using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class ScenePartie : Scene
    {
        Partie p;

        public ScenePartie(int map_width_, int map_height_)
            : base()
        {
            p = new Partie(map_width_, map_height_);
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
