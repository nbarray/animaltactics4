using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Net;

namespace animaltactics4
{
    class BoutonSeConnecter : Bouton
    {
        Rectangle tuveuxvoir;
        public BoutonSeConnecter(int x_, int y_)
            : base(new Rectangle(x_, y_, 400, 75), Contents.textures["bouton_normal"].Bounds)
        {
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    MoteurSon.PlayFX("bouton");
                    // Action !
                    bool param1ok = false;
                    bool param2ok = false;

                    IPAddress ip = null;
                    param1ok = Divers.pseudo.Length > 0 && Divers.pseudo.Length < 20;
                    param2ok = IPAddress.TryParse(Divers.ip, out ip);

                    if (param1ok && param2ok)
                    {
                        Engine.scenes.Push(new TraitementConnectionClient());
                    }
                    else
                    {
                        
                    }
                    een = true;
                }
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
                
                Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][148], rect);
        }
    }
}
