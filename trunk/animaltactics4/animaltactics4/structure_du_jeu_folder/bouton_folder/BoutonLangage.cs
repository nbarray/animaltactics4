using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonLangage : Bouton
    {
        private string text;

        public BoutonLangage(Rectangle rect_)
            : base(rect_, new Rectangle(0, 0, 800, 300))
        {
            text = Dico.current;
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    text = Dico.current;
                    switch (text)
                    {
                        case "Francais":
                            Dico.current = "English";
                            break;
                        case "English":
                            Dico.current = "Schtroumpf";
                            break;
                        case "Schtroumpf":
                            Dico.current = "Francais";
                            break;
                        default:
                            break;
                    }
                    Engine.files.currentLanguage = Dico.current;
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
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.current, rect);
        }

    }
}
