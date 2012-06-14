using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    static class Contents
    {
        static public Dictionary<string, Texture2D> textures = new Dictionary<string,Texture2D>();
        static public Dictionary<string, SpriteFont> fonts = new Dictionary<string,SpriteFont>();
        static private SpriteBatch Atsushi_Okhubo;

        static public void Initialize(GraphicsDevice device_)
        {
            Atsushi_Okhubo = new SpriteBatch(device_);
        }

        static public void LoadContent(ContentManager content_)
        {
            // Load tous tes contents
            textures.Add("bouton_normal", content_.Load<Texture2D>("Image\\Bouton\\bouton_normal"));
            textures.Add("bouton_selected", content_.Load<Texture2D>("Image\\Bouton\\bouton_selected"));
            textures.Add("space", content_.Load<Texture2D>("Image\\Fond\\SpaceArt"));

            fonts.Add("bouton", content_.Load<SpriteFont>("SPriteFont\\sfBouton"));
        }

        static public void Draw(string name_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_], rect_, Color.White);
            Atsushi_Okhubo.End();
        }
        static public void DrawStringInBox(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_, new Vector2(rect_.X + (rect_.Width / 2) - (fonts["bouton"].MeasureString(text_).X / 2), rect_.Y + (rect_.Height / 2) - (fonts["bouton"].MeasureString(text_).Y / 2)), Color.White);
            Atsushi_Okhubo.End();
        }
    }
}
