using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class HUD
    {
        private int flash;
        private bool doFlash;
        private Color flashColor;
        public int time;
        public float resolution_x, resolution_y;
        private int UniteAttaquante, UniteDefenseuse;
        private Color color1, color2;
        private string texteCombat1, texteCombat2;
        e_pouvoir powaa;
        private int degats1, degats2;
        private int AffichageCombat, AffichagePowa;
        public int AffichageCombat_
        {
            get { return AffichageCombat; }
            set { AffichageCombat = value; }
        }
        private int nombre1, nombre2, nombre1b, nombre2b;
        private Random r;
        private int[] tableauDecalage;
        private int[] tableauRespiration;
        private e_race race1, race2;
        private bool Victory;
        public bool Victory_
        {
            get { return Victory; }
            set { Victory = value; }
        }
        private Color VictoryColor;
        private int VictoryRace;//0,1,2,3
        private int positionDuTexteY, positionDuTexteX;
        //public BoutonCirculaire bAttaque, bMouvement, bPouvoir;

        public HUD(Vector2 resolution_)
        {
            time = 0;
            r = new Random();
            resolution_x = resolution_.X / 1200f;
            resolution_y = resolution_.Y / 900f;
            //bAttaque = new BoutonCirculaire(ModeAction.Attaque);
            //bMouvement = new BoutonCirculaire(ModeAction.Mouvement);
            //bPouvoir = new BoutonCirculaire(ModeAction.Pouvoir);

            //switch (resolution_)
            //{
            //    case resolution.r1024x768:
            //        resolution_x = 1024f / 1200f;
            //        resolution_y = 768f / 900f;
            //        break;
            //    case resolution.r800x600:
            //        resolution_x = 800f / 1200f;
            //        resolution_y = 600f / 900f;
            //        break;
            //    case resolution.r1366x768:
            //        resolution_x = 1366f / 1200f;
            //        resolution_y = 768f / 900f;
            //        break;
            //    case resolution.r1280x768:
            //        resolution_x = 1280f / 1200f;
            //        resolution_y = 768f / 900f;
            //        break;
            //    case resolution.r1280x1024:
            //        resolution_x = 1280f / 1200f;
            //        resolution_y = 1024f / 900f;
            //        break;
            //    default:
            //        resolution_x = 1;
            //        resolution_y = 1;
            //        break;
            //}
            positionDuTexteX = (int)(1000 * resolution_x);
            positionDuTexteY = (int)(300 * resolution_y);
            flash = (int)(1200 * resolution_x) + 1;
            doFlash = false;
            AffichageCombat = 0;
            AffichagePowa = 0;
            tableauDecalage = new int[20];
            tableauRespiration = new int[20];
            Victory = false;
        }

        public void Draw(SystemeDeJeu gameplay_, MoteurGraphique moteurgraphique_)
        {
            #region HUD+Time
            //sprite_.Draw(tex_.Textures_[8], new Rectangle((int)(1035 * resolution_x), (int)(26 * resolution_y),
            //    (int)(190 * resolution_x), (int)(120 * resolution_y)), Color.Black);
            //sprite_.Draw(tex_.Textures_[8], new Rectangle((int)(1035 * resolution_x), (int)((time + 28) * resolution_y),
            //    (int)(190 * resolution_x), (int)(((120 - (time + 25))) * resolution_y)), Color.White);
            //sprite_.Draw(tex_.Textures_[10], new Rectangle(positionDuTexteX - (int)(100 * resolution_x), 0, (int)(300 * resolution_x),
            //    (int)(900 * resolution_y)), Color.White);
            #endregion
            if (gameplay_.armees[gameplay_.tourencours].difficulte == 0
                && gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].alive)
            {
                #region stats unite
                statUnite(gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect],
                    gameplay_.armees[gameplay_.tourencours].couleur);
                #endregion
            }
            #region Boutons d'action
            if (gameplay_.armees[gameplay_.tourencours].difficulte == 0 && gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].alive)
            {
                int i = gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].i;
                int j = gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].j;
                Rectangle rect = genererRectangle(i, j, moteurgraphique_.map[i, j].altitude,
                    moteurgraphique_.camerax, moteurgraphique_.cameray, moteurgraphique_.direction);
                //DrawButtons(sprite_, tex_,
                //    rect.X,
                //    rect.Y,
                //    gameplay_.armees[gameplay_.tourencours].
                //    bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].typeUnite == TypeUnite.Elite);
                //UpdateButtons(ref gameplay_.mood, gameplay_.armees[gameplay_.tourencours].
                //    bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].typeUnite == TypeUnite.Elite);
            }
            #endregion
            if (doFlash)
            {
                #region flash
                flash -= 50;
                //sprite_.Draw(tex_.Textures_[18], new Rectangle(flash, 0, (int)(1200 * resolution_x), (int)(900 * resolution_y)),
                //    flashColor);
                //sprite_.Draw(tex_.Textures_[19], new Rectangle(-flash, 0, (int)(1200 * resolution_x), (int)(900 * resolution_y)),
                //    flashColor);
                if (flash < -(int)(1200 * resolution_x))
                {
                    doFlash = false;
                }
                #endregion
            }
            #region Affichage Combat
            if (AffichageCombat > 0)
            {
                #region combat
                if (AffichageCombat % 35 == 0)
                {
                    respi();
                }
                AffichageCombat -= 18;

                //sprite_.Draw(tex_.Textures_[12], new Rectangle((int)(100 * resolution_x), (int)(300 * resolution_y), (int)(700 * resolution_x),
                //(int)(300 * resolution_y)), Color.White);
                #region drawpv
                switch (race1)
                {
                    case e_race.Fenrir:
                        //sprite_.Draw(tex_.Textures_[15], new Rectangle((int)(120 * resolution_x),
                        //    (int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre1b) * 32), 288), 0, 32, 100),
                        //    color1);
                        break;
                    case e_race.Krissa:
                        //sprite_.Draw(tex_.Textures_[16], new Rectangle((int)(120 * resolution_x),
                        //    (int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre1b) * 32), 288), 0, 32, 100),
                        //    color1);
                        break;
                    case e_race.Pandawan:
                        //sprite_.Draw(tex_.Textures_[14], new Rectangle((int)(120 * resolution_x),
                        //    (int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre1b) * 32), 288), 0, 32, 100),
                        //    color1);
                        break;
                    case e_race.Pingvin:
                        //sprite_.Draw(tex_.Textures_[17], new Rectangle((int)(120 * resolution_x),
                        //    (int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre1b) * 32), 288), 0, 32, 100),
                        //    color1);
                        break;
                    default:
                        break;
                }
                switch (race2)
                {
                    case e_race.Fenrir:
                        //sprite_.Draw(tex_.Textures_[15], new Rectangle((int)(732 * resolution_x),
                        //(int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre2b) * 32), 288), 0, 32, 100),
                        //   color2);
                        break;
                    case e_race.Krissa:
                        //sprite_.Draw(tex_.Textures_[16], new Rectangle((int)(732 * resolution_x),
                        //(int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre2b) * 32), 288), 0, 32, 100),
                        //   color2);
                        break;
                    case e_race.Pandawan:
                        //sprite_.Draw(tex_.Textures_[14], new Rectangle((int)(732 * resolution_x),
                        // (int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre2b) * 32), 288), 0, 32, 100),
                        //   color2);
                        break;
                    case e_race.Pingvin:
                        //sprite_.Draw(tex_.Textures_[17], new Rectangle((int)(732 * resolution_x),
                        //(int)(320 * resolution_y), 48, 144), new Rectangle(Math.Min(320 - ((nombre2b) * 32), 288), 0, 32, 100),
                        //    color2);
                        break;
                    default:
                        break;
                }
                #endregion
                //Unite 1
                if ((AffichageCombat) / 200 > nombre1)
                {
                    for (int k = Math.Min(Math.Max(nombre1, 1), (AffichageCombat) / 200) - 1; k >= 0; k--)
                    {
                        // sprite_.Draw(tex_.Textures_[UniteAttaquante], new Rectangle((int)((110 + k * 23 + tableauDecalage[k]) * resolution_x),
                        //     (int)((500 - k * 16 + tableauDecalage[k] / 2) * resolution_y), (int)((100) * resolution_x), (int)(100 * resolution_y)),
                        //     new Rectangle(0, 128 * tableauRespiration[k], 128, 128), Color.White);
                    }
                }
                else
                {
                    for (int k = Math.Max(Math.Max(nombre1b, (AffichageCombat) / 200) - 1, 1); k >= 0; k--)
                    {
                        //  sprite_.Draw(tex_.Textures_[UniteAttaquante], new Rectangle((int)((110 + k * 23 + tableauDecalage[k]) * resolution_x),
                        //      (int)((500 - k * 16 + tableauDecalage[k] / 2) * resolution_y), (int)((100) * resolution_x), (int)(100 * resolution_y)),
                        //      new Rectangle(0, 128 * tableauRespiration[k], 128, 128), Color.White);
                    }
                }
                //Unite 2
                if ((AffichageCombat) / 200 > nombre2)
                {
                    for (int k = Math.Min(Math.Max(nombre2, 1), (AffichageCombat) / 200) - 1; k >= 0; k--)
                    {
                        // sprite_.Draw(tex_.Textures_[UniteDefenseuse], new Rectangle((int)((690 - k * 23 - tableauDecalage[k + 10]) * resolution_x),
                        //     (int)((500 - k * 16 + tableauDecalage[k + 10] / 2) * resolution_y), (int)(100 * resolution_x), (int)(100 * resolution_y)),
                        //     new Rectangle(128, 128 * tableauRespiration[k], 128, 128), Color.White);
                    }
                }
                else
                {
                    for (int k = Math.Max(Math.Max(nombre2b, (AffichageCombat) / 200) - 1, 1); k >= 0; k--)
                    {
                        // sprite_.Draw(Textures.textures[UniteDefenseuse], new Rectangle((int)((690 - k * 23 - tableauDecalage[k + 10]) * resolution_x),
                        //     (int)((500 - k * 16 + tableauDecalage[k + 10] / 2) * resolution_y), (int)(100 * resolution_x), (int)(100 * resolution_y)),
                        //     new Rectangle(128, 128 * tableauRespiration[k], 128, 128), Color.White);
                    }
                }
                if (AffichageCombat < 1750)
                {
                    //sprite_.DrawString(Textures.tahoma, texteCombat1, new Vector2((int)(390 * resolution_x), (int)(360 * resolution_y)), color1);
                }
                if (AffichageCombat < 1500)
                {
                    //sprite_.DrawString(Textures.tahoma, degats1.ToString(), new Vector2((int)(405 * resolution_x), (int)(390 * resolution_y)), color1);
                    //sprite_.DrawString(Textures.tahoma, "Degat(s)", new Vector2((int)(444 * resolution_x), (int)(390 * resolution_y)), color1);
                }
                if (AffichageCombat < 1250)
                {
                    //sprite_.DrawString(Textures.tahoma, texteCombat2, new Vector2((int)(430 * resolution_x), (int)(510 * resolution_y)), color2);
                }
                if (AffichageCombat < 1000)
                {
                    //sprite_.DrawString(tex_.Tahoma_, degats2.ToString(), new Vector2((int)(445 * resolution_x), (int)(540 * resolution_y)), color2);
                    //sprite_.DrawString(tex_.Tahoma_, "Degat(s)", new Vector2((int)(464 * resolution_x), (int)(540 * resolution_y)), color2);
                }
                #endregion
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    AffichageCombat = 0;
                }
            }
            #endregion
            #region Affichage Pouvoir
            if (AffichagePowa > 0)
            {
                #region pouvoir
                AffichagePowa -= 18;

                switch (powaa)
                {
                    case e_pouvoir.PandaSceau:
                        //sprite_.Draw(tex_.Textures_[104],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(0, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.PandaSniper:
                        //sprite_.Draw(tex_.Textures_[104],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(300, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.PandaNinja:
                        //sprite_.Draw(tex_.Textures_[104],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(600, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.PingvinSoin:
                        //sprite_.Draw(tex_.Textures_[106],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(0, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.PingvinThor:
                        //sprite_.Draw(tex_.Textures_[106],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(300, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.PingvinRage:
                        //sprite_.Draw(tex_.Textures_[106],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(600, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.FenrirMissiles:
                        //sprite_.Draw(tex_.Textures_[105],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //       new Rectangle(0, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.FenrirBoost:
                        //sprite_.Draw(tex_.Textures_[105],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(300, 0, 300, 300), Color.White);
                        break;
                    case e_pouvoir.FenrirRailgun:
                        //sprite_.Draw(tex_.Textures_[105],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(600, 0, 300, 300), Color.White);
                        break;
                    default:
                        //sprite_.Draw(tex_.Textures_[99],
                        //    new Rectangle((int)(300 * resolution_x), (int)(300 * resolution_y), (int)(300 * resolution_x),
                        //    (int)(300 * resolution_y)),
                        //        new Rectangle(0, 0, 300, 300), Color.White);
                        break;
                }
                #endregion
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    AffichagePowa = 0;
                }
            }
            #endregion
            #region score
            if (gameplay_.armees[gameplay_.tourencours].difficulte == 0)
            {
                //    DrawScore(sprite_, gameplay_, tex_, new Vector2(900, 170), (int)gameplay_.numeroDeTour);
            }
            #endregion
            if (Victory && AffichageCombat <= 0)
            {
                #region victoire
                //sprite_.Draw(tex_.Textures_[25], new Rectangle(0, 0, (int)(1200 * resolution_x), (int)(900 * resolution_y)), VictoryColor);
                //sprite_.Draw(tex_.Textures_[22], new Rectangle((int)(475 * resolution_x), (int)(375 * resolution_y), (int)(250 * resolution_x),
                //    (int)(250 * resolution_y)), new Rectangle(250 * VictoryRace, 0, 250, 250), Color.White);
                //DrawScore(sprite_, gameplay_, tex_, new Vector2(450, 720), (int)gameplay_.numeroDeTour);
                #endregion
            }
        }
        private void compteTour(int t_, Vector2 v_)
        {
            //string s = "Tour : " + t_.ToString();
            //sprite_.DrawString(Textures.tahoma, s,
            //    new Vector2(v_.X - Textures.tahoma.MeasureString(s).X / 2 + 1, v_.Y + 1), Color.DarkGray);
            //sprite_.DrawString(Textures.tahoma, s, new Vector2(v_.X - Textures.tahoma.MeasureString(s).X / 2, v_.Y), Color.White);
        }
        private void DrawScore(SystemeDeJeu gameplay_, Vector2 v_, int t_)
        {
            //sprite_.Draw(Textures.textures[85],
            //        new Rectangle((int)v_.X + 9, (int)v_.Y - 1, 282, 32),
            //        Color.Black);
            //sprite_.Draw(Textures.textures[109],
            //    new Rectangle((int)v_.X + 10, (int)v_.Y, 279, 30),
            //    gameplay_.armees[gameplay_.tourencours].couleur);
            //sprite_.Draw(Textures.textures[109],
            //    new Rectangle((int)v_.X + 10 + (gameplay_.armees[gameplay_.tourencours].score * 280) /
            //        (gameplay_.armees[gameplay_.tourencours].score + gameplay_.armees[(gameplay_.tourencours + 1) % 2].score),
            //        (int)v_.Y,
            //        (gameplay_.armees[(gameplay_.tourencours + 1) % 2].score * 280) /
            //        (gameplay_.armees[gameplay_.tourencours].score + gameplay_.armees[(gameplay_.tourencours + 1) % 2].score), 30),
            //        new Rectangle((gameplay_.armees[gameplay_.tourencours].score * 280) /
            //       (gameplay_.armees[gameplay_.tourencours].score + gameplay_.armees[(gameplay_.tourencours + 1) % 2].score),
            //        0,
            //        (gameplay_.armees[(gameplay_.tourencours + 1) % 2].score * 280) /
            //        (gameplay_.armees[gameplay_.tourencours].score + gameplay_.armees[(gameplay_.tourencours + 1) % 2].score), 30),
            //    gameplay_.armees[(gameplay_.tourencours + 1) % 2].couleur);
            //sprite_.Draw(Textures.textures[85],
            //    new Rectangle((int)v_.X + 148, (int)v_.Y - 1, 4, 8),
            //    Color.Black);
            //sprite_.Draw(Textures.textures[85],
            //    new Rectangle((int)v_.X + 148, (int)v_.Y + 23, 4, 8),
            //    Color.Black);
            //compteTour(sprite_, tex_, t_, new Vector2(v_.X + 150, v_.Y + 40));
        }
        public void DrawButtons(int x_, int y_, bool pouvoir_)
        {
            //bAttaque.Draw(sprite_, tex_, x_ - 30, y_);
            //bMouvement.Draw(sprite_, tex_, x_ + 6, y_);
            //if (pouvoir_)
            //{
            //    bPouvoir.Draw(sprite_, tex_, x_ - 12, y_ - 30);
            //}
        }
        public void UpdateButtons(ref e_modeAction mood_, bool pouvoir_)
        {
            //bAttaque.Update(ref mood_);
            //bMouvement.Update(ref mood_);
            //if (pouvoir_)
            //{
            //    bPouvoir.Update(ref mood_);
            //}
        }
        public bool sontvises()
        {
            return true;//bAttaque.Estvise() || bMouvement.Estvise() || bPouvoir.Estvise();
        }

        public bool intersect(Point p_)
        {
            bool intersect = p_.X > (int)(900 * resolution_x);
            if (AffichageCombat > 0)
            {
                intersect = intersect || (p_.X > (int)(100 * resolution_x) && p_.X < (int)(800 * resolution_x))
                    || (p_.Y > (int)(300 * resolution_y) && p_.Y < (int)(600 * resolution_y));
            }
            return intersect;
        }

        public void statUnite(Unite unite_, Color couleur_)
        {
            //sprite_.DrawString(Textures.tahoma, unite_.nom, new Vector2(positionDuTexteX, positionDuTexteY), couleur_);
            //sprite_.DrawString(Textures.tahoma, "Force : " + unite_.getStat[0], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (3)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Dexterite : " + unite_.getStat[1], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (4)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Constitution : " + unite_.getStat[2], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (5)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Defense : " + unite_.getStat[3], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (6)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Esprit : " + unite_.getStat[4], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (7)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Chance : " + unite_.getStat[5], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (8)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Vitesse : " + unite_.getStat[6], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (9)),
            //    couleur_);
            //sprite_.DrawString(Textures.tahoma, "Niveau : ", new Vector2(positionDuTexteX, positionDuTexteY + 16 * (1)), couleur_);
            // Nicooooo's grade sys
            //sprite_.Draw(Textures.textures[9],
            //             new Vector2(positionDuTexteX + Textures.tahoma.MeasureString("Niveau : ").X + 2, positionDuTexteY + 16 * 1 + 4),
            //             new Rectangle((unite_.getStat[7] - 1) * 16, 0, 16, 16),
            //             Color.White);
            // +++++++++++++++++++++
            //sprite_.DrawString(Textures.tahoma, "Experience : " + unite_.getStat[8], new Vector2(positionDuTexteX, positionDuTexteY + 16 * (2)),
            //    couleur_);
            //sprite_.Draw(Textures.textures[23], new Rectangle(positionDuTexteX, positionDuTexteY + 167, 102, 10), Color.Black);
            //sprite_.Draw(Textures.textures[23], new Rectangle(positionDuTexteX + 1, positionDuTexteY + 168,
            //    (100 * unite_.getStat[9]) / unite_.getStat[10], 8), couleur_);
            //if (unite_.typeUnite == TypeUnite.Elite)
            //{
            //    sprite_.Draw(Textures.textures[23], new Rectangle(positionDuTexteX, positionDuTexteY + 179, 102, 9), Color.Black);
            //    sprite_.Draw(Textures.textures[23], new Rectangle(positionDuTexteX + 1, positionDuTexteY + 180,
            //        (100 * unite_.energieactuel) / unite_.energiemax, 7), Color.Purple);
            //}
            //sprite_.Draw(Textures.textures[unite_.image], new Rectangle(positionDuTexteX - (int)(100 * resolution_x), positionDuTexteY, 100, 100), new Rectangle(0, 0, 128, 128), Color.White);
        }

        public void fight(Unite attaquant_, Unite defenseur_, string texte1_, int degats1_, Color couleur1_,
            string texte2_, int degats2_, Color couleur2_, e_race race1_, e_race race2_)
        {
            UniteAttaquante = attaquant_.image;
            UniteDefenseuse = defenseur_.image;
            texteCombat1 = texte1_;
            degats1 = degats1_;
            AffichageCombat = 1800;
            color1 = couleur1_;
            race1 = race1_;
            texteCombat2 = texte2_;
            degats2 = degats2_;
            color2 = couleur2_;
            race2 = race2_;
            nombre2 = Math.Min((defenseur_.getStat[9] + degats2) * 10 / defenseur_.getStat[10], 10);
            nombre1 = Math.Min((attaquant_.getStat[9] + degats1) * 10 / attaquant_.getStat[10], 10);
            nombre2b = (int)(Convert.ToDecimal(((defenseur_.getStat[9]) * 10 / defenseur_.getStat[10])) + 0.5m);
            nombre1b = (int)(Convert.ToDecimal(((attaquant_.getStat[9]) * 10 / attaquant_.getStat[10])) + 0.5m);
            for (int i = 0; i < 20; i++)
            {
                tableauDecalage[i] = r.Next(100) / 5;
                tableauRespiration[i] = r.Next(100) % 2;
            }
        }
        public void powa(e_pouvoir nom_)
        {
            powaa = nom_;
            AffichagePowa = 1300;
        }

        public void DoAFlash(Color color_)
        {
            doFlash = true;
            flash = 0;
            flashColor = color_;
        }

        public void respi()
        {
            for (int i = 0; i < 20; i++)
            {
                tableauRespiration[i] = r.Next(100) % 2;
            }
        }

        public void victory(Color color_, e_race race_)
        {
            Victory = true;
            VictoryColor = color_;
            switch (race_)
            {
                case e_race.Fenrir:
                    VictoryRace = 0;
                    break;
                case e_race.Krissa:
                    VictoryRace = 3;
                    break;
                case e_race.Pandawan:
                    VictoryRace = 2;
                    break;
                case e_race.Pingvin:
                    VictoryRace = 1;
                    break;
                default:
                    break;
            }
            DoAFlash(VictoryColor);
        }

        public Rectangle genererRectangle(int i_, int j_, int altitude_, int camerax_, int cameray_, int direction_)
        {
            Rectangle rect;
            switch (direction_)
            {
                case 0://n
                    rect = new Rectangle((i_ - j_) * 32 - camerax_ + 32, (i_ + j_) * 16 - altitude_ - cameray_ - 64,
                        64, 64);
                    break;
                case 1://o
                    rect = new Rectangle((32 - j_ - i_) * 32 - camerax_ + 32, (i_ + 32 - j_) * 16 - altitude_ - cameray_ - 64,
                        64, 64);
                    break;
                case 2://s
                    rect = new Rectangle((32 - i_ - 32 + j_) * 32 - camerax_ + 32,
                        (32 - i_ + 32 - j_) * 16 - altitude_ - cameray_ - 64, 64, 64);
                    break;
                default://e
                    rect = new Rectangle((j_ - 32 + i_) * 32 - camerax_ + 32, (j_ + 32 - i_) * 16 - altitude_ - cameray_ - 64,
                        64, 64);
                    break;
            }
            return rect;
        }
    }
}
