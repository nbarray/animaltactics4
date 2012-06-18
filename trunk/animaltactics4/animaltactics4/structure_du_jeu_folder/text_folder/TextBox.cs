using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class TextBox
    {
        public Rectangle rect;
        private string text;
        private List<string> line;

        public TextBox(Rectangle rect_)
        {
            text = "";
            rect = rect_;
            line = new List<string>();
        }

        public void Add(string text_)
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
                if (textWidth > rect.Width && text[i] == ' ')
                {
                    line.Add(temp);
                    temp = "";
                }
            }
            line.Add(temp);
        }

        public void Draw()
        {
            
            Contents.Draw("textbox", rect);
            for (int i = 0; i < line.Count; i++)
            {
                Rectangle r = new Rectangle(rect.X + 15, rect.Y + i * 20 + 15, rect.Width, 10);
                if (r.Y < rect.Height)
                {
                    
                Contents.DrawString(line[i], r);
                }
            }
        }
    }
}
