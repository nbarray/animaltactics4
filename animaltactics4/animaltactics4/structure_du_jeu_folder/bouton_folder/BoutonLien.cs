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

        public BoutonLien(Rectangle rect_, Rectangle sub_, Scene linkTo_, string text_)
            : base(rect_, sub_, "")
        {
            linkTo = linkTo_;
            text = text_;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Bouton.isPressed && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (base.rect.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                {
                    // Action !
                    if (linkTo != null)
                    {
                        Engine.scenes.Push(linkTo);
                    }
                    else
                    {
                        if (Engine.scenes.Count == 1)
                        {
                            Game1.quitter = true;
                        }
                        else
                        {
                            Engine.scenes.Pop();
                        }
                    }
                }
            }

            if (Bouton.isPressed && Mouse.GetState().LeftButton == ButtonState.Released)
            {
                Bouton.isPressed = false;
            }
        }

        public override void Draw()
        {
            if (!base.rect.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBox(text, rect);
        }
    }
}
