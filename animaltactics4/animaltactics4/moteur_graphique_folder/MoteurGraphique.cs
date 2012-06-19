using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Loohy
    [Serializable]
    class MoteurGraphique
    {
        public int direction;//0n, 1o, 2s, 3e
        public int longueur, largeur, camerax, cameray, lastcamerax, lastcameray;
        float flammiches;
        public Tile[,] map;
        public e_brouillardDeGuerre fog;

        Random r;

        bool pvOrNot;
        bool clicOrNot;

        //Loohy
        public MoteurGraphique(int longueur_, int largeur_)
        {
            longueur = longueur_;
            largeur = largeur_;
            camerax = 0;
            cameray = 0;
            direction = 0;
            flammiches = 0;
            int compteur1 = 0;
            int compteur2 = 0;
            r = new Random();
            pvOrNot = false;
            map = new Tile[longueur, largeur];
            while (compteur1 < longueur)
            {
                while (compteur2 < largeur)
                {
                    map[compteur1, compteur2] = new Tile(compteur1, compteur2);
                    compteur2++;
                }
                compteur1++;
                compteur2 = 0;
            }
            mapAleaFaceToFaceGlace(longueur_, largeur_, 4, 4, 4);
            //if (r.Next(100) % 2 == 0)
            //{
            //    mapAleaFaceToFace(32, 32, 3, 3, 2);
            //}
            //else
            //{
            //    mapAleaFaceToFaceGlace(32, 32, 1, 3, 8);
            //}
            fog = e_brouillardDeGuerre.ToutVisible;
            //Aplatir();
        }

        //Loohy
        public void Draw(SystemeDeJeu gameplay_)
        {
            if (flammiches > 100)
            {
                flammiches = 0;
            }
            else
            {
                flammiches = (flammiches + 0.5f);
            }
            switch (direction)
            {
                case 0:
                    DrawTilesNord(gameplay_);
                    break;
                case 1:
                    DrawTilesOuest(gameplay_);
                    break;
                case 2:
                    DrawTilesSud(gameplay_);
                    break;
                default:
                    DrawTilesEst(gameplay_);
                    break;
            }
            switch (gameplay_.listeDesJoueurs[gameplay_.tourencours].espece)
            {
                case e_race.Fenrir:
                    DrawpvUniteSelect(gameplay_, 4);
                    break;
                case e_race.Krissa:
                    DrawpvUniteSelect(gameplay_, 3);
                    break;
                case e_race.Pandawan:
                    DrawpvUniteSelect(gameplay_, 2);
                    break;
                case e_race.Pingvin:
                    DrawpvUniteSelect(gameplay_, 1);
                    break;
                default:
                    break;
            }
            if (gameplay_.listeDesJoueurs[gameplay_.tourencours].bataillon[gameplay_.listeDesJoueurs[gameplay_.tourencours].uniteselect].alive)
            {
                //map[gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].i,
                //    gameplay_.armees[gameplay_.tourencours].bataillon[gameplay_.armees[gameplay_.tourencours].uniteselect].j]
                //    .Drawmouv( camerax, cameray, tex_, direction);
            }
            if (gameplay_.conditionsDeVictoire == e_typeDePartie.Tresor)
            {
                DrawTresor(gameplay_.tresor_i, gameplay_.tresor_j);
            }
        }

        //Loohy
        private void DrawpvUniteSelect(SystemeDeJeu gameplay_, int n_)
        {
            map[gameplay_.listeDesJoueurs[gameplay_.tourencours].bataillon[gameplay_.listeDesJoueurs[gameplay_.tourencours].uniteselect].i,
                gameplay_.listeDesJoueurs[gameplay_.tourencours].bataillon[gameplay_.listeDesJoueurs[gameplay_.tourencours].uniteselect].j]
                .Drawpv(camerax, cameray, gameplay_.listeDesJoueurs[gameplay_.tourencours].couleur, n_, direction);
        }
        //Loohy
        private void DrawTilesNord(SystemeDeJeu gameplay_)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                    if (pvOrNot)
                    {
                        if (map[i, j].presence)
                        {
                            switch (gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].espece)
                            {
                                case e_race.Fenrir:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 15, direction);
                                    break;
                                case e_race.Krissa:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 16, direction);
                                    break;
                                case e_race.Pandawan:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 14, direction);
                                    break;
                                case e_race.Pingvin:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 17, direction);
                                    break;
                                default:
                                    break;
                            }
                            if (gameplay_.conditionsDeVictoire == e_typeDePartie.Echiquier)
                            {
                                map[i, j].DrawCrown(camerax, cameray,
                                                gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, direction);
                            }
                        }
                    }
                }
            }
        }
        //Loohy
        private void DrawTilesOuest(SystemeDeJeu gameplay_)
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = largeur - 1; j >= 0; j--)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                    if (pvOrNot)
                    {
                        if (map[i, j].presence)
                        {
                            switch (gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].espece)
                            {
                                case e_race.Fenrir:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 15, direction);
                                    break;
                                case e_race.Krissa:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 16, direction);
                                    break;
                                case e_race.Pandawan:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 14, direction);
                                    break;
                                case e_race.Pingvin:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 17, direction);
                                    break;
                                default:
                                    break;
                            }
                            if (gameplay_.conditionsDeVictoire == e_typeDePartie.Echiquier)
                            {
                                map[i, j].DrawCrown(camerax, cameray,
                                                gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, direction);
                            }
                        }
                    }
                }
            }
        }
        //Loohy
        private void DrawTilesSud(SystemeDeJeu gameplay_)
        {
            for (int i = longueur - 1; i >= 0; i--)
            {
                for (int j = largeur - 1; j >= 0; j--)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                    if (pvOrNot)
                    {
                        if (map[i, j].presence)
                        {
                            switch (gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].espece)
                            {
                                case e_race.Fenrir:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 15, direction);
                                    break;
                                case e_race.Krissa:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 16, direction);
                                    break;
                                case e_race.Pandawan:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 14, direction);
                                    break;
                                case e_race.Pingvin:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 17, direction);
                                    break;
                                default:
                                    break;
                            }
                            if (gameplay_.conditionsDeVictoire == e_typeDePartie.Echiquier)
                            {
                                map[i, j].DrawCrown(camerax, cameray,
                                                gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, direction);
                            }
                        }
                    }
                }
            }
        }
        //Loohy
        private void DrawTilesEst(SystemeDeJeu gameplay_)
        {
            for (int i = longueur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                    if (pvOrNot)
                    {
                        if (map[i, j].presence)
                        {
                            switch (gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].espece)
                            {
                                case e_race.Fenrir:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 15, direction);
                                    break;
                                case e_race.Krissa:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 16, direction);
                                    break;
                                case e_race.Pandawan:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 14, direction);
                                    break;
                                case e_race.Pingvin:
                                    map[i, j].Drawpv(camerax, cameray,
                                        gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, 17, direction);
                                    break;
                                default:
                                    break;
                            }
                            if (gameplay_.conditionsDeVictoire == e_typeDePartie.Echiquier)
                            {
                                map[i, j].DrawCrown(camerax, cameray,
                                                gameplay_.listeDesJoueurs[map[i, j].pointeurArmee].couleur, direction);
                            }
                        }
                    }
                }
            }
        }

        //Loohy
        public void DrawEditeur()
        {
            switch (direction)
            {
                case 0:
                    DrawTilesNordEditeur();
                    break;
                case 1:
                    DrawTilesOuestEditeur();
                    break;
                case 2:
                    DrawTilesSudEditeur();
                    break;
                default:
                    DrawTilesEstEditeur();
                    break;
            }
        }
        //Loohy
        private void DrawTilesNordEditeur()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                }
            }
        }
        //Loohy
        private void DrawTilesOuestEditeur()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = largeur - 1; j >= 0; j--)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                }
            }
        }
        //Loohy
        private void DrawTilesSudEditeur()
        {
            for (int i = longueur - 1; i >= 0; i--)
            {
                for (int j = largeur - 1; j >= 0; j--)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                }
            }
        }
        //Loohy
        private void DrawTilesEstEditeur()
        {
            for (int i = longueur - 1; i >= 0; i--)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].Draw(camerax, cameray, (int)flammiches, direction);
                }
            }
        }

        //Loohy
        public void DrawTresor(int i_, int j_)
        {
            map[i_, j_].DrawTresor(camerax, cameray, direction);
        }

        //Loohy
        public void Update(SystemeDeJeu gameplay_, HUD hud_)
        {
            Camera();
            for (int d = 0; d < 7; d++)
            {
                for (int i = (int)getCaseFromMouseAvecAltitude().X + 3; i >= (int)getCaseFromMouseAvecAltitude().X - 1; i--)
                {
                    int j = (int)getCaseFromMouseAvecAltitude().Y - 1;
                    if (i + d >= 0 && j + d >= 0 && i + d < longueur && j + d < largeur)
                    {
                        //map[i + d, j + d].estEnSurbrillance = true;
                        if ((lastcamerax != camerax || lastcameray != cameray) && clicOrNot)
                        {
                            surbrillance(i + d, j + d, new Rectangle(0, 0, 0, 0));
                        }
                    }
                }
                for (int j = (int)getCaseFromMouseAvecAltitude().Y + 3; j >= (int)getCaseFromMouseAvecAltitude().Y - 1; j--)
                {
                    int i = (int)getCaseFromMouseAvecAltitude().X - 1;
                    if (i + d >= 0 && j + d >= 0 && i + d < longueur && j + d < largeur)
                    {
                        //map[i + d, j + d].estEnSurbrillance = true;
                        if ((lastcamerax != camerax || lastcameray != cameray) && clicOrNot)
                        {
                            map[i + d, j + d].UpdateLosange(camerax, cameray, direction);
                        }
                        surbrillance(i + d, j + d, new Rectangle(0, 0, 0, 0));
                    }
                }
            }
            if (clicOrNot)
            {
                lastcamerax = camerax;
                lastcameray = cameray;
            }
            #region Clavier
            #region Shift
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && clicOrNot)
            {
                pvOrNot = !pvOrNot;
                clicOrNot = false;
            }
            #endregion
            #region Back
            if (Keyboard.GetState().IsKeyDown(Keys.Back) && clicOrNot)
            {
                direction = (direction + 1) % 4;
                centrerSur(longueur / 2, largeur / 2);
                clicOrNot = false;
                gameplay_.rotation();
            }
            #endregion
            #region Ctrl
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl) && clicOrNot &&
                gameplay_.listeDesJoueurs[gameplay_.tourencours].
                            bataillon[gameplay_.listeDesJoueurs[gameplay_.tourencours].
                            uniteselect].attaqOrNot)
            {
                switch (gameplay_.mood)
                {
                    case e_modeAction.Attaque:
                        if (gameplay_.listeDesJoueurs[gameplay_.tourencours].
                            bataillon[gameplay_.listeDesJoueurs[gameplay_.tourencours].uniteselect].
                            typeUnite == TypeUnite.Elite)
                        {
                            gameplay_.mood = e_modeAction.Pouvoir;
                        }
                        else
                        {
                            gameplay_.mood = e_modeAction.Mouvement;
                        }
                        break;
                    case e_modeAction.Mouvement:
                        gameplay_.mood = e_modeAction.Attaque;
                        break;
                    case e_modeAction.Pouvoir:
                        gameplay_.mood = e_modeAction.Mouvement;
                        break;
                    default:
                        break;
                }
                clicOrNot = false;
            }
            #endregion
            if (Keyboard.GetState().IsKeyUp(Keys.LeftShift) &&
                    Keyboard.GetState().IsKeyUp(Keys.LeftControl)
                && Keyboard.GetState().IsKeyUp(Keys.Back)
                && Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Down)
                && Keyboard.GetState().IsKeyUp(Keys.Left)
                && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                clicOrNot = true;
            }
            #endregion
        }
        //Loohy
        public void UpdateEditeur()
        {
            Camera();
            viderSurbrillance();
            for (int d = 0; d < 7; d++)
            {
                for (int i = (int)getCaseFromMouseAvecAltitude().X + 3; i >= (int)getCaseFromMouseAvecAltitude().X - 1; i--)
                {
                    int j = (int)getCaseFromMouseAvecAltitude().Y - 1;
                    if (i + d >= 0 && j + d >= 0 && i + d < longueur && j + d < largeur)
                    {
                        //map[i + d, j + d].estEnSurbrillance = true;
                        if ((lastcamerax != camerax || lastcameray != cameray) && clicOrNot)
                        {
                            surbrillance(i + d, j + d, new Rectangle(0, 0, 0, 0));
                        }
                    }
                }
                for (int j = (int)getCaseFromMouseAvecAltitude().Y + 3; j >= (int)getCaseFromMouseAvecAltitude().Y - 1; j--)
                {
                    int i = (int)getCaseFromMouseAvecAltitude().X - 1;
                    if (i + d >= 0 && j + d >= 0 && i + d < longueur && j + d < largeur)
                    {
                        //map[i + d, j + d].estEnSurbrillance = true;
                        if ((lastcamerax != camerax || lastcameray != cameray) && clicOrNot)
                        {
                            map[i + d, j + d].UpdateLosange(camerax, cameray, direction);
                        }
                        surbrillance(i + d, j + d, new Rectangle(0, 0, 0, 0));
                    }
                }
            }
            if (clicOrNot)
            {
                lastcamerax = camerax;
                lastcameray = cameray;
            }
            #region Clavier
            #region Back
            if (Keyboard.GetState().IsKeyDown(Keys.Back) && clicOrNot)
            {
                direction = (direction + 1) % 4;
                centrerSur(longueur / 2, largeur / 2);
                clicOrNot = false;
            }
            #endregion
            if (Keyboard.GetState().IsKeyUp(Keys.Back)
                && Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Down)
                && Keyboard.GetState().IsKeyUp(Keys.Left)
                && Keyboard.GetState().IsKeyUp(Keys.Right))
            {
                clicOrNot = true;
            }
            #endregion
        }

        //Loohy
        public void surbrillance(int i_, int j_, Rectangle rect_)
        {
            if ((i_ + 1 == longueur || !map[i_ + 1, j_].estEnSurbrillance)
                && (i_ + 1 == longueur || (j_ + 1 == largeur || !map[i_ + 1, j_ + 1].estEnSurbrillance))
                && (j_ + 1 == largeur || !map[i_, j_ + 1].estEnSurbrillance)
                && map[i_, j_].estSurvolee(rect_, camerax, cameray, direction))
            {
                map[i_, j_].estEnSurbrillance = true;
                //map[i_, j_].surbrillancePortee = 9;
                //map[i_, j_].sousRectportee.X = 19 * 64;
                //Console.WriteLine(i_ +"/"+ j_);
            }
            else
            {
                map[i_, j_].estEnSurbrillance = false;
                //map[i_, j_].surbrillancePortee = 2;
                //map[i_, j_].sousRectportee.X = 11 * 64;
            }
        }

        //Loohy
        private void Camera()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cameray -= 6;
                clicOrNot = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cameray += 6;
                clicOrNot = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                camerax -= 6;
                clicOrNot = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                camerax += 6;
                clicOrNot = false;
            }
        }

        //Loohy
        #region generateurs de decor
        public void montagne(int i_, int j_)
        {
            for (int d = 0; d < 10; d++)
            {
                for (int p = i_ - d; p < i_ + d; p++)
                {
                    for (int q = j_ - d; q < j_ + d; q++)
                    {
                        if (p >= 0 && p < longueur && q >= 0 && q < largeur)
                        {
                            map[p, q].altitude += r.Next(100) % 4 + 4;
                        }
                    }
                }
            }
        }
        public void foret(int i_, int j_)
        {
            for (int d = 0; d < 6; d++)
            {
                for (int p = i_ - d; p < i_ + d; p++)
                {
                    for (int q = j_ - d; q < j_ + d; q++)
                    {
                        if (p >= 0 && p < longueur && q >= 0 && q < largeur)
                        {
                            if ((r.Next(100) % 10 == 1) && (map[p, q].E_Sol == e_Typedesol.herbe
                                || map[p, q].E_Sol == e_Typedesol.neige) && (map[p, q].E_Route == e_Typederoute.vide))
                            {
                                map[p, q].E_DecorArriere = e_Decorarriere.foret;
                                map[p, q].E_DecorAvant = e_Decoravant.foret;
                                map[p, q].coutEnMouvement = 3;
                            }
                        }
                    }
                }
            }
        }
        public bool bunker(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer) && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.bunker;
                map[i_, j_].E_DecorAvant = e_Decoravant.bunker;
                map[i_, j_].coutEnMouvement = 2;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool icebunker(int i_, int j_)
        {
            if (map[i_, j_].E_DecorArriere == e_Decorarriere.vide)
            {
                if ((map[i_, j_].E_Sol == e_Typedesol.mer) || (map[i_, j_].E_Sol == e_Typedesol.banquise))
                {
                    map[i_, j_].E_DecorArriere = e_Decorarriere.iceBunker;
                    map[i_, j_].E_DecorAvant = e_Decoravant.iceBunker;
                    map[i_, j_].coutEnMouvement = 2;
                }
                else
                {
                    map[i_, j_].E_DecorArriere = e_Decorarriere.bunker;
                    map[i_, j_].E_DecorAvant = e_Decoravant.bunker;
                    map[i_, j_].coutEnMouvement = 2;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public void roadTo(int i1_, int j1_, int i2_, int j2_)
        {
            map[i1_, j1_].E_Route = e_Typederoute.route;
            map[i1_, j1_].coutEnMouvement = 1;
            map[i1_, j1_].estAccessible = true;
            if (i1_ != i2_ || j1_ != j2_)
            {
                #region ligne droite
                if (i1_ < i2_ && j1_ == j2_)
                {
                    roadTo(i1_ + 1, j1_, i2_, j2_);
                }
                if (i1_ > i2_ && j1_ == j2_)
                {
                    roadTo(i1_ - 1, j1_, i2_, j2_);
                }
                if (j1_ < j2_ && i1_ == i2_)
                {
                    roadTo(i1_, j1_ + 1, i2_, j2_);
                }
                if (j1_ > j2_ && i1_ == i2_)
                {
                    roadTo(i1_, j1_ - 1, i2_, j2_);
                }
                #endregion
                #region ligne pas droite
                if (i1_ < i2_ && j1_ < j2_)
                {
                    if (map[i1_, j1_ + 1].E_Route == e_Typederoute.route || map[i1_ + 1, j1_].E_Riviere == e_Riviere.riviere)
                    {
                        roadTo(i1_, j1_ + 1, i2_, j2_);
                    }
                    else
                    {
                        if (map[i1_ + 1, j1_].E_Route == e_Typederoute.route || map[i1_, j1_ + 1].E_Riviere == e_Riviere.riviere)
                        {
                            roadTo(i1_ + 1, j1_, i2_, j2_);
                        }
                        else
                        {
                            if (r.Next(100) % 2 == 0)
                            {
                                roadTo(i1_, j1_ + 1, i2_, j2_);
                            }
                            else
                            {
                                roadTo(i1_ + 1, j1_, i2_, j2_);
                            }
                        }
                    }
                }
                if (i1_ > i2_ && j1_ < j2_)
                {
                    if (map[i1_, j1_ + 1].E_Route == e_Typederoute.route || map[i1_ - 1, j1_].E_Riviere == e_Riviere.riviere)
                    {
                        roadTo(i1_, j1_ + 1, i2_, j2_);
                    }
                    else
                    {
                        if (map[i1_ - 1, j1_].E_Route == e_Typederoute.route || map[i1_, j1_ + 1].E_Riviere == e_Riviere.riviere)
                        {
                            roadTo(i1_ - 1, j1_, i2_, j2_);
                        }
                        else
                        {
                            if (r.Next(100) % 2 == 0)
                            {
                                roadTo(i1_ - 1, j1_, i2_, j2_);
                            }
                            else
                            {
                                roadTo(i1_, j1_ + 1, i2_, j2_);
                            }
                        }
                    }
                }
                if (i1_ < i2_ && j1_ > j2_)
                {
                    if (map[i1_, j1_ - 1].E_Route == e_Typederoute.route || map[i1_ + 1, j1_].E_Riviere == e_Riviere.riviere)
                    {
                        roadTo(i1_, j1_ - 1, i2_, j2_);
                    }
                    else
                    {
                        if (map[i1_ + 1, j1_].E_Route == e_Typederoute.route || map[i1_, j1_ - 1].E_Riviere == e_Riviere.riviere)
                        {
                            roadTo(i1_ + 1, j1_, i2_, j2_);
                        }
                        else
                        {
                            if (r.Next(100) % 2 == 0)
                            {
                                roadTo(i1_, j1_ - 1, i2_, j2_);
                            }
                            else
                            {
                                roadTo(i1_ + 1, j1_, i2_, j2_);
                            }
                        }
                    }
                }
                if (i1_ > i2_ && j1_ > j2_)
                {
                    if (map[i1_, j1_ - 1].E_Route == e_Typederoute.route || map[i1_ - 1, j1_].E_Riviere == e_Riviere.riviere)
                    {
                        roadTo(i1_, j1_ - 1, i2_, j2_);
                    }
                    else
                    {
                        if (map[i1_ - 1, j1_].E_Route == e_Typederoute.route || map[i1_, j1_ - 1].E_Riviere == e_Riviere.riviere)
                        {
                            roadTo(i1_ - 1, j1_, i2_, j2_);
                        }
                        else
                        {
                            if (r.Next(100) % 2 == 0)
                            {
                                roadTo(i1_ - 1, j1_, i2_, j2_);
                            }
                            else
                            {
                                roadTo(i1_, j1_ - 1, i2_, j2_);
                            }
                        }
                    }
                }
                #endregion
            }
        }
        public void river(int i_, int j_)
        {
            if (i_ >= 0 && j_ >= 0 && i_ < longueur && j_ < largeur
                && (map[i_, j_].E_Sol != e_Typedesol.mer && map[i_, j_].E_Sol != e_Typedesol.banquise))
            {
                map[i_, j_].E_Riviere = e_Riviere.riviere;
                map[i_, j_].estAccessible = false;
                float affluentsmax = 1;
                bool goSud = false;
                bool goNord = false;
                bool goEst = false;
                bool goOuest = false;
                #region hauteurs environnantes;
                do
                {
                    if (i_ != 0 && map[i_ - 1, j_].altitude < map[i_, j_].altitude && affluentsmax > 0)
                    {
                        goNord = true;
                        affluentsmax--;
                    }
                    else
                    {
                        affluentsmax -= 0.25f;
                    }
                    if (i_ + 1 != longueur && map[i_ + 1, j_].altitude < map[i_, j_].altitude && affluentsmax > 0)
                    {
                        goSud = true;
                        affluentsmax--;
                    }
                    else
                    {
                        affluentsmax -= 0.25f;
                    }
                    if (j_ != 0 && map[i_, j_ - 1].altitude < map[i_, j_].altitude && affluentsmax > 0)
                    {
                        goOuest = true;
                        affluentsmax--;
                    }
                    else
                    {
                        affluentsmax -= 0.25f;
                    }
                    if (j_ + 1 != largeur && map[i_, j_ + 1].altitude < map[i_, j_].altitude && affluentsmax > 0)
                    {
                        goEst = true;
                        affluentsmax--;
                    }
                    else
                    {
                        affluentsmax -= 0.25f;
                    }
                } while (affluentsmax > 0);
                #endregion
                if (goSud)
                {
                    river(i_ + 1, j_);
                }
                if (goNord)
                {
                    river(i_ - 1, j_);
                }
                if (goOuest)
                {
                    river(i_, j_ - 1);
                }
                if (goEst)
                {
                    river(i_, j_ + 1);
                }
            }
        }
        public void ruines(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer && map[i_, j_].E_Sol != e_Typedesol.banquise)
                && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide)
                && (map[i_, j_].E_Route == e_Typederoute.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.ruine;
                map[i_, j_].coutEnMouvement = 3;
            }
        }
        #endregion

        //Loohy
        #region generateurs de villages
        public void VillagePanda(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer && map[i_, j_].E_Sol != e_Typedesol.banquise)
                   && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.villagePanda;
                for (int h = -1; h < 2; h++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        if (i_ + h > -1 && i_ + h < longueur && j_ + k > -1 && j_ + k < largeur)
                        {
                            if ((map[i_ + h, j_ + k].E_Sol != e_Typedesol.mer && map[i_ + h, j_ + k].E_Sol != e_Typedesol.banquise)
                                && (map[i_ + h, j_ + k].E_DecorArriere == e_Decorarriere.vide))
                            {
                                map[i_ + h, j_ + k].E_DecorArriere = e_Decorarriere.villagePanda;
                                map[i_ + h, j_ + k].coutEnMouvement += 1;
                            }
                        }
                    }
                }
            }
        }
        public void VillagePingvin(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer)
                   && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.villagePingvin;
                for (int h = -1; h < 2; h++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        if (i_ + h > -1 && i_ + h < longueur && j_ + k > -1 && j_ + k < largeur)
                        {
                            if (map[i_ + h, j_ + k].E_DecorArriere == e_Decorarriere.vide)
                            {
                                map[i_ + h, j_ + k].E_DecorArriere = e_Decorarriere.villagePingvin;
                                map[i_ + h, j_ + k].coutEnMouvement += 1;
                            }
                        }
                    }
                }
            }
        }
        public void VillageKrissa(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer && map[i_, j_].E_Sol != e_Typedesol.banquise)
                   && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.villageKrissa;
                for (int h = -1; h < 2; h++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        if (i_ + h > -1 && i_ + h < longueur && j_ + k > -1 && j_ + k < largeur)
                        {
                            if ((map[i_ + h, j_ + k].E_Sol != e_Typedesol.mer
                                && map[i_ + h, j_ + k].E_Sol != e_Typedesol.banquise)
                                && (map[i_ + h, j_ + k].E_DecorArriere == e_Decorarriere.vide))
                            {
                                map[i_ + h, j_ + k].E_DecorArriere = e_Decorarriere.villageKrissa;
                                map[i_ + h, j_ + k].coutEnMouvement += 1;
                            }
                        }
                    }
                }
            }
        }
        public void CampementFenrir(int i_, int j_)
        {
            if ((map[i_, j_].E_Sol != e_Typedesol.mer && map[i_, j_].E_Sol != e_Typedesol.banquise)
                   && (map[i_, j_].E_DecorArriere == e_Decorarriere.vide)
                   && (map[i_, j_].E_Riviere == e_Riviere.vide))
            {
                map[i_, j_].E_DecorArriere = e_Decorarriere.campementFenrir;
                for (int h = -1; h < 2; h++)
                {
                    for (int k = -1; k < 2; k++)
                    {
                        if (i_ + h > -1 && i_ + h < longueur && j_ + k > -1 && j_ + k < largeur)
                        {
                            if ((map[i_ + h, j_ + k].E_Sol != e_Typedesol.mer && map[i_ + h, j_ + k].E_Sol != e_Typedesol.banquise)
                                && (map[i_ + h, j_ + k].E_DecorArriere == e_Decorarriere.vide)
                                && (map[i_, j_].E_Riviere == e_Riviere.vide))
                            {
                                map[i_ + h, j_ + k].E_DecorArriere = e_Decorarriere.campementFenrir;
                                map[i_ + h, j_ + k].coutEnMouvement += 1;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        //Loohy
        public void mapDef()
        {

            map = new Tile[32, 32];
            for (int p = 0; p < 32; p++)
            {
                for (int q = 0; q < 32; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].altitude -= 10;
                }
            }

            for (int z = 0; z < 10; z++)
            {
                foret(z + 5, 10);
            }

            ruines(15, 4);

            viderVue();
        }

        //Loohy
        #region generateurs de maps
        public void mapAleaHerbe(int i_, int j_, int nombreDeMontagne_,
            int nombreDeForet_, int nombreDeBunker_, int nombreDeRivieres_)
        {
            int a1 = r.Next(100) % i_;
            int b1 = r.Next(100) % j_;
            int a2 = r.Next(100) % i_;
            int b2 = r.Next(100) % j_;
            longueur = i_;
            largeur = j_;
            map = new Tile[i_, j_];
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].altitude -= 10;
                }
            }
            for (int z = 0; z < nombreDeMontagne_; z++)
            {
                montagne(r.Next(100) % i_, r.Next(100) % j_);
            }
            #region sol(altitude)
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    if (map[p, q].altitude < 0)
                    {
                        map[p, q].altitude = 0;
                        map[p, q].E_Sol = e_Typedesol.mer;
                        map[p, q].estAccessible = false;
                    }
                    else
                    {
                        if (map[p, q].altitude < 8)
                        {
                            map[p, q].E_Sol = e_Typedesol.sable;
                        }
                    }
                }
            }
            #endregion
            for (int z = 0; z < nombreDeRivieres_; z++)
            {
                while (map[a1, b1].E_Sol == e_Typedesol.sable && map[a1, b1].altitude < 20)
                {
                    a1 = r.Next(100) % i_;
                    b1 = r.Next(100) % j_;
                }
                river(a1, b1);
                a1 = r.Next(100) % i_;
                b1 = r.Next(100) % j_;
            }
            for (int z = 0; z < nombreDeBunker_; z++)
            {
                a1 = r.Next(100) % i_;
                b1 = r.Next(100) % j_;
                a2 = r.Next(100) % i_;
                b2 = r.Next(100) % j_;
                if (bunker(a1, b1) && bunker(a2, b2))
                {
                    roadTo(a1, b1, a2, b2);
                }
            }
            for (int z = 0; z < nombreDeForet_; z++)
            {
                foret(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < r.Next(100) % 8; z++)
            {
                ruines(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q].Adapt(this, r.Next(100) / 10);
                }
            }
            viderVue();
        }
        public void mapAleaGlace(int i_, int j_, int nombreDeMontagne_,
            int nombreDeForet_, int nombreDeBunker_, int nombreDeRivieres_)
        {
            int a1 = r.Next(100) % i_;
            int b1 = r.Next(100) % j_;
            int a2 = r.Next(100) % i_;
            int b2 = r.Next(100) % j_;
            longueur = i_;
            largeur = j_;
            map = new Tile[i_, j_];
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].altitude -= 10;
                    map[p, q].E_Sol = e_Typedesol.neige;
                }
            }
            for (int z = 0; z < nombreDeMontagne_; z++)
            {
                montagne(r.Next(100) % i_, r.Next(100) % j_);
            }
            #region sol(altitude)
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    if (map[p, q].altitude < 0)
                    {
                        map[p, q].altitude = 0;
                        map[p, q].E_Sol = e_Typedesol.mer;
                        map[p, q].estAccessible = false;
                    }
                    else
                    {
                        if (map[p, q].altitude < 8)
                        {
                            map[p, q].altitude = 0;
                            map[p, q].E_Sol = e_Typedesol.banquise;
                        }
                    }
                }
            }
            #endregion
            for (int z = 0; z < nombreDeRivieres_; z++)
            {
                while (map[a1, b1].E_Sol == e_Typedesol.banquise && map[a1, b1].altitude < 20)
                {
                    a1 = r.Next(100) % i_;
                    b1 = r.Next(100) % j_;
                }
                river(a1, b1);
                a1 = r.Next(100) % i_;
                b1 = r.Next(100) % j_;
            }
            for (int z = 0; z < nombreDeBunker_; z++)
            {
                a1 = r.Next(100) % i_;
                b1 = r.Next(100) % j_;
                a2 = r.Next(100) % i_;
                b2 = r.Next(100) % j_;
                if (icebunker(a1, b1) && icebunker(a2, b2))
                {
                    roadTo(a1, b1, a2, b2);
                }
            }
            for (int z = 0; z < nombreDeForet_; z++)
            {
                foret(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < r.Next(100) % 8; z++)
            {
                ruines(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q].Adapt(this, r.Next(100) / 10);
                }
            }
            viderVue();
        }
        public void mapAleaFaceToFace(int i_, int j_, int nombreDeMontagne_, int nombreDeForet_, int nombreDeRivieres_)
        {
            int a1 = i_ / 4;
            int b1 = j_ / 4;
            int a2 = 3 * (i_ / 4);
            int b2 = 3 * (j_ / 4);
            int a3, b3;
            longueur = i_;
            largeur = j_;
            map = new Tile[i_, j_];
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].altitude -= 7;
                }
            }
            for (int z = 0; z < nombreDeMontagne_; z++)
            {
                montagne(r.Next(100) % i_, r.Next(100) % j_);
            }
            montagne(a1, b1);
            montagne(a2, b2);
            bunker(a1, b1);
            bunker(a2, b2);
            #region sol(altitude)
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    if (map[p, q].altitude < 0)
                    {
                        map[p, q].altitude = 0;
                        map[p, q].E_Sol = e_Typedesol.mer;
                        map[p, q].estAccessible = false;
                    }
                    else
                    {
                        if (map[p, q].altitude < 8)
                        {
                            map[p, q].E_Sol = e_Typedesol.sable;
                        }
                    }
                }
            }
            #endregion
            for (int z = 0; z < nombreDeRivieres_; z++)
            {
                while (map[a1, b1].E_Sol == e_Typedesol.sable && map[a1, b1].altitude < 20)
                {
                    a3 = r.Next(100) % i_;
                    b3 = r.Next(100) % j_;
                }
                river(a1, b1);
                a3 = r.Next(100) % i_;
                b3 = r.Next(100) % j_;
            }
            roadTo(a1, b1, a2, b2);
            for (int z = 0; z < nombreDeForet_; z++)
            {
                foret(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < 3; z++)
            {
                CampementFenrir(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < r.Next(100) % 8; z++)
            {
                ruines(r.Next(100) % i_, r.Next(100) % j_);
            }
            Adapt();
            viderVue();
        }
        public void mapAleaFaceToFaceGlace(int i_, int j_, int nombreDeMontagne_, int nombreDeForet_, int nombreDeRivieres_)
        {
            int a1 = i_ / 4;
            int b1 = j_ / 4;
            int a2 = 3 * (i_ / 4);
            int b2 = 3 * (j_ / 4);
            int a3, b3;
            longueur = i_;
            largeur = j_;
            map = new Tile[i_, j_];
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].altitude -= 7;
                    map[p, q].E_Sol = e_Typedesol.neige;
                }
            }
            for (int z = 0; z < nombreDeMontagne_; z++)
            {
                montagne(r.Next(100) % i_, r.Next(100) % j_);
            }
            montagne(a1, b1);
            montagne(a2, b2);
            #region sol(altitude)
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    if (map[p, q].altitude < 0)
                    {
                        map[p, q].altitude = 0;
                        map[p, q].E_Sol = e_Typedesol.mer;
                        map[p, q].estAccessible = false;
                    }
                    else
                    {
                        if (map[p, q].altitude < 8)
                        {
                            map[p, q].E_Sol = e_Typedesol.banquise;
                        }
                    }
                }
            }
            #endregion
            icebunker(a1, b1);
            icebunker(a2, b2);
            for (int z = 0; z < nombreDeRivieres_; z++)
            {
                while (map[a1, b1].E_Sol == e_Typedesol.banquise && map[a1, b1].altitude < 20)
                {
                    a3 = r.Next(100) % i_;
                    b3 = r.Next(100) % j_;
                }
                river(a1, b1);
                a3 = r.Next(100) % i_;
                b3 = r.Next(100) % j_;
            }
            roadTo(a1, b1, a2, b2);
            for (int z = 0; z < nombreDeForet_; z++)
            {
                foret(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < 3; z++)
            {
                VillagePingvin(r.Next(100) % i_, r.Next(100) % j_);
            }
            for (int z = 0; z < r.Next(100) % 8; z++)
            {
                ruines(r.Next(100) % i_, r.Next(100) % j_);
            }
            Adapt();
            viderVue();
        }
        public void mapAleaDesert(int i_, int j_)
        {
            longueur = i_;
            largeur = j_;
            List<Vector2> villes = new List<Vector2>();
            map = new Tile[i_, j_];
            for (int p = 0; p < i_; p++)
            {
                for (int q = 0; q < j_; q++)
                {
                    map[p, q] = new Tile(p, q);
                    map[p, q].E_Sol = e_Typedesol.desert;
                    map[p, q].altitude = r.Next(100) % 15;
                }
            }
            villes.Add(new Vector2(longueur / 4, largeur / 4));
            villes.Add(new Vector2((2 * longueur) / 4, largeur / 4));
            villes.Add(new Vector2((2 * longueur) / 4, (2 * largeur) / 4));
            villes.Add(new Vector2(longueur / 4, (2 * largeur) / 4));
            for (int z = 0; z < 5; z++)
            {
                villes.Add(new Vector2(r.Next(100) % longueur, r.Next(100) % largeur));
            }
            for (int k = 0; k < villes.Count; k++)
            {
                switch (r.Next(100) % 3)
                {
                    case 0:
                        bunker((int)villes[k].X, (int)villes[k].Y);
                        break;
                    default:
                        VillageKrissa((int)villes[k].X, (int)villes[k].Y);
                        break;
                }
                roadTo((int)villes[k].X, (int)villes[k].Y,
                    (int)villes[(k + 1) % villes.Count].X, (int)villes[(k + 1) % villes.Count].Y);
            }
            Adapt();
        }
        #endregion

        //Loohy
        public void Adapt()
        {
            for (int p = 0; p < longueur; p++)
            {
                for (int q = 0; q < largeur; q++)
                {
                    map[p, q].Adapt(this, r.Next(100) / 10);
                    map[p, q].UpdateLosange(camerax, cameray, direction);
                }
            }
        }

        //Loohy
        public void porteeEgal0()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].surbrillancePortee = 0;
                }
            }
        }

        //Loohy
        public void centrerSur(int i_, int j_)
        {
            camerax = -450 + 32 * i_ - 32 * j_;
            cameray = -450 + 16 * i_ + 16 * j_;
        }

        //Loohy
        public void viderChemin()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].poidsAcces = 100;
                    map[i, j].cheminValid = false;
                }
            }
        }
        //Loohy
        public void viderVue()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    switch (fog)
                    {
                        case e_brouillardDeGuerre.ToutVisible:
                            map[i, j].visible = true;
                            break;
                        default:
                            map[i, j].visible = false;
                            break;
                    }
                }
            }
        }
        //Loohy
        public void viderSurbrillance()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].estEnSurbrillance = false;
                    map[i, j].surbrillancePortee = 0;
                }
            }
        }
        //Loohy
        public void Aplatir()
        {
            for (int i = 0; i < longueur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    map[i, j].altitude = 0;
                }
            }
        }

        //Loohy
        public Vector2 getCaseFromMouseSansAltitude()
        {
            switch (direction)
            {
                case 0:
                    return new Vector2(Math.Max(0, Math.Min(longueur - 1, (Mouse.GetState().X - 32 + Mouse.GetState().Y * 2 - 64 + camerax + 2 * cameray) / 64 - 7)),
                        Math.Max(0, Math.Min(largeur - 1, (-Mouse.GetState().X + 32 + Mouse.GetState().Y * 2 - 64 - camerax + 2 * cameray) / 64 + 3)));
                case 1:
                    return new Vector2();
                case 2:
                    return new Vector2();
                default:
                    return new Vector2();
            }
            //Rectangle rect;
            //switch (direction)
            //{
            //    case 0://n
            //        rect = new Rectangle((i - j) * 32 - camerax_, (i + j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    case 1://o
            //        rect = new Rectangle((32 - j - i) * 32 - camerax_, (i + 32 - j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    case 2://s
            //        rect = new Rectangle((32 - i - 32 + j) * 32 - camerax_, (32 - i + 32 - j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    default://e
            //        rect = new Rectangle((j - 32 + i) * 32 - camerax_, (j + 32 - i) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //}
            //return rect;
        }
        public Vector2 getCaseFromMouseAvecAltitude()
        {
            switch (direction)
            {
                case 0:
                    return new Vector2((int)Math.Max(0, Math.Min(longueur - 1, (Mouse.GetState().X / Contents.pprc - 32 + (Mouse.GetState().Y * 2) / Contents.pprc - 64 + camerax + 2 * cameray) / 64-3)), (int)
                        Math.Max(0, Math.Min(largeur - 1, (-Mouse.GetState().X / Contents.pprc + 32 + (Mouse.GetState().Y * 2) / Contents.pprc - 64 - camerax + 2 * cameray) / 64)));
                case 1:
                    return new Vector2();
                case 2:
                    return new Vector2();
                default:
                    return new Vector2();
            }
            //Rectangle rect;
            //switch (direction)
            //{
            //    case 0://n
            //        rect = new Rectangle((i - j) * 32 - camerax_, (i + j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    case 1://o
            //        rect = new Rectangle((32 - j - i) * 32 - camerax_, (i + 32 - j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    case 2://s
            //        rect = new Rectangle((32 - i - 32 + j) * 32 - camerax_, (32 - i + 32 - j) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //    default://e
            //        rect = new Rectangle((j - 32 + i) * 32 - camerax_, (j + 32 - i) * 16 - altitude - cameray_, 64, 64);
            //        break;
            //}
            //return rect;
        }
    }
}
