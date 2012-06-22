using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animaltactics4
{
    [Serializable]
    class Aura
    {
        string nomdAura;
        TypedAura aura;
        int intensite;

        public Aura(string nomdAura_, TypedAura aura_, int intensite_)
        {
            nomdAura = nomdAura_;
            aura = aura_;
            intensite = intensite_;
        }

        public void ActiverAura(Unite moi_, MoteurGraphique moteurgraphique_, SystemeDeJeu gameplay_, int coef_)
        {
            for (int porteeAura = 1; porteeAura < moi_.getStat[4] / 4; porteeAura++)
            {
                for (int k = 0; k < porteeAura; k++)
                {
                    if (moi_.i + k >= 0 && moi_.i + k < moteurgraphique_.map.GetLength(0)
                        && moi_.j + (porteeAura - k) >= 0 && moi_.j + (porteeAura - k) < moteurgraphique_.map.GetLength(1))
                    {
                        if (moteurgraphique_.map[moi_.i + k, moi_.j + (porteeAura - k)].presence)
                        {
                            auraAt(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + k, moi_.j + (porteeAura - k)].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i + k, moi_.j + (porteeAura - k)].pointeurUnite], coef_,
                                moi_.numeroArmee);
                        }
                    }
                    if (moi_.i - k >= 0 && moi_.i - k < moteurgraphique_.map.GetLength(0)
                         && moi_.j - (porteeAura - k) >= 0 && moi_.j - (porteeAura - k) < moteurgraphique_.map.GetLength(1))
                    {
                        if (moteurgraphique_.map[moi_.i - k, moi_.j - (porteeAura - k)].presence)
                        {
                            auraAt(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - k, moi_.j - (porteeAura - k)].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i - k, moi_.j - (porteeAura - k)].pointeurUnite], coef_,
                                moi_.numeroArmee);
                        }
                    }
                    if (moi_.i + (porteeAura - k) >= 0 && moi_.i + (porteeAura - k) < moteurgraphique_.map.GetLength(0)
                         && moi_.j - k >= 0 && moi_.j - k < moteurgraphique_.map.GetLength(1))
                    {
                        if (moteurgraphique_.map[moi_.i + (porteeAura - k), moi_.j - k].presence)
                        {
                            auraAt(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i + (porteeAura - k), moi_.j - k].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i + (porteeAura - k), moi_.j - k].pointeurUnite], coef_,
                                moi_.numeroArmee);
                        }
                    }
                    if (moi_.i - (porteeAura - k) >= 0 && moi_.i - (porteeAura - k) < moteurgraphique_.map.GetLength(0)
                         && moi_.j + k >= 0 && moi_.j + k < moteurgraphique_.map.GetLength(1))
                    {
                        if (moteurgraphique_.map[moi_.i - (porteeAura - k), moi_.j + k].presence)
                        {
                            auraAt(gameplay_.listeDesJoueurs[moteurgraphique_.map[moi_.i - (porteeAura - k), moi_.j + k].pointeurArmee].
                                bataillon[moteurgraphique_.map[moi_.i - (porteeAura - k), moi_.j + k].pointeurUnite], coef_,
                                moi_.numeroArmee);
                        }
                    }
                }
            }
        }
        private void auraAt(Unite him_, int coef_, int numeroArmee_)
        {
            if (him_.numeroArmee == numeroArmee_)
            {
                him_.profiteDuneAura = (coef_ == 1);
                #region boost
                switch (aura)
                {
                    case TypedAura.BoostAttaque:
                        him_.bonusAttaque += coef_ * intensite;
                        break;
                    case TypedAura.BoostArmure:
                        him_.bonusArmure += coef_ * intensite;
                        break;
                    case TypedAura.BoostPuissance:
                        him_.bonuspuissance += coef_ * intensite;
                        break;
                    case TypedAura.BoostResistance:
                        him_.bonusresistance += coef_ * intensite;
                        break;
                    case TypedAura.BoostPrecision:
                        him_.bonusprecision += coef_ * intensite;
                        break;
                    case TypedAura.BoostCoupCritique:
                        him_.bonusCoupcritique += coef_ * intensite;
                        break;
                    case TypedAura.BoostEsquive:
                        him_.bonusEsquive += coef_ * intensite;
                        break;
                    case TypedAura.BoostInitiative:
                        him_.bonusInitiative += coef_ * intensite;
                        break;
                    default:
                        break;
                }
                #endregion
            }
        }
    }
}
