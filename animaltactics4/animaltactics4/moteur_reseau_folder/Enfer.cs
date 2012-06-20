using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace animaltactics4
{
    class Enfer : Scene
    {
        public Enfer()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }

        public override void UpdateScene(GameTime gameTime)
        {
            if (Ponk.chaussure_de_l_archiduc != null)
            {
                Ponk._que_vois_tu_Louis();
            }

            ((BoutonLien)boutons[0]).Update(gameTime, new Func<bool>(Ponk._feu_rouge));
        }
    }
}
