using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    // ci-dessous à intégrer je sais pas trop dans quelle situation correspondront tels ou tels caractères. avis à toutes suggestions
    enum e_caractere
    {
        Defensive, Aggressive, Lache, Passive
    }

    class IntelligenceArtificielle
    {
        public int difficulte; //1 : facile 2 : moyen 3 : difficile 0 : joueur
        public bool finish;
        bool unitSelect;
        bool cibleAcquise;
        bool ilABouger;
        bool ilAFaussementBouger;
        bool dejaBienPlace;
        int iArrivee;
        int jArrivee;

        public IntelligenceArtificielle(int difficulte_, Unite moi_)
        {
            iArrivee = moi_.i;
            jArrivee = moi_.j;
            difficulte = difficulte_;
            finish = true;
            cibleAcquise = false;
            ilABouger = false;
            ilAFaussementBouger = false;
            dejaBienPlace = false;
        }

        #region IAjoute

        // region ci-dessous pas très utile mais on pourrait toujours la mettre dans un tutoriel ?
        #region IAdebilejoute
        public void checkContenuDansPorteeDebileJoute(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, HUD hud_)
        {
            //cible : gameplay_.armees[moteurgraphique_.map[i_, j_].pointeurArmee].bataillon[moteurgraphique_.map[i_, j_].pointeurUnite]
            cibleAcquise = false;
            for (int k = 0; k < portee_; k++)
            {
                if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur
                    && moi_.j + (portee_ - k) >= 0 && moi_.j + (portee_ - k) < moteurgraphique_.largeur)
                {
                    if (moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].presence && cibleAcquise == false &&
                        moi_.attaqOrNot && moi_.numeroArmee != moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee)
                    {
                        moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee]
                            .bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurUnite], portee_,
                            moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                        cibleAcquise = true;
                    }
                }
                if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur
                     && moi_.j - (portee_ - k) >= 0 && moi_.j - (portee_ - k) < moteurgraphique_.largeur)
                {
                    if (moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].presence && cibleAcquise == false &&
                        moi_.attaqOrNot && moi_.numeroArmee != moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee)
                    {
                        moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee]
                            .bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurUnite], portee_,
                            moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                        cibleAcquise = true;
                    }
                }
                if (moi_.i + (portee_ - k) >= 0 && moi_.i + (portee_ - k) < moteurgraphique_.longueur
                     && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                {
                    if (moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].presence && cibleAcquise == false &&
                        moi_.attaqOrNot && moi_.numeroArmee != moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee)
                    {
                        moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee]
                            .bataillon[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurUnite], portee_,
                            moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                        cibleAcquise = true;
                    }
                }
                if (moi_.i - (portee_ - k) >= 0 && moi_.i - (portee_ - k) < moteurgraphique_.longueur
                     && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                {
                    if (moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].presence && cibleAcquise == false &&
                        moi_.attaqOrNot && moi_.numeroArmee != moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee)
                    {
                        moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee]
                            .bataillon[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurUnite], portee_,
                            moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                        cibleAcquise = true;
                    }
                }
            }
        }

        public void deplacementRandomJoute(MoteurGraphique moteurgraphique_, Armee armee_, Unite moi_, SystemeDeJeu gameplay_)
        {
            Random r = new Random();
            int i = moi_.i;
            int j = moi_.j;
            ilABouger = false;
            switch (r.Next(100) % 4)
            {
                case 0:
                    moi_.goEst(moteurgraphique_, armee_, gameplay_);
                    break;
                case 1:
                    moi_.goNord(moteurgraphique_, armee_, gameplay_);
                    break;
                case 2:
                    moi_.goOuest(moteurgraphique_, armee_, gameplay_);
                    break;
                case 3:
                    moi_.goSud(moteurgraphique_, armee_, gameplay_);
                    break;
                default:
                    break;
            }
            if (moi_.i != i && moi_.j != j)
            {
                ilABouger = true;
            }
        }

        public void PlayDebileJoute(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, HUD hud_)
        {
            if (moi_.mouvement > 0 && moi_.attaqOrNot)
            {
                for (int portee_ = 1; portee_ < 7; portee_++)
                {
                    if (moi_.portee[portee_] > -1)
                    {
                        checkContenuDansPorteeDebileJoute(moteurgraphique_, portee_, moi_, gameplay_, hud_);
                    }
                }
                deplacementRandomJoute(moteurgraphique_, gameplay_.listeDesJoueurs[gameplay_.tourencours], moi_, gameplay_);
                if (!ilABouger)
                {
                    finish = true;
                }
            }
            else
            {
                finish = true;
            }
        }
        #endregion

        /* je tiens à préciser que le fait que l'IA ci-dessous fasse parfois des déplacements inutiles est NORMAL et il en est de même pour les autres IAfacile
        (faut rester dans la tradition des IA faciles un peu bêbêtes :p) */
        #region IAfacilejoute

        /* pour la fonction ci-dessous (et toutes les checkContenu) il faut que dans son appel portee_ soit les differentes portées d'attaque de l'unité
           ce qui n'est pas le cas pour l'instant d'ou les "trop loin" qui apparaissent souvent dans les animations */
        public void checkContenuDansPorteeFacileJoute(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            //cible : gameplay_.armees[moteurgraphique_.map[i_, j_].pointeurArmee].bataillon[moteurgraphique_.map[i_, j_].pointeurUnite]
            List<Unite> ciblesPotentielles = new List<Unite>();
            List<int> porteesPotentielles = new List<int>();

            if (moi_.alive)
            {
                if (moi_.attaqOrNot)
                {
                    #region boucleTestCiblesPotentielles

                    for (int k = 0; k < portee_; k++)
                    {
                        if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur
                            && moi_.j + (portee_ - k) >= 0 && moi_.j + (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(portee_);
                            }
                        }
                        if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur
                             && moi_.j - (portee_ - k) >= 0 && moi_.j - (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(portee_);
                            }
                        }
                        if (moi_.i + (portee_ - k) >= 0 && moi_.i + (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurUnite]);
                                porteesPotentielles.Add(portee_);
                            }
                        }
                        if (moi_.i - (portee_ - k) >= 0 && moi_.i - (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurUnite]);
                                porteesPotentielles.Add(portee_);
                            }
                        }
                    }
                    for (int i = 0; i < ciblesPotentielles.Count - 1; i++)
                    {
                        if (!ciblesPotentielles[i].alive)
                        {
                            ciblesPotentielles.RemoveAt(i);
                            porteesPotentielles.RemoveAt(i);
                        }
                    }

                    #endregion

                    #region attaqueEfficacementUniteAvecLeMoinsDePV

                    //for (int w = ciblesPotentielles.Count - 1; w >= 0; w--)
                    //{
                    //    if (moi_.typedAttaque[porteesPotentielles[w]] == true)
                    //    {
                    //        if (moi_.attaque <= ciblesPotentielles[w].armure + ciblesPotentielles[w].bonusArmure)
                    //        {
                    //            ciblesPotentielles.RemoveAt(w);
                    //            porteesPotentielles.RemoveAt(w);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (moi_.attaque <= ciblesPotentielles[w].resistance + ciblesPotentielles[w].bonusresistance)
                    //        {
                    //            ciblesPotentielles.RemoveAt(w);
                    //            porteesPotentielles.RemoveAt(w);
                    //        }
                    //    }
                    //}

                    for (int galopa = 0; galopa < ciblesPotentielles.Count; galopa++)
                    {
                        if (Math.Abs((moi_.i - ciblesPotentielles[galopa].i) + (moi_.j - ciblesPotentielles[galopa].j)) >= 7)
                        {
                            ciblesPotentielles.RemoveAt(galopa);
                            porteesPotentielles.RemoveAt(galopa);
                        }
                    }

                    for (int ponyta = 0; ponyta < ciblesPotentielles.Count; ponyta++)
                    {
                        if (moi_.portee[Math.Abs((moi_.i - ciblesPotentielles[ponyta].i) + (moi_.j - ciblesPotentielles[ponyta].j))] <= 0)
                        {
                            ciblesPotentielles.RemoveAt(ponyta);
                            porteesPotentielles.RemoveAt(ponyta);
                        }
                    }

                    do
                    {
                        for (int i = 0; i < ciblesPotentielles.Count - 1; i++)
                        {
                            if (ciblesPotentielles[i].pvactuel < ciblesPotentielles[i + 1].pvactuel)
                            {
                                ciblesPotentielles.RemoveAt(i + 1);
                                porteesPotentielles.RemoveAt(i + 1);
                            }
                            else
                            {
                                ciblesPotentielles.RemoveAt(i);
                                porteesPotentielles.RemoveAt(i);
                            }
                        }
                    } while (ciblesPotentielles.Count > 1);

                    if (ciblesPotentielles.Count > 0)
                    {
                        moi_.Initiative(ciblesPotentielles[0], porteesPotentielles[0], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                    }
                    #endregion
                }
            }
        }

        public void deplacementFacileJoute(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Unite moi_, Armee armee_)
        {
            ilABouger = false;
            List<int> distanceAvecEnnemis = new List<int>();
            List<Vector2> positionsEnnemies = new List<Vector2>();

            if (moi_.alive)
            {
                for (int youhou = 0; youhou < gameplay_.listeDesJoueurs.Count; youhou++)
                {
                    if (gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[youhou].camp)
                    {
                        foreach (Unite unite in gameplay_.listeDesJoueurs[(gameplay_.tourencours + 1) % 2].bataillon)
                        {
                            if (unite.alive)
                            {
                                distanceAvecEnnemis.Add(Math.Abs(moi_.i - unite.i) + Math.Abs(moi_.j - unite.j));
                                positionsEnnemies.Add(new Vector2(unite.i, unite.j));
                            }
                        }
                    }
                }

                #region trouverEnnemiLePlusProche

                do
                {
                    for (int i = 0; i < distanceAvecEnnemis.Count - 1; i++)
                    {
                        if (distanceAvecEnnemis[i] < distanceAvecEnnemis[i + 1])
                        {
                            distanceAvecEnnemis.RemoveAt(i + 1);
                            positionsEnnemies.RemoveAt(i + 1);
                        }
                        else
                        {
                            distanceAvecEnnemis.RemoveAt(i);
                            positionsEnnemies.RemoveAt(i);
                        }
                    }
                } while (distanceAvecEnnemis.Count > 1);

                if (positionsEnnemies.Count > 0)
                {
                    if (!gameplay_.listeDesJoueurs[moteurgraphique_.map[(int)positionsEnnemies[0].X, (int)positionsEnnemies[0].Y].pointeurArmee].bataillon[moteurgraphique_.map[(int)positionsEnnemies[0].X, (int)positionsEnnemies[0].Y].pointeurUnite].alive)
                    {
                        distanceAvecEnnemis[0] = -1;
                    }
                #endregion

                    #region deplacementVersEnnemiCiDessus
                    if (distanceAvecEnnemis[0] != -1)
                    {
                        for (int portee_ = 1; portee_ < 32; portee_++)
                        {
                            for (int k = 0; k < portee_; k++)
                            {
                                if (ilABouger == false)
                                {
                                    if (portee_ == distanceAvecEnnemis[0])
                                    {
                                        ilABouger = true;
                                    }
                                    else if ((int)positionsEnnemies[0].X + k >= 0 && (int)positionsEnnemies[0].X + k < moteurgraphique_.longueur &&
                                        (int)positionsEnnemies[0].Y + (portee_ - k) >= 0 && (int)positionsEnnemies[0].Y + (portee_ - k) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)positionsEnnemies[0].X + k, (int)positionsEnnemies[0].Y + (portee_ - k)].cheminValid)
                                        {
                                            ilABouger = true;
                                            iArrivee = (int)positionsEnnemies[0].X + k;
                                            jArrivee = (int)positionsEnnemies[0].Y + (portee_ - k);
                                            moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + k, (int)positionsEnnemies[0].Y + (portee_ - k));
                                        }

                                        else if ((int)positionsEnnemies[0].X - k >= 0 && (int)positionsEnnemies[0].X - k < moteurgraphique_.longueur &&
                                                 (int)positionsEnnemies[0].Y - (portee_ - k) >= 0 && (int)positionsEnnemies[0].Y - (portee_ - k) < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)positionsEnnemies[0].X - k, (int)positionsEnnemies[0].Y - (portee_ - k)].cheminValid)
                                            {
                                                ilABouger = true;
                                                iArrivee = (int)positionsEnnemies[0].X - k;
                                                jArrivee = (int)positionsEnnemies[0].Y - (portee_ - k);
                                                moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - k, (int)positionsEnnemies[0].Y - (portee_ - k));
                                            }

                                            else if ((int)positionsEnnemies[0].X + (portee_ - k) >= 0 && (int)positionsEnnemies[0].X + (portee_ - k) < moteurgraphique_.longueur &&
                                                     (int)positionsEnnemies[0].Y - k >= 0 && (int)positionsEnnemies[0].Y - k < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)positionsEnnemies[0].X + (portee_ - k), (int)positionsEnnemies[0].Y - k].cheminValid)
                                                {
                                                    ilABouger = true;
                                                    iArrivee = (int)positionsEnnemies[0].X + (portee_ - k);
                                                    jArrivee = (int)positionsEnnemies[0].Y - k;
                                                    moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + (portee_ - k), (int)positionsEnnemies[0].Y - k);
                                                }

                                                else if ((int)positionsEnnemies[0].X - (portee_ - k) >= 0 && (int)positionsEnnemies[0].X - (portee_ - k) < moteurgraphique_.longueur &&
                                                         (int)positionsEnnemies[0].Y + k >= 0 && (int)positionsEnnemies[0].Y + k < moteurgraphique_.largeur)
                                                {
                                                    if (moteurgraphique_.map[(int)positionsEnnemies[0].X - (portee_ - k), (int)positionsEnnemies[0].Y + k].cheminValid)
                                                    {
                                                        ilABouger = true;
                                                        iArrivee = (int)positionsEnnemies[0].X - (portee_ - k);
                                                        jArrivee = (int)positionsEnnemies[0].Y + k;
                                                        moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - (portee_ - k), (int)positionsEnnemies[0].Y + k);
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
            }
        }

        public void PlayFacileJoute(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            List<int> porteeeeeeeeeeesValables = new List<int>();
            for (int i = 0; i < 7; i++)
            {
                if (moi_.portee[i] > 0)
                {
                    porteeeeeeeeeeesValables.Add(i);
                }
            }

            foreach (int portee_ in porteeeeeeeeeeesValables)
            {
                checkContenuDansPorteeFacileJoute(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
            }

            deplacementFacileJoute(moteurgraphique_, gameplay_, moi_, armee_);

            if (moi_.attaqOrNot)
            {
                foreach (int portee_ in porteeeeeeeeeeesValables)
                {
                    checkContenuDansPorteeFacileJoute(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                }
            }

            finish = true;

        }

        #endregion

        #region IAmoyenjoute

        public void checkContenuDansPorteeMoyenJoute(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            //cible : gameplay_.armees[moteurgraphique_.map[i_, j_].pointeurArmee].bataillon[moteurgraphique_.map[i_, j_].pointeurUnite]
            List<Unite> ciblesPotentielles = new List<Unite>();
            List<int> porteesPotentielles = new List<int>();

            #region boucleTestCiblesPotentielles
            if (moi_.attaqOrNot)
            {
                for (int k = 0; k < portee_; k++)
                {
                    if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur
                        && moi_.j + (portee_ - k) >= 0 && moi_.j + (portee_ - k) < moteurgraphique_.largeur)
                    {
                        if (moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].presence &&
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].camp)
                        {
                            ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurUnite]);
                            porteesPotentielles.Add(portee_);
                        }
                    }
                    if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur
                         && moi_.j - (portee_ - k) >= 0 && moi_.j - (portee_ - k) < moteurgraphique_.largeur)
                    {
                        if (moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].presence &&
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].camp)
                        {
                            ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurUnite]);
                            porteesPotentielles.Add(portee_);
                        }
                    }
                    if (moi_.i + (portee_ - k) >= 0 && moi_.i + (portee_ - k) < moteurgraphique_.longueur
                         && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                    {
                        if (moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].presence &&
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].camp)
                        {
                            ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurUnite]);
                            porteesPotentielles.Add(portee_);
                        }
                    }
                    if (moi_.i - (portee_ - k) >= 0 && moi_.i - (portee_ - k) < moteurgraphique_.longueur
                         && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                    {
                        if (moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].presence &&
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].camp)
                        {
                            ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurUnite]);
                            porteesPotentielles.Add(portee_);
                        }
                    }
                }


                for (int i = 0; i < ciblesPotentielles.Count - 1; i++)
                {
                    if (!ciblesPotentielles[i].alive)
                    {
                        ciblesPotentielles.RemoveAt(i);
                        porteesPotentielles.RemoveAt(i);
                    }
                }

            #endregion

                // la région ci-dessous serait probablement le caractère agressif
                #region attaqueEfficacementUniteAvecLaMeilleurePrecisionEtLeMoinsDePV

                for (int w = ciblesPotentielles.Count - 1; w >= 0; w--)
                {
                    if (moi_.typedAttaque[porteesPotentielles[w]] == true)
                    {
                        if (moi_.attaque <= ciblesPotentielles[w].armure + ciblesPotentielles[w].bonusArmure)
                        {
                            ciblesPotentielles.RemoveAt(w);
                            porteesPotentielles.RemoveAt(w);
                        }
                    }
                    else
                    {
                        if (moi_.attaque <= ciblesPotentielles[w].resistance + ciblesPotentielles[w].bonusresistance)
                        {
                            ciblesPotentielles.RemoveAt(w);
                            porteesPotentielles.RemoveAt(w);
                        }
                    }
                }

                do
                {
                    for (int j = 0; j < ciblesPotentielles.Count - 1; j++)
                    {
                        if (ciblesPotentielles[j].pvactuel < ciblesPotentielles[j + 1].pvactuel)
                        {
                            ciblesPotentielles.RemoveAt(j + 1);
                            porteesPotentielles.RemoveAt(j + 1);
                        }
                        else
                        {
                            ciblesPotentielles.RemoveAt(j);
                            porteesPotentielles.RemoveAt(j);
                        }
                    }
                } while (ciblesPotentielles.Count > 1);

                if (ciblesPotentielles.Count > 0)
                {
                    moi_.Initiative(ciblesPotentielles[0], porteesPotentielles[0], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                }
            }
                #endregion
        }

        public void deplacementMoyenJoute(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Unite moi_, Armee armee_, HUD hud_)
        {
            dejaBienPlace = false;
            ilABouger = false;
            List<Unite> unitesEnnemis = new List<Unite>();
            List<int> distanceAvecEnnemis = new List<int>();
            List<Vector2> positionsEnnemies = new List<Vector2>();
            List<int> porteesDeMeilleuresPrecisions = new List<int>();
            int porteeMax = 0;

            if (moi_.alive)
            {
                for (int c = 0; c < 7; c++)
                {
                    if (moi_.portee[c] > 0)
                    {
                        porteeMax = c;
                    }
                }

                #region ajouterToutesLesUnitesEnnemies

                for (int wazaaa = 0; wazaaa < gameplay_.listeDesJoueurs.Count; wazaaa++)
                {
                    if (gameplay_.listeDesJoueurs[wazaaa].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp)
                    {
                        foreach (Unite unite in gameplay_.listeDesJoueurs[wazaaa].bataillon)
                        {
                            if (unite.alive && Math.Abs(moi_.i - unite.i) + Math.Abs(moi_.j - unite.j) <= (moi_.mouvement + porteeMax))
                            {
                                unitesEnnemis.Add(unite);
                                distanceAvecEnnemis.Add(Math.Abs(moi_.i - unite.i) + Math.Abs(moi_.j - unite.j));
                                positionsEnnemies.Add(new Vector2(unite.i, unite.j));
                            }
                        }
                    }
                }

                #endregion

                #region obtenirUneListeDesMeilleuresPorteesDePrecision

                for (int f = 10; f > 0; f--)
                {
                    for (int g = porteeMax; g > 0; g--)
                    {
                        if (moi_.portee[g] == f)
                        {
                            porteesDeMeilleuresPrecisions.Add(g);
                        }
                    }
                }
                #endregion

                #region trouverEnnemiLeMieuxPlace

                #region preTestDuLosange

                for (int i = distanceAvecEnnemis.Count - 1; i >= 0; i--)
                {
                    ilAFaussementBouger = false;

                    for (int n = porteesDeMeilleuresPrecisions.Count - 1; n > 0; n--)
                    {
                        for (int j = 0; j <= porteesDeMeilleuresPrecisions[n] - 1; j++)
                        {
                            if (ilABouger == false && dejaBienPlace == false)
                            {
                                if (porteesDeMeilleuresPrecisions[n] == distanceAvecEnnemis[i])
                                {
                                    ilAFaussementBouger = true;
                                }
                                else
                                {
                                    if ((int)positionsEnnemies[i].X + j >= 0 && (int)positionsEnnemies[i].X + j < moteurgraphique_.longueur &&
                                        (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)positionsEnnemies[i].X + j, (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j)].cheminValid)
                                        {
                                            ilAFaussementBouger = true;
                                        }
                                        else if ((int)positionsEnnemies[i].X - j >= 0 && (int)positionsEnnemies[i].X - j < moteurgraphique_.longueur &&
                                                 (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)positionsEnnemies[i].X - j, (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j)].cheminValid)
                                            {
                                                ilAFaussementBouger = true;
                                            }
                                            else if ((int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.longueur &&
                                                     (int)positionsEnnemies[i].Y - j >= 0 && (int)positionsEnnemies[i].Y - j < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j), (int)positionsEnnemies[i].Y - j].cheminValid)
                                                {
                                                    ilAFaussementBouger = true;
                                                }
                                                else if ((int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.longueur &&
                                                         (int)positionsEnnemies[i].Y + j >= 0 && (int)positionsEnnemies[i].Y + j < moteurgraphique_.largeur)
                                                {
                                                    if (moteurgraphique_.map[(int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j), (int)positionsEnnemies[i].Y + j].cheminValid)
                                                    {
                                                        ilAFaussementBouger = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (ilAFaussementBouger == false)
                    {
                        distanceAvecEnnemis.RemoveAt(i);
                        unitesEnnemis.RemoveAt(i);
                        positionsEnnemies.RemoveAt(i);
                    }
                }
                #endregion

                while (distanceAvecEnnemis.Count > 1)
                {
                    for (int i = 0; i < distanceAvecEnnemis.Count - 1; i++)
                    {
                        if (gameplay_.listeDesJoueurs[moteurgraphique_.map[(int)positionsEnnemies[i].X, (int)positionsEnnemies[i].Y].pointeurArmee].bataillon[moteurgraphique_.map[(int)positionsEnnemies[i].X, (int)positionsEnnemies[i].Y].pointeurUnite].pvactuel <
                            gameplay_.listeDesJoueurs[moteurgraphique_.map[(int)positionsEnnemies[i + 1].X, (int)positionsEnnemies[i + 1].Y].pointeurArmee].bataillon[moteurgraphique_.map[(int)positionsEnnemies[i + 1].X, (int)positionsEnnemies[i + 1].Y].pointeurUnite].pvactuel)
                        {
                            unitesEnnemis.RemoveAt(i + 1);
                            positionsEnnemies.RemoveAt(i + 1);
                            distanceAvecEnnemis.RemoveAt(i + 1);
                        }
                        else
                        {
                            unitesEnnemis.RemoveAt(i);
                            positionsEnnemies.RemoveAt(i);
                            distanceAvecEnnemis.RemoveAt(i);
                        }
                    }
                }

                #endregion

                #region deplacementVersEnnemiLePlusPratique

                if (distanceAvecEnnemis.Count > 0)
                {
                    #region seMettreALaMeilleurePortee

                    for (int i = 0; i < porteesDeMeilleuresPrecisions.Count; i++)
                    {
                        for (int j = 0; j <= porteesDeMeilleuresPrecisions[i] - 1; j++)
                        {
                            if (ilABouger == false && dejaBienPlace == false)
                            {
                                if (porteesDeMeilleuresPrecisions[i] == distanceAvecEnnemis[0])
                                {
                                    dejaBienPlace = true;
                                    moi_.Initiative(unitesEnnemis[0], porteesDeMeilleuresPrecisions[i], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                }
                                else
                                {
                                    if ((int)positionsEnnemies[0].X + j >= 0 && (int)positionsEnnemies[0].X + j < moteurgraphique_.longueur &&
                                        (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)positionsEnnemies[0].X + j, (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j)].cheminValid)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + j, (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j));
                                        }
                                        else if ((int)positionsEnnemies[0].X - j >= 0 && (int)positionsEnnemies[0].X - j < moteurgraphique_.longueur &&
                                                 (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)positionsEnnemies[0].X - j, (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j)].cheminValid)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - j, (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j));
                                            }
                                            else if ((int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.longueur &&
                                                     (int)positionsEnnemies[0].Y - j >= 0 && (int)positionsEnnemies[0].Y - j < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y - j].cheminValid)
                                                {
                                                    ilABouger = true;
                                                    moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y - j);
                                                }
                                                else if ((int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.longueur &&
                                                         (int)positionsEnnemies[0].Y + j >= 0 && (int)positionsEnnemies[0].Y + j < moteurgraphique_.largeur)
                                                {
                                                    if (moteurgraphique_.map[(int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y + j].cheminValid)
                                                    {
                                                        ilABouger = true;
                                                        moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y + j);
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
                }
                #endregion

                else
                {
                    deplacementFacileJoute(moteurgraphique_, gameplay_, moi_, armee_);
                }
            }

            if (dejaBienPlace == false && ilABouger == false && moi_.attaqOrNot)
            {
                deplacementFacileJoute(moteurgraphique_, gameplay_, moi_, armee_);
            }
        }

        public void PlayMoyenJoute(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            List<int> porteesDeMeilleuresPrecisions = new List<int>();

            #region obtenirUneListeDesMeilleuresPorteesDePrecision

            for (int f = 10; f > 0; f--)
            {
                for (int g = 6; g > 0; g--)
                {
                    if (moi_.portee[g] == f)
                    {
                        porteesDeMeilleuresPrecisions.Add(g);
                    }
                }
            }
            #endregion

            if (moi_.attaqOrNot)
            {
                for (int portee_ = 0; portee_ < porteesDeMeilleuresPrecisions.Count - 1; portee_++)
                {
                    checkContenuDansPorteeMoyenJoute(moteurgraphique_, porteesDeMeilleuresPrecisions[portee_], moi_, gameplay_, armee_, hud_);
                }
            }

            deplacementMoyenJoute(moteurgraphique_, gameplay_, moi_, armee_, hud_);
            if (moi_.attaqOrNot)
            {
                for (int portee_ = 0; portee_ < porteesDeMeilleuresPrecisions.Count - 1; portee_++)
                {
                    checkContenuDansPorteeMoyenJoute(moteurgraphique_, porteesDeMeilleuresPrecisions[portee_], moi_, gameplay_, armee_, hud_);
                }
            }

            deplacementMoyenJoute(moteurgraphique_, gameplay_, moi_, armee_, hud_);

            if (moi_.attaqOrNot)
            {
                for (int portee_ = 0; portee_ < porteesDeMeilleuresPrecisions.Count - 1; portee_++)
                {
                    checkContenuDansPorteeMoyenJoute(moteurgraphique_, porteesDeMeilleuresPrecisions[portee_], moi_, gameplay_, armee_, hud_);
                }
            }

            finish = true;

        }

        #endregion

        #region IAdifficilejoute

        public void checkContenuDansPorteeDifficileJoute()
        {

        }

        public void deplacementDifficileJoute()
        {

        }

        public void PlayDifficileJoute()
        {

        }



        #endregion

        #endregion

        #region IAtresor

        #region IAfaciletresor

        public void checkContenuDansPorteeFacileTresor(Unite moi_, SystemeDeJeu gameplay_, MoteurGraphique moteurgraphique_, Armee armee_, HUD hud_)
        {
            List<int> porteeeeeeeeeeesValables = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                if (moi_.portee[i] > 0)
                {
                    porteeeeeeeeeeesValables.Add(i);
                }
            }
            if (moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].presence == true)
            {
                if (gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee].camp)
                {
                    if (Math.Abs((moi_.i - gameplay_.tresor_i) + (moi_.j - gameplay_.tresor_j)) < 7)
                    {
                        if (moi_.portee[Math.Abs((moi_.i - gameplay_.tresor_i) + (moi_.j - gameplay_.tresor_j))] > 0)
                        {
                            moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee].bataillon[moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurUnite], Math.Abs((moi_.i - gameplay_.tresor_i) + (moi_.j - gameplay_.tresor_j)), moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                        }
                        else
                        {
                            foreach (int portee_ in porteeeeeeeeeeesValables)
                            {
                                checkContenuDansPorteeMoyenJoute(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                            }
                        }
                    }

                    else
                    {
                        foreach (int portee_ in porteeeeeeeeeeesValables)
                        {
                            checkContenuDansPorteeMoyenJoute(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                        }
                    }
                }
            }
        }

        public void deplacementFacileTresor(MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Unite moi_, Armee armee_)
        {
            // cible : gameplay_.armees[moteurgraphique_.map[i_, j_].pointeurArmee].bataillon[moteurgraphique_.map[i_, j_].pointeurUnite]

            ilABouger = false;
            if (moi_.alive)
            {
                if (moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee == -1 && moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].cheminValid)
                {
                    moi_.PathFindingLoohy(moteurgraphique_, gameplay_.tresor_i, gameplay_.tresor_j);
                }

                #region conditionSiJaiPasLeTresor
                if (moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee == -1 || (moi_.numeroArmee != moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee && gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee].camp))
                {
                    for (int portee_ = 0; portee_ < 32; portee_++)
                    {
                        for (int k = 0; k < portee_; k++)
                        {
                            if (gameplay_.tresor_i + k >= 0 && gameplay_.tresor_i + k < moteurgraphique_.longueur &&
                                gameplay_.tresor_j + (portee_ - k) >= 0 && gameplay_.tresor_j + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[gameplay_.tresor_i + k, gameplay_.tresor_j + (portee_ - k)].cheminValid &&
                                    ilABouger == false)
                                {
                                    ilABouger = true;
                                    moi_.PathFindingLoohy(moteurgraphique_, gameplay_.tresor_i + k, gameplay_.tresor_j + (portee_ - k));
                                }

                                else if (gameplay_.tresor_i - k >= 0 && gameplay_.tresor_i - k < moteurgraphique_.longueur &&
                                    gameplay_.tresor_j - (portee_ - k) >= 0 && gameplay_.tresor_j - (portee_ - k) < moteurgraphique_.largeur)
                                {
                                    if (moteurgraphique_.map[gameplay_.tresor_i - k, gameplay_.tresor_j - (portee_ - k)].cheminValid &&
                                        ilABouger == false)
                                    {
                                        ilABouger = true;
                                        moi_.PathFindingLoohy(moteurgraphique_, gameplay_.tresor_i - k, gameplay_.tresor_j - (portee_ - k));
                                    }

                                    else if (gameplay_.tresor_i + (portee_ - k) >= 0 && gameplay_.tresor_i + (portee_ - k) < moteurgraphique_.longueur &&
                                        gameplay_.tresor_j - k >= 0 && gameplay_.tresor_j - k < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[gameplay_.tresor_i + (portee_ - k), gameplay_.tresor_j - k].cheminValid &&
                                            ilABouger == false)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, gameplay_.tresor_i + (portee_ - k), gameplay_.tresor_j - k);
                                        }

                                        else if (gameplay_.tresor_i - (portee_ - k) >= 0 && gameplay_.tresor_i - (portee_ - k) < moteurgraphique_.longueur &&
                                            gameplay_.tresor_j + k >= 0 && gameplay_.tresor_j + k < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[gameplay_.tresor_i - (portee_ - k), gameplay_.tresor_j + k].cheminValid &&
                                                ilABouger == false)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, gameplay_.tresor_i - (portee_ - k), gameplay_.tresor_j + k);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion

                #region conditionSiJaiLeTresor
                else if (moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].presence &&
                             moi_.numeroArmee == moteurgraphique_.map[gameplay_.tresor_i, gameplay_.tresor_j].pointeurArmee)
                {
                    if (moi_.i == gameplay_.tresor_i && moi_.j == gameplay_.tresor_j)
                    {
                        for (int portee_ = 0; portee_ < 32; portee_++)
                        {
                            for (int k = 0; k < portee_; k++)
                            {
                                if ((int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + k >= 0 &&
                                    (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + k < moteurgraphique_.longueur &&
                                    (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + (portee_ - k) >= 0 &&
                                    (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + (portee_ - k) < moteurgraphique_.largeur)
                                {
                                    if (moteurgraphique_.map[(int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + k,
                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + (portee_ - k)].cheminValid &&
                                        ilABouger == false)
                                    {
                                        ilABouger = true;
                                        moi_.PathFindingLoohy(moteurgraphique_, (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + k,
                                            (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + (portee_ - k));
                                    }

                                    else if ((int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - k >= 0 &&
                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - k < moteurgraphique_.longueur &&
                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - (portee_ - k) >= 0 &&
                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - (portee_ - k) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - k,
                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - (portee_ - k)].cheminValid &&
                                        ilABouger == false)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - k,
                                                (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - (portee_ - k));
                                        }

                                        else if ((int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + (portee_ - k) >= 0 &&
                                            (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + (portee_ - k) < moteurgraphique_.longueur &&
                                            (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - k >= 0 &&
                                            (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - k < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + (portee_ - k),
                                            (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - k].cheminValid &&
                                            ilABouger == false)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X + (portee_ - k),
                                                    (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y - k);
                                            }

                                            else if ((int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - (portee_ - k) >= 0 &&
                                                (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - (portee_ - k) < moteurgraphique_.longueur &&
                                                (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + k >= 0 &&
                                                (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + k < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - (portee_ - k),
                                                (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + k].cheminValid &&
                                                ilABouger == false)
                                                {
                                                    ilABouger = true;
                                                    moi_.PathFindingLoohy(moteurgraphique_, (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.X - (portee_ - k),
                                                        (int)gameplay_.listeDesJoueurs[moi_.numeroArmee].QG.Y + k);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else // si une unité alliée a le trésor
                    {
                        deplacementFacileJoute(moteurgraphique_, gameplay_, moi_, armee_);
                    }
                }
                #endregion
            }
        }

        public void PlayFacileTresor(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            deplacementFacileTresor(moteurgraphique_, gameplay_, moi_, armee_);
            if (moi_.i != gameplay_.tresor_i && moi_.j != gameplay_.tresor_j)
            {
                for (int portee_ = 1; portee_ < 7; portee_++)
                {
                    if (moi_.portee[portee_] > -1)
                    {
                        checkContenuDansPorteeFacileTresor(moi_, gameplay_, moteurgraphique_, armee_, hud_);
                    }
                }
            }
            else
            {
                deplacementFacileTresor(moteurgraphique_, gameplay_, moi_, armee_);
            }

            finish = true;
        }

        #endregion

        // en construction
        #region IAdifficiletresor



        #endregion

        #endregion

        #region IAechiquier

        #region IAfacileEchiquier

        // même commentaire que pour checkContenuDansPorteeFacileJoute
        public void checkContenuDansPorteeFacileEchiquier(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            List<Unite> ciblesPotentielles = new List<Unite>();
            List<int> porteesPotentielles = new List<int>();
            int abscisseHerosEnnemi = -1;
            int ordonneeHerosEnnemi = -1;

            if (moi_.alive)
            {
                for (int i = 0; i < gameplay_.listeDesJoueurs.Count; i++)
                {
                    if (gameplay_.listeDesJoueurs[i].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp)
                    {
                        foreach (Unite unite in gameplay_.listeDesJoueurs[i].bataillon)
                        {
                            if (unite.typeUnite == e_typeUnite.Heros)
                            {
                                abscisseHerosEnnemi = unite.i;
                                ordonneeHerosEnnemi = unite.j;
                            }
                        }
                    }
                }

                #region boucleTestCiblesPotentielles

                if (moi_.attaqOrNot && moi_.typeUnite != e_typeUnite.Heros)
                {
                    for (int k = 0; k < portee_; k++)
                    {
                        if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur
                            && moi_.j + (portee_ - k) >= 0 && moi_.j + (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                        if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur
                             && moi_.j - (portee_ - k) >= 0 && moi_.j - (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                        if (moi_.i + (portee_ - k) >= 0 && moi_.i + (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                        if (moi_.i - (portee_ - k) >= 0 && moi_.i - (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                    }

                #endregion

                    #region attaquerHerosOuUniteAvecPlusBasPV

                    if (moi_.attaqOrNot)
                    {
                        do
                        {
                            for (int i = ciblesPotentielles.Count - 1; i >= 0; i--)
                            {
                                if (!ciblesPotentielles[i].alive)
                                {
                                    ciblesPotentielles.RemoveAt(i);
                                    porteesPotentielles.RemoveAt(i);
                                }
                            }

                            for (int j = 0; j < ciblesPotentielles.Count - 1; j++)
                            {
                                if (ciblesPotentielles[j].i == abscisseHerosEnnemi && ciblesPotentielles[j].j == ordonneeHerosEnnemi)
                                {
                                    if (moi_.portee[Math.Abs((moi_.i - abscisseHerosEnnemi) + (moi_.j - ordonneeHerosEnnemi))] > 0)
                                    {
                                        moi_.Initiative(ciblesPotentielles[j], porteesPotentielles[j], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                        ciblesPotentielles.RemoveRange(0, ciblesPotentielles.Count - 1);
                                    }
                                }
                            }

                            if (moi_.attaqOrNot)
                            {
                                for (int erf = ciblesPotentielles.Count - 1; erf >= 0; erf--)
                                {
                                    if (Math.Abs(moi_.i - ciblesPotentielles[erf].i) + (moi_.j - ciblesPotentielles[erf].j) >= 7)
                                    {
                                        ciblesPotentielles.RemoveAt(erf);
                                        porteesPotentielles.RemoveAt(erf);
                                    }

                                    if (moi_.portee[Math.Abs((moi_.i - ciblesPotentielles[erf].i) + (moi_.j - ciblesPotentielles[erf].j))] <= 0)
                                    {
                                        ciblesPotentielles.RemoveAt(erf);
                                        porteesPotentielles.RemoveAt(erf);
                                    }
                                }

                                for (int i = 0; i < ciblesPotentielles.Count - 1; i++)
                                {

                                    if (ciblesPotentielles[i].pvactuel < ciblesPotentielles[i + 1].pvactuel)
                                    {
                                        ciblesPotentielles.RemoveAt(i + 1);
                                        porteesPotentielles.RemoveAt(i + 1);
                                    }
                                    else
                                    {
                                        ciblesPotentielles.RemoveAt(i);
                                        porteesPotentielles.RemoveAt(i);
                                    }
                                }
                            }
                        } while (ciblesPotentielles.Count > 1 && moi_.attaqOrNot);
                    }
                    if (ciblesPotentielles.Count > 0)
                    {
                        moi_.Initiative(ciblesPotentielles[0], porteesPotentielles[0], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                    }
                }
                    #endregion
            }
        }

        public void deplacementFacileEchiquier(SystemeDeJeu gameplay_, MoteurGraphique moteurgraphique_, Unite moi_)
        {
            ilABouger = false;
            int abscisseHerosEnnemi = -1;
            int ordonneeHerosEnnemi = -1;
            if (moi_.alive)
            {
                for (int akwakwak = 0; akwakwak < gameplay_.listeDesJoueurs.Count; akwakwak++)
                {
                    if (gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[akwakwak].camp)
                    {
                        foreach (Unite unite in gameplay_.listeDesJoueurs[akwakwak].bataillon)
                        {
                            if (unite.typeUnite == e_typeUnite.Heros)
                            {
                                abscisseHerosEnnemi = unite.i;
                                ordonneeHerosEnnemi = unite.j;
                            }
                        }
                    }
                }

                if (abscisseHerosEnnemi != -1)
                {
                    for (int portee_ = 1; portee_ < 32; portee_++)
                    {
                        for (int k = 0; k < portee_; k++)
                        {
                            if (abscisseHerosEnnemi + k >= 0 && abscisseHerosEnnemi + k < moteurgraphique_.longueur &&
                                ordonneeHerosEnnemi + (portee_ - k) >= 0 && ordonneeHerosEnnemi + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[abscisseHerosEnnemi + k, ordonneeHerosEnnemi + (portee_ - k)].cheminValid &&
                                    ilABouger == false)
                                {
                                    ilABouger = true;
                                    moi_.PathFindingLoohy(moteurgraphique_, abscisseHerosEnnemi + k, ordonneeHerosEnnemi + (portee_ - k));
                                }

                                else if (abscisseHerosEnnemi - k >= 0 && abscisseHerosEnnemi - k < moteurgraphique_.longueur &&
                                    ordonneeHerosEnnemi - (portee_ - k) >= 0 && ordonneeHerosEnnemi - (portee_ - k) < moteurgraphique_.largeur)
                                {
                                    if (moteurgraphique_.map[abscisseHerosEnnemi - k, ordonneeHerosEnnemi - (portee_ - k)].cheminValid &&
                                        ilABouger == false)
                                    {
                                        ilABouger = true;
                                        moi_.PathFindingLoohy(moteurgraphique_, abscisseHerosEnnemi - k, ordonneeHerosEnnemi - (portee_ - k));
                                    }

                                    else if (abscisseHerosEnnemi + (portee_ - k) >= 0 && abscisseHerosEnnemi + (portee_ - k) < moteurgraphique_.longueur &&
                                        ordonneeHerosEnnemi - k >= 0 && ordonneeHerosEnnemi - k < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[abscisseHerosEnnemi + (portee_ - k), ordonneeHerosEnnemi - k].cheminValid &&
                                            ilABouger == false)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, abscisseHerosEnnemi + (portee_ - k), ordonneeHerosEnnemi - k);
                                        }

                                        else if (abscisseHerosEnnemi - (portee_ - k) >= 0 && abscisseHerosEnnemi - (portee_ - k) < moteurgraphique_.longueur &&
                                            ordonneeHerosEnnemi + k >= 0 && ordonneeHerosEnnemi + k < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[abscisseHerosEnnemi - (portee_ - k), ordonneeHerosEnnemi + k].cheminValid &&
                                                ilABouger == false)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, abscisseHerosEnnemi - (portee_ - k), ordonneeHerosEnnemi + k);
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

        public void PlayFacileEchiquier(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            for (int portee_ = 1; portee_ < 7; portee_++)
            {
                if (moi_.portee[portee_] > -1)
                {
                    checkContenuDansPorteeFacileEchiquier(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                }
            }
            if (moi_.attaqOrNot)
            {
                deplacementFacileEchiquier(gameplay_, moteurgraphique_, moi_);
                for (int portee_ = 1; portee_ < 7; portee_++)
                {
                    if (moi_.portee[portee_] > -1)
                    {
                        checkContenuDansPorteeFacileEchiquier(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                    }
                }
            }
            finish = true;
        }

        #endregion

        #region IAmoyenEchiquier

        public void checkContenuDansPorteeMoyenEchiquier(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            List<Unite> ciblesPotentielles = new List<Unite>();
            List<int> porteesPotentielles = new List<int>();
            int abscisseHerosEnnemi = -1;
            int ordonneeHerosEnnemi = -1;

            if (moi_.alive)
            {
                foreach (Unite unite in gameplay_.listeDesJoueurs[(gameplay_.tourencours + 1) % 2].bataillon)
                {
                    if (unite.typeUnite == e_typeUnite.Heros)
                    {
                        abscisseHerosEnnemi = unite.i;
                        ordonneeHerosEnnemi = unite.j;
                    }
                }

                #region boucleTestCiblesPotentielles

                if (moi_.attaqOrNot && moi_.typeUnite != e_typeUnite.Heros)
                {
                    for (int k = 0; k < portee_; k++)
                    {
                        if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur
                            && moi_.j + (portee_ - k) >= 0 && moi_.j + (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                        if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur
                             && moi_.j - (portee_ - k) >= 0 && moi_.j - (portee_ - k) < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (portee_ - k)].pointeurUnite]);
                                porteesPotentielles.Add(k); ;
                            }
                        }
                        if (moi_.i + (portee_ - k) >= 0 && moi_.i + (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i + (portee_ - k), moi_.j - k].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                        if (moi_.i - (portee_ - k) >= 0 && moi_.i - (portee_ - k) < moteurgraphique_.longueur
                             && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                        {
                            if (moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].presence &&
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].camp)
                            {
                                ciblesPotentielles.Add(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurArmee].
                                    bataillon[moteurgraphique_.map[moi_.i - (portee_ - k), moi_.j + k].pointeurUnite]);
                                porteesPotentielles.Add(k);
                            }
                        }
                    }

                #endregion

                    #region attaquerHerosOuUniteAvecPlusBasPV
                    do
                    {
                        if (moi_.attaqOrNot)
                        {
                            for (int i = ciblesPotentielles.Count - 1; i >= 0; i--)
                            {
                                if (!ciblesPotentielles[i].alive)
                                {
                                    ciblesPotentielles.RemoveAt(i);
                                    porteesPotentielles.RemoveAt(i);
                                }
                            }

                            for (int j = 0; j < ciblesPotentielles.Count - 1; j++)
                            {
                                if (ciblesPotentielles[j].i == abscisseHerosEnnemi && ciblesPotentielles[j].j == ordonneeHerosEnnemi)
                                {
                                    moi_.Initiative(ciblesPotentielles[j], porteesPotentielles[j], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                    ciblesPotentielles.RemoveRange(0, ciblesPotentielles.Count - 1);
                                }
                            }

                            if (moi_.attaqOrNot)
                            {
                                for (int i = ciblesPotentielles.Count - 2; i >= 0; i--)
                                {
                                    if (ciblesPotentielles[i].pvactuel < ciblesPotentielles[i + 1].pvactuel)
                                    {
                                        ciblesPotentielles.RemoveAt(i + 1);
                                        porteesPotentielles.RemoveAt(i + 1);
                                    }
                                    else
                                    {
                                        ciblesPotentielles.RemoveAt(i);
                                        porteesPotentielles.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    } while (ciblesPotentielles.Count > 1 && moi_.attaqOrNot);

                    if (ciblesPotentielles.Count > 0)
                    {
                        moi_.Initiative(ciblesPotentielles[0], porteesPotentielles[0], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                    }
                }
                    #endregion
            }
        }

        public void deplacementMoyenEchiquier(SystemeDeJeu gameplay_, MoteurGraphique moteurgraphique_, Unite moi_, Armee armee_, HUD hud_)
        {
            dejaBienPlace = false;
            unitSelect = false;
            ilABouger = false;
            List<Unite> unitesEnnemis = new List<Unite>();
            List<int> distanceAvecEnnemis = new List<int>();
            List<Vector2> positionsEnnemies = new List<Vector2>();
            List<int> porteesDeMeilleuresPrecisions = new List<int>();
            int porteeMax = 0;

            if (moi_.alive)
            {
                for (int c = 0; c < 7; c++)
                {
                    if (moi_.portee[c] > 0)
                    {
                        porteeMax = c;
                    }
                }

                #region ajouterToutesLesUnitesEnnemies

                for (int wazaaa = 0; wazaaa < gameplay_.listeDesJoueurs.Count; wazaaa++)
                {
                    if (gameplay_.listeDesJoueurs[wazaaa].camp != gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp)
                    {
                        foreach (Unite unite in gameplay_.listeDesJoueurs[wazaaa].bataillon)
                        {
                            if (unite.alive && Math.Abs(moi_.i - unite.i) + Math.Abs(moi_.j - unite.j) <= (moi_.mouvement + porteeMax))
                            {
                                unitesEnnemis.Add(unite);
                                distanceAvecEnnemis.Add(Math.Abs(moi_.i - unite.i) + Math.Abs(moi_.j - unite.j));
                                positionsEnnemies.Add(new Vector2(unite.i, unite.j));
                            }
                        }
                    }
                }

                #endregion

                #region obtenirUneListeDesMeilleuresPorteesDePrecision

                for (int f = 10; f > 0; f--)
                {
                    for (int g = porteeMax; g > 0; g--)
                    {
                        if (moi_.portee[g] == f)
                        {
                            porteesDeMeilleuresPrecisions.Add(g);
                        }
                    }
                }
                #endregion

                #region trouverEnnemiLeMieuxPlace

                #region preTestDuLosange

                for (int i = distanceAvecEnnemis.Count - 1; i >= 0; i--)
                {
                    ilAFaussementBouger = false;

                    for (int n = porteesDeMeilleuresPrecisions.Count - 1; n > 0; n--)
                    {
                        for (int j = 0; j <= porteesDeMeilleuresPrecisions[n] - 1; j++)
                        {
                            if (ilABouger == false && dejaBienPlace == false)
                            {
                                if (porteesDeMeilleuresPrecisions[n] == distanceAvecEnnemis[i])
                                {
                                    ilAFaussementBouger = true;
                                }
                                else
                                {
                                    if ((int)positionsEnnemies[i].X + j >= 0 && (int)positionsEnnemies[i].X + j < moteurgraphique_.longueur &&
                                        (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)positionsEnnemies[i].X + j, (int)positionsEnnemies[i].Y + (porteesDeMeilleuresPrecisions[n] - j)].cheminValid)
                                        {
                                            ilAFaussementBouger = true;
                                        }
                                        else if ((int)positionsEnnemies[i].X - j >= 0 && (int)positionsEnnemies[i].X - j < moteurgraphique_.longueur &&
                                                 (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)positionsEnnemies[i].X - j, (int)positionsEnnemies[i].Y - (porteesDeMeilleuresPrecisions[n] - j)].cheminValid)
                                            {
                                                ilAFaussementBouger = true;
                                            }
                                            else if ((int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.longueur &&
                                                     (int)positionsEnnemies[i].Y - j >= 0 && (int)positionsEnnemies[i].Y - j < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)positionsEnnemies[i].X + (porteesDeMeilleuresPrecisions[n] - j), (int)positionsEnnemies[i].Y - j].cheminValid)
                                                {
                                                    ilAFaussementBouger = true;
                                                }
                                                else if ((int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j) >= 0 && (int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j) < moteurgraphique_.longueur &&
                                                         (int)positionsEnnemies[i].Y + j >= 0 && (int)positionsEnnemies[i].Y + j < moteurgraphique_.largeur)
                                                {
                                                    if (moteurgraphique_.map[(int)positionsEnnemies[i].X - (porteesDeMeilleuresPrecisions[n] - j), (int)positionsEnnemies[i].Y + j].cheminValid)
                                                    {
                                                        ilAFaussementBouger = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (ilAFaussementBouger == false)
                    {
                        distanceAvecEnnemis.RemoveAt(i);
                        unitesEnnemis.RemoveAt(i);
                        positionsEnnemies.RemoveAt(i);
                    }
                }
                #endregion

                #region checkSiUnHerosEstAPortee

                for (int i = 0; i < distanceAvecEnnemis.Count - 1; i++)
                {
                    if (unitesEnnemis[i].typeUnite == e_typeUnite.Heros && unitSelect == false)
                    {
                        if (i > 0)
                        {
                            unitesEnnemis.RemoveRange(i + 1, unitesEnnemis.Count - (i + 1));
                            unitesEnnemis.RemoveRange(0, i);
                            distanceAvecEnnemis.RemoveRange(i + 1, distanceAvecEnnemis.Count - (i + 1));
                            distanceAvecEnnemis.RemoveRange(0, i);
                            positionsEnnemies.RemoveRange(i + 1, positionsEnnemies.Count - (i + 1));
                            positionsEnnemies.RemoveRange(0, i);
                        }
                        else
                        {
                            unitesEnnemis.RemoveRange(1, unitesEnnemis.Count - 1);
                            distanceAvecEnnemis.RemoveRange(i + 1, distanceAvecEnnemis.Count - (i + 1));
                            positionsEnnemies.RemoveRange(i + 1, positionsEnnemies.Count - (i + 1));
                        }

                        unitSelect = true;
                    }
                }
                #endregion

                #region siPasDeHerosAlorsGardeUnitAvecLeMoinsDePV
                while (distanceAvecEnnemis.Count > 1)
                {
                    for (int i = 0; i < distanceAvecEnnemis.Count - 1; i++)
                    {
                        if (gameplay_.listeDesJoueurs[moteurgraphique_.map[(int)positionsEnnemies[i].X, (int)positionsEnnemies[i].Y].pointeurArmee].bataillon[moteurgraphique_.map[(int)positionsEnnemies[i].X, (int)positionsEnnemies[i].Y].pointeurUnite].pvactuel <
                            gameplay_.listeDesJoueurs[moteurgraphique_.map[(int)positionsEnnemies[i + 1].X, (int)positionsEnnemies[i + 1].Y].pointeurArmee].bataillon[moteurgraphique_.map[(int)positionsEnnemies[i + 1].X, (int)positionsEnnemies[i + 1].Y].pointeurUnite].pvactuel)
                        {
                            unitesEnnemis.RemoveAt(i + 1);
                            positionsEnnemies.RemoveAt(i + 1);
                            distanceAvecEnnemis.RemoveAt(i + 1);
                        }
                        else
                        {
                            unitesEnnemis.RemoveAt(i);
                            positionsEnnemies.RemoveAt(i);
                            distanceAvecEnnemis.RemoveAt(i);
                        }
                    }
                }
                #endregion

                #endregion

                #region deplacementVersEnnemiLePlusPratique

                if (distanceAvecEnnemis.Count > 0)
                {
                    #region seMettreALaMeilleurePortee

                    for (int i = 0; i < porteesDeMeilleuresPrecisions.Count; i++)
                    {
                        for (int j = 0; j <= porteesDeMeilleuresPrecisions[i] - 1; j++)
                        {
                            if (ilABouger == false && dejaBienPlace == false)
                            {
                                if (porteesDeMeilleuresPrecisions[i] == distanceAvecEnnemis[0])
                                {
                                    dejaBienPlace = true;
                                    moi_.Initiative(unitesEnnemis[0], porteesDeMeilleuresPrecisions[i], moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                }
                                else
                                {
                                    if ((int)positionsEnnemies[0].X + j >= 0 && (int)positionsEnnemies[0].X + j < moteurgraphique_.longueur &&
                                        (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[(int)positionsEnnemies[0].X + j, (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j)].cheminValid)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + j, (int)positionsEnnemies[0].Y + (porteesDeMeilleuresPrecisions[i] - j));
                                        }
                                        else if ((int)positionsEnnemies[0].X - j >= 0 && (int)positionsEnnemies[0].X - j < moteurgraphique_.longueur &&
                                                 (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[(int)positionsEnnemies[0].X - j, (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j)].cheminValid)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - j, (int)positionsEnnemies[0].Y - (porteesDeMeilleuresPrecisions[i] - j));
                                            }
                                            else if ((int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.longueur &&
                                                     (int)positionsEnnemies[0].Y - j >= 0 && (int)positionsEnnemies[0].Y - j < moteurgraphique_.largeur)
                                            {
                                                if (moteurgraphique_.map[(int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y - j].cheminValid)
                                                {
                                                    ilABouger = true;
                                                    moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X + (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y - j);
                                                }
                                                else if ((int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j) >= 0 && (int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j) < moteurgraphique_.longueur &&
                                                         (int)positionsEnnemies[0].Y + j >= 0 && (int)positionsEnnemies[0].Y + j < moteurgraphique_.largeur)
                                                {
                                                    if (moteurgraphique_.map[(int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y + j].cheminValid)
                                                    {
                                                        ilABouger = true;
                                                        moi_.PathFindingLoohy(moteurgraphique_, (int)positionsEnnemies[0].X - (porteesDeMeilleuresPrecisions[i] - j), (int)positionsEnnemies[0].Y + j);
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
                }
                else
                {
                    deplacementFacileJoute(moteurgraphique_, gameplay_, moi_, armee_);
                }
                #endregion
            }
        }

        public void PlayMoyenEchiquier(SystemeDeJeu gameplay_, MoteurGraphique moteurgraphique_, Unite moi_, Armee armee_, HUD hud_)
        {
            List<int> porteesDeMeilleuresPrecisions = new List<int>();

            #region obtenirUneListeDesMeilleuresPorteesDePrecision

            for (int f = 10; f > 0; f--)
            {
                for (int g = 6; g > 0; g--)
                {
                    if (moi_.portee[g] == f)
                    {
                        porteesDeMeilleuresPrecisions.Add(g);
                    }
                }
            }
            #endregion

            deplacementMoyenEchiquier(gameplay_, moteurgraphique_, moi_, armee_, hud_);

            if (moi_.attaqOrNot)
            {
                for (int portee_ = 0; portee_ < porteesDeMeilleuresPrecisions.Count - 1; portee_++)
                {
                    checkContenuDansPorteeMoyenEchiquier(moteurgraphique_, porteesDeMeilleuresPrecisions[portee_], moi_, gameplay_, armee_, hud_);
                }
            }

            deplacementMoyenEchiquier(gameplay_, moteurgraphique_, moi_, armee_, hud_);

            finish = true;
        }

        #endregion

        #endregion

        #region IAcolline

        public void checkContenuDansPorteeFacileColline(MoteurGraphique moteurgraphique_, int portee_, Unite moi_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            int absx = moteurgraphique_.longueur / 2;
            int ordy = moteurgraphique_.largeur / 2;
            if (moi_.alive)
            {
                if (moi_.i != absx || moi_.j != ordy)
                {
                    #region siPersonneOuUnAlliePossedeColline

                    if (moteurgraphique_.map[absx, ordy].pointeurArmee == -1 || gameplay_.listeDesJoueurs[moteurgraphique_.map[absx, ordy].pointeurArmee].camp ==
                            gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i, moi_.j].pointeurArmee].camp)
                    {
                        checkContenuDansPorteeFacileJoute(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                    }

                    #endregion

                    #region siUnEnnemiPossedeLaColline

                    else
                    {
                        for (int p = 1; p < 7; p++) // ici aussi il faut que 7 soit remplacé par la portée d'attaque max de l'unité moi_
                        {
                            for (int k = 0; k < p; k++)
                            {
                                if (moi_.attaqOrNot)
                                {
                                    if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.longueur &&
                                        moi_.j + (p - k) >= 0 && moi_.j + (p - k) < moteurgraphique_.largeur)
                                    {
                                        if (moi_.i + k == absx && moi_.j + (p - k) == ordy)
                                        {
                                            moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[absx, ordy].pointeurArmee].bataillon[moteurgraphique_.map[absx, ordy].pointeurUnite], p, moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                        }
                                        else if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.longueur &&
                                                 moi_.j - (p - k) >= 0 && moi_.j - (p - k) < moteurgraphique_.largeur)
                                        {
                                            if (moi_.i - k == absx && moi_.j - (p - k) == ordy)
                                            {
                                                moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[absx, ordy].pointeurArmee].bataillon[moteurgraphique_.map[absx, ordy].pointeurUnite], p, moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                            }
                                            else if (moi_.i + (p - k) >= 0 && moi_.i + (p - k) < moteurgraphique_.longueur &&
                                                     moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.largeur)
                                            {
                                                if (moi_.i + (p - k) == absx && moi_.j - k == ordy)
                                                {
                                                    moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[absx, ordy].pointeurArmee].bataillon[moteurgraphique_.map[absx, ordy].pointeurUnite], p, moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
                                                }
                                                else if (moi_.i - (p - k) >= 0 && moi_.i - (p - k) < moteurgraphique_.longueur &&
                                                         moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.largeur)
                                                {
                                                    if (moi_.i - (p - k) == absx && moi_.j + k == ordy)
                                                    {
                                                        moi_.Initiative(gameplay_.listeDesJoueurs[moteurgraphique_.map[absx, ordy].pointeurArmee].bataillon[moteurgraphique_.map[absx, ordy].pointeurUnite], p, moteurgraphique_, gameplay_, ref gameplay_.mood, hud_);
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
                }
            }
        }

        public void deplacementFacileColline(SystemeDeJeu gameplay_, Unite moi_, MoteurGraphique moteurgraphique_)
        {
            int absx = moteurgraphique_.longueur / 2;
            int ordy = moteurgraphique_.largeur / 2;
            ilABouger = false;

            if (moi_.alive)
            {
                if (moi_.i != absx || moi_.j != ordy)
                {
                    for (int portee_ = 0; portee_ < 32; portee_++)
                    {
                        for (int k = 0; k < portee_; k++)
                        {
                            if (absx + k >= 0 && absx + k < moteurgraphique_.longueur &&
                                ordy + (portee_ - k) >= 0 && ordy + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[absx + k, ordy + (portee_ - k)].cheminValid &&
                                    ilABouger == false)
                                {
                                    ilABouger = true;
                                    moi_.PathFindingLoohy(moteurgraphique_, absx + k, ordy + (portee_ - k));
                                }

                                else if (absx - k >= 0 && absx - k < moteurgraphique_.longueur &&
                                     ordy - (portee_ - k) >= 0 && ordy - (portee_ - k) < moteurgraphique_.largeur)
                                {
                                    if (moteurgraphique_.map[absx - k, ordy - (portee_ - k)].cheminValid &&
                                        ilABouger == false)
                                    {
                                        ilABouger = true;
                                        moi_.PathFindingLoohy(moteurgraphique_, absx - k, ordy - (portee_ - k));
                                    }

                                    else if (absx + (portee_ - k) >= 0 && absx + (portee_ - k) < moteurgraphique_.longueur &&
                                        ordy - k >= 0 && ordy - k < moteurgraphique_.largeur)
                                    {
                                        if (moteurgraphique_.map[absx + (portee_ - k), ordy - k].cheminValid &&
                                            ilABouger == false)
                                        {
                                            ilABouger = true;
                                            moi_.PathFindingLoohy(moteurgraphique_, absx + (portee_ - k), ordy - k);
                                        }

                                        else if (absx - (portee_ - k) >= 0 && absx - (portee_ - k) < moteurgraphique_.longueur &&
                                            ordy + k >= 0 && ordy + k < moteurgraphique_.largeur)
                                        {
                                            if (moteurgraphique_.map[absx - (portee_ - k), ordy + k].cheminValid &&
                                                ilABouger == false)
                                            {
                                                ilABouger = true;
                                                moi_.PathFindingLoohy(moteurgraphique_, absx - (portee_ - k), ordy + k);
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

        public void PlayFacileColline(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, Armee armee_, HUD hud_)
        {
            deplacementFacileColline(gameplay_, moi_, moteurgraphique_);
            for (int portee_ = 1; portee_ < 7; portee_++)
            {
                if (moi_.portee[portee_] > -1)
                {
                    checkContenuDansPorteeFacileColline(moteurgraphique_, portee_, moi_, gameplay_, armee_, hud_);
                }
            }
            finish = true;
        }

        #endregion

        public void Play(Unite moi_, MoteurGraphique moteurgraphique_, Armee armee_, SystemeDeJeu gameplay_, HUD hud_)
        {
            if (moi_.fileDeMouvements.Count == 0)
            {
                switch (difficulte)
                {
                    case 1:
                        switch (gameplay_.conditionsDeVictoire)
                        {
                            case e_typeDePartie.Joute:
                                PlayFacileJoute(moi_, moteurgraphique_, gameplay_, armee_, hud_);
                                break;
                            case e_typeDePartie.Tresor:
                                PlayFacileTresor(moi_, moteurgraphique_, gameplay_, armee_, hud_);
                                break;
                            case e_typeDePartie.Echiquier:
                                PlayFacileEchiquier(moi_, moteurgraphique_, gameplay_, armee_, hud_);
                                break;
                            case e_typeDePartie.Colline:
                                PlayFacileColline(moi_, moteurgraphique_, gameplay_, armee_, hud_);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (gameplay_.conditionsDeVictoire)
                        {
                            case e_typeDePartie.Joute:
                                PlayMoyenJoute(moi_, moteurgraphique_, gameplay_, armee_, hud_);
                                break;
                            case e_typeDePartie.Tresor:
                                finish = true;
                                break;
                            case e_typeDePartie.Echiquier:
                                PlayMoyenEchiquier(gameplay_, moteurgraphique_, moi_, armee_, hud_);
                                break;
                            case e_typeDePartie.Colline:
                                finish = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        switch (gameplay_.conditionsDeVictoire)
                        {
                            case e_typeDePartie.Joute:
                                finish = true;
                                break;
                            case e_typeDePartie.Tresor:
                                finish = true;
                                break;
                            case e_typeDePartie.Echiquier:
                                finish = true;
                                break;
                            case e_typeDePartie.Colline:
                                finish = true;
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
