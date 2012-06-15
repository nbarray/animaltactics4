using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    class TextBox
    {
        public List<string> text;
        public Rectangle rect;

        public TextBox(Rectangle rect_)
        {
            rect = rect_;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            Contents.Draw("textbox", rect);
            Contents.DrawStringInBoxJustify(text, rect);
        }
    }
}
