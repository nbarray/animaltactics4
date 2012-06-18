using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    //Loohy
    class EditeurCarte : Scene
    {
        public e_toolSize tsize;
        public e_pinceau tstate;
        public MoteurGraphique titanAE;

        public EditeurCarte()
            : base()
        {
            boutons.Add(new BoutonDeroulant(new Rectangle(0, 0, 180, 50), 49));
            boutons.Add(new BoutonDeroulant(new Rectangle(181, 0, 150, 50), 50));
            boutons.Add(new BoutonLien(50, 800, new Rectangle(0, 0, 800, 300), null, 5));
            titanAE = new MoteurGraphique(32, 32);
            //titanAE.viderVue();
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            foreach (Bouton item in boutons)
            {
                item.UpdateD(ref  tsize, ref tstate);
            }
            titanAE.UpdateEditeur();
        }

        public override void DrawScene()
        {
            titanAE.DrawEditeur();
            foreach (Bouton item in boutons)
            {
                item.Draw();
            }
        }
    }
}
