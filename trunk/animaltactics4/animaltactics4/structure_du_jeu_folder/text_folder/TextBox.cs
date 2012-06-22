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
        private int offset;
        private int margin_top, margin_left;

        public TextBox(Rectangle rect_, int margin_t = 0, int margin_l = 15)
        {
            margin_left = margin_l;
            margin_top = margin_t;
            text = "";
            rect = rect_;
            line = new List<string>();
            arrowUp = new Rectangle(rect.X + rect.Width + 10, rect.Y, 50, 50);
            arrowDown = new Rectangle(rect.X + rect.Width + 10, rect.Y + rect.Height - 50, 50, 50);
            offset = 0;
        }

        public void Clear()
        {
            text = "";
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
        }

        public void Update()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
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
        }

        public void Draw()
        {

            Contents.Draw("textbox", rect);
            for (int i = 0; i < Math.Min(29, line.Count); i++)
            {
                Rectangle r = new Rectangle(rect.X + margin_left, rect.Y + (i * 20) - offset + margin_top, rect.Width, 10);
                if (Contents.GetRealRect(r).Y < Contents.GetRealRect(rect).Y + Contents.GetRealRect(rect).Height && Contents.GetRealRect(r).Y >= Contents.GetRealRect(rect).Y + margin_top)
                {
                    Contents.DrawString(line[i], r);
                }
            }

            Contents.Draw("play", arrowUp);
            Contents.Draw("play", arrowDown, SpriteEffects.FlipVertically);
        }
    }

    class CreditBox
    {
        public Rectangle rect, arrowUp, arrowDown;
        private string text;
        private List<int> line;
        public int offset;
        private int margin_top, margin_left;

        public CreditBox(Rectangle rect_, int margin_t = 0, int margin_l = 15)
        {
            margin_left = margin_l;
            margin_top = margin_t;
            text = "";
            rect = rect_;
            line = new List<int>();
            arrowUp = new Rectangle(rect.X + rect.Width + 10, rect.Y, 50, 50);
            arrowDown = new Rectangle(rect.X + rect.Width + 10, rect.Y + rect.Height - 50, 50, 50);
            offset = -950;
            for (int i = 156; i < 206; i++)
            {
                Add(i);
            }
        }

        public void Clear()
        {
            text = "";
        }
        public void Add(int text_)//156-187
        {
            line.Add(text_);
        }

        public void Update()
        {
           offset += 1;
        }

        public void Draw()
        {
            //Contents.Draw("textbox", rect);
            Contents.Draw("px3", new Rectangle(0, 0, 1200, 900), Color.DarkBlue);
            for (int i = 0; i < line.Count; i++)
            {
                Rectangle r = new Rectangle(rect.X + margin_left, rect.Y + (i * 40) - offset + margin_top, rect.Width, 10);
                if (Contents.GetRealRect(r).Y < Contents.GetRealRect(rect).Y + Contents.GetRealRect(rect).Height && Contents.GetRealRect(r).Y >= Contents.GetRealRect(rect).Y + margin_top)
                {
                    Console.WriteLine(i);
                    if (line[i] == 156 || line[i] == 158 || line[i] == 160 || line[i] == 164 || line[i] == 166 || line[i] == 168 || line[i] == 170 ||
                        line[i] == 172 || line[i] == 177 || line[i] == 179 || line[i] == 184 || line[i] == 186 || line[i] == 197)
                    {
                        Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][line[i]], r, Color.Yellow);
                    }
                    else
                    {
                        Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][line[i]], r);
                    }
                }
            }
        }
    }
}
