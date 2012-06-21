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
            boutons.Add(new BoutonLangage(new Rectangle(Divers.X / 2 - 200, 600, 400, 75)));
            boutons.Add(new BoutonFullScreen(new Rectangle(Divers.X / 2 - 200, 500, 400, 75), new Rectangle(0, 0, 800, 300)));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonaCoulisse(500, 150, new Color(1f, 0f, 0f, 0.9f)));
            boutons.Add(new BoutonaCoulisse(660, 150, new Color(0.6f, 0.8f, 0.9f, 0.9f)));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            Divers.UpdateBoutonCoulisse((BoutonaCoulisse)boutons[3]);
            Divers.UpdateBoutonCoulisse((BoutonaCoulisse)boutons[4]);
            if (((BoutonaCoulisse)boutons[3]).actif)
            {
                MoteurSon.setVolumeMusique((300f - (float)((BoutonaCoulisse)boutons[3]).yCoulisse) / 300f);
            }
            if (((BoutonaCoulisse)boutons[4]).actif)
            {
                MoteurSon.setVolumeFX((300f - (float)((BoutonaCoulisse)boutons[4]).yCoulisse) / 300f);
            }
        }

        public override void DrawScene()
        {
            base.DrawScene();
        }
    }
}
