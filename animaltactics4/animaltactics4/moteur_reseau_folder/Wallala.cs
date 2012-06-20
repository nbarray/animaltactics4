using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class Wallala : Scene
    {
        public Wallala()
            : base()
        {
            Chaka._instramgram(Chaka._quarante_deux_tue_du_marechal_bluton);
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }

        public override void UpdateScene(GameTime gameTime)
        {
            Chaka._que_vois_tu_Louis();
            base.UpdateScene(gameTime);
        }
    }
}
