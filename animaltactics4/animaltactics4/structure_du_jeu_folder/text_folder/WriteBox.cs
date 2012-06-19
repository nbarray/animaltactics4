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
        private Rectangle cursor;
        private const int OFFSET = 100;
        public WriteBox(Rectangle rect_)
        {
            rect = rect_;
            selected = false;
            text = "";
            een = false;
            lettreUnique = false;
            cursor = new Rectangle(rect.X + 42, rect.Y + 15, 5, rect.Height - 42);
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

                if (temp != Keys.None && ((int)temp >= 65 && (int)temp <= 90 || temp == Keys.Back))
                {
                    if (!lettreUnique)
                    {
                        lettreUnique = true;
                        if (temp == Keys.Back)
                        {
                            text = text.Substring(0, text.Length - 1);
                        }
                        else
                        {
                            text += Input.GetValueOf(temp);
                        }

                        cursor.X = rect.X + (int)Contents.MeasureString(text).X + 42;
                    }
                }

                if (lettreUnique)
                {
                    if (temp == Keys.None)
                    {
                        lettreUnique = false;
                    }
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
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

            Contents.DrawString(text, new Rectangle(rect.X + OFFSET, rect.Y + 15, rect.Width, rect.Height));
        }
    }
}
