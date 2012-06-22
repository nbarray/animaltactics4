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
        static public Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();
        static public Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        static public Dictionary<string, Video> videos = new Dictionary<string, Video>();
        static private SpriteBatch Atsushi_Okhubo;
        static public float screenWidth, screenHeight, pprc;
        static public VideoPlayer Miyazaki;
        static public float ouvertureDePorte; //Ferme la porte !!!

        //Coldman
        static public Vector2 GetResolution
        {
            get { return new Vector2(screenWidth, screenHeight); }
        }

        static public void Initialize(GraphicsDevice device_)
        {
            Atsushi_Okhubo = new SpriteBatch(device_);
            Miyazaki = new VideoPlayer();
            adapter(device_.DisplayMode.Width, device_.DisplayMode.Height);
            ouvertureDePorte = 0;
        }

        //Coldman & Loohy
        static public void LoadContent(ContentManager content_)
        {
            Dico.Initialize();
            // Load tous tes contents et aussi les pas contents
            #region Unites
            textures.Add(e_classe.PingvinWalkyrie.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            textures.Add(e_classe.PingvinLanceFlammes.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinLanceFlamme"));
            textures.Add(e_classe.PingvinChar.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinChar2"));
            textures.Add(e_classe.PingvinUgin.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinUgin"));
            textures.Add(e_classe.PingvinBolter.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinBolter"));
            textures.Add(e_classe.PingvinBerserker.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinBerseker"));
            textures.Add(e_classe.PingvinThor.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinThor"));
            textures.Add(e_classe.PingvinMugin.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinMugin"));
            textures.Add(e_classe.PingvinOdin.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinOdin"));
            textures.Add(e_classe.PandawanMoine.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaMoineErrant"));
            textures.Add(e_classe.PandawanYabusame.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaSamouraiArcher"));
            textures.Add(e_classe.PandawanBushi.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaSamourai"));
            textures.Add(e_classe.PandawanCharDragon.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaTank"));
            textures.Add(e_classe.PandawanMerco.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaMercenaire"));
            textures.Add(e_classe.PandawanSokei.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaLancier"));
            textures.Add(e_classe.PandawanNinja.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaNinja"));
            textures.Add(e_classe.PandawanSniper.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaSniper"));
            textures.Add(e_classe.PandawanSayan.ToString(), content_.Load<Texture2D>("Image\\Unite\\PandaSayen"));
            textures.Add(e_classe.FenrirWarBlade.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirEpeiste"));
            textures.Add(e_classe.FenrirTireur.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirTireur"));
            textures.Add(e_classe.FenrirPsyker.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirPsyker"));
            textures.Add(e_classe.FenrirTemplier.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirTemplier"));
            textures.Add(e_classe.FenrirEclaireur.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirScout"));
            textures.Add(e_classe.FenrirDreadnought.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirDreadnought"));
            textures.Add(e_classe.FenrirRailgun.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirRailgun"));
            textures.Add(e_classe.FenrirWarlord.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirWarlord"));
            textures.Add(e_classe.FenrirOkami.ToString(), content_.Load<Texture2D>("Image\\Unite\\FenrirOkami"));
            textures.Add(e_classe.KrissaChef.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaChef"));
            textures.Add(e_classe.KrissaAssassin.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaAssassin"));
            textures.Add(e_classe.KrissaLegionnaire.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaLegionnaire"));
            textures.Add(e_classe.KrissaGeolier.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaGeolier"));
            textures.Add(e_classe.KrissaMaraudeur.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaMaraudeur"));
            textures.Add(e_classe.KrissaVermine.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaVermine"));
            textures.Add(e_classe.KrissaAbomination.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaAbomination"));
            textures.Add(e_classe.KrissaDesperado.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaDesperado"));
            textures.Add(e_classe.KrissaCanonnier.ToString(), content_.Load<Texture2D>("Image\\Unite\\KrissaCanonnier"));
            textures.Add(e_classe.Overlord.ToString(), content_.Load<Texture2D>("Image\\Unite\\PingvinWalkyrie"));
            #endregion
            textures.Add("bouton_normal", content_.Load<Texture2D>("Image\\Bouton\\bouton_normal"));
            textures.Add("bouton_selected", content_.Load<Texture2D>("Image\\Bouton\\bouton_selected"));
            textures.Add("space", content_.Load<Texture2D>("Image\\Fond\\SpaceArt"));
            textures.Add("porte", content_.Load<Texture2D>("Image\\Fond\\porte"));
            textures.Add("grosse", content_.Load<Texture2D>("Image\\Divers\\bite"));
            textures.Add("porteN", content_.Load<Texture2D>("Image\\Divers\\porteN"));
            textures.Add("porteS", content_.Load<Texture2D>("Image\\Divers\\porteS"));
            textures.Add("porteE", content_.Load<Texture2D>("Image\\Divers\\porteE"));
            textures.Add("porteO", content_.Load<Texture2D>("Image\\Divers\\porteO"));
            textures.Add("porteC", content_.Load<Texture2D>("Image\\Divers\\porteC"));
            textures.Add("Decagone", content_.Load<Texture2D>("Image\\Divers\\decagone"));
            textures.Add("e_race", content_.Load<Texture2D>("Image\\Divers\\Races"));
            textures.Add("aura", content_.Load<Texture2D>("Image\\Info\\aura"));

            fonts.Add("bouton", content_.Load<SpriteFont>("SpriteFont\\sfBouton"));
            fonts.Add("text", content_.Load<SpriteFont>("SpriteFont\\sftext"));
            fonts.Add("titre", content_.Load<SpriteFont>("SpriteFont\\titre"));
            fonts.Add("writebox", content_.Load<SpriteFont>("SpriteFont\\writebox"));
            fonts.Add("chrono", content_.Load<SpriteFont>("SpriteFont\\chrono"));

            textures.Add("tresor", content_.Load<Texture2D>("Image\\Info\\tresor"));
            textures.Add("grade", content_.Load<Texture2D>("Image\\Info\\Grade"));

            videos.Add("intro", content_.Load<Video>("Video\\intro"));

            textures.Add("mouvement", content_.Load<Texture2D>("Image\\Info\\BarreDeMouvement"));
            textures.Add("flag1", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("flag2", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("flag3", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("flag4", content_.Load<Texture2D>("Image\\Info\\FlagPanda"));
            textures.Add("Tiles", content_.Load<Texture2D>("Image\\Tuile\\Tiles"));
            textures.Add("Bridges", content_.Load<Texture2D>("Image\\Tuile\\bridges"));

            textures.Add("textbox", content_.Load<Texture2D>("Image\\Fond\\textbox"));
            textures.Add("victoire", content_.Load<Texture2D>("Image\\Fond\\victory"));
            textures.Add("cursor_tb", content_.Load<Texture2D>("Image\\Bouton\\cursor_textbox"));
            textures.Add("play", content_.Load<Texture2D>("Image\\Bouton\\lec_play"));
            textures.Add("fog", content_.Load<Texture2D>("Image\\Bouton\\fog"));
            textures.Add("aqme", content_.Load<Texture2D>("Image\\Bouton\\barre de texte"));
            textures.Add("dif", content_.Load<Texture2D>("Image\\Bouton\\difficultes"));
            textures.Add("mod", content_.Load<Texture2D>("Image\\Bouton\\modes"));
            textures.Add("sauvegarde", content_.Load<Texture2D>("Image\\Bouton\\sauvegarde"));
            textures.Add("Bulles", content_.Load<Texture2D>("Image\\Bouton\\Bulles"));
            textures.Add("Tube", content_.Load<Texture2D>("Image\\Bouton\\Tube"));
            textures.Add("CurseurCoulisse", content_.Load<Texture2D>("Image\\Bouton\\CurseurCoulisse"));

            textures.Add("px", content_.Load<Texture2D>("Image\\Divers\\Block"));
            textures.Add("px2", content_.Load<Texture2D>("Image\\Divers\\px"));
            textures.Add("px3", content_.Load<Texture2D>("Image\\Divers\\pxbrillant"));

            textures.Add("bleuApp", content_.Load<Texture2D>("Image\\Animation\\bleu"));
            textures.Add("rougeApp", content_.Load<Texture2D>("Image\\Animation\\rouge"));
            textures.Add("vertApp", content_.Load<Texture2D>("Image\\Animation\\vert"));
            textures.Add("jauneApp", content_.Load<Texture2D>("Image\\Animation\\jaune"));
            textures.Add("blancApp", content_.Load<Texture2D>("Image\\Animation\\wwteam"));
            textures.Add("LOGO", content_.Load<Texture2D>("Image\\Animation\\logo fini"));

            textures.Add("gordon", content_.Load<Texture2D>("Image\\Animation\\flash"));
            textures.Add("gordon inverse", content_.Load<Texture2D>("Image\\Animation\\flashreverse"));

            textures.Add("waitforplayer", content_.Load<Texture2D>("Image\\Divers\\waitforplayer"));
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
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), 
                    Color.White);
            Atsushi_Okhubo.End();
        }
        #region Surcharges

        //Coldman
        static public void Draw(string name_, Rectangle rect_, SpriteEffects effects)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)),
                    textures[name_].Bounds,
                    Color.White,
                    0f,
                    new Vector2(),
                    effects,
                    0f);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void Draw(string name_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), subrect_, c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), subrect_, c_, rot_,
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
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), subrect_, Color.White);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Rectangle subrect_, float rot_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2) - (int)(rect_.Width * pprc / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2) - (int)(rect_.Height * pprc / 2),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), subrect_, Color.White, rot_,
                    new Vector2(rect_.Width * pprc / 2, rect_.Height * pprc / 2), SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void Draw(string name_, Rectangle rect_, Color c_, Rectangle subrect_, float rot_, Vector2 vectorOf_ZeroToOne_Floats_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures[name_],
                new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2)
                    - (int)(rect_.Width * pprc * vectorOf_ZeroToOne_Floats_.X),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2)
                    - (int)(rect_.Height * pprc * vectorOf_ZeroToOne_Floats_.Y),
                    (int)(rect_.Width * pprc + 0.5f), (int)(rect_.Height * pprc + 0.5f)), subrect_, c_, rot_,
                    new Vector2(rect_.Width * pprc * vectorOf_ZeroToOne_Floats_.X,
                        rect_.Height * pprc * vectorOf_ZeroToOne_Floats_.Y),
                    SpriteEffects.None, 0);
            Atsushi_Okhubo.End();
        }
        #endregion

        //Coldman & Loohy
        static public void DrawStringInBoxCentered(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["text"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["text"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["text"].MeasureString(text_).Y / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void DrawStringInBoxCenteredChrono(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["chrono"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["chrono"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["chrono"].MeasureString(text_).Y / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void DrawStringInBoxCentered(string asset_, string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts[asset_], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts[asset_].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts[asset_].MeasureString(text_).Y / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman & Loohy
        static public void DrawStringInBoxCentered(string text_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2)
                    + (int)(rect_.Width * pprc / 2)
                    - (fonts["bouton"].MeasureString(text_).X / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)
                    + (int)(rect_.Height * pprc / 2) - (fonts["bouton"].MeasureString(text_).Y / 2)),
                    c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void DrawString(string text_, Rectangle rect_, Color c_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["bouton"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)),
                    c_);
            Atsushi_Okhubo.End();
        }
        //Loohy
        static public void DrawString(string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts["text"], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        //Coldman
        static public void DrawString(string asset_, string text_, Rectangle rect_)
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.DrawString(fonts[asset_], text_,
                new Vector2(rect_.X * pprc + (int)((screenWidth - Divers.X * pprc) / 2),
                    rect_.Y * pprc + (int)((screenHeight - Divers.Y * pprc) / 2)),
                    Color.White);
            Atsushi_Okhubo.End();
        }
        
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

        static public bool contientLaSouris(Losange los_)
        {
            return (los_.c1.EnDessous(Mouse.GetState().X, Mouse.GetState().Y) &&
                    los_.c2.EnDessous(Mouse.GetState().X, Mouse.GetState().Y) &&
                    los_.c4.AuDessus(Mouse.GetState().X, Mouse.GetState().Y) &&
                    los_.c3.AuDessus(Mouse.GetState().X, Mouse.GetState().Y));
        }

        //Loohy
        static public void DrawGates(int t_)
        {
            if (t_ < 0)//Fermeture
            {
                if (ouvertureDePorte > 0)
                {
                    ouvertureDePorte -= 15f;
                }
                #region Switch
                switch (t_)
                {
                    case -1:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        break;
                    case -2:
                        Draw("porteO", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                    default:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                }
                #endregion
            }
            else//Ouverture
            {
                if (ouvertureDePorte < 400)
                {
                    ouvertureDePorte += 15f;
                }
                #region Switch
                switch (t_)
                {
                    case 1:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0, 1200, 900));
                        break;
                    case 2:
                        Draw("porteO", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                    default:
                        Draw("porteO", new Rectangle(0 - (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteS", new Rectangle(0 - (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteE", new Rectangle(0 + (int)ouvertureDePorte, 0 + (int)ouvertureDePorte, 1200, 900));
                        Draw("porteN", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        Draw("porteC", new Rectangle(0 + (int)ouvertureDePorte, 0 - (int)ouvertureDePorte, 1200, 900));
                        break;
                }
                #endregion
            }
        }
        //Loohy
        static public Vector2 MeasureString(string s_)
        {
            return fonts["bouton"].MeasureString(s_);
        }
        //Coldman
        static public Vector2 MeasureString(string s_, string asset)
        {
            return fonts[asset].MeasureString(s_);
        }

        static public void Calculs(Ligne l_)
        {
            l_.segment = new Vector2(Math.Abs(l_.p1.X - l_.p2.X), Math.Abs(l_.p1.Y - l_.p2.Y));
            l_.a = (((float)l_.p2.Y - (float)l_.p1.Y) / ((float)l_.p2.X - (float)l_.p1.X));
            l_.b = l_.p1.Y - l_.a * l_.p1.X;
        }

        static public void Cadre()
        {
            Atsushi_Okhubo.Begin();
            Atsushi_Okhubo.Draw(textures["px"], new Rectangle(0, 0, (int)screenWidth, (int)((screenHeight - Divers.Y * pprc) / 2)), Color.Black);
            Atsushi_Okhubo.Draw(textures["px"], new Rectangle(0, (int)((screenHeight + Divers.Y * pprc) / 2), (int)screenWidth, 
                (int)((screenHeight - Divers.Y * pprc) / 2)), Color.Black);
            Atsushi_Okhubo.Draw(textures["px"], new Rectangle(0, 0, (int)((screenWidth - Divers.X * pprc) / 2), (int)screenHeight), Color.Black);
            Atsushi_Okhubo.Draw(textures["px"], new Rectangle((int)((screenWidth + Divers.X * pprc) / 2), 0,
                (int)((screenWidth - Divers.X * pprc) / 2), (int)screenHeight), Color.Black);
                //new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                //    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
            //    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc)), Color.White);
            Atsushi_Okhubo.End();
        }

        static public Rectangle GetRealRect(Rectangle rect_)
        {
            return new Rectangle((int)(rect_.X * pprc) + (int)((screenWidth - Divers.X * pprc) / 2),
                    (int)(rect_.Y * pprc) + (int)((screenHeight - Divers.Y * pprc) / 2),
                    (int)(rect_.Width * pprc), (int)(rect_.Height * pprc));
        }

        static public int GetRealInt(int i)
        {
            return (int)(i * pprc);
        }
        //Loohy
        static public Point getRelativeMouse()
        {
            return new Point((int)((Mouse.GetState().X - (int)((screenWidth - Divers.X * pprc) / 2)) / pprc), (int)((Mouse.GetState().Y - (int)((screenHeight - Divers.Y * pprc) / 2)) / pprc));
        }
    }
}
