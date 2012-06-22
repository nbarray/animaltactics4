using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animaltactics4
{
    [Serializable]
    class Pouvoir
    {
        e_pouvoir nom;
        e_typeDePouvoir type;
        e_typeDeBoost boost;
        public List<int> porteePouvoir;
        bool estPhysique; // vrai = pouvoir physique
        bool affectepv;
        bool affectEnergie;
        public bool vertical;
        int coutEnergie;
        int recharge;
        int efficacite;

        public Pouvoir(e_pouvoir nom_, e_typeDePouvoir type_, List<int> porteePouvoir_, bool estPhysique_, int coutEnergie_,
            int recharge_, int efficacite_, bool vertical_)
        {
            nom = nom_;
            type = type_;
            porteePouvoir = porteePouvoir_;
            estPhysique = estPhysique_;
            coutEnergie = coutEnergie_;
            recharge = recharge_;
            efficacite = efficacite_;
            if (nom == e_pouvoir.Geolier)
            {
                boost = e_typeDeBoost.BonusEsquive;
            }
            vertical = vertical_;
        }

        public void UtiliserPouvoir(Unite moi_, MoteurGraphique moteurgraphique_,
            SystemeDeJeu gameplay_, int i_, int j_, ref e_modeAction mood_, HUD hud_)
        {
            if (moi_.energieactuel >= coutEnergie)
            {
                hud_.powa(nom);
                //cible : gameplay_.armees[moteurgraphique_.map[i_, j_].pointeurArmee].bataillon[moteurgraphique_.map[i_, j_].pointeurUnite]
                mood_ = e_modeAction.Mouvement;
                moi_.attaqOrNot = false;
                moi_.energieactuel -= coutEnergie;
                if (moteurgraphique_.map[i_, j_].presence)
                {
                    switch (type)
                    {
                        case e_typeDePouvoir.Degat:
                            #region Degats
                            if (estPhysique)
                            {
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].pvactuel -= Math.Max(0, efficacite - gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].armure);
                            }
                            else
                            {
                                gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].pvactuel -= Math.Max(0, efficacite - gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].resistance);
                            }
                            gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                    bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].assassin = moi_.numeroArmee;
                            break;
                            #endregion
                        case e_typeDePouvoir.Soin:
                            #region Soin
                            gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].pvactuel += efficacite;
                            break;
                            #endregion
                        case e_typeDePouvoir.Boost:
                            #region Boost
                            switch (boost)
                            {
                                case e_typeDeBoost.BonusAttaque:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusAttaque += efficacite;
                                    break;
                                case e_typeDeBoost.BonusArmure:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusArmure += efficacite;
                                    break;
                                case e_typeDeBoost.BonusPuissance:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonuspuissance += efficacite;
                                    break;
                                case e_typeDeBoost.BonusResistance:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusresistance += efficacite;
                                    break;
                                case e_typeDeBoost.BonusPrecision:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusprecision += efficacite;
                                    break;
                                case e_typeDeBoost.BonusCoupCritique:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusCoupcritique += efficacite;
                                    break;
                                case e_typeDeBoost.BonusEsquive:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusEsquive *= efficacite;
                                    break;
                                case e_typeDeBoost.BonusInitiative:
                                    gameplay_.listeDesJoueurs[moteurgraphique_.map[i_, j_].pointeurArmee].
                                bataillon[moteurgraphique_.map[i_, j_].pointeurUnite].bonusInitiative += efficacite;
                                    break;
                                default:
                                    break;
                            }
                            break;
                            #endregion
                        default:
                            break;
                    }
                }
                if (nom == e_pouvoir.PandaNinja)
                {
                    moi_.estInvisible = true;
                }
            }
        }

        /*public void Update(MoteurGraphique moteurgraphique_, Gameplay gameplay_, int i, int j, bool attaqOrNot, bool mouvOrNot, 
            Unite moi_ )
        {
            #region power
            if (Mouse.GetState().RightButton == ButtonState.Pressed && attaqOrNot)
            {
                for (int portee_ = 1; portee_ < 32; portee_++)
                {
                    if (porteePouvoir.Contains(portee_))
                    {
                        for (int k = 0; k < portee_; k++)
                        {
                            if (i + k >= 0 && i + k < moteurgraphique_.longueur
                                && j + (portee_ - k) >= 0 && j + (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + k, j + (portee_ - k)].estEnSurbrillance &&
                                       moteurgraphique_.map[i + k, j + (portee_ - k)].visible &&
                                       attaqOrNot)
                                {
                                    attaqOrNot = false;
                                    mouvOrNot = false;
                                    UtiliserPouvoir(moi_, moteurgraphique_, gameplay_, i + k, j + (portee_ - k));
                                    gameplay_.CheckPV(moteurgraphique_);
                                }
                            }
                            if (i - k >= 0 && i - k < moteurgraphique_.longueur
                                 && j - (portee_ - k) >= 0 && j - (portee_ - k) < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - k, j - (portee_ - k)].estEnSurbrillance &&
                                       attaqOrNot)
                                {
                                    attaqOrNot = false;
                                    mouvOrNot = false;
                                    UtiliserPouvoir(moi_, moteurgraphique_, gameplay_, i - k, j - (portee_ - k));
                                    gameplay_.CheckPV(moteurgraphique_);
                                }
                            }
                            if (i + (portee_ - k) >= 0 && i + (portee_ - k) < moteurgraphique_.longueur
                                 && j - k >= 0 && j - k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i + (portee_ - k), j - k].estEnSurbrillance &&
                                       attaqOrNot)
                                {
                                    attaqOrNot = false;
                                    mouvOrNot = false;
                                    UtiliserPouvoir(moi_, moteurgraphique_, gameplay_, i + (portee_ - k), j - k);
                                    gameplay_.CheckPV(moteurgraphique_);
                                }
                            }
                            if (i - (portee_ - k) >= 0 && i - (portee_ - k) < moteurgraphique_.longueur
                                 && j + k >= 0 && j + k < moteurgraphique_.largeur)
                            {
                                if (moteurgraphique_.map[i - (portee_ - k), j + k].estEnSurbrillance &&
                                       attaqOrNot)
                                {
                                    attaqOrNot = false;
                                    mouvOrNot = false;
                                    UtiliserPouvoir(moi_, moteurgraphique_, gameplay_, i - (portee_ - k), j + k);
                                    gameplay_.CheckPV(moteurgraphique_);
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }*/
    }
}
