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
        public string currentLanguage;
        public float volumeMusique, volumeFX;

        //Loohy
        public ListeDesFichiers()
        {
            listeDesListesdArmee = new List<string>();
            listeDesMaps = new List<string>();
            currentLanguage = "Francais";
            volumeFX = 0.1f;
            volumeMusique = 0.1f;
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
            listeA.AddUnite(e_classe.PingvinWalkyrie);
            listeA.AddUnite(e_classe.PingvinBolter);
            listeA.AddUnite(e_classe.PingvinBolter);
            listeA.AddUnite(e_classe.PingvinChar);
            listeA.AddUnite(e_classe.PingvinChar);
            listeA.AddUnite(e_classe.PingvinUgin);
            t = "Pingvin01";
            SauvegardeArmee(ref t, listeA);
            listeA.NEW(e_race.Pandawan);
            listeA.AddUnite(e_classe.PandawanSayan);
            listeA.AddUnite(e_classe.PandawanNinja);
            listeA.AddUnite(e_classe.PandawanSniper);
            listeA.AddUnite(e_classe.PandawanMoine);
            listeA.AddUnite(e_classe.PandawanBushi);
            listeA.AddUnite(e_classe.PandawanYabusame);
            listeA.AddUnite(e_classe.PandawanCharDragon);
            listeA.AddUnite(e_classe.PandawanYabusame);
            listeA.AddUnite(e_classe.PandawanCharDragon);
            t = "Pandawan01";
            SauvegardeArmee(ref t, listeA);
            listeA.NEW(e_race.Krissa);
            listeA.AddUnite(e_classe.KrissaChef);
            listeA.AddUnite(e_classe.KrissaAssassin);
            listeA.AddUnite(e_classe.KrissaAssassin);
            listeA.AddUnite(e_classe.KrissaLegionnaire);
            listeA.AddUnite(e_classe.KrissaVermine);
            listeA.AddUnite(e_classe.KrissaVermine);
            listeA.AddUnite(e_classe.KrissaMaraudeur);
            listeA.AddUnite(e_classe.KrissaMaraudeur);
            listeA.AddUnite(e_classe.KrissaCanonnier);
            t = "Krissa01";
            SauvegardeArmee(ref t, listeA);
            listeA.NEW(e_race.Fenrir);
            listeA.AddUnite(e_classe.FenrirOkami);
            listeA.AddUnite(e_classe.FenrirWarlord);
            listeA.AddUnite(e_classe.FenrirRailgun);
            listeA.AddUnite(e_classe.FenrirDreadnought);
            listeA.AddUnite(e_classe.FenrirEclaireur);
            listeA.AddUnite(e_classe.FenrirPsyker);
            listeA.AddUnite(e_classe.FenrirTireur);
            listeA.AddUnite(e_classe.FenrirTireur);
            listeA.AddUnite(e_classe.FenrirWarBlade);
            t = "Fenrir01";
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
            Gaia.mapAleaDesert(32, 32);
            t = "Carte désertique aléatoire";
            SauvegardeCarte(ref t, Gaia);

        }
    }
}
