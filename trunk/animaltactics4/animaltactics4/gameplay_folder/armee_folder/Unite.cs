using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Loohy & Marvin
    class Unite
    {
        #region stats

        private int force, dexterite, constitution, defense, esprit, chance, vitesse, lvl, xp;
        public int[] getStat
        {
            get
            {
                return (new int[12] { force, dexterite, constitution, defense, esprit, chance, vitesse, lvl, xp, pvactuel, pvmax, 
                initiative });
            }
        }

        public int pvmax;
        public int pvactuel;
        public int mouvement;
        public int mouvementmax;
        public int attaque;
        public int armure;
        public int initiative;
        public int esquive;
        public int coupcritique;
        public int resistance;
        public int puissance;
        public int precision;
        public int energiemax;
        public int energieactuel;

        public int bonusAttaque;
        public int bonusArmure;
        public int bonusInitiative;
        public int bonusEsquive;
        public int bonusCoupcritique;
        public int bonusresistance;
        public int bonuspuissance;
        public int bonusprecision;

        public int[] portee;//A chaque valeur de portee, donne le pourcentage de precision(nombre compris entre 0 et 10)
        public bool[] typedAttaque;//V : attaque physique, F : attaque magique

        // List<int> porteePouvoir; //Une liste des differentes portees des pouvoirs 

        #endregion
        #region Autres
        public e_classe metier;
        public string nom;
        public e_typeUnite typeUnite;
        public Pouvoir SHORYUKEN;
        public Aura aura;
        public string image;
        Rectangle sousrect;
        private float Anim;
        private float vitesseAnim;
        public e_EtatAnim state;

        public bool alive, profiteDuneAura;

        public int debug;

        Random r;

        bool een;

        public int numeroUnite;
        public int numeroArmee;

        public bool attaqOrNot;

        private bool[,] estPasseParLa;

        public IntelligenceArtificielle IA;
        #endregion
        #region Mouvement
        bool mouvOrNot;
        public List<mouv> fileDeMouvements;
        private int iDepart;
        private int jDepart;
        public int i;
        public int ivirtuel;
        public int j;
        public int jvirtuel;
        #endregion
        public bool porteTresor, estInvisible;
        public int points, nombreDeRotations;

        public Unite(e_classe c_,e_typeUnite typeUnite_, Pouvoir SHORYUKEN_, Aura aura_,
            string nom_, int force_, int dexterite_, int constitution_, int defense_,
            int esprit_, int chance_, int vitesse_, int[] portee_, bool[] typedAttaque_, int numeroUnite_,
            int numeroArmee_, int mouvement_, int ia_ = 0, e_typeDePartie etat_ = e_typeDePartie.Joute)
        {
            metier = c_;
            debug = 0;
            nom = nom_;
            typeUnite = typeUnite_;
            SHORYUKEN = SHORYUKEN_;
            aura = aura_;
            profiteDuneAura = false;

            #region Carac
            force = force_;
            dexterite = dexterite_;
            constitution = constitution_;
            defense = defense_;
            esprit = esprit_;
            chance = chance_;
            vitesse = vitesse_;

            lvl = 1;
            xp = 0;

            mouvement = mouvement_;
            mouvementmax = mouvement_;
            CaracFromStats();

            portee = portee_;
            typedAttaque = typedAttaque_;
            points = 6 * defense + 5 * dexterite + 5 * chance + 3 * vitesse + 6 * constitution;
            bool attaP = false;
            bool attaM = false;
            float moy = 0;
            for (int po = 0; po < portee.Length; po++)
            {
                attaP = attaP || typedAttaque[po];
                attaM = attaM || (!typedAttaque[po] && portee[po] != 0);
                moy += portee[po];
            }
            moy /= 20f;
            if (attaM)
            {
                points += (int)(esprit * 7 * moy);
            }
            else
            {
                points += esprit * 3;
            }
            if (typeUnite == e_typeUnite.Elite)
            {
                points += 2 * esprit;
            }
            if (attaP)
            {
                points += (int)(force * 7 * moy);
            }
            else
            {
                points += force * 3;
            }
            points = (points * mouvementmax) / 80;
            #endregion

            mouvOrNot = true;
            attaqOrNot = true;

            numeroArmee = numeroArmee_;
            numeroUnite = numeroUnite_;

            i = 5 + numeroUnite;
            ivirtuel = i;
            j = 6 + numeroArmee;
            jvirtuel = j;

            r = new Random();

            alive = true;

            sousrect = new Rectangle(0, 0, 128, 128);
            Anim = 0;
            vitesseAnim = 0.025f;
            state = e_EtatAnim.repos1;
            jDepart = 0;
            iDepart = 0;
            estPasseParLa = new bool[32, 32];
            fileDeMouvements = new List<mouv>();
            nombreDeRotations = 0;

            een = true;

            image = c_.ToString();

            IA = new IntelligenceArtificielle(ia_, this);
            //Console.WriteLine(nom + " : " + points);

            porteTresor = false;
            estInvisible = false;
        }

        public void Riposte(Unite ennemi_, int porteeDeFrappe_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_,
            string txt_, int dgts_,//--
            Color clr_, e_race e_race_, HUD hud_)
        {
            string txt1, txt2;
            int dgts1, dgts2;
            Color clr1, clr2;
            e_race e_race1, e_race2;
            if (pvactuel > 0)
            {
                #region frapper
                if (typedAttaque[porteeDeFrappe_])
                {
                    //type dattaque : physique si typedAttaque[porteedeFrappe]= vrai
                    #region Physique
                    if ((precision + bonusprecision) * portee[porteeDeFrappe_] / 10 - ennemi_.esquive >= (r.Next(1000) % 100))
                    {
                        if (r.Next(1000) % 100 < (coupcritique + bonusCoupcritique))
                        {
                            if (ennemi_.armure < (attaque + bonusAttaque) * 2)
                            {
                                ennemi_.pvactuel -= ((attaque + bonusAttaque) * 2 - ennemi_.armure);
                                txt2 = "Coup Critique !!";
                                dgts2 = ((attaque + bonusAttaque) * 2 - ennemi_.armure);
                            }
                            else
                            {
                                txt2 = "  Inefficace !  ";
                                dgts2 = 0;
                            }
                        }
                        else
                        {
                            if (ennemi_.armure < (attaque + bonusAttaque))
                            {
                                ennemi_.pvactuel -= ((attaque + bonusAttaque) - ennemi_.armure);
                                txt2 = "    Attaque !   ";
                                dgts2 = ((attaque + bonusAttaque) - ennemi_.armure);
                            }
                            else
                            {
                                txt2 = "  Inefficace !  ";
                                dgts2 = 0;
                            }
                        }
                    }
                    else
                    {
                        xp += 1;
                        if (portee[porteeDeFrappe_] == 0)
                        {
                            txt2 = "   Trop loin !  ";
                            dgts2 = 0;
                        }
                        else
                        {
                            txt2 = "      Rate !    ";
                            dgts2 = 0;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Magique
                    if ((precision + bonusprecision) * portee[porteeDeFrappe_] / 10 - ennemi_.esquive >= (r.Next(1000) % 100))
                    {
                        if (r.Next(1000) % 100 < (coupcritique + bonusCoupcritique))
                        {
                            if (ennemi_.resistance < (puissance + bonuspuissance) * 2)
                            {
                                ennemi_.pvactuel -= ((puissance + bonuspuissance) * 2 - ennemi_.resistance);
                                txt2 = "Coup Critique !!";
                                dgts2 = ((puissance + bonuspuissance) * 2 - ennemi_.armure);
                            }
                            else
                            {
                                txt2 = "  Inefficace !  ";
                                dgts2 = 0;
                            }
                        }
                        else
                        {
                            if (ennemi_.resistance < (puissance + bonuspuissance))
                            {
                                ennemi_.pvactuel -= ((puissance + bonuspuissance) - ennemi_.resistance);
                                txt2 = "    Attaque !   ";
                                dgts2 = ((puissance + bonuspuissance) - ennemi_.armure);
                            }
                            else
                            {
                                txt2 = "  Inefficace !  ";
                                dgts2 = 0;
                            }
                        }
                    }
                    else
                    {
                        xp += 1;
                        if (portee[porteeDeFrappe_] == 0)
                        {
                            txt2 = "   Trop loin !  ";
                            dgts2 = 0;
                        }
                        else
                        {
                            txt2 = "      Rate !    ";
                            dgts2 = 0;
                        }
                    }
                    #endregion
                }
                #endregion
            }
            else
            {
                txt2 = "  Deja morte !  ";
                dgts2 = 0;
            }
            txt1 = txt_;
            dgts1 = dgts_;
            clr1 = clr_;
            e_race1 = e_race_;
            clr2 = gameplay_.listeDesJoueurs[numeroArmee].couleur;
            e_race2 = gameplay_.listeDesJoueurs[numeroArmee].espece;
            hud_.fight(ennemi_, this, txt1, dgts1, clr1, txt2, dgts2, clr2, e_race1, e_race2);
            gameplay_.CheckPV(moteurgraphique_, hud_);
        }
        public void Frappe(Unite ennemi_, int porteeDeFrappe_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, HUD hud_)
        {
            string txt1;
            int dgts1;
            Color clr1;
            e_race race1;
            #region frapper
            if (typedAttaque[porteeDeFrappe_])
            {
                //type dattaque : physique si typedAttaque[porteedeFrappe]= vrai
                #region Physique
                if ((precision + bonusprecision) * portee[porteeDeFrappe_] / 10 - ennemi_.esquive >= (r.Next(1000) % 100))
                {
                    if (r.Next(1000) % 100 < (coupcritique + bonusCoupcritique))
                    {
                        if (ennemi_.armure < (attaque + bonusAttaque) * 2)
                        {
                            ennemi_.pvactuel -= ((attaque + bonusAttaque) * 2 - ennemi_.armure);
                            txt1 = "Coup Critique !!";
                            dgts1 = ((attaque + bonusAttaque) * 2 - ennemi_.armure);
                        }
                        else
                        {
                            txt1 = "  Inefficace !  ";
                            dgts1 = 0;
                        }
                    }
                    else
                    {
                        if (ennemi_.armure < (attaque + bonusAttaque))
                        {
                            ennemi_.pvactuel -= ((attaque + bonusAttaque) - ennemi_.armure);
                            txt1 = "    Attaque !   ";
                            dgts1 = ((attaque + bonusAttaque) - ennemi_.armure);
                        }
                        else
                        {
                            txt1 = "  Inefficace !  ";
                            dgts1 = 0;
                        }
                    }

                    xp += 3;
                    ennemi_.xp += 1;
                }
                else
                {
                    xp += 1;
                    if (portee[porteeDeFrappe_] == 0)
                    {
                        txt1 = "   Trop loin !  ";
                        dgts1 = 0;
                    }
                    else
                    {
                        txt1 = "      Rate !    ";
                        dgts1 = 0;
                    }
                }
                #endregion
            }
            else
            {
                #region magique
                if ((precision + bonusprecision) * portee[porteeDeFrappe_] / 10 - ennemi_.esquive >= (r.Next(1000) % 100))
                {
                    if (r.Next(1000) % 100 < (coupcritique + bonusCoupcritique))
                    {
                        if (ennemi_.resistance < (puissance + bonuspuissance) * 2)
                        {
                            ennemi_.pvactuel -= ((puissance + bonuspuissance) * 2 - ennemi_.resistance);
                            txt1 = "Coup Critique !!";
                            dgts1 = ((puissance + bonuspuissance) * 2 - ennemi_.armure);
                        }
                        else
                        {
                            txt1 = "  Inefficace !  ";
                            dgts1 = 0;
                        }
                    }
                    else
                    {
                        if (ennemi_.resistance < (puissance + bonuspuissance))
                        {
                            ennemi_.pvactuel -= ((puissance + bonuspuissance) - ennemi_.resistance);
                            txt1 = "    Attaque !   ";
                            dgts1 = ((puissance + bonuspuissance) - ennemi_.armure);
                        }
                        else
                        {
                            txt1 = "  Inefficace !  ";
                            dgts1 = 0;
                        }
                    }

                    xp += 3;
                    ennemi_.xp += 1;
                }
                else
                {
                    xp += 1;
                    if (portee[porteeDeFrappe_] == 0)
                    {
                        txt1 = "   Trop loin !  ";
                        dgts1 = 0;
                    }
                    else
                    {
                        txt1 = "      Rate !    ";
                        dgts1 = 0;
                    }
                }
                #endregion
            }
            #endregion
            clr1 = gameplay_.listeDesJoueurs[numeroArmee].couleur;
            race1 = gameplay_.listeDesJoueurs[numeroArmee].espece;
            ennemi_.Riposte(this, porteeDeFrappe_, moteurgraphique_, gameplay_, txt1, dgts1, clr1, race1, hud_);
        }//--
        public void Initiative(Unite ennemi_, int porteDeFrappe_, MoteurGraphique moteurgraphique_,
            SystemeDeJeu gameplay_, ref e_modeAction mood, HUD hud_)
        {
            if (!ennemi_.estInvisible)
            {
                estInvisible = false;
                if ((initiative + bonusInitiative) >= ennemi_.initiative)
                {
                    Frappe(ennemi_, porteDeFrappe_, moteurgraphique_, gameplay_, hud_);
                }
                else
                {
                    ennemi_.Frappe(this, porteDeFrappe_, moteurgraphique_, gameplay_, hud_);
                }
                mood = e_modeAction.Mouvement;
                attaqOrNot = false;
            }
        }

        public void Afficher(Tile tile_, SystemeDeJeu gameplay_)
        {
            tile_.pointeurUnite = numeroUnite;
            tile_.pointeurArmee = numeroArmee;
            tile_.textureUnite = image;
            tile_.presence = true;
            tile_.estAccessible = false;
            tile_.dessinTomb = false;
            tile_.pourcentageDePv = (100 * pvactuel) / pvmax;
            tile_.mouvUnite = mouvement;
            tile_.mouvUniteMax = (mouvement * 40) / mouvementmax;
            tile_.xpUnite = (xp);
            Anim += vitesseAnim;
            tile_.jDepart = jDepart;
            tile_.iDepart = iDepart;
            if (Anim > 1)
            {
                #region anim
                Anim = 0;
                switch (state)
                {
                    case e_EtatAnim.mouvement1:
                        state = e_EtatAnim.mouvement2;
                        sousrect.Y = 0;
                        break;
                    case e_EtatAnim.mouvement2:
                        state = e_EtatAnim.mouvement3;
                        sousrect.Y = 3 * 128;
                        break;
                    case e_EtatAnim.mouvement3:
                        state = e_EtatAnim.repos1;
                        sousrect.Y = 0;
                        vitesseAnim = 0.025f;
                        break;
                    case e_EtatAnim.repos1:
                        state = e_EtatAnim.repos2;
                        sousrect.Y = 128;
                        ivirtuel = i;
                        jvirtuel = j;
                        break;
                    case e_EtatAnim.repos2:
                        state = e_EtatAnim.repos1;
                        sousrect.Y = 0;
                        break;
                    default:
                        break;
                }
                #endregion
            }
            tile_.state = state;
            tile_.sousRectUnite = sousrect;
            tile_.AttaqOrNot = attaqOrNot;
            tile_.aura = profiteDuneAura;
            tile_.heros = typeUnite == e_typeUnite.Heros;
            tile_.cachette = e_Cache.Visible;
            if (estInvisible)
            {
                if (gameplay_.tourencours == numeroArmee)
                {
                    tile_.cachette = e_Cache.InvisibleAmi;
                }
                else
                {
                    tile_.cachette = e_Cache.Invisible;
                }
            }
        }

        public void CaracFromStats()
        {
            pvmax = 30 + (constitution * 5) / 10;
            pvactuel = pvmax;
            energiemax = 2 * esprit;
            energieactuel = energiemax;
            initiative = vitesse;
            bonusInitiative = 0;
            armure = (int)Math.Log((double)(defense + force + 1));
            bonusArmure = 0;
            attaque = (force * 3) / 2;
            bonusAttaque = 0;
            puissance = (esprit * 3) / 2;
            bonuspuissance = 0;
            resistance = (int)Math.Log((double)(defense + esprit + 1));
            bonusresistance = 0;
            esquive = (dexterite + chance + vitesse) / 3;
            bonusresistance = 0;
            precision = 100 + ((dexterite * 3) / 8);
            bonusprecision = 0;
            coupcritique = chance / 2;
            bonusCoupcritique = 0;
        }
        private void LevelUp()
        {
            lvl++;
            xp -= 10;

            int R;
            for (int c = 0; c < chance; c++)
            {
                R = r.Next(1000) % (force + defense + constitution + esprit + dexterite + vitesse);
                #region upcarac
                if (R > 0 && R < force)
                {
                    force++;
                }
                else
                {
                    if (R > force && R < dexterite + force)
                    {
                        dexterite++;
                    }
                    else
                    {
                        if (R > dexterite + force && R < defense + force + dexterite)
                        {
                            defense++;
                        }
                        else
                        {
                            if (R > defense + force + dexterite && R < constitution + force + dexterite + defense)
                            {
                                constitution++;
                            }
                            else
                            {
                                if (R > constitution + force + dexterite + defense
                                    && R < esprit + force + dexterite + defense + constitution)
                                {
                                    esprit++;
                                }
                                else
                                {
                                    if (R > esprit + force + dexterite + defense + constitution
                                        && R < vitesse + force + dexterite + defense + constitution + esprit)
                                    {
                                        vitesse++;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            CaracFromStats();
        }
        public void FindeTour()//remettre bonus stats a 0
        {
            if (pvactuel > 0)
            {
                mouvement = mouvementmax;
                attaqOrNot = true;
                if (xp >= 10 && lvl < 15)
                {
                    LevelUp();
                }
                pvactuel += pvmax / 20;
                if (pvactuel > pvmax)
                {
                    pvactuel = pvmax;
                }
                energieactuel += energiemax / 20;
                if (energieactuel > energiemax)
                {
                    energieactuel = energiemax;
                }
                bonusAttaque = 0;
                bonusArmure = 0;
                bonusCoupcritique = 0;
                bonusEsquive = 0;
                bonusInitiative = 0;
                bonusprecision = 0;
                bonuspuissance = 0;
                bonusresistance = 0;
            }
            debug = 0;
        }
        public int Agonie(MoteurGraphique moteurgraphique_)
        {
            moteurgraphique_.map[i, j].pointeurUnite = 0;
            moteurgraphique_.map[i, j].pointeurArmee = 0;
            moteurgraphique_.map[i, j].presence = false;
            moteurgraphique_.map[i, j].dessinTomb = true;
            moteurgraphique_.map[i, j].estAccessible = true;
            attaqOrNot = false;
            jDepart = 0;
            iDepart = 0;
            porteTresor = false;
            alive = false;
            return points;
        }

        public void Attaquer(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            if ((i + 1 < moteurgraphique_.longueur && moteurgraphique_.map[i + 1, j].presence)
                && ((Keyboard.GetState().IsKeyDown(Keys.F)
                || (moteurgraphique_.map[i + 1, j].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && attaqOrNot))
            {
                AttaqueEst(moteurgraphique_, gameplay_, ref mood_, hud_);
            }
            if ((j > 0 && moteurgraphique_.map[i, j - 1].presence)
                && ((Keyboard.GetState().IsKeyDown(Keys.R)
                || (moteurgraphique_.map[i, j - 1].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && attaqOrNot))
            {
                AttaqueNord(moteurgraphique_, gameplay_, ref mood_, hud_);
            }
            if ((i > 0 && moteurgraphique_.map[i - 1, j].presence)
                && ((Keyboard.GetState().IsKeyDown(Keys.E)
                || (moteurgraphique_.map[i - 1, j].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && attaqOrNot))
            {
                AttaqueOuest(moteurgraphique_, gameplay_, ref mood_, hud_);
            }
            if ((j + 1 < moteurgraphique_.largeur && moteurgraphique_.map[i, j + 1].presence)
                && ((Keyboard.GetState().IsKeyDown(Keys.D)
                || (moteurgraphique_.map[i, j + 1].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && attaqOrNot))
            {
                AttaqueSud(moteurgraphique_, gameplay_, ref mood_, hud_);
            }

            #region attaque a distance
            if (Mouse.GetState().RightButton == ButtonState.Pressed && attaqOrNot)
            {
                for (int portee_ = 1; portee_ < 7; portee_++)
                {
                    if (portee[portee_] != 0)
                    {
                        for (int k = 0; k < portee_; k++)
                        {
                            if (i + k >= 0 && i + k < moteurgraphique_.longueur
                                && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + k, j + (portee_ - k)].presence &&
                                       moteurgraphique_.map[i + k, j + (portee_ - k)].estEnSurbrillance &&
                                       moteurgraphique_.map[i + k, j + (portee_ - k)].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i + k, j + (portee_ - k)].
                                         pointeurArmee].bataillon[moteurgraphique_.map[i + k, j + (portee_ - k)].pointeurUnite],
                                         portee_, moteurgraphique_, gameplay_, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            if (i - k >= 0 && i - k < moteurgraphique_.longueur
                                 && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - k, j - (portee_ - k)].presence &&
                                       moteurgraphique_.map[i - k, j - (portee_ - k)].estEnSurbrillance &&
                                       moteurgraphique_.map[i - k, j - (portee_ - k)].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i - k, j - (portee_ - k)].
                                        pointeurArmee].bataillon[moteurgraphique_.map[i - k, j - (portee_ - k)].pointeurUnite],
                                        portee_, moteurgraphique_, gameplay_, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                                 && j - k >= 0 && j - k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + (portee_ - k), j - k].presence &&
                                       moteurgraphique_.map[i + (portee_ - k), j - k].estEnSurbrillance &&
                                       moteurgraphique_.map[i + (portee_ - k), j - k].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i + (portee_ - k), j - k].
                                        pointeurArmee].bataillon[moteurgraphique_.map[i + (portee_ - k), j - k].pointeurUnite],
                                        portee_, moteurgraphique_, gameplay_, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                                 && j + k >= 0 && j + k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - (portee_ - k), j + k].presence &&
                                       moteurgraphique_.map[i - (portee_ - k), j + k].estEnSurbrillance &&
                                       moteurgraphique_.map[i - (portee_ - k), j + k].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i - (portee_ - k), j + k].
                                        pointeurArmee].bataillon[moteurgraphique_.map[i - (portee_ - k), j + k].pointeurUnite],
                                        portee_, moteurgraphique_, gameplay_, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #region <> attaques
        public void AttaqueSud(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            if (j + 1 < moteurgraphique_.largeur && moteurgraphique_.map[i, j + 1].presence)
            {
                mouvOrNot = false;
                Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i, j + 1].
                    pointeurArmee].bataillon[moteurgraphique_.map[i, j + 1].pointeurUnite], 1,
                    moteurgraphique_, gameplay_, ref mood_, hud_);
                sousrect.X = 128;
            }
        }
        public void AttaqueNord(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            if (j > 0 && moteurgraphique_.map[i, j - 1].presence)
            {
                mouvOrNot = false;
                Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i, j - 1].
                    pointeurArmee].bataillon[moteurgraphique_.map[i, j - 1].pointeurUnite], 1,
                    moteurgraphique_, gameplay_, ref mood_, hud_);
                sousrect.X = 128 * 3;
            }
        }
        public void AttaqueOuest(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            mouvOrNot = false;
            Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i - 1, j].
                pointeurArmee].bataillon[moteurgraphique_.map[i - 1, j].pointeurUnite], 1,
                moteurgraphique_, gameplay_, ref mood_, hud_);
            sousrect.X = 256;
        }
        public void AttaqueEst(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            mouvOrNot = false;
            Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[i + 1, j].
                pointeurArmee].bataillon[moteurgraphique_.map[i + 1, j].pointeurUnite], 1,
                moteurgraphique_, gameplay_, ref mood_, hud_);
            sousrect.X = 0;
        }
        #endregion

        public void UpdatePouvoir(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, ref e_modeAction mood_, HUD hud_)
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed && attaqOrNot)
            {
                foreach (int portee_ in SHORYUKEN.porteePouvoir)
                {
                    if (SHORYUKEN.vertical)
                    {
                        int k = 0;
                        #region 1
                        if (i + k >= 0 && i + k < moteurgraphique_.longueur
                                                && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[i + k, j + (portee_ - k)].presence &&
                                   moteurgraphique_.map[i + k, j + (portee_ - k)].estEnSurbrillance &&
                                   moteurgraphique_.map[i + k, j + (portee_ - k)].visible &&
                                   attaqOrNot)
                            {
                                mouvOrNot = false;
                                SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i + k, j + (portee_ - k), ref mood_, hud_);
                                gameplay_.CheckPV(moteurgraphique_, hud_);
                            }
                        }
                        #endregion
                        #region 2
                        if (i - k >= 0 && i - k < moteurgraphique_.longueur
                                                 && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[i - k, j - (portee_ - k)].presence &&
                                   moteurgraphique_.map[i - k, j - (portee_ - k)].estEnSurbrillance &&
                                   moteurgraphique_.map[i - k, j - (portee_ - k)].visible &&
                                   attaqOrNot)
                            {
                                mouvOrNot = false;
                                SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i - k, j - (portee_ - k), ref mood_, hud_);
                                gameplay_.CheckPV(moteurgraphique_, hud_);
                            }
                        }
                        #endregion
                        #region 3
                        if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                                                 && j - k >= 0 && j - k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[i + (portee_ - k), j - k].presence &&
                                   moteurgraphique_.map[i + (portee_ - k), j - k].estEnSurbrillance &&
                                   moteurgraphique_.map[i + (portee_ - k), j - k].visible &&
                                   attaqOrNot)
                            {
                                mouvOrNot = false;
                                SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i + (portee_ - k), j - k, ref mood_, hud_);
                                gameplay_.CheckPV(moteurgraphique_, hud_);
                            }
                        }
                        #endregion
                        #region 4
                        if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                                                 && j + k >= 0 && j + k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[i - (portee_ - k), j + k].presence &&
                                   moteurgraphique_.map[i - (portee_ - k), j + k].estEnSurbrillance &&
                                   moteurgraphique_.map[i - (portee_ - k), j + k].visible &&
                                   attaqOrNot)
                            {
                                mouvOrNot = false;
                                SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i - (portee_ - k), j + k, ref mood_, hud_);
                                gameplay_.CheckPV(moteurgraphique_, hud_);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        for (int k = 0; k <= portee_; k++)
                        {
                            #region 1
                            if (i + k >= 0 && i + k < moteurgraphique_.longueur
                                                    && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + k, j + (portee_ - k)].presence &&
                                       moteurgraphique_.map[i + k, j + (portee_ - k)].estEnSurbrillance &&
                                       moteurgraphique_.map[i + k, j + (portee_ - k)].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i + k, j + (portee_ - k),
                                        ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            #endregion
                            #region 2
                            if (i - k >= 0 && i - k < moteurgraphique_.longueur
                                                     && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - k, j - (portee_ - k)].presence &&
                                       moteurgraphique_.map[i - k, j - (portee_ - k)].estEnSurbrillance &&
                                       moteurgraphique_.map[i - k, j - (portee_ - k)].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i - k, j - (portee_ - k), ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            #endregion
                            #region 3
                            if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                                                     && j - k >= 0 && j - k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + (portee_ - k), j - k].presence &&
                                       moteurgraphique_.map[i + (portee_ - k), j - k].estEnSurbrillance &&
                                       moteurgraphique_.map[i + (portee_ - k), j - k].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i + (portee_ - k), j - k, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            #endregion
                            #region 4
                            if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                                                     && j + k >= 0 && j + k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - (portee_ - k), j + k].presence &&
                                       moteurgraphique_.map[i - (portee_ - k), j + k].estEnSurbrillance &&
                                       moteurgraphique_.map[i - (portee_ - k), j + k].visible &&
                                       attaqOrNot)
                                {
                                    mouvOrNot = false;
                                    SHORYUKEN.UtiliserPouvoir(this, moteurgraphique_, gameplay_, i - (portee_ - k), j + k, ref mood_, hud_);
                                    gameplay_.CheckPV(moteurgraphique_, hud_);
                                }
                            }
                            #endregion
                        }
                    }
                }

            }
        }

        public void lookAtPortee(MoteurGraphique moteurgraphique_)
        {
            for (int portee_ = 1; portee_ < 7; portee_++)
            {
                afficherPortee(moteurgraphique_, portee_);
            }
        }
        public void lookAtPorteePouvoir(MoteurGraphique moteurgraphique_)
        {
            if (SHORYUKEN != null)
            {
                foreach (int portee_ in SHORYUKEN.porteePouvoir)
                {
                    if (SHORYUKEN.vertical)
                    {
                        afficherPorteePouvoirVertical(moteurgraphique_, portee_);
                    }
                    else
                    {
                        afficherPorteePouvoir(moteurgraphique_, portee_);
                    }
                }
            }
        }

        public void afficherPorteePouvoirVertical(MoteurGraphique moteurgraphique_, int portee_)
        {
            int k = 0;
            if (i + k >= 0 && i + k < moteurgraphique_.longueur
                && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
            {
                moteurgraphique_.map[i + k, j + (portee_ - k)].surbrillancePortee = 10;
                moteurgraphique_.map[i + k, j + (portee_ - k)].sousRectportee.X = 64 * 19;
            }
            if (i - k >= 0 && i - k < moteurgraphique_.longueur
                 && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
            {
                moteurgraphique_.map[i - k, j - (portee_ - k)].surbrillancePortee = 10;
                moteurgraphique_.map[i - k, j - (portee_ - k)].sousRectportee.X = 64 * 19;
            }
            if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                 && j - k >= 0 && j - k < moteurgraphique_.largeur)
            {
                moteurgraphique_.map[i + (portee_ - k), j - k].surbrillancePortee = 10;
                moteurgraphique_.map[i + (portee_ - k), j - k].sousRectportee.X = 64 * 19;
            }
            if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                 && j + k >= 0 && j + k < moteurgraphique_.largeur)
            {
                moteurgraphique_.map[i - (portee_ - k), j + k].surbrillancePortee = 10;
                moteurgraphique_.map[i - (portee_ - k), j + k].sousRectportee.X = 64 * 19;
            }
        }
        public void afficherPorteePouvoir(MoteurGraphique moteurgraphique_, int portee_)
        {
            for (int k = 0; k <= portee_; k++)
            {
                if (i + k >= 0 && i + k < moteurgraphique_.longueur
                    && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + k, j + (portee_ - k)].surbrillancePortee = 10;
                    moteurgraphique_.map[i + k, j + (portee_ - k)].sousRectportee.X = 64 * 19;
                }
                if (i - k >= 0 && i - k < moteurgraphique_.longueur
                     && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - k, j - (portee_ - k)].surbrillancePortee = 10;
                    moteurgraphique_.map[i - k, j - (portee_ - k)].sousRectportee.X = 64 * 19;
                }
                if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                     && j - k >= 0 && j - k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + (portee_ - k), j - k].surbrillancePortee = 10;
                    moteurgraphique_.map[i + (portee_ - k), j - k].sousRectportee.X = 64 * 19;
                }
                if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                     && j + k >= 0 && j + k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - (portee_ - k), j + k].surbrillancePortee = 10;
                    moteurgraphique_.map[i - (portee_ - k), j + k].sousRectportee.X = 64 * 19;
                }
            }
        }
        public void afficherPortee(MoteurGraphique moteurgraphique_, int portee_)
        {
            for (int k = 0; k < portee_; k++)
            {
                if (i + k >= 0 && i + k < moteurgraphique_.longueur
                    && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + k, j + (portee_ - k)].surbrillancePortee = portee[portee_];
                    moteurgraphique_.map[i + k, j + (portee_ - k)].sousRectportee.X = 64 * 9 + 64 * portee[portee_];
                }
                if (i - k >= 0 && i - k < moteurgraphique_.longueur
                     && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - k, j - (portee_ - k)].surbrillancePortee = portee[portee_];
                    moteurgraphique_.map[i - k, j - (portee_ - k)].sousRectportee.X = 64 * 9 + 64 * portee[portee_];
                }
                if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                     && j - k >= 0 && j - k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + (portee_ - k), j - k].surbrillancePortee = portee[portee_];
                    moteurgraphique_.map[i + (portee_ - k), j - k].sousRectportee.X = 64 * 9 + 64 * portee[portee_];
                }
                if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                     && j + k >= 0 && j + k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - (portee_ - k), j + k].surbrillancePortee = portee[portee_];
                    moteurgraphique_.map[i - (portee_ - k), j + k].sousRectportee.X = 64 * 9 + 64 * portee[portee_];
                }
            }
        }

        public void soeurAnne(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, SystemeDeJeu gameplay_)
        {
            if (/*IA.difficulte == 0 &&*/ alive)
            {
                if (i >= 0 && i < moteurgraphique_.longueur && j >= 0 && j < moteurgraphique_.largeur)
                {
                    casesVisitees_[i, j] = true;
                    moteurgraphique_.map[i, j].visible = true;
                    #region detecter les invisibles proches
                    for (int p = -1; p < 2; p++)
                    {
                        for (int q = -1; q < 2; q++)
                        {
                            if (i + p >= 0 && i + p < moteurgraphique_.longueur &&
                                j + q >= 0 && j + q < moteurgraphique_.largeur
                                && (p != 0 || q != 0) && moteurgraphique_.map[i + p, j + q].visible
                                && moteurgraphique_.map[i + p, j + q].presence)
                            {
                                if (gameplay_.listeDesJoueurs[moteurgraphique_.map[i + p, j + q].pointeurArmee].
                                bataillon[moteurgraphique_.map[i + p, j + q].pointeurUnite].numeroArmee != numeroArmee)
                                {
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i + p, j + q].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i + p, j + q].pointeurUnite].estInvisible = false;
                                }
                            }
                        }
                    }
                    #endregion
                    #region Annes
                    if (i != 0)
                    {
                        anneOuest(moteurgraphique_, ref casesVisitees_, i - 1, j, moteurgraphique_.map[i - 1, j].altitude, 7, true);
                        if (j != 0)
                        {
                            anneOuestNord(moteurgraphique_, ref casesVisitees_, i - 1, j - 1, moteurgraphique_.map[i - 1, j - 1].altitude,
                                7, true);
                        }
                        if (j != moteurgraphique_.largeur - 1)
                        {
                            anneSudOuest(moteurgraphique_, ref casesVisitees_, i - 1, j + 1, moteurgraphique_.map[i - 1, j + 1].altitude,
                                7, true);
                        }
                    }
                    if (i != moteurgraphique_.longueur - 1)
                    {
                        anneEst(moteurgraphique_, ref casesVisitees_, i + 1, j, moteurgraphique_.map[i + 1, j].altitude, 7, true);
                        if (j != 0)
                        {
                            anneNordEst(moteurgraphique_, ref casesVisitees_, i + 1, j - 1, moteurgraphique_.map[i + 1, j - 1].altitude,
                                7, true);
                        }
                        if (j != moteurgraphique_.largeur - 1)
                        {
                            anneEstSud(moteurgraphique_, ref casesVisitees_, i + 1, j + 1, moteurgraphique_.map[i + 1, j + 1].altitude,
                                7, true);
                        }
                    }
                    if (j != 0)
                    {
                        anneNord(moteurgraphique_, ref casesVisitees_, i, j - 1, moteurgraphique_.map[i, j - 1].altitude, 7, true);
                    }
                    if (j != moteurgraphique_.largeur - 1)
                    {
                        anneSud(moteurgraphique_, ref casesVisitees_, i, j + 1, moteurgraphique_.map[i, j + 1].altitude, 7, true);
                    }
                    #endregion
                }
            }
        }
        #region Sous appels
        #region Principaux
        public void anneSud(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j+1
            if (j_ < moteurgraphique_.largeur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ + 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneSud(moteurgraphique_, ref casesVisitees_, i_, j_ + 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneNord(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j-1
            if (j_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ - 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneNord(moteurgraphique_, ref casesVisitees_, i_, j_ - 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneEst(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i+1,j
            if (i_ < moteurgraphique_.longueur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ + 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneEst(moteurgraphique_, ref casesVisitees_, i_ + 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneOuest(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i-1,j
            if (i_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ - 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneOuest(moteurgraphique_, ref casesVisitees_, i_ - 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        #endregion
        #region Secondaires
        public void anneSudOuest(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j+1
            if (j_ < moteurgraphique_.largeur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ + 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneSudOuest(moteurgraphique_, ref casesVisitees_, i_, j_ + 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
            //i-1,j
            if (i_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ - 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneSudOuest(moteurgraphique_, ref casesVisitees_, i_ - 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneNordEst(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j-1
            if (j_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ - 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneNordEst(moteurgraphique_, ref casesVisitees_, i_, j_ - 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
            //i+1,j
            if (i_ < moteurgraphique_.longueur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ + 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneNordEst(moteurgraphique_, ref casesVisitees_, i_ + 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneEstSud(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j+1
            if (j_ < moteurgraphique_.largeur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ + 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneEstSud(moteurgraphique_, ref casesVisitees_, i_, j_ + 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
            //i+1,j
            if (i_ < moteurgraphique_.longueur - 1 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ + 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneEstSud(moteurgraphique_, ref casesVisitees_, i_ + 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        public void anneOuestNord(MoteurGraphique moteurgraphique_, ref bool[,] casesVisitees_, int i_, int j_,
            int altitudeDepart_, int distance_, bool bonneVue_)
        {
            //i,j-1
            if (j_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_, j_ - 1].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneOuestNord(moteurgraphique_, ref casesVisitees_, i_, j_ - 1, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
            //i-1,j
            if (i_ > 0 &&
                (
                (altitudeDepart_ < moteurgraphique_.map[i_, j_].altitude
                && altitudeDepart_ + 32 > moteurgraphique_.map[i_, j_].altitude
                && moteurgraphique_.map[i_, j_].altitude < moteurgraphique_.map[i_ - 1, j_].altitude)
                ||
                (altitudeDepart_ >= moteurgraphique_.map[i_, j_].altitude)
                ))
            {
                casesVisitees_[i_, j_] = true;
                if (bonneVue_)
                {
                    moteurgraphique_.map[i_, j_].visible = true;
                }
                if (distance_ > 0)
                {
                    anneOuestNord(moteurgraphique_, ref casesVisitees_, i_ - 1, j_, altitudeDepart_, distance_ - 1,
                        moteurgraphique_.map[i_, j_].E_DecorArriere == e_Decorarriere.vide);
                }
            }
        }
        #endregion
        #endregion

        public void Mouvement(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            #region Touches
            if ((i + 1 < moteurgraphique_.longueur)
                       && ((Keyboard.GetState().IsKeyDown(Keys.S)
                       || (moteurgraphique_.map[i + 1, j].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                       && mouvOrNot))
            {
                goEst(moteurgraphique_, armee_, gameplay_);
                lookAtCheminsInitialize(moteurgraphique_);
            }
            if ((j > 0)
                && ((Keyboard.GetState().IsKeyDown(Keys.W)
                || (moteurgraphique_.map[i, j - 1].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && mouvOrNot))
            {
                goNord(moteurgraphique_, armee_, gameplay_);
                lookAtCheminsInitialize(moteurgraphique_);
            }
            if ((i > 0)
                && ((Keyboard.GetState().IsKeyDown(Keys.Q)
                || (moteurgraphique_.map[i - 1, j].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && mouvOrNot))
            {
                goOuest(moteurgraphique_, armee_, gameplay_);
                lookAtCheminsInitialize(moteurgraphique_);
            }
            if ((j + 1 < moteurgraphique_.largeur)
                && ((Keyboard.GetState().IsKeyDown(Keys.A)
                || (moteurgraphique_.map[i, j + 1].estEnSurbrillance && Mouse.GetState().RightButton == ButtonState.Pressed))
                && mouvOrNot))
            {
                goSud(moteurgraphique_, armee_, gameplay_);
                lookAtCheminsInitialize(moteurgraphique_);
            }
            #endregion

            if (Keyboard.GetState().IsKeyUp(Keys.S) &&
                Keyboard.GetState().IsKeyUp(Keys.A) &&
                Keyboard.GetState().IsKeyUp(Keys.W) &&
                Keyboard.GetState().IsKeyUp(Keys.Q) &&
                Mouse.GetState().LeftButton == ButtonState.Released &&
                state == e_EtatAnim.repos1)
            {
                mouvOrNot = true;
            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed && mouvOrNot && fileDeMouvements.Count == 0)
            {
                for (int c = 0; c < moteurgraphique_.longueur; c++)
                {
                    for (int d = 0; d < moteurgraphique_.largeur; d++)
                    {
                        if (mouvOrNot && moteurgraphique_.map[c, d].estAccessible && moteurgraphique_.map[c, d].estEnSurbrillance
                            && moteurgraphique_.map[c, d].cheminValid)
                        {
                            PathFindingLoohy(moteurgraphique_, c, d);
                        }
                    }
                }
            }
        }//--
        #region <> mouvements
        public bool goSud(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            if (j + 1 < moteurgraphique_.largeur && moteurgraphique_.map[i, j + 1].estAccessible && mouvement >= moteurgraphique_.map[i, j + 1].coutEnMouvement)
            {
                mouvOrNot = false;
                debug = 0;
                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, -1);
                }

                moteurgraphique_.map[i, j].pointeurUnite = 0;
                moteurgraphique_.map[i, j].pointeurArmee = 0;
                moteurgraphique_.map[i, j].presence = false;
                moteurgraphique_.map[i, j].estAccessible = true;
                jDepart = 0;
                iDepart = 0;

                j++;

                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, 1);
                }
                mouvement -= moteurgraphique_.map[i, j].coutEnMouvement;
                sousrect.X = 128;
                tourner();
                state = e_EtatAnim.mouvement1;
                sousrect.Y = 256;
                vitesseAnim = 0.2f;
                jDepart = -1;
                iDepart = 1;
                moteurgraphique_.viderChemin();
                lookAtCheminsInitialize(moteurgraphique_);
                moteurgraphique_.viderVue();
                armee_.soeurAnne(moteurgraphique_, gameplay_);
                armee_.auras(moteurgraphique_, gameplay_);
                return true;
            }
            else
            {
                mouvOrNot = false;
                return false;
            }
        }
        public bool goNord(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            if (j - 1 > 0 && moteurgraphique_.map[i, j - 1].estAccessible && mouvement >= moteurgraphique_.map[i, j - 1].coutEnMouvement)
            {
                mouvOrNot = false;
                debug = 0;
                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, -1);
                }

                moteurgraphique_.map[i, j].pointeurUnite = 0;
                moteurgraphique_.map[i, j].pointeurArmee = 0;
                moteurgraphique_.map[i, j].presence = false;
                moteurgraphique_.map[i, j].estAccessible = true;
                jDepart = 0;
                iDepart = 0;

                j--;

                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, 1);
                }
                mouvement -= moteurgraphique_.map[i, j].coutEnMouvement;
                sousrect.X = 128 * 3;
                tourner();
                state = e_EtatAnim.mouvement1;
                sousrect.Y = 256;
                vitesseAnim = 0.2f;
                jDepart = 1;
                iDepart = -1;
                moteurgraphique_.viderChemin();
                lookAtCheminsInitialize(moteurgraphique_);
                moteurgraphique_.viderVue();
                armee_.soeurAnne(moteurgraphique_, gameplay_);
                armee_.auras(moteurgraphique_, gameplay_);
                return true;
            }
            else
            {
                mouvOrNot = false;
                return false;
            }
        }
        public bool goOuest(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            if (i - 1 > 0 && moteurgraphique_.map[i - 1, j].estAccessible && mouvement >= moteurgraphique_.map[i - 1, j].coutEnMouvement)
            {
                mouvOrNot = false;
                debug = 0;
                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, -1);
                }

                moteurgraphique_.map[i, j].pointeurUnite = 0;
                moteurgraphique_.map[i, j].pointeurArmee = 0;
                moteurgraphique_.map[i, j].presence = false;
                moteurgraphique_.map[i, j].estAccessible = true;
                jDepart = 0;
                iDepart = 0;

                i--;

                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, 1);
                }
                mouvement -= moteurgraphique_.map[i, j].coutEnMouvement;
                sousrect.X = 256;
                tourner();
                state = e_EtatAnim.mouvement1;
                sousrect.Y = 256;
                vitesseAnim = 0.2f;
                jDepart = +1;
                iDepart = +1;
                moteurgraphique_.viderChemin();
                lookAtCheminsInitialize(moteurgraphique_);
                moteurgraphique_.viderVue();
                armee_.soeurAnne(moteurgraphique_, gameplay_);
                armee_.auras(moteurgraphique_, gameplay_);
                return true;
            }
            else
            {
                mouvOrNot = false;
                return false;
            }
        }
        public bool goEst(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            if (i + 1 < moteurgraphique_.longueur && moteurgraphique_.map[i + 1, j].estAccessible && mouvement >= moteurgraphique_.map[i + 1, j].coutEnMouvement)
            {
                mouvOrNot = false;
                debug = 0;
                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, -1);
                }

                moteurgraphique_.map[i, j].pointeurUnite = 0;
                moteurgraphique_.map[i, j].pointeurArmee = 0;
                moteurgraphique_.map[i, j].presence = false;
                moteurgraphique_.map[i, j].estAccessible = true;
                jDepart = 0;
                iDepart = 0;

                i++;

                if (aura != null)
                {
                    aura.ActiverAura(this, moteurgraphique_, gameplay_, 1);
                }
                mouvement -= moteurgraphique_.map[i, j].coutEnMouvement;
                sousrect.X = 0;
                tourner();
                state = e_EtatAnim.mouvement1;
                sousrect.Y = 256;
                vitesseAnim = 0.2f;
                jDepart = -1;
                iDepart = -1;
                moteurgraphique_.viderChemin();
                lookAtCheminsInitialize(moteurgraphique_);
                moteurgraphique_.viderVue();
                armee_.soeurAnne(moteurgraphique_, gameplay_);
                armee_.auras(moteurgraphique_, gameplay_);
                return true;
            }
            else
            {
                mouvOrNot = false;
                return false;
            }
        }
        #endregion

        private void lookAtChemins(MoteurGraphique moteurgraphique_,
            int poidsDesCasesParcourues, int i_, int j_)
        {
            //moteurgraphique_.map[i_, j_]
            if (moteurgraphique_.map[i_, j_].estAccessible &&
                poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement <= mouvement)
            {
                moteurgraphique_.map[i_, j_].cheminValid = true;
                if (moteurgraphique_.map[i_, j_].poidsAcces > poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement)
                {
                    moteurgraphique_.map[i_, j_].poidsAcces = poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement;
                }
                #region chemin possibles
                if (i_ > 0)
                {
                    lookAtChemins(moteurgraphique_,
                        poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement, i_ - 1, j_);
                }
                if (j_ > 0)
                {
                    lookAtChemins(moteurgraphique_,
                        poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement, i_, j_ - 1);
                }
                if (i_ + 1 < moteurgraphique_.longueur)
                {
                    lookAtChemins(moteurgraphique_,
                        poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement, i_ + 1, j_);
                }
                if (j_ + 1 < moteurgraphique_.largeur)
                {
                    lookAtChemins(moteurgraphique_,
                        poidsDesCasesParcourues + moteurgraphique_.map[i_, j_].coutEnMouvement, i_, j_ + 1);
                }
                #endregion
            }
        }
        public void lookAtCheminsInitialize(MoteurGraphique moteurgraphique_)
        {
            {
                moteurgraphique_.viderChemin();
                moteurgraphique_.map[i, j].poidsAcces = 0;
                #region chemin possibles
                if (i > 0)
                {
                    lookAtChemins(moteurgraphique_, 0, i - 1, j);
                }
                if (j > 0)
                {
                    lookAtChemins(moteurgraphique_, 0, i, j - 1);
                }
                if (i + 1 < moteurgraphique_.longueur)
                {
                    lookAtChemins(moteurgraphique_, 0, i + 1, j);
                }
                if (j + 1 < moteurgraphique_.largeur)
                {
                    lookAtChemins(moteurgraphique_, 0, i, j + 1);
                }
                #endregion
                poidsPathFindingLoohy(moteurgraphique_);
            }
        }

        // Pathfinding nico

        private void NicoSearch(MoteurGraphique moteurgraphique_, int ox_, int oy_)
        {
            int ghostX, ghostY;

            ghostX = i;
            ghostY = j;

            while (een && (ghostX != ox_ || ghostY != oy_))
            {
                Console.WriteLine("Chemin : ");

                if (i < moteurgraphique_.longueur - 1 && moteurgraphique_.map[ghostX + 1, ghostY].estAccessible)
                {
                    ghostX++;
                }
                else if (i > 1 && moteurgraphique_.map[ghostX - 1, ghostY].estAccessible)
                {
                    ghostX--;
                }
                else if (j < moteurgraphique_.largeur - 1 && moteurgraphique_.map[ghostX, ghostY + 1].estAccessible)
                {
                    ghostY++;
                }
                else if (j > 1 && moteurgraphique_.map[ghostX, ghostY - 1].estAccessible)
                {
                    ghostY--;
                }
            }
            Console.WriteLine();
        }

        // Pathfinding Loohy
        public void poidsPathFindingLoohy(MoteurGraphique moteurgraphique_)
        {
            for (int k = 0; k < mouvement; k++)
            {
                if (i + k >= 0 && i + k < moteurgraphique_.longueur
                    && j + (mouvement - k) >= 0 && j + (mouvement - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + k, j + (mouvement - k)].plusPetitPoidsAlentour(moteurgraphique_);
                }
                if (i - k >= 0 && i - k < moteurgraphique_.longueur
                     && j - (mouvement - k) >= 0 && j - (mouvement - k) < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - k, j - (mouvement - k)].plusPetitPoidsAlentour(moteurgraphique_);
                }
                if (i + (mouvement - k) >= 0 && i + (mouvement - k) < moteurgraphique_.longueur
                     && j - k >= 0 && j - k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i + (mouvement - k), j - k].plusPetitPoidsAlentour(moteurgraphique_);
                }
                if (i - (mouvement - k) >= 0 && i - (mouvement - k) < moteurgraphique_.longueur
                     && j + k >= 0 && j + k < moteurgraphique_.largeur)
                {
                    moteurgraphique_.map[i - (mouvement - k), j + k].plusPetitPoidsAlentour(moteurgraphique_);
                }
            }
        }
        public void PathFindingLoohy(MoteurGraphique moteurgraphique_, int iArrivee_, int jArrivee_)
        {
            if (debug < 1000)
            {
                debug++;
                if (iArrivee_ != ivirtuel || jArrivee_ != jvirtuel)
                {
                    #region Arriver sur la case la plus legere a cote
                    if (iArrivee_ != 0 && moteurgraphique_.map[iArrivee_ - 1, jArrivee_].poidsAcces < moteurgraphique_.map[iArrivee_ + 1, jArrivee_].poidsAcces)//SNE
                    {
                        if (moteurgraphique_.map[iArrivee_ - 1, jArrivee_].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ - 1].poidsAcces)//SE
                        {
                            if (moteurgraphique_.map[iArrivee_ - 1, jArrivee_].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ + 1].poidsAcces)//E
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_ - 1, jArrivee_);
                            }
                            else//S
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ + 1);
                            }
                        }
                        else//SN
                        {
                            if (moteurgraphique_.map[iArrivee_, jArrivee_ - 1].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ + 1].poidsAcces)//N
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ - 1);
                            }
                            else//S
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ + 1);
                            }
                        }
                    }
                    else//SNO
                    {
                        if (moteurgraphique_.map[iArrivee_ + 1, jArrivee_].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ - 1].poidsAcces)//SO
                        {
                            if (moteurgraphique_.map[iArrivee_ + 1, jArrivee_].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ + 1].poidsAcces)//O
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_ + 1, jArrivee_);
                            }
                            else//S
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ + 1);
                            }
                        }
                        else//SN
                        {
                            if (moteurgraphique_.map[iArrivee_, jArrivee_ - 1].poidsAcces < moteurgraphique_.map[iArrivee_, jArrivee_ + 1].poidsAcces)//N
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ - 1);
                            }
                            else//S
                            {
                                PathFindingLoohy(moteurgraphique_, iArrivee_, jArrivee_ + 1);
                            }
                        }
                    }
                    #endregion
                    #region Puis Mouv
                    if (iArrivee_ == ivirtuel - 1 && jArrivee_ == jvirtuel)
                    {
                        AddOuest();
                    }
                    else
                    {
                        if (iArrivee_ == ivirtuel + 1 && jArrivee_ == jvirtuel)
                        {
                            AddEst();
                        }
                        else
                        {
                            if (jArrivee_ == jvirtuel - 1 && iArrivee_ == ivirtuel)
                            {
                                AddNord();
                            }
                            else
                            {
                                if (jArrivee_ == jvirtuel + 1 && iArrivee_ == ivirtuel)
                                {
                                    AddSud();
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        public void lireLaFile(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_)
        {
            if (fileDeMouvements.Count > 0)
            {
                if (IA.difficulte != 0 ||state == e_EtatAnim.repos1 || state == e_EtatAnim.repos2)
                {
                    switch (fileDeMouvements[0])
                    {
                        case mouv.Sud:
                            goSud(moteurgraphique_, armee_, gameplay_);
                            break;
                        case mouv.Nord:
                            goNord(moteurgraphique_, armee_, gameplay_);
                            break;
                        case mouv.Est:
                            goEst(moteurgraphique_, armee_, gameplay_);
                            break;
                        case mouv.Ouest:
                            goOuest(moteurgraphique_, armee_, gameplay_);
                            break;
                        default:
                            break;
                    }
                    //depiler
                    fileDeMouvements.RemoveAt(0);
                }
            }
        }

        #region Addmouv
        public void AddEst()
        {
            fileDeMouvements.Add(mouv.Est);
            ivirtuel++;
        }
        public void AddOuest()
        {
            fileDeMouvements.Add(mouv.Ouest);
            ivirtuel--;
        }
        public void AddSud()
        {
            fileDeMouvements.Add(mouv.Sud);
            jvirtuel++;
        }
        public void AddNord()
        {
            fileDeMouvements.Add(mouv.Nord);
            jvirtuel--;
        }
        #endregion

        public void utiliserIA(MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_, HUD hud_)
        {
            if (fileDeMouvements.Count == 0)
            {
                IA.Play(this, moteurgraphique_, armee_, gameplay_, hud_);
            }
        }
        public void reactiverIA()
        {
            IA.finish = false;
        }

        private void rotation()
        {
            switch (sousrect.X)
            {
                case 0://est
                    sousrect.X = 128;
                    break;
                case 128://sud
                    sousrect.X = 256;
                    break;
                case 256://ouest
                    sousrect.X = 128 * 3;
                    break;
                default://nord
                    sousrect.X = 0;
                    break;
            }
        }
        private void tourner()
        {
            for (int n = 0; n < nombreDeRotations; n++)
            {
                rotation();
            }
        }

        public bool HaveBonus()
        {
            if (bonusArmure == 0 && bonusAttaque == 0 && bonusCoupcritique == 0 && bonusEsquive == 0 && bonusInitiative == 0
                && bonusprecision == 0 && bonuspuissance == 0 && bonusresistance == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
