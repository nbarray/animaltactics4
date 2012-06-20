using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class MenuRejoindre : Scene
    {

        /* TODO:
         * Writebox pseudo, ip
         * PORT = 4242
         * Bouton: Se Connecter => lance la connection vers le serveur !
         * Bouton: Retour => null
         */

        WriteBox pseudo, ip;

        public MenuRejoindre()
            : base()
        {
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonSeConnecter(Divers.X / 2 - 200, 600));
            pseudo = new WriteBox(new Rectangle(700,100, 400,75));
            ip = new WriteBox(new Rectangle(700, 200, 400, 75));
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            pseudo.Update();
            ip.Update();
            Divers.pseudo = pseudo.text;
            Divers.ip = ip.text;
        }

        public override void DrawScene()
        {
            base.DrawScene();
            pseudo.Draw();
            ip.Draw();

            Contents.DrawString(Dico.langues[Dico.current][149], new Rectangle(700 - 100, 100, 400, 75), Divers.pseudoRejoindreColor);
            Contents.DrawString(Dico.langues[Dico.current][150], new Rectangle(700 - 100, 200, 400, 75), Divers.ipRejoindreColor);
        }
    }
}
