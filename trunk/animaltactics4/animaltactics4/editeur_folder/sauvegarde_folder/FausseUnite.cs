using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
            Armee ost = new Armee(0, e_race.Random, Color.Black, 0, 0, 0);
            ost.AddUnite(classe);
            points = ost.bataillon[0].points;
        }
    }
}
