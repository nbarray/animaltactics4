using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuEncyclopedie : Scene
    {
        TextBox textbox;
        Onglet onglets;
        public MenuEncyclopedie()
            : base()
        {
            textbox = new TextBox(new Rectangle(300, 100, 800, Divers.Y - 300));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            onglets = new Onglet(new Rectangle(15, 100, 285, Divers.Y - 300));
            onglets.Add(Dico.langues[Dico.current][52]);
            onglets.Add(Dico.langues[Dico.current][53]);
            onglets.Add(Dico.langues[Dico.current][54]);
            onglets.Add(Dico.langues[Dico.current][55]);
            onglets.Add(Dico.langues[Dico.current][56]);
        }

        public override void UpdateScene(GameTime gameTime)
        {
            textbox.Update();
            onglets.Update(textbox);
            base.UpdateScene(gameTime);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            textbox.Draw();
            onglets.Draw();
        }
    }
}
