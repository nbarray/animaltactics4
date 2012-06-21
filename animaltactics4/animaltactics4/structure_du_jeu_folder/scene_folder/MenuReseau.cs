using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuReseau : Scene
    {
        public MenuReseau()
            : base()
        {
            boutons.Add(new BoutonConnect(2 * Divers.X / 3 - 200, 600));
            boutons.Add(new BoutonHeberg(Divers.X / 3 - 200, 600));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            Client.writebox = new WriteBox(new Rectangle(Divers.X / 2 - 200, Divers.Y / 2 - 75 / 2, 400, 75));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            Client.writebox.Update();
        }

        public override void DrawScene()
        {
            base.DrawScene();
            Contents.Draw("bouton_selected", new Rectangle(160, 100, 2* Divers.X / 3 + 100, 300));
            Contents.DrawStringInBoxCentered("titre", Dico.langues[Dico.current][65], new Rectangle(0, 100, 1200, 300));
            Client.writebox.Draw();
        }
    }
}
