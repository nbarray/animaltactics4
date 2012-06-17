using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace animaltactics4
{
    //Loohy
    [Serializable]
    class ListeDesFichiers
    {
        public List<string> listeDesListesdArmee, listeDesMaps;

        //Loohy
        public ListeDesFichiers()
        {
            listeDesListesdArmee = new List<string>();
            listeDesMaps = new List<string>();
        }
        public void AddArmyName(string s_)
        {
            listeDesListesdArmee.Add(s_);
        }
    }
}
