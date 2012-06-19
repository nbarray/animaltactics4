using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Loohy
    
    class EditeurArmee : Scene
    {
        WriteBox writer;

        Dictionary<e_race, List<FausseUnite>> ToutesLesUnites;
        e_race current;
        Armee army;
        int pointsRestants;
        ListeArmee listeA;
        Vector2 point;
        bool pressed;
        e_classe view;

        public EditeurArmee()
            : base()
        {
            boutons.Add(new BoutonLien(50, 750, new Rectangle(0, 0, 800, 300), null, 5));

            listeA = new ListeArmee(e_race.Pingvin);
            current = e_race.Krissa;
            army = new Armee(2, e_race.Random, Color.White, 0, 0,0);
            army.AddUnite(e_classe.PingvinOdin);
            pressed = false;
            view = e_classe.FenrirTemplier;
            ToutesLesUnites = new Dictionary<e_race, List<FausseUnite>>();
            #region ping
            //0 ping
            ToutesLesUnites.Add(e_race.Pingvin, new List<FausseUnite>());
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinOdin));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinMugin));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinThor));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinBerserker));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinWalkyrie));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinBolter));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinChar));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinLanceFlammes));
            ToutesLesUnites[e_race.Pingvin].Add(new FausseUnite(e_classe.PingvinUgin));
            #endregion
            #region panda
            //1 panda
            ToutesLesUnites.Add(e_race.Pandawan, new List<FausseUnite>());
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanSayan));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanSniper));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanNinja));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanMoine));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanBushi));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanYabusame));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanSokei));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanMerco));
            ToutesLesUnites[e_race.Pandawan].Add(new FausseUnite(e_classe.PandawanCharDragon));
            #endregion
            #region fenr
            //2 fenr
            ToutesLesUnites.Add(e_race.Fenrir, new List<FausseUnite>());
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirOkami));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirDreadnought));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirRailgun));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirWarlord));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirWarBlade));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirTireur));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirPsyker));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirEclaireur));
            ToutesLesUnites[e_race.Fenrir].Add(new FausseUnite(e_classe.FenrirTemplier));
            #endregion
            #region krissa
            //3 kriss
            ToutesLesUnites.Add(e_race.Krissa, new List<FausseUnite>());
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaChef));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaAssassin));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaLegionnaire));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaGeolier));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaMaraudeur));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaVermine));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaAbomination));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaDesperado));
            ToutesLesUnites[e_race.Krissa].Add(new FausseUnite(e_classe.KrissaCanonnier));
            #endregion
            NEW();

            writer = new WriteBox(new Rectangle(600, Divers.Y - 220, 450, 75));
        }

        //Loohy
        private void NEW()
        {
            switch (current)
            {
                case e_race.Fenrir:
                    current = e_race.Krissa;
                    army.AddUnite(e_classe.KrissaChef);
                    break;
                case e_race.Krissa:
                    current = e_race.Pingvin;
                    army.AddUnite(e_classe.PingvinOdin);
                    break;
                case e_race.Pandawan:
                    current = e_race.Fenrir;
                    army.AddUnite(e_classe.FenrirOkami);
                    break;
                default:
                    current = e_race.Pandawan;
                    army.AddUnite(e_classe.PandawanSayan);
                    break;
            }
            listeA.NEW(current);
            pointsRestants = 400 - army.bataillon[1].points;
            army.bataillon.RemoveAt(1);
            army.effectif--;
        }
        //Loohy
        private void DrawDeca(Rectangle rect_, Unite unite_)
        {
            Contents.Draw("Decagone", rect_, Color.Gray);
            float rot = 0;
            for (int d = 0; d < 10; d++)
            {
                float rot2 = rot;
                int f = 0;
                while (rot2 - rot < (float)(Math.PI / 5))
                {
                    rot2 += (float)(Math.PI / 500);
                    f++;
                    //Contents.Draw("px2",
                    //    new Rectangle(rect_.X - 3, rect_.Y + rect_.Height / 2 - 3,
                    //   GetStatDeca(d, 80) - (int)((f * (GetStatDeca(d, 80) - GetStatDeca((d + 1) % 10, 80))) / 100f 
                    //   + Math.Log(1 + 200*Math.Min(f, 100 - f)))*2, 5),
                    //   listeA.couleur, new Rectangle(0, 0, 100, 100),
                    //    rot2);
                }
                Contents.Draw("px2", new Rectangle(rect_.X, rect_.Y + rect_.Height / 2 - 3,
                    GetStatDeca(d, 80)*2, 5),
                    new Color(255 - listeA.couleur.R, 255 - listeA.couleur.G, 255 - listeA.couleur.B), new Rectangle(0, 0, 100, 100),
                rot);
                rot += (float)(Math.PI / 5);
            }
            //Contents.Draw("px2", new Rectangle(rect_.X  - 3, rect_.Y + rect_.Height / 2 - 3,
            //    GetStatDeca(0, 80)*2, 2),
            //    new Color(255 - listeA.couleur.R, 255 - listeA.couleur.G, 255 - listeA.couleur.B), new Rectangle(0, 0, 100, 100),
            //rot);
            rot += (float)(Math.PI / 5);
            //Contents.Draw("px2", new Rectangle(rect_.X  - 3, rect_.Y + rect_.Height / 2 - 3,
            //    GetStatDeca(1, 80)*2, 2),
            //    new Color(255 - listeA.couleur.R, 255 - listeA.couleur.G, 255 - listeA.couleur.B), new Rectangle(0, 0, 100, 100),
            //rot);
        }
        //Loohy & FuckingSheep
        public int GetStatDeca(int d_, int tailleMax)
        {
            switch (d_)
            {
                case 9:
                    return (army.bataillon[0].armure * tailleMax) / 2;
                case 1:
                    return (army.bataillon[0].resistance * tailleMax) / 2;
                case 2:
                    return (army.bataillon[0].energiemax * tailleMax) / 20;
                case 3:
                    return (army.bataillon[0].puissance * tailleMax) / 20;
                case 4:
                    return (army.bataillon[0].coupcritique * tailleMax) / 7;
                case 8:
                    return (army.bataillon[0].esquive * tailleMax) / 10;
                case 5:
                    return ((army.bataillon[0].precision - 100) * tailleMax) / 5;
                case 7:
                    return (army.bataillon[0].initiative * tailleMax) / 10;
                case 6:
                    return (army.bataillon[0].attaque * tailleMax) / 20;
                case 0:
                    return (army.bataillon[0].pvmax * tailleMax) / 30;
                default:
                    return 200;
            }
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            Rectangle bob = new Rectangle(75, 200, 50, 50);
            Rectangle mike = new Rectangle(1000, 800, 150, 50);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !pressed)
            {
                #region race
                if (Contents.contientLaSouris(new Rectangle(50, 50, 100, 100)))
                {
                    pressed = true;
                    NEW();
                }
                #endregion
                #region AddUnite
                bob.Y += 55;
                for (int g = 1; g < ToutesLesUnites[current].Count; g++)
                {
                    if (Contents.contientLaSouris(bob))
                    {
                        if (ToutesLesUnites[current][g].points <= pointsRestants && listeA.bataillon.Count < 9)
                        {
                            listeA.AddUnite(ToutesLesUnites[current][g].classe);
                            pointsRestants -= army.bataillon[0].points;
                        }
                    }
                    bob.Y += 55;
                }
                #endregion
                #region RETIRER
                bob = new Rectangle(1075, 200, 50, 50);
                bob.Y += 55;
                for (int g = 1; g < listeA.bataillon.Count; g++)
                {
                    if (Contents.contientLaSouris(bob))
                    {
                        pointsRestants += listeA.bataillon[g].points;
                        listeA.bataillon.RemoveAt(g);
                        break;
                    }
                    bob.Y += 55;
                }
                #endregion
                if (Contents.contientLaSouris(mike) && writer.text != "")
                {
                    Sauvegarde(ref writer.text);
                }
                pressed = true;
            }
            else
            {
                #region See Unite
                for (int g = 0; g < ToutesLesUnites[current].Count; g++)
                {
                    if (Contents.contientLaSouris(bob))
                    {
                        army.vider(0, 0);
                        army.AddUnite(ToutesLesUnites[current][g].classe);
                        view = ToutesLesUnites[current][g].classe;
                    }
                    bob.Y += 55;
                }
                #endregion
            }

            if (Mouse.GetState().LeftButton != ButtonState.Pressed)
            {
                pressed = false;
            }

            writer.Update();
        }

        public override void DrawScene()
        {
            base.DrawScene();
            Contents.DrawString(Dico.langues[Dico.current][18] + pointsRestants.ToString(),
                new Rectangle(180, 80,0,0), listeA.couleur);
            Rectangle bob = new Rectangle(75, 200, 50, 50);
            Rectangle mike = new Rectangle(1000,800, 150, 50);
            #region current
            switch (current)
            {
                case e_race.Fenrir:
                    Contents.Draw("e_race", new Rectangle(50, 50, 100, 100), new Rectangle(0, 0, 250, 250));
                    break;
                case e_race.Krissa:
                    Contents.Draw("e_race", new Rectangle(50, 50, 100, 100), new Rectangle(750, 0, 250, 250));
                    break;
                case e_race.Pandawan:
                    Contents.Draw("e_race", new Rectangle(50, 50, 100, 100), new Rectangle(500, 0, 250, 250));
                    break;
                case e_race.Pingvin:
                    Contents.Draw("e_race", new Rectangle(50, 50, 100, 100), new Rectangle(250, 0, 250, 250));
                    break;
                default:
                    break;
            }
            #endregion
            #region cases
            for (int g = 0; g < ToutesLesUnites[current].Count; g++)
            {
                if (ToutesLesUnites[current][g].points <= pointsRestants)
                {
                    Contents.Draw("px", bob,
                        Color.Green, new Rectangle(4, 4, 120, 120));
                }
                else
                {
                    Contents.Draw("px", bob,
                        Color.Red, new Rectangle(4, 4, 120, 120));
                }
                Contents.Draw(Divers.getName(ToutesLesUnites[current][g].classe), bob, new Rectangle(2, 2, 110, 110));
                bob.Y += 55;
            }
            bob = new Rectangle(1075, 200, 50, 50);
            for (int g = 0; g < listeA.bataillon.Count; g++)
            {
                Contents.Draw("px", bob,
                    listeA.couleur, new Rectangle(4, 4, 120, 120));
                Contents.Draw(Divers.getName(listeA.bataillon[g].classe), bob, new Rectangle(2, 2, 110, 110));
                bob.Y += 55;
            }
            #endregion
            #region Unite
            bob = new Rectangle(250, 290, 128, 128);
            Contents.Draw("px", bob, listeA.couleur);
            bob.Y += 2;
            Contents.Draw(army.bataillon[0].nom, bob, new Rectangle(128, 0, 128, 128));
            bob.Y -= 2;
            Rectangle Samsung = new Rectangle(250, 200, 0,0);
            Contents.DrawString(army.bataillon[0].nom, Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Samsung.X += 20;
            Contents.DrawString(army.bataillon[0].points.ToString() + " points", Samsung, Color.White);
            Samsung.X += 200;
            Contents.DrawString(Dico.langues[Dico.current][19] + army.bataillon[0].getStat[0].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][20] + army.bataillon[0].getStat[1].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][21] + army.bataillon[0].getStat[2].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][22] + army.bataillon[0].getStat[3].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][23] + army.bataillon[0].getStat[4].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][24] + army.bataillon[0].getStat[5].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][25] + army.bataillon[0].getStat[6].ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Contents.DrawString(Dico.langues[Dico.current][26] + army.bataillon[0].mouvementmax.ToString(), Samsung, Color.White);
            Samsung.Y += (int)Contents.MeasureString("T").Y + 4;
            Samsung.X = 250;
            Contents.DrawString(Divers.getText(view), Samsung, Color.White);
            //force, dexterite, constitution, defense, esprit, chance, vitesse 
            //DrawDeca(new Rectangle(600, 200, 400, 400), army.bataillon[0]);
            #endregion
            #region bouton save
            if (Contents.contientLaSouris(mike))
            {
                Contents.Draw("px", mike, Color.Gray);
                Contents.DrawString("Sauvegarde", new Rectangle(mike.X + 5, mike.Y + 10, 0, 0), Color.Black);
            }
            else
            {
                Contents.Draw("px", mike, Color.DarkGray);
                Contents.DrawString("Sauvegarde", new Rectangle(mike.X + 5, mike.Y + 10, 0, 0), Color.White);
            }
            #endregion

            writer.Draw();
        }

        public void Sauvegarde(ref string txt_)
        {
            Divers.serializer(listeA, txt_);
            Engine.files.AddArmyName(txt_);
            Divers.serializer(Engine.files, "allTheLists4242Penguin");
            txt_ = "";
        }
    }
}
