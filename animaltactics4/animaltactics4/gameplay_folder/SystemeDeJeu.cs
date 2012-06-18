using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class SystemeDeJeu
    {
        public bool tresor_existe;
        public int tresor_i, tresor_j;

        public int tourencours;
        public float limiteDeTours, numeroDeTour;
        public List<Armee> listeDesJoueurs;
        bool clic, waitForFinDeTour;
        public e_modeAction mood;
        public e_typeDePartie conditionsDeVictoire;

        public SystemeDeJeu()
        {
            tourencours = 0;
            numeroDeTour = 1;
            listeDesJoueurs = new List<Armee>();
            waitForFinDeTour = false;
            mood = e_modeAction.Mouvement;
            conditionsDeVictoire = e_typeDePartie.Joute; // HO LA LA probleme resolu ? (Who said this ?)
            limiteDeTours = 0;
        }

        public void AddUnite(int armee_, TypeUnite typeUnite_, Pouvoir SHORYUKEN_, Aura aura_, string nom_, int force_, int dexterite_, int constitution_, int defense_,
            int esprit_, int chance_, int vitesse_, int[] portee_, bool[] typedAttaque_, int numeroImage, int mouvement, int ia_)
        {
            listeDesJoueurs[armee_].AddUnite(typeUnite_, SHORYUKEN_, aura_, nom_, force_, dexterite_, constitution_, defense_,
            esprit_, chance_, vitesse_, portee_, typedAttaque_, armee_, numeroImage, mouvement, ia_);
        }
        public void AddUnite(int armee_, e_classe classe_)
        {
            listeDesJoueurs[armee_].AddUnite(classe_);
        }
        public void AddUnite(int armee_, e_classe classe_, int ia_)
        {
            listeDesJoueurs[armee_].AddUnite(classe_, ia_);
        }

        //Loohy
        public void Afficher(MoteurGraphique loohy_)
        {
            foreach (Armee item in listeDesJoueurs)
            {
                item.Afficher(loohy_, this);
            }
        }

        public void Update(MoteurGraphique loohy_, /*Lecteur coldman_,*/ HUD hud_)
        {
            if (waitForFinDeTour)
            {
                FinDeTour(loohy_, /*coldman_,*/ hud_);
                if (waitForFinDeTour)
                {
                    listeDesJoueurs[tourencours].UpdateSansClicSelonIAouNon(loohy_, this);
                }
            }
            else
            {
                listeDesJoueurs[tourencours].UpdateSelonIAouNon(loohy_, this, ref mood, /*coldman_,*/ hud_);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && clic)
                {
                    FinDeTour(loohy_, /*coldman_,*/ hud_);
                    clic = false;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Enter))
                {
                    clic = true;
                }
            }
            if (conditionsDeVictoire == e_typeDePartie.Tresor)
            {
                UpdateTresor(loohy_, hud_);
            }
        }

        public void FinDeTour(MoteurGraphique moteurgraphique_, /*Lecteur coldman_,*/ HUD hud_)
        {
            numeroDeTour += 0.5f;
            //coldman_.Play(Lecteur.EffectKey.laser);
            bool vousAvezTousFini = true;
            foreach (Unite bob in listeDesJoueurs[tourencours].bataillon)
            {
                vousAvezTousFini = vousAvezTousFini && bob.fileDeMouvements.Count == 0;
            }
            if (vousAvezTousFini)
            {
                #region si limite de tours
                if (conditionsDeVictoire == e_typeDePartie.Colline)
                {
                    limiteDeTours -= 0.5f;
                    if (limiteDeTours > 0)
                    {
                        waitForFinDeTour = false;
                        listeDesJoueurs[tourencours].FindeTour();
                        tourencours = (tourencours + 1) % listeDesJoueurs.Count;
                        listeDesJoueurs[tourencours].reactiverIA();
                        hud_.time = 0;
                        hud_.DoAFlash(listeDesJoueurs[tourencours].couleur);
                        listeDesJoueurs[tourencours].soeurAnne(moteurgraphique_, this);
                        listeDesJoueurs[tourencours].appliquerVues(moteurgraphique_);
                        listeDesJoueurs[tourencours].soeurAnne(moteurgraphique_, this);
                        listeDesJoueurs[tourencours].auras(moteurgraphique_, this);
                        mood = e_modeAction.Mouvement;
                        if (moteurgraphique_.map[tresor_i, tresor_j].presence
                            && listeDesJoueurs[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                            bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].alive)
                        {
                            listeDesJoueurs[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].score +=
                                Math.Max(50 - (int)limiteDeTours, 0);
                        }
                    }
                    else
                    {
                        if (listeDesJoueurs[0].score > listeDesJoueurs[1].score)
                        {
                            victory(0, hud_);
                        }
                        else
                        {
                            victory(1, hud_);
                        }
                    }
                }
                #endregion
                #region sinon
                else
                {
                    waitForFinDeTour = false;
                    listeDesJoueurs[tourencours].FindeTour();
                    moteurgraphique_.viderChemin();
                    tourencours = (tourencours + 1) % listeDesJoueurs.Count;
                    listeDesJoueurs[tourencours].reactiverIA();
                    hud_.time = 0;
                    hud_.DoAFlash(listeDesJoueurs[tourencours].couleur);
                    listeDesJoueurs[tourencours].soeurAnne(moteurgraphique_, this);
                    listeDesJoueurs[tourencours].appliquerVues(moteurgraphique_);
                    listeDesJoueurs[tourencours].soeurAnne(moteurgraphique_, this);
                    listeDesJoueurs[tourencours].auras(moteurgraphique_, this);
                    mood = e_modeAction.Mouvement;
                }
                #endregion
            }
            else
            {
                waitForFinDeTour = true;
            }
        }

        //Loohy
        public void CheckPV(MoteurGraphique moteurgraphique_, HUD hud_)
        {
            foreach (Armee item in listeDesJoueurs)
            {
                item.checkPV(moteurgraphique_, this);
            }
            CheckVictoire(hud_);
        }

        //Loohy
        public void pop(MoteurGraphique moteurgraphique_)
        {
            foreach (Armee item in listeDesJoueurs)
            {
                item.pop(moteurgraphique_, this);
            }
        }

        //Loohy
        /*public void initialize(MoteurGraphique moteurgraphique_, e_typeDePartie conditionsDeVictoire_, HUD hud_, float limiteDeTours_ = 0)
        {
            numeroDeTour = 1;
            foreach (Armee item in listeDesJoueurs)
            {
                item.vider(moteurgraphique_.longueur, moteurgraphique_.largeur);
            }
            //TODO
            listeDesJoueurs[0].QG = new Vector2((int)(moteurgraphique_.longueur / 4), (int)(moteurgraphique_.largeur / 4));
            listeDesJoueurs[1].QG = new Vector2((int)((moteurgraphique_.longueur * 3) / 4), (int)((moteurgraphique_.largeur * 3) / 4));
            conditionsDeVictoire = conditionsDeVictoire_;
            #region Unites
            for (int m = 0; m < 2; m++)
            {
                switch (listeDesJoueurs[m].espece)
                {
                    case e_race.Fenrir:
                        AddUnite(m, e_classe.FenrirOkami, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirRailgun, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirDreadnought, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirWarBlade, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirWarBlade, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirTireur, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.FenrirEclaireur, listeDesJoueurs[m].difficulte);
                        break;
                    case e_race.Pandawan:
                        AddUnite(m, e_classe.PandawanSayan, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanNinja, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanSniper, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanBushi, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanYabusame, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanCharDragon, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PandawanSokei, listeDesJoueurs[m].difficulte);
                        break;
                    case e_race.Krissa:
                        AddUnite(m, e_classe.ChefKrissa, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Assassin, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Abomination, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Legionnaire, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Maraudeur, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Vermine, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.Vermine, listeDesJoueurs[m].difficulte);
                        break;
                    default:
                        AddUnite(m, e_classe.PingvinOdin, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinThor, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinWalkyrie, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinWalkyrie, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinLanceFlammes, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinLanceFlammes, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinChar, listeDesJoueurs[m].difficulte);
                        AddUnite(m, e_classe.PingvinUgin, listeDesJoueurs[m].difficulte);
                        break;
                }
            }
            #endregion
            pop(moteurgraphique_);
            hud_.Victory_ = false;
            hud_.time = 0;
            tresor_i = (moteurgraphique_.longueur / 2);
            tresor_j = (moteurgraphique_.largeur / 2);
            if (conditionsDeVictoire_ == e_typeDePartie.Tresor)
            {
                tresor_existe = true;
                moteurgraphique_.map[tresor_i, tresor_j].E_DecorArriere = e_Decorarriere.cratere;
                moteurgraphique_.Adapt();
            }
            else
            {
                tresor_existe = false;
            }
            if (conditionsDeVictoire_ == e_typeDePartie.Colline)
            {
                limiteDeTours = limiteDeTours_;
            }
            else
            {
                limiteDeTours = 0;
            }

            //voir les points
            //Classe kikoo = Classe.PingvinWalkyrie;
            //do
            //{
            //    armees[0].AddUnite(kikoo);
            //    kikoo++;
            //} while (kikoo != Classe.Overlord);
        }
        */
        //Loohy
        public void initializeWithListedArmies(List<string> nomDesArmees_, List<int> difficultes_, List<Color> couleurs_,
            MoteurGraphique moteurgraphique_,
            e_typeDePartie conditionsDeVictoire_, HUD hud_, float limiteDeTours_ = 0)
        {
            numeroDeTour = 1;
            //TODO
            //listeDesJoueurs[0].QG = new Vector2((int)(moteurgraphique_.longueur / 4), (int)(moteurgraphique_.largeur / 4));
            //listeDesJoueurs[1].QG = new Vector2((int)((moteurgraphique_.longueur * 3) / 4), (int)((moteurgraphique_.largeur * 3) / 4));
            listeDesJoueurs = new List<Armee>();
            for (int p = 0; p < nomDesArmees_.Count; p++)
            {
                listeDesJoueurs.Add(new Armee(p, e_race.Random, couleurs_[p], moteurgraphique_.longueur, moteurgraphique_.largeur));
                listeDesJoueurs[p].ConvertFromList(Divers.obtenirList(nomDesArmees_[p]), difficultes_[p]);
            }
            conditionsDeVictoire = conditionsDeVictoire_;
            pop(moteurgraphique_);
            hud_.Victory_ = false;
            hud_.time = 0;
            tresor_i = (moteurgraphique_.longueur / 2);
            tresor_j = (moteurgraphique_.largeur / 2);
            if (conditionsDeVictoire_ == e_typeDePartie.Tresor)
            {
                tresor_existe = true;
                moteurgraphique_.map[tresor_i, tresor_j].E_DecorArriere = e_Decorarriere.cratere;
                moteurgraphique_.Adapt();
            }
            else
            {
                tresor_existe = false;
            }
            if (conditionsDeVictoire_ == e_typeDePartie.Colline)
            {
                limiteDeTours = limiteDeTours_;
                moteurgraphique_.map[moteurgraphique_.longueur / 2, moteurgraphique_.largeur / 2].
                    E_DecorArriere = e_Decorarriere.bunker;
                moteurgraphique_.map[moteurgraphique_.longueur / 2, moteurgraphique_.largeur / 2].E_DecorAvant
                    = e_Decoravant.bunker;
                moteurgraphique_.Adapt();
            }
            else
            {
                limiteDeTours = 0;
            }

            //voir les points
            //Classe kikoo = Classe.PingvinWalkyrie;
            //do
            //{
            //    armees[0].AddUnite(kikoo);
            //    kikoo++;
            //} while (kikoo != Classe.Overlord);
        }

        //Loohy
        public void finDePartie(Color color_, HUD hud_)
        {
            hud_.DoAFlash(color_);
        }

        //Loohy
        public void CheckVictoire(HUD hud_)
        {
            switch (conditionsDeVictoire)
            {
                case e_typeDePartie.Echiquier:
                    #region Joute/Hero
                    for (int p = 0; p < listeDesJoueurs.Count; p++)
                    {
                        bool een = true;
                        for (int k = 0; k < listeDesJoueurs.Count; k++)
                        {
                            if (k != p)
                            {
                                een = een && !listeDesJoueurs[k].atLeastOneHeroAlive;
                            }
                            if (een)
                            {
                                victory(p, hud_);
                            }
                        }
                    }
                    #endregion
                    break;
                case e_typeDePartie.Joute:
                    #region Joute
                    for (int p = 0; p < listeDesJoueurs.Count; p++)
                    {
                        bool een = true;
                        for (int k = 0; k < listeDesJoueurs.Count; k++)
                        {
                            if (k != p)
                            {
                                een = een && !listeDesJoueurs[k].atLeastOneAlive;
                            }
                            if (een)
                            {
                                victory(p, hud_);
                            }
                        }
                    }
                    #endregion
                    break;
                case e_typeDePartie.Tresor://TODO
                    #region Joute
                    for (int p = 0; p < listeDesJoueurs.Count; p++)
                    {
                        bool een = true;
                        for (int k = 0; k < listeDesJoueurs.Count; k++)
                        {
                            if (k != p)
                            {
                                een = een && !listeDesJoueurs[k].atLeastOneAlive;
                            }
                            if (een)
                            {
                                victory(p, hud_);
                            }
                        }
                    }
                    #endregion
                    for (int g = 0; g < listeDesJoueurs.Count; g++)
                    {
                        if ((int)listeDesJoueurs[g].QG.X == tresor_i && (int)listeDesJoueurs[g].QG.Y == tresor_j)
                        {
                            victory(g, hud_);
                        }
                    }
                    break;
                case e_typeDePartie.Colline://TODO
                    #region Joute
                    for (int p = 0; p < listeDesJoueurs.Count; p++)
                    {
                        bool een = true;
                        for (int k = 0; k < listeDesJoueurs.Count; k++)
                        {
                            if (k != p)
                            {
                                een = een && !listeDesJoueurs[k].atLeastOneAlive;
                            }
                            if (een)
                            {
                                victory(p, hud_);
                            }
                        }
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        //Loohy
        public void victory(int armeeVictorieuse, HUD hud_)
        {
            hud_.victory(listeDesJoueurs[armeeVictorieuse].couleur, listeDesJoueurs[armeeVictorieuse].espece);
        }
        public void egalite(HUD hud_)
        {
            hud_.victory(Color.Black, e_race.Random);
        }

        //Loohy
        public void UpdateTresor(MoteurGraphique moteurgraphique_, HUD hud_)
        {
            if (moteurgraphique_.map[tresor_i, tresor_j].presence &&
                listeDesJoueurs[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                    bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].alive)
            {
                listeDesJoueurs[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                    bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].porteTresor = true;
            }
            for (int h = 0; h < 2; h++)
            {
                foreach (Unite mafe in listeDesJoueurs[h].bataillon)
                {
                    if (mafe.porteTresor)
                    {
                        tresor_i = mafe.i;
                        tresor_j = mafe.j;
                    }
                }
                if (tresor_i == listeDesJoueurs[h].QG.X && tresor_j == listeDesJoueurs[h].QG.Y)
                {
                    victory(h, hud_);
                }
            }
        }

        //Loohy
        public void rotation()
        {
            foreach (Armee item in listeDesJoueurs)
            {
                item.rotation();
            }
        }
    }
}
