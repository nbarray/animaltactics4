using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class MenuClassique : Scene
    {
        string carte;
        Color[] couleurs;
        List<Color> couleursDispo;
        int[] difficulte;
        string[] armees;
        int limiteDeTours;
        bool p;

        public MenuClassique()
            : base()
        {
            boutons.Add(new BoutonNouvellePartie(Divers.X / 2 - 200, 600, new Rectangle(0, 0, 800, 300), 0));
            boutons.Add(new BoutonLien(Divers.X / 2 - 200, 700, new Rectangle(0, 0, 800, 300), null, 5));
            boutons.Add(new BoutonChoix(new Rectangle(325, 200, 100, 100), new Rectangle(0, 0, 80, 80), 3, "fog"));
            boutons.Add(new BoutonChoix(new Rectangle(200, 200, 100, 100), new Rectangle(0, 0, 100, 100), 4, "mod"));
            armees = new string[6];
            difficulte = new int[6];
            couleurs = new Color[6];
            limiteDeTours = 15;
            for (int i = 0; i < 6; i++)
            {
                armees[i] = "";
                difficulte[i] = 0;
                couleurs[i] = Color.White;
            }
            couleursDispo = new List<Color> { Color.Red, Color.Blue, Color.Orange, Color.Yellow};
            carte = "";
            p = false;

        }

        public override void UpdateScene(GameTime gameTime_)
        {
            base.UpdateScene(gameTime_);
            List<string> nomDesArmees_ = new List<string>();
            List<int> difficultes_ = new List<int>();
            List<Color> couleurs_ = new List<Color>();
            for (int i = 0; i < 6; i++)
            {
                if (armees[i] != "")
                {
                    nomDesArmees_.Add(armees[i]);
                    difficultes_.Add(difficulte[i]);
                    couleurs_.Add(couleurs[i]);
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
            ((BoutonNouvellePartie)boutons[0]).UpdateSpecial(gameTime_, carte, nomDesArmees_, difficultes_, couleurs_, conditionsDeVictoire_, fog_, limiteDeTours);
        }

        public override void DrawScene()
        {
            base.DrawScene();
            Rectangle acwl = new Rectangle(100, 390 - (int)Contents.MeasureString("S").Y, (int)Contents.MeasureString(carte).X, (int)Contents.MeasureString("S").Y);
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
                            index = 6;
                        }
                        index++;
                    }
                }
                acwl.Y += acwl.Height + 3;
            }

            Rectangle blankass = new Rectangle(625, 30, (int)Contents.MeasureString("S").Y, (int)Contents.MeasureString("S").Y);
            Rectangle noOneIsInnocent = new Rectangle(628 + (int)Contents.MeasureString("S").Y, 30 + ((int)Contents.MeasureString("S").Y - 20) / 2, 20, 20);
            acwl = new Rectangle(651 + (int)Contents.MeasureString("S").Y, 30, 300, (int)Contents.MeasureString("S").Y);
            Rectangle noirDesir = new Rectangle(954 + (int)Contents.MeasureString("S").Y, 30 + ((int)Contents.MeasureString("S").Y - 20) / 2, 20, 20);
            for (int i = 0; i < 6; i++)
            {
                Contents.Draw("px", blankass, Color.DarkGray);
                Contents.DrawString(difficulte[i].ToString(), new Rectangle(blankass.X+2, blankass.Y+2,0,0));
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
            p = Mouse.GetState().LeftButton == ButtonState.Pressed || Mouse.GetState().RightButton == ButtonState.Pressed;
        }

        public void decalage()
        {
            for (int i = 1; i < 6; i++)
            {
                if (armees[i] != "" &&armees[i-1] == "")
                {
                    armees[i - 1] = armees[i];
                    armees[i] = "";
                }
            }
        }

        public void couleurSuivante(int index_)
        {
            
        }
    }
}
