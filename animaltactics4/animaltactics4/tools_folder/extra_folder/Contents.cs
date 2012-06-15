using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    static class Contents
    {
        static public Dictionary<string, Texture2D> textures = new Dictionary<string,Texture2D>();
        static public Dictionary<string, SpriteFont> fonts = new Dictionary<string,SpriteFont>();
        static public Dictionary<string, Video> videos = new Dictionary<string, Video>();
        static private SpriteBatch Atsushi_Okhubo;
        static private float screenWidth, screenHeight, pprc;
        static public VideoPlayer Miyazaki;

        //Coldman
        static public Vector2 GetResolution
        {
            get { return new Vector2(screenWidth, screenHeight);}
        }

        static public void Initialize(GraphicsDevice device_)
        {
            Atsushi_Okhubo = new SpriteBatch(device_);
            Miyazaki = new VideoPlayer();
            adapter(device_.DisplayMode.Width, device_.DisplayMode.Height);
        }

        //Coldman
        static public void LoadContent(ContentManager content_)
        {
            // Load tous tes contents
            textures.Add("bouton_normal", content_.Load<Texture2D>("Image\\Bouton\\bouton_normal"));
            textures.Add("bouton_selected", content_.Load<Texture2D>("Image\\Bouton\\bouton_selected"));
            textures.Add("space", content_.Load<Texture2D>("Image\\Fond\\SpaceArt"));
            textures.Add("grosse", content_.Load<Texture2D>("Image\\Divers\\bite"));
            textures.Add("aura", content_.Load<Texture2D>("Image\\Info\\aura"));

            fonts.Add("bouton", content_.Load<SpriteFont>("SpriteFont\\sfBouton"));
            fonts.Add("text", content_.Load<SpriteFont>("SpriteFont\\sftext"));

            textures.Add("tresor", content_.Load<Texture2D>("Image\\Info\\tresor"));
            textures.Add("grade", content_.Load<Texture2D>("Image\\Info\\Grade"));
            videos.Add("intro", content_.Load<Video>("Video\\intro"));
            textures.Add("mouvement", content_.Load<Texture2D>("Image\\Info\\BarreDeMouvement"));
            textures.Add("flag1", content_.Load<Texture2D>("Image\\Info\\FlagPingvin"));
            
            textures.Add("flag2", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("flag3", content_.Load<Texture2D>("Image\\Info\\FlagPingvin"));
            textures.Add("flag4", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("Tiles", content_.Load<Texture2D>("Image\\Tuile\\Tiles"));
            textures.Add("Bridges", content_.Load<Texture2D>("Image\\Tuile\\bridges"));
        }

        //Loohy
        static public void adapter(float screenWidth_, float screenHeight_)
        {
            screenHeight = screenHeight_;
            screenWidth = screenWidth_;
            pprc = Math.Min(screenWidth / Divers.X, screenHeight / Divers.Y);
        }

        //Coldman & Loohy
        static public void Draw(string name_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), Color.White);
            Atsushi_Okhubo.End();
        }
        #region Surcharges

        //Coldman
        static public void Draw(string name_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, c_, rot_,
                    new Vector2(rect_.Width * pprc / 2, rect_.Height * pprc / 2), SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Rectangle subrect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, Color.White);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), subrect_, Color.White, rot_,
                    new Vector2(rect_.Width * pprc / 2, rect_.Height * pprc / 2), SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        } 
        #endregion

        //Coldman & Loohy
        static public void DrawStringInBox(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["bouton"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["bouton"].MeasureString(text_).Y / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void DrawStringInBoxJustify(List<string> text_, Rectangle rect_)
        {
            Vector2 vec = new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2));
            Atsushi_Okhubo.Begin();
            for (int i = 0; i < text_.Count; i++)
            {
                vec.Y += 10;
                Atsushi_Okhubo.DrawString(fonts["text"], text_[i], vec, Color.White);
            }
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void DrawVideo(string name_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(Miyazaki.GetTexture(),
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public bool contientLaSouris(Rectangle rect_)
        {
            return new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)).Contains(Mouse.GetState().X, Mouse.GetState().Y);

        }
    }
}
