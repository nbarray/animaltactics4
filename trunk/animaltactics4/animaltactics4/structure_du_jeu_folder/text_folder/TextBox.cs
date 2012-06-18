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
        public List<string> text;
        public Rectangle rect;
        private string shadow;

        public TextBox(Rectangle rect_)
        {
            rect = rect_;
            text = new List<string>();
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw()
        {
            Contents.Draw("textbox", rect);
            Contents.DrawStringInATextBox(text, rect);
        }

        private string LoadFromFile(string path)
        {
            FileStream stream;
            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                return reader.ReadToEnd();
                stream.Close();
            }
            catch (Exception e)
            {
                text.Add(e.Message);
                return "Thank you Coldman.";
            }

        }

        private void GetWordsFrom(string str)
        {
            string temp = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    text.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += str[i];
                }
            }
        }
    }
}
