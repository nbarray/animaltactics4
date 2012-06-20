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

        public WriteBox(Rectangle rect_)
        {
            rect = rect_;
            selected = false;
            text = "";
            een = false;
            lettreUnique = false;
        }

        public void Update()
        {
            if (selected)
            {
                // TODO: Finish writebox
                Keys[] keys = Keyboard.GetState().GetPressedKeys();
                Keys temp = Keys.None;
                foreach (Keys item in keys)
                {
                    if (item != Keys.None)
                    {
                        temp = item;
                    }
                }

                if (temp != Keys.None)
                {
                    if (!lettreUnique)
                    {
                        lettreUnique = true;
                        if (temp == Keys.Back && text.Length > 0)
                        {
                            text = text.Substring(0, text.Length - 1);
                        }
                        else
                        {
                            if (text.Length < 20)
                            {
                                text += Input.GetValueOf(temp);
                            }
                        }
                    }
                }

                if (lettreUnique)
                {
                    if (temp == Keys.None)
                    {
                        lettreUnique = false;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) || (!Contents.contientLaSouris(rect) && Mouse.GetState().LeftButton == ButtonState.Pressed))
                {
                    selected = false;
                }
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
            Contents.DrawString("writebox",text, new Rectangle(rect.X + 45,  rect.Y + rect.Height / 2 - (int)Contents.MeasureString(text, "writebox").Y / 2, rect.Width, rect.Height));
        }
    }
}
