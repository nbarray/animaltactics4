using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonFullScreen : Bouton
    {
        bool sound;
        public bool fullscreen;
        private Rectangle tuveuxvoir;

        public BoutonFullScreen(Rectangle rect_, Rectangle sub_)
            : base(rect_, sub_)
        {
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            sound = true;
            fullscreen = false;
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    // Action !
                    MoteurSon.PlayFX("bouton");
                    Game1.toFullScreen = !Game1.toFullScreen;
                    een = true;
                }
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                sound = true;
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                if (sound)
                    MoteurSon.PlayFX("clic");
                sound = false;
                //Fait la moins dure, loohy, c'est pour ton bien
                Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][67], rect);
        }
    }
}
