using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace animaltactics4
{
    class TextBox
    {
        public Rectangle rect, arrowUp, arrowDown;
        private string text;
        private List<string> line;
        private bool text_overflow, een;
        private int offset;

        public TextBox(Rectangle rect_)
        {
            text = "";
            rect = rect_;
            line = new List<string>();
            text_overflow = false;
            arrowUp = new Rectangle(rect.X + rect.Width + 10, rect.Y, 50, 50);
            arrowDown = new Rectangle(rect.X + rect.Width + 10, rect.Y + rect.Height - 50, 50, 50);
            een = false;
        }

        public void Add(string text_)
        {
            line.Clear();
            text = text_;
            JustifyText();
        }

        public void AddConsoleMode(string text_)
        {
            text = text_;
            JustifyText();
        }

        private void JustifyText()
        {
            string temp = "";
            for (int i = 0; i < text.Length; i++)
            {
                temp += text[i];
                int textWidth = (int)Contents.MeasureString(temp).X;
                if (textWidth > Contents.GetRealRect(rect).Width - 142 && text[i] == ' ')
                {
                    line.Add(temp);
                    temp = "";
                }
            }
            line.Add(temp);

            if (line.Count * 20 + 15 > Contents.GetRealRect(rect).Height)
            {
                text_overflow = true;
            }
        }

        public void Update()
        {
            if (text_overflow)
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    een = true;
                    if (Contents.contientLaSouris(arrowDown))
                    {
                        offset += 20;
                    }
                    else if (Contents.contientLaSouris(arrowUp))
                    {
                        if (offset >= 20)
                        {
                            offset -= 20;
                        }
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
            
            Contents.Draw("textbox", rect);
            for (int i = 0; i < line.Count; i++)
            {
                Rectangle r = new Rectangle(rect.X, rect.Y + i * 20 + 100 - offset, rect.Width, 10);
                if (r.Y < rect.Height && r.Y > rect.Y + 80)
                {
                    Contents.DrawStringInBoxCentered(line[i], r);
                }
            }

            if (text_overflow)
            {
                Contents.Draw("play", arrowUp);
                Contents.Draw("play", arrowDown, SpriteEffects.FlipVertically);
            }
        }
    }
}
