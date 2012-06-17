using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Armee
    {
        public List<Unite> bataillon;
        public Vector2 QG;

        public e_race espece;
        public Color couleur;
        public int effectif, uniteselect;
        public int numeroarmee, score;
        bool clic;
        public bool atLeastOneAlive, atLeastOneHeroAlive;
        bool IA;
        public int difficulte;
        public bool[,] casesVisitees;

        public Armee(int numeroarmee_, e_race espece_, Color couleur_, int sizeX_, int sizeY_)
        {
            QG = new Vector2(0, 0);
            IA = false;
            score = 1;
            numeroarmee = numeroarmee_;
            if (espece_ == e_race.Random)
            {
                Random r = new Random();
                if (numeroarmee == 0)
                {
                    #region 0
                    switch (r.Next(100) % 4)
                    {
                        case 1://Panda
                            couleur = Color.Red;
                            espece = e_race.Pandawan;
                            break;
                        case 2://Fenrir
                            couleur = Color.Blue;
                            espece = e_race.Fenrir;
                            break;
                        case 3://Krissa
                            couleur = Color.Green;
                            espece = e_race.Pandawan;
                            break;
                        default://Pingvin
                            couleur = Color.Yellow;
                            espece = e_race.Pingvin;
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region 1
                    switch (r.Next(100) % 4)
                    {
                        case 1://Panda
                            couleur = Color.Pink;
                            espece = e_race.Pandawan;
                            break;
                        case 2://Fenrir
                            couleur = Color.Purple;
                            espece = e_race.Fenrir;
                            break;
                        case 3://Krissa
                            couleur = Color.ForestGreen;
                            espece = e_race.Pandawan;
                            break;
                        default://Pingvin
                            couleur = Color.Orange;
                            espece = e_race.Pingvin;
                            break;
                    }
                    #endregion
                }
            }
            else
            {
                couleur = couleur_;
                espece = espece_;
            }
            effectif = 0;
            uniteselect = 0;
            bataillon = new List<Unite>();
            atLeastOneAlive = false;
            atLeastOneHeroAlive = false;
            casesVisitees = new bool[sizeX_, sizeY_];
            for (int i = 0; i < sizeX_; i++)
            {
                for (int j = 0; j < sizeY_; j++)
                {
                    casesVisitees[i, j] = false;
                }
            }
        }
        public Armee(int numeroarmee_, e_race espece_, Color couleur_, int sizeX_, int sizeY_, int difficulte_)
        {
            QG = new Vector2(0, 0);
            IA = true;
            score = 0;
            difficulte = difficulte_;
            numeroarmee = numeroarmee_;
            if (espece_ == e_race.Random)
            {
                Random r = new Random();
                if (numeroarmee == 0)
                {
                    #region 0
                    switch (r.Next(100) % 4)
                    {
                        case 1://Panda
                            couleur = Color.Red;
                            espece = e_race.Pandawan;
                            break;
                        case 2://Fenrir
                            couleur = Color.Blue;
                            espece = e_race.Fenrir;
                            break;
                        case 3://Krissa
                            couleur = Color.Green;
                            espece = e_race.Krissa;
                            break;
                        default://Pingvin
                            couleur = Color.Yellow;
                            espece = e_race.Pingvin;
                            break;
                    }
                    #endregion
                }
                else
                {
                    #region 1
                    switch (r.Next(100) % 4)
                    {
                        case 1://Panda
                            couleur = Color.Pink;
                            espece = e_race.Pandawan;
                            break;
                        case 2://Fenrir
                            couleur = Color.Purple;
                            espece = e_race.Fenrir;
                            break;
                        case 3://Krissa
                            couleur = Color.ForestGreen;
                            espece = e_race.Krissa;
                            break;
                        default://Pingvin
                            couleur = Color.Orange;
                            espece = e_race.Pingvin;
                            break;
                    }
                    #endregion
                }
            }
            else
            {
                couleur = couleur_;
                espece = espece_;
            }
            effectif = 0;
            uniteselect = 0;
            bataillon = new List<Unite>();
            atLeastOneAlive = false;
            casesVisitees = new bool[sizeX_, sizeY_];
            for (int i = 0; i < sizeX_; i++)
            {
                for (int j = 0; j < sizeY_; j++)
                {
                    casesVisitees[i, j] = false;
                }
            }
        }

        public void AddUnite(TypeUnite typeUnite_, Pouvoir SHORYUKEN_, Aura aura_, string nom_, int force_, int dexterite_, int constitution_,
            int defense_, int esprit_, int chance_, int vitesse_, int[] portee_, bool[] typedAttaque_, int numeroArmee_,
            int numeroImage_, int mouvement_, int ia_)
        {
            bataillon.Add(new Unite(typeUnite_, SHORYUKEN_, aura_, nom_, force_, dexterite_, constitution_, defense_,
            esprit_, chance_, vitesse_, portee_, typedAttaque_, effectif, numeroArmee_, mouvement_, ia_));
            effectif++;
            atLeastOneAlive = true;
            if (typeUnite_ == TypeUnite.Heros)
            {
                atLeastOneHeroAlive = true;
            }
        }
        public void AddUnite(e_classe classe_, int ia_ = 0)
        {
            int[] portee = new int[7];
            bool[] typedAttaque = new bool[7];
            for (int i = 0; i < 7; i++)
            {
                portee[i] = 0;
                typedAttaque[i] = true;//attaque physique
            }
            switch (classe_)
            {
                #region Pingvin
                case e_classe.PingvinWalkyrie:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 12, 10, 12, 13, 10, 12, 13, portee, typedAttaque,
                        this.numeroarmee, 29, 8, ia_);
                    break;
                case e_classe.PingvinLanceFlammes:
                    portee[1] = 10;
                    portee[2] = 7;
                    portee[3] = 4;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 9, 13, 7, 7, 8, 7, 10, portee, typedAttaque,
                        this.numeroarmee, 30, 8, ia_);
                    break;
                case e_classe.PingvinChar:
                    portee[1] = 2;
                    portee[2] = 4;
                    portee[3] = 6;
                    portee[4] = 8;
                    portee[5] = 6;
                    portee[6] = 4;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 15, 5, 12, 15, 5, 7, 5, portee, typedAttaque,
                        this.numeroarmee, 31, 9, ia_);
                    break;
                case e_classe.PingvinUgin:
                    portee[1] = 10;
                    typedAttaque[1] = false;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 5, 11, 10, 10, 12, 8, 10, portee, typedAttaque,
                        this.numeroarmee, 35, 8, ia_);
                    break;
                case e_classe.PingvinBolter:
                    portee[1] = 3;
                    portee[2] = 6;
                    portee[3] = 10;
                    portee[4] = 6;
                    portee[5] = 3;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 10, 12, 8, 6, 6, 6, 12, portee, typedAttaque,
                        this.numeroarmee, 33, 8, ia_);
                    break;
                case e_classe.PingvinBerserker:
                    portee[1] = 10;
                    typedAttaque[1] = false;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PingvinRage, e_typeDePouvoir.Boost, new List<int> { 0 },
                        true, 0, 0, 10, false), null,
                        Divers.getName(classe_), 15, 12, 15, 9, 9, 8, 15, portee, typedAttaque,
                        this.numeroarmee, 32, 10, ia_);
                    break;
                case e_classe.PingvinMugin:
                    portee[1] = 2;
                    portee[2] = 5;
                    portee[3] = 8;
                    portee[4] = 10;
                    portee[5] = 8;
                    portee[6] = 5;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PingvinSoin, e_typeDePouvoir.Soin, new List<int> { 1 },
                        true, 0, 0, 10, false), null,
                        Divers.getName(classe_), 12, 11, 10, 7, 13, 12, 7, portee, typedAttaque,
                        this.numeroarmee, 36, 7, ia_);
                    break;
                case e_classe.PingvinThor:
                    portee[1] = 10;
                    portee[2] = 5;
                    portee[3] = 5;
                    portee[4] = 5;
                    typedAttaque[2] = false;
                    typedAttaque[3] = false;
                    typedAttaque[4] = false;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PingvinThor, e_typeDePouvoir.Degat, new List<int> { 6, 8, 10, 12 },
                        true, 0, 0, 10, false), null,
                        Divers.getName(classe_), 14, 12, 13, 13, 12, 12, 15, portee, typedAttaque,
                        this.numeroarmee, 37, 9, ia_);
                    break;
                case e_classe.PingvinOdin:
                    portee[1] = 10;
                    portee[2] = 6;
                    portee[3] = 6;
                    typedAttaque[1] = false;
                    AddUnite(TypeUnite.Heros, null, new Aura(Divers.getName(classe_), TypedAura.BoostArmure, 10), Divers.getName(classe_), 17, 12, 18, 20, 12, 14, 11, portee, typedAttaque,
                        this.numeroarmee, 34, 9, ia_);
                    break;
                #endregion
                #region Fenrir
                case e_classe.FenrirWarBlade:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 15, 8, 12, 13, 5, 11, 9, portee, typedAttaque,
                        this.numeroarmee, 42, 8, ia_);
                    break;
                case e_classe.FenrirPsyker:
                    portee[1] = 8;
                    portee[2] = 6;
                    portee[3] = 4;
                    typedAttaque[1] = false;
                    typedAttaque[2] = false;
                    typedAttaque[3] = false;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 6, 12, 10, 8, 16, 13, 9, portee, typedAttaque,
                        this.numeroarmee, 43, 8, ia_);
                    break;
                case e_classe.FenrirTireur:
                    portee[1] = 4;
                    portee[2] = 7;
                    portee[3] = 9;
                    portee[4] = 7;
                    portee[5] = 5;
                    portee[6] = 3;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 12, 11, 9, 9, 8, 11, 12, portee, typedAttaque,
                        this.numeroarmee, 44, 8, ia_);
                    break;
                case e_classe.FenrirBouclier:
                    portee[1] = 9;
                    portee[2] = 5;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 13, 7, 13, 15, 11, 10, 8, portee, typedAttaque,
                        this.numeroarmee, 49, 8, ia_);
                    break;
                case e_classe.FenrirEclaireur:
                    portee[1] = 8;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 12, 13, 8, 7, 8, 14, 12, portee, typedAttaque,
                        this.numeroarmee, 47, 8, ia_);
                    break;
                case e_classe.FenrirDreadnought:
                    portee[1] = 8;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.FenrirMissiles, e_typeDePouvoir.Degat, new List<int> { 3, 4, 5, 6 },
                        true, 0, 0, 10, false), null,
                        Divers.getName(classe_), 18, 6, 16, 18, 12, 13, 6, portee, typedAttaque,
                        this.numeroarmee, 45, 8, ia_);
                    break;
                case e_classe.FenrirWarlord:
                    portee[1] = 10;
                    portee[2] = 8;
                    portee[3] = 8;
                    typedAttaque[3] = false;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.FenrirBoost, e_typeDePouvoir.Boost, new List<int> { 1, 2 },
                        true, 0, 0, 10, false), null,
                        Divers.getName(classe_), 14, 10, 14, 12, 13, 11, 10, portee, typedAttaque,
                        this.numeroarmee, 50, 8, ia_);
                    break;
                case e_classe.FenrirRailgun:
                    portee[1] = 8;
                    portee[2] = 9;
                    portee[3] = 9;
                    portee[4] = 9;
                    typedAttaque[1] = false;
                    typedAttaque[2] = false;
                    typedAttaque[3] = false;
                    typedAttaque[4] = false;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.FenrirRailgun, e_typeDePouvoir.Degat, new List<int> { 7, 8, 9, 10 }
                        , true, 0, 0, 10, true), null,
                        Divers.getName(classe_), 7, 15, 12, 12, 17, 12, 11, portee, typedAttaque,
                        this.numeroarmee, 48, 8, ia_);
                    break;
                case e_classe.FenrirOkami:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Heros, null, new Aura("SHEEP POWAA !!", TypedAura.BoostAttaque, 10), Divers.getName(classe_), 18, 17, 17, 15, 14, 16, 15, portee, typedAttaque,
                        this.numeroarmee, 46, 8, ia_);
                    break;
                #endregion
                #region Pandawan
                case e_classe.PandawanYabusame:
                    portee[1] = 3;
                    portee[2] = 5;
                    portee[3] = 7;
                    portee[4] = 10;
                    portee[5] = 7;
                    portee[6] = 5;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 12, 10, 12, 10, 8, 12, 8, portee, typedAttaque,
                        this.numeroarmee, 56, 8, ia_);
                    break;
                case e_classe.PandawanBushi:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 14, 10, 14, 12, 7, 13, 9, portee, typedAttaque,
                        this.numeroarmee, 55, 8, ia_);
                    break;
                case e_classe.PandawanCharDragon:
                    portee[1] = 9;
                    portee[2] = 4;
                    portee[3] = 9;
                    typedAttaque[2] = false;
                    typedAttaque[3] = false;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 14, 10, 13, 15, 6, 11, 8, portee, typedAttaque,
                        this.numeroarmee, 58, 8, ia_);
                    break;
                case e_classe.PandawanMoine:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PandaSceau, e_typeDePouvoir.Soin, new List<int> { 1, 2, 3 },
                        false, 0, 0, 10, false), null,
                        Divers.getName(classe_), 10, 10, 14, 8, 16, 12, 8, portee, typedAttaque,
                        this.numeroarmee, 57, 8, ia_);
                    break;
                case e_classe.PandawanMerco:
                    portee[1] = 3;
                    portee[2] = 6;
                    portee[3] = 10;
                    portee[4] = 6;
                    portee[5] = 3;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 10, 10, 10, 8, 7, 12, 8, portee, typedAttaque,
                        this.numeroarmee, 63, 8, ia_);
                    break;
                case e_classe.PandawanSokei:
                    portee[1] = 10;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 10, 10, 12, 11, 5, 10, 8, portee, typedAttaque,
                        this.numeroarmee, 60, 8, ia_);
                    break;
                case e_classe.PandawanNinja:
                    portee[1] = 10;
                    portee[2] = 7;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PandaNinja, e_typeDePouvoir.Boost, new List<int> { 0 },
                        true, 12, 0, 0, false), null,
                        Divers.getName(classe_), 13, 10, 10, 10, 13, 15, 9, portee, typedAttaque,
                        this.numeroarmee, 59, 8, ia_);
                    break;
                case e_classe.PandawanSniper:
                    portee[1] = 2;
                    portee[4] = 7;
                    portee[5] = 9;
                    portee[6] = 8;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.PandaSniper, e_typeDePouvoir.Degat, new List<int> { 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
                        true, 5, 0, 15, true), null,
                        Divers.getName(classe_), 15, 10, 11, 8, 12, 17, 9, portee, typedAttaque,
                        this.numeroarmee, 62, 8, ia_);
                    break;
                case e_classe.PandawanSayan:
                    portee[1] = 8;
                    typedAttaque[1] = false;
                    AddUnite(TypeUnite.Heros, null, new Aura("PANDAA", TypedAura.BoostCoupCritique, 15), Divers.getName(classe_), 20, 15, 20, 16, 12, 20, 8, portee, typedAttaque,
                        this.numeroarmee, 61, 8, ia_);
                    break;
                #endregion
                #region Krissa
                case e_classe.KrissaChef:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 13, 12, 6, 6, 9, 10, 14, portee, typedAttaque,
                        this.numeroarmee, 68, 8, ia_);
                    break;
                case e_classe.KrissaAssassin:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.Krissa2, e_typeDePouvoir.Degat, new List<int> { 1 },
                        true, 0, 0, 0, false), null, Divers.getName(classe_), 7, 14, 6, 7, 14, 12, 13, portee, typedAttaque,
                        this.numeroarmee, 69, 8, ia_);
                    break;
                case e_classe.KrissaLegionnaire:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.Krissa2, e_typeDePouvoir.Degat, new List<int> { 1 },
                        true, 0, 0, 0, false), null, Divers.getName(classe_), 12, 11, 8, 12, 10, 11, 11, portee, typedAttaque,
                        this.numeroarmee, 70, 8, ia_);
                    break;
                case e_classe.KrissaGeolier:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Elite, new Pouvoir(e_pouvoir.Krissa1, e_typeDePouvoir.Degat, new List<int> { 1 },
                        true, 0, 0, 0, false), null, Divers.getName(classe_), 16, 14, 5, 4, 7, 13, 12, portee, typedAttaque,
                        this.numeroarmee, 57, 8, ia_);
                    break;
                case e_classe.KrissaMaraudeur:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Base, null, null, Divers.getName(classe_), 8, 16, 6, 7, 7, 14, 15, portee, typedAttaque,
                        this.numeroarmee, 72, 8, ia_);
                    break;
                case e_classe.KrissaVermine:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Base, null, null,
                        Divers.getName(classe_), 11, 15, 10, 8, 14, 15, 13, portee, typedAttaque,
                        this.numeroarmee, 73, 8, ia_);
                    break;
                case e_classe.KrissaAbomination:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Base, null, null,
                        Divers.getName(classe_), 15, 16, 7, 10, 13, 14, 9, portee, typedAttaque,
                        this.numeroarmee, 74, 8, ia_);
                    break;
                case e_classe.Krissa8:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Base, null, null,
                        Divers.getName(classe_), 13, 13, 8, 6, 11, 17, 14, portee, typedAttaque,
                        this.numeroarmee, 57, 8, ia_);
                    break;
                case e_classe.Krissa9:
                    portee[1] = 9;
                    AddUnite(TypeUnite.Heros, null, new Aura("ALVINCODAAA", TypedAura.BoostEsquive, 15), Divers.getName(classe_), 20, 15, 10, 10, 15, 18, 17, portee, typedAttaque,
                        this.numeroarmee, 57, 8, ia_);
                    break;
                #endregion
                #region Divers
                case e_classe.Overlord:
                    portee[1] = 10;
                    portee[2] = 10;
                    portee[3] = 10;
                    portee[4] = 10;
                    AddUnite(TypeUnite.Overlord, null, new Aura("MEGUSTA", TypedAura.BoostArmure, 99), Divers.getName(classe_), 99, 99, 99, 99, 99, 99, 99, portee, typedAttaque,
                        this.numeroarmee, 42, 8, ia_);
                    break;
                #endregion
                default:
                    break;
            }
        }

        public void Afficher(MoteurGraphique loohy_, SystemeDeJeu gameplay_)
        {
            for (int i = 0; i < effectif; i++)
            {
                if (bataillon[i].alive)
                {
                    bataillon[i].Afficher(loohy_.map[bataillon[i].i, bataillon[i].j], gameplay_);
                }
            }
        }

        public void Update(MoteurGraphique loohy_, SystemeDeJeu gameplay_, ref e_modeAction mood_, /*Lecteur coldman_,*/ HUD hud_)
        {
            if (bataillon[uniteselect].fileDeMouvements.Count == 0)
            {
                switch (mood_)
                {
                    case e_modeAction.Attaque:
                        bataillon[uniteselect].Attaquer(loohy_, gameplay_, ref mood_, hud_);
                        break;
                    case e_modeAction.Pouvoir:
                        if (bataillon[uniteselect].SHORYUKEN != null)
                        {
                            bataillon[uniteselect].UpdatePouvoir(loohy_, gameplay_, ref mood_, hud_);
                        }
                        break;
                    default:
                        bataillon[uniteselect].Mouvement(loohy_, gameplay_.listeDesJoueurs[gameplay_.tourencours], gameplay_);
                        break;
                }
            }
            loohy_.porteeEgal0();
            if (gameplay_.mood == e_modeAction.Attaque)
            {
                bataillon[uniteselect].lookAtPortee(loohy_);
            }
            if (gameplay_.mood == e_modeAction.Pouvoir)
            {
                bataillon[uniteselect].lookAtPorteePouvoir(loohy_);
            }
            if ((bataillon[uniteselect].state == e_EtatAnim.repos1 || bataillon[uniteselect].state == e_EtatAnim.repos2)
                && !hud_.sontvises())
            {
                Selectionner(loohy_, /*coldman_,*/ hud_);
            }
            foreach (Unite item in bataillon)
            {
                item.lireLaFile(loohy_, gameplay_.listeDesJoueurs[gameplay_.tourencours], gameplay_);
            }
        }
        public void UpdateSelonIAouNon(MoteurGraphique loohy_, SystemeDeJeu gameplay_, ref e_modeAction mood_,
            /*Lecteur coldman_,*/ HUD hud_)
        {
            if (IA)
            {
                UpdateIA(loohy_, gameplay_,/* coldman_,*/ hud_);
            }
            else
            {
                Update(loohy_, gameplay_, ref mood_, /*coldman_, */hud_);
            }
        }
        public void UpdateSansClicSelonIAouNon(MoteurGraphique loohy_, SystemeDeJeu gameplay_)
        {
            foreach (Unite item in bataillon)
            {
                item.lireLaFile(loohy_, gameplay_.listeDesJoueurs[gameplay_.tourencours], gameplay_);
            }
        }

        public void Selectionner(MoteurGraphique moteurgraphique_, /*Lecteur coldman_, */HUD hud_)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Tab) && clic)
            {
                suivant(moteurgraphique_, true, hud_);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Tab) && Mouse.GetState().LeftButton != ButtonState.Pressed)
            {
                clic = true;
            }

            for (int i = 0; i < effectif; i++)
            {
                if (moteurgraphique_.map[bataillon[i].i, bataillon[i].j].estEnSurbrillance
                    && Mouse.GetState().LeftButton == ButtonState.Pressed && clic && bataillon[i].alive)
                {
                    //coldman_.Play(bataillon[uniteselect].nom);
                    clic = false;
                    uniteselect = i;
                    bataillon[uniteselect].lookAtCheminsInitialize(moteurgraphique_);
                }
            }
        }

        public void FindeTour()
        {
            for (int i = 0; i < effectif; i++)
            {
                bataillon[i].FindeTour();
            }
        }

        public void mort(int numeroDelUnite_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            int p = bataillon[numeroDelUnite_].Agonie(moteurgraphique_);
            if (gameplay_.conditionsDeVictoire != e_typeDePartie.Colline)
            {
                gameplay_.listeDesJoueurs[(numeroarmee + 1) % 2].score += p;
            }
            gameplay_.listeDesJoueurs[gameplay_.tourencours].soeurAnne(moteurgraphique_, gameplay_);
        }

        public void checkPV(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            for (int i = 0; i < effectif; i++)
            {
                if (bataillon[i].alive && bataillon[i].pvactuel <= 0)
                {
                    mort(i, moteurgraphique_, gameplay_);
                }
            }
            atLeastOneAlive = false;
            foreach (Unite item in bataillon)
            {
                atLeastOneAlive = atLeastOneAlive || item.alive;
            }

            atLeastOneHeroAlive = false;
            foreach (Unite item in bataillon)
            {
                atLeastOneHeroAlive = atLeastOneHeroAlive || (item.alive && item.typeUnite == TypeUnite.Heros);
            }
        }

        public void pop(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            for (int f = 0; f < effectif; f++)
            {
                #region case libre
                if (moteurgraphique_.map[(int)QG.X, (int)QG.Y].estAccessible)
                {
                    bataillon[f].i = (int)QG.X;
                    bataillon[f].j = (int)QG.Y;
                }
                else
                {
                    if (moteurgraphique_.map[(int)QG.X - 1, (int)QG.Y].estAccessible)
                    {
                        bataillon[f].i = (int)QG.X - 1;
                        bataillon[f].j = (int)QG.Y;
                    }
                    else
                    {
                        if (moteurgraphique_.map[(int)QG.X - 1, (int)QG.Y - 1].estAccessible)
                        {
                            bataillon[f].i = (int)QG.X - 1;
                            bataillon[f].j = (int)QG.Y - 1;
                        }
                        else
                        {
                            if (moteurgraphique_.map[(int)QG.X, (int)QG.Y - 1].estAccessible)
                            {
                                bataillon[f].i = (int)QG.X;
                                bataillon[f].j = (int)QG.Y - 1;
                            }
                            else
                            {
                                if (moteurgraphique_.map[(int)QG.X + 1, (int)QG.Y].estAccessible)
                                {
                                    bataillon[f].i = (int)QG.X + 1;
                                    bataillon[f].j = (int)QG.Y;
                                }
                                else
                                {
                                    if (moteurgraphique_.map[(int)QG.X + 1, (int)QG.Y + 1].estAccessible)
                                    {
                                        bataillon[f].i = (int)QG.X + 1;
                                        bataillon[f].j = (int)QG.Y + 1;
                                    }
                                    else
                                    {
                                        if (moteurgraphique_.map[(int)QG.X, (int)QG.Y + 1].estAccessible)
                                        {
                                            bataillon[f].i = (int)QG.X;
                                            bataillon[f].j = (int)QG.Y + 1;
                                        }
                                        else
                                        {
                                            if (moteurgraphique_.map[(int)QG.X - 1, (int)QG.Y + 1].estAccessible)
                                            {
                                                bataillon[f].i = (int)QG.X - 1;
                                                bataillon[f].j = (int)QG.Y + 1;
                                            }
                                            else
                                            {
                                                if (moteurgraphique_.map[(int)QG.X - 2, (int)QG.Y + 1].estAccessible)
                                                {
                                                    bataillon[f].i = (int)QG.X - 2;
                                                    bataillon[f].j = (int)QG.Y + 1;
                                                }
                                                else
                                                {
                                                    if (moteurgraphique_.map[(int)QG.X - 2, (int)QG.Y].estAccessible)
                                                    {
                                                        bataillon[f].i = (int)QG.X - 2;
                                                        bataillon[f].j = (int)QG.Y;
                                                    }
                                                    else
                                                    {
                                                        if (moteurgraphique_.map[(int)QG.X - 2, (int)QG.Y - 1].estAccessible)
                                                        {
                                                            bataillon[f].i = (int)QG.X - 2;
                                                            bataillon[f].j = (int)QG.Y - 1;
                                                        }
                                                        else
                                                        {
                                                            if (moteurgraphique_.map[(int)QG.X - 2, (int)QG.Y - 2].estAccessible)
                                                            {
                                                                bataillon[f].i = (int)QG.X - 2;
                                                                bataillon[f].j = (int)QG.Y - 2;
                                                            }
                                                            else
                                                            {
                                                                if (moteurgraphique_.map[(int)QG.X - 1, (int)QG.Y - 2].estAccessible)
                                                                {
                                                                    bataillon[f].i = (int)QG.X - 1;
                                                                    bataillon[f].j = (int)QG.Y - 2;
                                                                }
                                                                else
                                                                {
                                                                    if (moteurgraphique_.map[(int)QG.X, (int)QG.Y - 2].estAccessible)
                                                                    {
                                                                        bataillon[f].i = (int)QG.X;
                                                                        bataillon[f].j = (int)QG.Y - 2;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (moteurgraphique_.map[(int)QG.X + 1, (int)QG.Y - 2].estAccessible)
                                                                        {
                                                                            bataillon[f].i = (int)QG.X + 1;
                                                                            bataillon[f].j = (int)QG.Y - 2;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                bataillon[f].Afficher(moteurgraphique_.map[bataillon[f].i, bataillon[f].j], gameplay_);
            }
        }

        public void vider(int sizeX_, int sizeY_)
        {
            for (int k = effectif - 1; k >= 0; k--)
            {
                bataillon.RemoveAt(k);
            }
            effectif = 0;
            for (int i = 0; i < sizeX_; i++)
            {
                for (int j = 0; j < sizeY_; j++)
                {
                    casesVisitees[i, j] = false;
                }
            }
        }

        public void NEW(e_race newRace_, Color newColor_, e_race saufCa_, int difficulte_)
        {
            score = 1;
            do
            {
                if (newRace_ == e_race.Random)
                {
                    Random r = new Random();
                    if (numeroarmee == 0)
                    {
                        #region 0
                        switch (r.Next(100) % 4)
                        {
                            case 1://Panda
                                couleur = Color.Red;
                                espece = e_race.Pandawan;
                                break;
                            case 2://Fenrir
                                couleur = Color.Blue;
                                espece = e_race.Fenrir;
                                break;
                            case 3://Krissa
                                couleur = Color.Green;
                                espece = e_race.Pandawan;
                                break;
                            default://Pingvin
                                couleur = Color.Yellow;
                                espece = e_race.Pingvin;
                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        #region 1
                        switch (r.Next(100) % 4)
                        {
                            case 1://Panda
                                couleur = Color.Pink;
                                espece = e_race.Pandawan;
                                break;
                            case 2://Fenrir
                                couleur = Color.Purple;
                                espece = e_race.Fenrir;
                                break;
                            case 3://Krissa
                                couleur = Color.LightGreen;
                                espece = e_race.Pandawan;
                                break;
                            default://Pingvin
                                couleur = Color.Orange;
                                espece = e_race.Pingvin;
                                break;
                        }
                        #endregion
                    }
                }
                else
                {
                    couleur = newColor_;
                    espece = newRace_;
                }
            } while (espece == saufCa_);
            difficulte = difficulte_;
            if (difficulte == 0)
            {
                IA = false;
            }
            else
            {
                IA = true;
            }
        }

        public void UpdateIA(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, /*Lecteur coldman_,*/ HUD hud_)
        {
            if (true/*!bataillon[uniteselect].IA.finish*/)
            {
                utiliserIA(moteurgraphique_, gameplay_);
            }
            else
            {
                if (allFinished())
                {
                    gameplay_.FinDeTour(moteurgraphique_, /*coldman_,*/ hud_);
                }
                else
                {
                    suivant(moteurgraphique_, false, hud_);
                }
            }
        }
        public void utiliserIA(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            bataillon[uniteselect].utiliserIA(moteurgraphique_, this, gameplay_);
        }
        public void reactiverIA()
        {
            foreach (Unite abruti in bataillon)
            {
                abruti.reactiverIA();
            }
        }
        public bool allFinished()
        {
            bool b = true;
            foreach (Unite minion in bataillon)
            {
                b = b && (/*minion.IA.finish || */!minion.alive);
            }
            return b;
        }

        public void suivant(MoteurGraphique moteurgraphique_, bool centrer_, HUD hud_)
        {
            do
            {
                uniteselect = (uniteselect + 1) % effectif;
            } while (!bataillon[uniteselect].alive || !atLeastOneAlive);
            clic = false;
            if (bataillon[uniteselect].alive)
            {
                if (centrer_)
                {
                    moteurgraphique_.centrerSur(bataillon[uniteselect].i, bataillon[uniteselect].j, hud_);
                }
                bataillon[uniteselect].lookAtCheminsInitialize(moteurgraphique_);
            }
        }

        public void soeurAnne(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            if (!IA)
            {
                moteurgraphique_.viderVue();
                foreach (Unite item in bataillon)
                {
                    if (item.pvactuel > 0)
                    {
                        item.soeurAnne(moteurgraphique_, ref casesVisitees, gameplay_);
                    }
                }
            }
        }
        public void appliquerVues(MoteurGraphique moteurgraphique_)
        {
            moteurgraphique_.viderVue();
            for (int i = 0; i < moteurgraphique_.map.GetLength(0); i++)
            {
                for (int j = 0; j < moteurgraphique_.map.GetLength(1); j++)
                {
                    moteurgraphique_.map[i, j].apercue = casesVisitees[i, j];
                }
            }
        }
        public void auras(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_)
        {
            foreach (Unite item in bataillon) { item.profiteDuneAura = false; }
            foreach (Unite item in bataillon)
            {
                if (item.alive && item.typeUnite == TypeUnite.Heros && item.aura != null)
                {
                    item.aura.ActiverAura(item, moteurgraphique_, gameplay_, -1);
                    item.aura.ActiverAura(item, moteurgraphique_, gameplay_, 1);
                }
            }
        }
        public void rotation()
        {
            foreach (Unite item in bataillon)
            {
                item.nombreDeRotations = (item.nombreDeRotations + 1) % 4;
            }
        }

        public void ConvertFromList(ListeArmee list_, int difficulte_)
        {
            vider(casesVisitees.GetLength(0), casesVisitees.GetLength(1));
            NEW(list_.espece, list_.couleur, e_race.Random, difficulte_);
            foreach (FausseUnite item in list_.bataillon)
            {
                AddUnite(item.classe, difficulte_);
            }
        }
    }
}
