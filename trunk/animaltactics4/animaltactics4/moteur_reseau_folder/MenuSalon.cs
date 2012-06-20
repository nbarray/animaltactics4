using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class MenuSalon : Scene
    {
        string carte;
        Color[] couleurs;
        List<Color> couleursDispo;
        int[] difficulte, camp;
        string[] armees;
        int limiteDeTours;
        bool p, b, c, d;
        TextBox output;

        public MenuSalon()
            : base()
        {
            boutons.Add(new BoutonNouvellePartie(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), 0));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonChoix(new Rectangle(325, 200, 100, 100), new Rectangle(0, 0, 80, 80), 3, "fog"));
            boutons.Add(new BoutonChoix(new Rectangle(200, 200, 100, 100), new Rectangle(0, 0, 100, 100), 4, "mod"));
            armees = new string[6];
            difficulte = new int[6];
            couleurs = new Color[6];
            camp = new int[6];
            limiteDeTours = 15;
            for (int i = 0; i < 6; i++)
            {
                armees[i] = "";
                difficulte[i] = 0;
                couleurs[i] = Color.White;
                camp[i] = 1;
            }
            couleursDispo = new List<Color> { Color.Red, Color.Blue, Color.Orange, Color.Yellow, Color.Purple, Color.Green, Color.Indigo };
            carte = "";
            p = false;
            b = false;
            c = false;
            d = false;
            output = new TextBox(new Rectangle(900, 550, 250, 200));
        }

        public override void UpdateScene(GameTime gameTime_)
        {
            UpdateServer();
            base.UpdateScene(gameTime_);
            List<string> nomDesArmees_ = new List<string>();
            List<int> difficultes_ = new List<int>();
            List<int> camp_ = new List<int>();
            List<Color> couleurs_ = new List<Color>();
            for (int i = 0; i < 6; i++)
            {
                if (armees[i] != "")
                {
                    nomDesArmees_.Add(armees[i]);
                    difficultes_.Add(difficulte[i]);
                    couleurs_.Add(couleurs[i]);
                    camp_.Add(camp[i]);
                }
            }
            e_typeDePartie conditionsDeVictoire_ = e_typeDePartie.Echiquier;
            for (int i = 0; i < ((BoutonChoix)boutons[3]).current; i++)
            {
                conditionsDeVictoire_++;
            }
            e_brouillardDeGuerre fog_ = e_brouillardDeGuerre.ToutVisible;
            for (int i = 0; i < ((BoutonChoix)boutons[2]).current; i++)
            {
                fog_++;
            }
            ((BoutonNouvellePartie)boutons[0]).UpdateSpecial(gameTime_, carte, nomDesArmees_, difficultes_, camp_, couleurs_, conditionsDeVictoire_, fog_, 90, limiteDeTours);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            Rectangle acwl = new Rectangle(100, 390 - (int)Contents.MeasureString("S").Y, (int)Contents.MeasureString(carte).X, (int)Contents.MeasureString("S").Y);
            #region carte et ajout armee
            Contents.Draw("px", acwl, Color.DarkRed);
            Contents.DrawString(carte, acwl);
            acwl = new Rectangle(100, 400, 475, (int)Contents.MeasureString("S").Y);
            foreach (string item in Engine.files.listeDesMaps)
            {
                Contents.Draw("px", acwl, Color.DarkBlue);
                Contents.DrawString(item, acwl);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(acwl))
                {
                    carte = item;
                }
                acwl.Y += acwl.Height + 3;
            }
            acwl.X += acwl.Width + 50;
            acwl.Y = 400;
            foreach (string item in Engine.files.listeDesListesdArmee)
            {
                Contents.Draw("px", acwl, Color.DarkBlue);
                Contents.DrawString(item, acwl);
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(acwl) && !p)
                {
                    int index = 0;
                    while (index < 6)
                    {
                        if (armees[index] == "")
                        {
                            armees[index] = item;
                            couleurs[index] = couleursDispo[0];
                            couleursDispo.RemoveAt(0);
                            index = 6;
                        }
                        index++;
                    }
                }
                acwl.Y += acwl.Height + 3;
            }
            #endregion

            #region editer joueurs
            Rectangle blankass = new Rectangle(625, 30, (int)Contents.MeasureString("S").Y, (int)Contents.MeasureString("S").Y);
            Rectangle noOneIsInnocent = new Rectangle(628 + (int)Contents.MeasureString("S").Y, 30 + ((int)Contents.MeasureString("S").Y - 20) / 2, 20, 20);
            acwl = new Rectangle(651 + (int)Contents.MeasureString("S").Y, 30, 300, (int)Contents.MeasureString("S").Y);
            Rectangle noirDesir = new Rectangle(954 + (int)Contents.MeasureString("S").Y, 30 + ((int)Contents.MeasureString("S").Y - 20) / 2, 20, 20);
            for (int i = 0; i < 6; i++)
            {
                Contents.Draw("px", blankass, Color.DarkGray);
                Contents.DrawString(difficulte[i].ToString(), new Rectangle(blankass.X + 4, blankass.Y + 4, 0, 0));
                Contents.Draw("px", noOneIsInnocent, Color.DarkGray);
                Contents.DrawString(camp[i].ToString(), new Rectangle(noOneIsInnocent.X + 2, noOneIsInnocent.Y + 2, 0, 0));
                Contents.Draw("px", noirDesir, couleurs[i]);
                if (armees[i] == "")
                {
                    Contents.Draw("px", acwl, Color.DarkGray);
                }
                else
                {
                    Contents.Draw("px", acwl, Color.DarkRed);
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(noirDesir) && !p)
                    {
                        couleurSuivante(i);
                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(blankass) && !p)
                    {
                        difficulte[i] = (difficulte[i] + 1) % 4;
                    }
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(noOneIsInnocent) && !p)
                    {
                        camp[i] = (camp[i]) % 6 + 1;
                    }
                    if (Mouse.GetState().RightButton == ButtonState.Pressed && Contents.contientLaSouris(acwl) && !p)
                    {
                        armees[i] = "";
                        couleursDispo.Add(couleurs[i]);
                        couleurs[i] = Color.White;
                        decalage();
                    }
                }
                Contents.DrawString(armees[i], acwl);
                blankass.Y += acwl.Height + 3;
                noOneIsInnocent.Y += acwl.Height + 3;
                acwl.Y += acwl.Height + 3;
                noirDesir.Y += acwl.Height + 3;
            }
            #endregion
            p = Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed;
            output.Draw();
        }

        public void decalage()
        {
            for (int i = 1; i < 6; i++)
            {
                if (armees[i] != "" && armees[i - 1] == "")
                {
                    armees[i - 1] = armees[i];
                    armees[i] = "";
                    difficulte[i - 1] = difficulte[i];
                    difficulte[i] = 0;
                    camp[i - 1] = camp[i];
                    camp[i] = 0;
                    couleurs[i - 1] = couleurs[i];
                    couleurs[i] = Color.White;
                }
            }
        }

        public void couleurSuivante(int index_)
        {
            couleursDispo.Add(couleurs[index_]);
            couleurs[index_] = couleursDispo[0];
            couleursDispo.RemoveAt(0);
        }

        public void UpdateServer()
        {
            b = Server.ListenTo();
            output.Add("Un client a rejoind le salon.");
        }
    }
}
