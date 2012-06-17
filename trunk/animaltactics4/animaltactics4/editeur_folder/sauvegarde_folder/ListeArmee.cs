using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    [Serializable]
    class ListeArmee
    {
        public e_race espece;
        public List<FausseUnite> bataillon;
        public Color couleur;
        public ListeArmee(e_race espece_)
        {
            bataillon = new List<FausseUnite>();
            espece = espece_;
            #region couleur
            switch (espece)
            {
                case e_race.Fenrir:
                    couleur = Color.DarkBlue;
                    break;
                case e_race.Krissa:
                    couleur = Color.DarkGreen;
                    break;
                case e_race.Pandawan:
                    couleur = Color.DarkRed;
                    break;
                default:
                    couleur = Color.DarkOrange;
                    break;
            } 
            #endregion
        }

        public void AddUnite(e_classe classe_)
        {
            bataillon.Add(new FausseUnite(classe_));
        }
        public void NEW(e_race newRace_)
        {
            espece = newRace_;
            for (int i = bataillon.Count - 1; i >= 0; i--)
            {
                bataillon.RemoveAt(i);
            }
            switch (espece)
            {
                case e_race.Fenrir:
                    AddUnite(e_classe.FenrirOkami);
                    break;
                case e_race.Krissa:
                    AddUnite(e_classe.KrissaChef);
                    break;
                case e_race.Pandawan:
                    AddUnite(e_classe.PandawanSayan);
                    break;
                default:
                    AddUnite(e_classe.PingvinOdin);
                    break;
            }
            #region couleur
            switch (espece)
            {
                case e_race.Fenrir:
                    couleur = Color.DarkBlue;
                    break;
                case e_race.Krissa:
                    couleur = Color.DarkGreen;
                    break;
                case e_race.Pandawan:
                    couleur = Color.DarkRed;
                    break;
                default:
                    couleur = Color.DarkOrange;
                    break;
            }
            #endregion
        }
    }
}
