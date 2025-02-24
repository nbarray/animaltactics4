﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Net;

namespace animaltactics4
{
    class BoutonConnect : Bouton
    {
        protected Rectangle tuveuxvoir;

        public BoutonConnect(int x, int y)
            : base(new Rectangle(x, y, 400, 75), new Rectangle(0, 0, 800, 300))
        {
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
        }

        public override void Update(GameTime gameTime)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    een = true;
                    Engine.scenes.Push(new SceneClient());
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
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][148], rect);
        }
    }
}
