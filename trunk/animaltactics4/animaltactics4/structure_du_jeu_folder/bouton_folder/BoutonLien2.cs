using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonLien2 : Bouton
    {
        Scene linkTo;
        Rectangle tuveuxvoir;
        int indexDico;
        int unpop;
        bool reseau;

        public BoutonLien2(int x, int y, Rectangle sub_, int unpop, int indexDico_, bool reseau = false)
            : base(new Rectangle(Divers.X / 2 - 200, y, 400, 75), sub_)
        {
            this.unpop = unpop;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            indexDico = indexDico_;
            this.reseau = reseau;
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MoteurSon.PlayFX("bouton");
                    Divers.Pops(unpop);
                    if (reseau)
                    {
                        Client.Stop();
                    }
                    een = true;
                }
            }

            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                //Fait la moins dure, loohy, c'est pour ton bien
                Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico], rect);
        }
    }
}
