using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonLien : Bouton
    {
        Scene linkTo;
        string text;
        Rectangle tuveuxvoir;

        static public bool een = false;

        public BoutonLien(Rectangle rect_, Rectangle sub_, Scene linkTo_, string text_)
            : base(rect_, sub_)
        {
            linkTo = linkTo_;
            text = text_;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
        }

        public override void Update(GameTime gameTime)
        {

            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    // Action !
                    if (linkTo != null)
                    {
                        Engine.scenes.Push(linkTo);
                    }
                    else
                    {
                        Engine.scenes.Pop();
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
            Contents.DrawStringInBox(text, rect);
        }
    }
}
