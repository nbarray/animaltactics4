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
        public Armee[] armees;
        bool clic, waitForFinDeTour;
        public e_modeAction mood;
        public e_typeDePartie conditionsDeVictoire;

        public SystemeDeJeu(e_race race1_, e_race race2_, Color couleur1_, Color couleur2_, int sizeX_, int sizeY_)
        {
            tourencours = 0;
            numeroDeTour = 1;
            armees = new Armee[2];
            armees[0] = new Armee(0, race1_, couleur1_, sizeX_, sizeY_);
            armees[1] = new Armee(1, race2_, couleur2_, sizeX_, sizeY_);
            waitForFinDeTour = false;
            mood = e_modeAction.Mouvement;
            conditionsDeVictoire = e_typeDePartie.Joute; // HO LA LA probleme resolu ?
            limiteDeTours = 0;
        }

        public void AddUnite(int armee_, TypeUnite typeUnite_, Pouvoir SHORYUKEN_, Aura aura_, string nom_, int force_, int dexterite_, int constitution_, int defense_,
            int esprit_, int chance_, int vitesse_, int[] portee_, bool[] typedAttaque_, int numeroImage, int mouvement, int ia_)
        {
            armees[armee_].AddUnite(typeUnite_, SHORYUKEN_, aura_, nom_, force_, dexterite_, constitution_, defense_,
            esprit_, chance_, vitesse_, portee_, typedAttaque_, armee_, numeroImage, mouvement, ia_);
        }
        public void AddUnite(int armee_, e_classe classe_)
        {
            armees[armee_].AddUnite(classe_);
        }
        public void AddUnite(int armee_, e_classe classe_, int ia_)
        {
            armees[armee_].AddUnite(classe_, ia_);
        }

        public void Afficher(MoteurGraphique loohy_)
        {
            armees[1].Afficher(loohy_, this);
            armees[0].Afficher(loohy_, this);
        }

        public void Update(MoteurGraphique loohy_, /*Lecteur coldman_,*/ HUD hud_)
        {
            if (waitForFinDeTour)
            {
                FinDeTour(loohy_, /*coldman_,*/ hud_);
                if (waitForFinDeTour)
                {
                    armees[tourencours].UpdateSansClicSelonIAouNon(loohy_, this);
                }
            }
            else
            {
                armees[tourencours].UpdateSelonIAouNon(loohy_, this, ref mood, /*coldman_,*/ hud_);
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
            foreach (Unite bob in armees[tourencours].bataillon)
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
                        armees[tourencours].FindeTour();
                        tourencours = (tourencours + 1) % 2;
                        armees[tourencours].reactiverIA();
                        hud_.time = 0;
                        hud_.DoAFlash(armees[tourencours].couleur);
                        armees[tourencours].soeurAnne(moteurgraphique_, this);
                        armees[tourencours].appliquerVues(moteurgraphique_);
                        armees[tourencours].soeurAnne(moteurgraphique_, this);
                        armees[tourencours].auras(moteurgraphique_, this);
                        mood = e_modeAction.Mouvement;
                        if (moteurgraphique_.map[tresor_i, tresor_j].presence
                            && armees[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                            bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].alive)
                        {
                            armees[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].score +=
                                Math.Max(50 - (int)limiteDeTours, 0);
                        }
                    }
                    else
                    {
                        if (armees[0].score > armees[1].score)
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
                    armees[tourencours].FindeTour();
                    moteurgraphique_.viderChemin();
                    tourencours = (tourencours + 1) % 2;
                    armees[tourencours].reactiverIA();
                    hud_.time = 0;
                    hud_.DoAFlash(armees[tourencours].couleur);
                    armees[tourencours].soeurAnne(moteurgraphique_, this);
                    armees[tourencours].appliquerVues(moteurgraphique_);
                    armees[tourencours].soeurAnne(moteurgraphique_, this);
                    armees[tourencours].auras(moteurgraphique_, this);
                    mood = e_modeAction.Mouvement;
                }
                #endregion
            }
            else
            {
                waitForFinDeTour = true;
            }
        }

        public void CheckPV(MoteurGraphique moteurgraphique_, HUD hud_)
        {
            armees[0].checkPV(moteurgraphique_, this);
            armees[1].checkPV(moteurgraphique_, this);
            CheckVictoire(hud_);
        }

        public void pop(MoteurGraphique moteurgraphique_)
        {
            armees[0].pop(moteurgraphique_, this);
            armees[1].pop(moteurgraphique_, this);
        }

        public void initialize(MoteurGraphique moteurgraphique_, e_typeDePartie conditionsDeVictoire_, HUD hud_, float limiteDeTours_ = 0)
        {
            numeroDeTour = 1;
            armees[0].vider(moteurgraphique_.longueur, moteurgraphique_.largeur);
            armees[1].vider(moteurgraphique_.longueur, moteurgraphique_.largeur);
            armees[0].QG = new Vector2((int)(moteurgraphique_.longueur / 4), (int)(moteurgraphique_.largeur / 4));
            armees[1].QG = new Vector2((int)((moteurgraphique_.longueur * 3) / 4), (int)((moteurgraphique_.largeur * 3) / 4));
            conditionsDeVictoire = conditionsDeVictoire_;
            #region Unites
            for (int m = 0; m < 2; m++)
            {
                switch (armees[m].espece)
                {
                    case e_race.Fenrir:
                        AddUnite(m, e_classe.FenrirOkami, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirRailgun, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirDreadnought, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirWarBlade, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirWarBlade, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirTireur, armees[m].difficulte);
                        AddUnite(m, e_classe.FenrirEclaireur, armees[m].difficulte);
                        break;
                    case e_race.Pandawan:
                        AddUnite(m, e_classe.PandawanSayan, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanNinja, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanSniper, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanBushi, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanYabusame, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanCharDragon, armees[m].difficulte);
                        AddUnite(m, e_classe.PandawanSokei, armees[m].difficulte);
                        break;
                    case e_race.Krissa:
                        AddUnite(m, e_classe.ChefKrissa, armees[m].difficulte);
                        AddUnite(m, e_classe.Assassin, armees[m].difficulte);
                        AddUnite(m, e_classe.Abomination, armees[m].difficulte);
                        AddUnite(m, e_classe.Legionnaire, armees[m].difficulte);
                        AddUnite(m, e_classe.Maraudeur, armees[m].difficulte);
                        AddUnite(m, e_classe.Vermine, armees[m].difficulte);
                        AddUnite(m, e_classe.Vermine, armees[m].difficulte);
                        break;
                    default:
                        AddUnite(m, e_classe.PingvinOdin, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinThor, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinWalkyrie, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinWalkyrie, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinLanceFlammes, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinLanceFlammes, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinChar, armees[m].difficulte);
                        AddUnite(m, e_classe.PingvinUgin, armees[m].difficulte);
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
        public void initializeWithListedArmies(MoteurGraphique moteurgraphique_,
            e_typeDePartie conditionsDeVictoire_, HUD hud_, float limiteDeTours_ = 0)
        {
            numeroDeTour = 1;
            armees[0].QG = new Vector2((int)(moteurgraphique_.longueur / 4), (int)(moteurgraphique_.largeur / 4));
            armees[1].QG = new Vector2((int)((moteurgraphique_.longueur * 3) / 4), (int)((moteurgraphique_.largeur * 3) / 4));
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

        public void finDePartie(Color color_, HUD hud_)
        {
            hud_.DoAFlash(color_);
        }

        public void CheckVictoire(HUD hud_)
        {
            switch (conditionsDeVictoire)
            {
                case e_typeDePartie.Echiquier:
                    #region Joute
                    if (!armees[0].atLeastOneHeroAlive)
                    {
                        victory(1, hud_);
                    }
                    if (!armees[1].atLeastOneHeroAlive)
                    {
                        victory(0, hud_);
                    }
                    #endregion
                    break;
                case e_typeDePartie.Joute:
                    #region Joute
                    if (!armees[0].atLeastOneAlive)
                    {
                        victory(1, hud_);
                    }
                    if (!armees[1].atLeastOneAlive)
                    {
                        victory(0, hud_);
                    }
                    #endregion
                    break;
                case e_typeDePartie.Tresor://TODO
                    #region Joute
                    if (!armees[0].atLeastOneAlive)
                    {
                        victory(1, hud_);
                    }
                    if (!armees[1].atLeastOneAlive)
                    {
                        victory(0, hud_);
                    }
                    #endregion
                    for (int g = 0; g < 2; g++)
                    {
                        if ((int)armees[g].QG.X == tresor_i && (int)armees[g].QG.Y == tresor_j)
                        {
                            victory(g, hud_);
                        }
                    }
                    break;
                case e_typeDePartie.Colline://TODO
                    #region Joute
                    if (!armees[0].atLeastOneAlive)
                    {
                        victory(1, hud_);
                    }
                    if (!armees[1].atLeastOneAlive)
                    {
                        victory(0, hud_);
                    }
                    #endregion
                    break;
                default:
                    break;
            }
        }

        public void victory(int armeeVictorieuse, HUD hud_)
        {
            hud_.victory(armees[armeeVictorieuse].couleur, armees[armeeVictorieuse].espece);
        }
        public void egalite(HUD hud_)
        {
            hud_.victory(Color.Black, e_race.Random);
        }

        public void UpdateTresor(MoteurGraphique moteurgraphique_, HUD hud_)
        {
            if (moteurgraphique_.map[tresor_i, tresor_j].presence && armees[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                    bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].alive)
            {
                armees[moteurgraphique_.map[tresor_i, tresor_j].pointeurArmee].
                    bataillon[moteurgraphique_.map[tresor_i, tresor_j].pointeurUnite].porteTresor = true;
            }
            for (int h = 0; h < 2; h++)
            {
                foreach (Unite mafe in armees[h].bataillon)
                {
                    if (mafe.porteTresor)
                    {
                        tresor_i = mafe.i;
                        tresor_j = mafe.j;
                    }
                }
                if (tresor_i == armees[h].QG.X && tresor_j == armees[h].QG.Y)
                {
                    victory(h, hud_);
                }
            }
        }

        public void rotation()
        {
            foreach (Armee item in armees)
            {
                item.rotation();
            }
        }
    }
}
