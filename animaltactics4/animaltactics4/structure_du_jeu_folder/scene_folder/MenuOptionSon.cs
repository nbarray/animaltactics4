using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    class MenuOptionSon : Scene
    {
        public MenuOptionSon()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonaCoulisse(500, 150, new Color(1f,0f,0f,0.9f)));
            boutons.Add(new BoutonaCoulisse(660, 150, new Color(0.6f, 0.8f, 0.9f, 0.9f)));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            Divers.UpdateBoutonCoulisse((BoutonaCoulisse)boutons[1]);
            Divers.UpdateBoutonCoulisse((BoutonaCoulisse)boutons[2]);
            if (((BoutonaCoulisse)boutons[1]).actif)
            {
                MoteurSon.setVolumeMusique((300f - (float)((BoutonaCoulisse)boutons[1]).yCoulisse) / 300f);
            }
            if (((BoutonaCoulisse)boutons[2]).actif)
            {
                MoteurSon.setVolumeFX((300f - (float)((BoutonaCoulisse)boutons[2]).yCoulisse) / 300f);
            }
        }
    }
}
