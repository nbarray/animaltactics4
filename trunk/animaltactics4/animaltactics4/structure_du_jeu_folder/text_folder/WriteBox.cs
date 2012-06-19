using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class WriteBox
    {
        public Rectangle rect;
        public bool selected;
        public string text;
        private bool een, lettreUnique;
        private Keys actual;

        public WriteBox(Rectangle rect_)
        {
            rect = rect_;
            selected = false;
            text = "";
            een = false;
            lettreUnique = false;
            actual = Keys.None;
        }

        public void Update()
        {
            if (selected)
            {
                // TODO: Finish writebox
            }
            else
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    een = true;
                    if (Contents.contientLaSouris(rect))
                    {
                        selected = true;
                    }
                }

                if (een && Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    een = false;
                }
            }
        }

        public void Draw()
        {
            if (selected)
            {
                Contents.Draw("bouton_selected", rect);
            }
            else
            {
                Contents.Draw("bouton_normal", rect);
            }

            Contents.DrawString(text, rect);
        }
    }
}
