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
        public void AddMapName(string s_)
        {
            listeDesMaps.Add(s_);
        }
        public void SauvegardeArmee(ref string txt_, ListeArmee listeA_)
        {
            Divers.serializer(listeA_, txt_);
            Engine.files.AddArmyName(txt_);
            Divers.serializer(Engine.files, "allTheLists4242Penguin");
            txt_ = "";
        }
        public void ArmeesDeBase()
        {
            string t;
            ListeArmee listeA = new ListeArmee(e_race.Pingvin);
            listeA.AddUnite(e_classe.PingvinOdin);
            listeA.AddUnite(e_classe.PingvinThor);
            listeA.AddUnite(e_classe.PingvinWalkyrie);
            listeA.AddUnite(e_classe.PingvinBolter);
            listeA.AddUnite(e_classe.PingvinChar);
            t = "Armée classique Pingvin"; // DICO
            SauvegardeArmee(ref t, listeA);
            listeA.NEW(e_race.Pandawan);
            listeA.AddUnite(e_classe.PandawanSayan);
            listeA.AddUnite(e_classe.PandawanNinja);
            listeA.AddUnite(e_classe.PandawanBushi);
            listeA.AddUnite(e_classe.PandawanYabusame);
            listeA.AddUnite(e_classe.PandawanCharDragon);
            t = "Armée classique Pandawan"; // DICO
            SauvegardeArmee(ref t, listeA);
        }

        public void SauvegardeCarte(ref string txt_, MoteurGraphique listeA_)
        {
            Divers.serializer(listeA_, txt_);
            Engine.files.AddMapName(txt_);
            Divers.serializer(Engine.files, "allTheLists4242Penguin");
            txt_ = "";
        }
        public void CartesDeBase()
        {
            string t;
            MoteurGraphique Gaia = new MoteurGraphique(32, 32);
            t = "Carte nordique aléatoire";
            SauvegardeCarte(ref t, Gaia);
            Gaia.mapAleaFaceToFace(32, 32, 4, 5, 4);
            t = "Carte asiatique aléatoire";
            SauvegardeCarte(ref t, Gaia);

        }
    }
}
