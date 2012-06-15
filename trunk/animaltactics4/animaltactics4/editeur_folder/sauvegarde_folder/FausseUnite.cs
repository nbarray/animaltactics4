using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animaltactics4
{
    [Serializable]
    class FausseUnite
    {
        public e_classe classe;
        public int points;
        //contiendra aussi l'equipement supplémentaire

        public FausseUnite(e_classe classe_)
        {
            classe = classe_;
            takePoints();
        }

        private void takePoints()
        {
            switch (classe)
            {
                case e_classe.PingvinWalkyrie:
                    points = 37;
                    break;
                case e_classe.PingvinLanceFlammes:
                    points = 30;
                    break;
                case e_classe.PingvinChar:
                    points = 46;
                    break;
                case e_classe.PingvinUgin:
                    points = 30;
                    break;
                case e_classe.PingvinBolter:
                    points = 32;
                    break;
                case e_classe.PingvinBerserker:
                    points = 48;
                    break;
                case e_classe.PingvinThor:
                    points = 64;
                    break;
                case e_classe.PingvinMugin:
                    points = 40;
                    break;
                case e_classe.PingvinOdin:
                    points = 68;
                    break;
                case e_classe.PandawanMoine:
                    points = 38;
                    break;
                case e_classe.PandawanYabusame:
                    points = 44;
                    break;
                case e_classe.PandawanBushi:
                    points = 36;
                    break;
                case e_classe.PandawanCharDragon:
                    points = 45;
                    break;
                case e_classe.PandawanMerco:
                    points = 36;
                    break;
                case e_classe.PandawanSokei:
                    points = 31;
                    break;
                case e_classe.PandawanNinja:
                    points = 41;
                    break;
                case e_classe.PandawanSniper:
                    points = 47;
                    break;
                case e_classe.PandawanSayan:
                    points = 50;
                    break;
                case e_classe.FenrirWarBlade:
                    points = 33;
                    break;
                case e_classe.FenrirTireur:
                    points = 42;
                    break;
                case e_classe.FenrirPsyker:
                    points = 39;
                    break;
                case e_classe.FenrirBouclier:
                    points = 37;
                    break;
                case e_classe.FenrirEclaireur:
                    points = 31;
                    break;
                case e_classe.FenrirDreadnought:
                    points = 42;
                    break;
                case e_classe.FenrirRailgun:
                    points = 63;
                    break;
                case e_classe.FenrirWarlord:
                    points = 56;
                    break;
                case e_classe.FenrirOkami:
                    points = 50;
                    break;
                case e_classe.ChefKrissa:
                    points = 60;
                    break;
                case e_classe.Assassin:
                    points = 30;
                    break;
                case e_classe.Legionnaire:
                    points = 30;
                    break;
                case e_classe.Geolier:
                    points = 30;
                    break;
                case e_classe.Maraudeur:
                    points = 30;
                    break;
                case e_classe.Vermine:
                    points = 30;
                    break;
                case e_classe.Abomination:
                    points = 30;
                    break;
                case e_classe.Krissa8:
                    points = 30;
                    break;
                case e_classe.Krissa9:
                    points = 30;
                    break;
                default:
                    points = 30;
                    break;
            }
        }
    }
}
