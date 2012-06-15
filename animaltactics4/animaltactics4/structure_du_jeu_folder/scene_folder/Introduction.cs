using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Introduction : Scene
    {
        bool een;
        Rectangle vidRectangle;

        public Introduction()
            : base()
        {
            een = false;
            vidRectangle = new Rectangle(0, 0, Divers.X, Divers.Y);

            Contents.Miyazaki.Play(Contents.videos["intro"]);
        }

        public override void DrawScene()
        {
                Contents.DrawVideo("intro", vidRectangle);
                
                if (Contents.Miyazaki.PlayPosition == Contents.videos["intro"].Duration || Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    Contents.Miyazaki.Stop();
                    Engine.scenes.Pop();
                    Engine.scenes.Push(new MenuPrincipal());
                }
        }
    }
}
