using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace animaltactics4
{
    #region ENUMERATIONS
    enum TypedAura
    {
        BoostAttaque,
        BoostArmure,
        BoostPuissance,
        BoostResistance,
        BoostPrecision,
        BoostCoupCritique,
        BoostEsquive,
        BoostInitiative
    }
    enum e_EtatAnim
    {
        mouvement1, mouvement2, mouvement3,
        repos1, repos2
    }
    enum mouv
    {
        Sud, Nord, Est, Ouest
    }
    enum e_typeUnite
    {
        Base,
        Elite,
        Heros,
        PNJ,
        Overlord
    }
    enum e_brouillardDeGuerre
    {
        ToutVisible, ToutVisite, Normal
    }
    enum e_menu
    {
        Principal, Jeu, Editeur, Extra, Option
    }
    enum e_race
    {
        Fenrir,
        Krissa,
        Pandawan,
        Pingvin,
        Random
    }
    enum e_classe
    {
        PingvinWalkyrie,//37
        PingvinLanceFlammes,//30
        PingvinChar,//46
        PingvinUgin,//30
        PingvinBolter,//32
        PingvinBerserker,//48
        PingvinThor,//64
        PingvinMugin,//40
        PingvinOdin,//68
        PandawanMoine,//38
        PandawanYabusame,//44
        PandawanBushi,//36
        PandawanCharDragon,//45
        PandawanMerco,//36
        PandawanSokei,//31
        PandawanNinja,//41
        PandawanSniper,//47
        PandawanSayan,//50
        FenrirWarBlade,//33
        FenrirTireur,//42
        FenrirPsyker,//39
        FenrirTemplier,//37
        FenrirEclaireur,//31
        FenrirDreadnought,//42
        FenrirRailgun,//63
        FenrirWarlord,//56
        FenrirOkami,//50
        KrissaChef,//60
        KrissaAssassin,//30
        KrissaLegionnaire,//30
        KrissaGeolier,//30
        KrissaMaraudeur,//30
        KrissaVermine,//30
        KrissaAbomination,//30
        KrissaDesperado,//30
        KrissaCanonnier,//30
        Overlord//0
    }
    enum e_pouvoir
    {
        PandaSceau, PandaSniper, PandaNinja,
        PingvinSoin, PingvinThor, PingvinRage,
        FenrirMissiles, FenrirBoost, FenrirRailgun,
        Krissa1, Legionnaire, Assassinat
    }
    enum e_typedAura
    {
        BoostAttaque,
        BoostArmure,
        BoostPuissance,
        BoostResistance,
        BoostPrecision,
        BoostCoupCritique,
        BoostEsquive,
        BoostInitiative
    }
    enum e_typeDePouvoir
    {
        Degat,
        Soin,
        Boost
    }
    enum e_typeDeBoost
    {
        BonusAttaque,
        BonusArmure,
        BonusPuissance,
        BonusResistance,
        BonusPrecision,
        BonusCoupCritique,
        BonusEsquive,
        BonusInitiative
    }
    enum e_modeAction
    {
        Attaque, Mouvement, Pouvoir
    }
    enum e_typeDePartie
    {
        Echiquier, Joute, Tresor, Colline
    }
    enum e_Typedesol
    {
        herbe,
        sable,
        neige,
        mer,
        banquise,
        desert,
        vide
    }
    enum e_Typederoute
    {
        route,
        pont,
        vide
    }
    enum e_Riviere
    {
        riviere,
        vide
    }
    enum e_Decorarriere
    {
        foret,
        bunker,
        iceBunker,
        ruine,
        villagePanda,
        villagePingvin,
        villageKrissa,
        campementFenrir,
        cratere,
        vide
    }
    enum e_Decoravant
    {
        foret,
        bunker,
        iceBunker,
        vide
    }
    enum e_Cache
    {
        Invisible, InvisibleAmi, Visible
    }
    public enum e_pinceau
    {
        Plaine, Neige, Banquise, Sable, Eau, Route, Riviere, Bunker, Foret, Ruine, Cratere, Village, Montagne, Vallee, Lissage, Rien
    }
    public enum e_toolSize
    {
        XSmall, Small, Standard, Medium, Large, XLarge
    }
    public enum e_etatDeroulant
    {
        Ouvert, Montant, Ferme, Descendant
    }
    #endregion

    static class Divers
    {
        static public readonly int X = 1200;
        static public readonly int Y = 900;

        //Loohy
        public static void serializer(object o, string file)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(file, FileMode.Create);
            formatter.Serialize(stream, o);
            stream.Close();
        }
        //Loohy
        public static object deserializer(string file)
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream filestream = new FileStream(file, FileMode.Open);
            object r = binary.Deserialize(filestream);
            filestream.Close();
            return r;
        }
        //Loohy
        public static void telechargerList(ref ListeArmee list_, string file_)
        {
            try
            {
                list_ = (ListeArmee)deserializer(file_);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Loohy
        public static ListeArmee obtenirList(string file_)
        {
            try
            {
                return (ListeArmee)deserializer(file_);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Loohy
        public static void telechargerMap(ref MoteurGraphique earthPenguin_, string file_)
        {
            try
            {
                earthPenguin_ = (MoteurGraphique)deserializer(file_);
            }
            catch (Exception)
            {
                earthPenguin_ = new MoteurGraphique(32, 32);
                earthPenguin_.mapAleaFaceToFace(32, 32, 4, 5, 4);
                throw;
            }
        }
        //Loohy
        public static string getName(e_classe c_)
        {
            if (Dico.current == null)
            {
            }
            switch (c_)
            {
                case e_classe.PingvinWalkyrie:
                    return Dico.langues[Dico.current][70];
                case e_classe.PingvinLanceFlammes:
                    return Dico.langues[Dico.current][71];
                case e_classe.PingvinChar:
                    return Dico.langues[Dico.current][72];
                case e_classe.PingvinUgin:
                    return Dico.langues[Dico.current][73];
                case e_classe.PingvinBolter:
                    return Dico.langues[Dico.current][74];
                case e_classe.PingvinBerserker:
                    return Dico.langues[Dico.current][75];
                case e_classe.PingvinThor:
                    return Dico.langues[Dico.current][76];
                case e_classe.PingvinMugin:
                    return Dico.langues[Dico.current][77];
                case e_classe.PingvinOdin:
                    return Dico.langues[Dico.current][78];
                case e_classe.PandawanMoine:
                    return Dico.langues[Dico.current][79];
                case e_classe.PandawanYabusame:
                    return Dico.langues[Dico.current][80];
                case e_classe.PandawanBushi:
                    return Dico.langues[Dico.current][82-1];
                case e_classe.PandawanCharDragon:
                    return Dico.langues[Dico.current][83 - 1];
                case e_classe.PandawanMerco:
                    return Dico.langues[Dico.current][84 - 1];
                case e_classe.PandawanSokei:
                    return Dico.langues[Dico.current][85 - 1];
                case e_classe.PandawanNinja:
                    return Dico.langues[Dico.current][86 - 1];
                case e_classe.PandawanSniper:
                    return Dico.langues[Dico.current][87 - 1];
                case e_classe.PandawanSayan:
                    return Dico.langues[Dico.current][88 - 1];
                case e_classe.FenrirWarBlade:
                    return Dico.langues[Dico.current][89 - 1];
                case e_classe.FenrirTireur:
                    return Dico.langues[Dico.current][90 - 1];
                case e_classe.FenrirPsyker:
                    return Dico.langues[Dico.current][91 - 1];
                case e_classe.FenrirTemplier:
                    return Dico.langues[Dico.current][92 - 1];
                case e_classe.FenrirEclaireur:
                    return Dico.langues[Dico.current][93 - 1];
                case e_classe.FenrirDreadnought:
                    return Dico.langues[Dico.current][94 - 1];
                case e_classe.FenrirRailgun:
                    return Dico.langues[Dico.current][95 - 1];
                case e_classe.FenrirWarlord:
                    return Dico.langues[Dico.current][96 - 1];
                case e_classe.FenrirOkami:
                    return Dico.langues[Dico.current][97 - 1];
                case e_classe.KrissaChef:
                    return Dico.langues[Dico.current][98 - 1];
                case e_classe.KrissaAssassin:
                    return Dico.langues[Dico.current][99 - 1];
                case e_classe.KrissaLegionnaire:
                    return Dico.langues[Dico.current][100 - 1];
                case e_classe.KrissaGeolier:
                    return Dico.langues[Dico.current][101 - 1];
                case e_classe.KrissaMaraudeur:
                    return Dico.langues[Dico.current][102 - 1];
                case e_classe.KrissaVermine:
                    return Dico.langues[Dico.current][103 - 1];
                case e_classe.KrissaAbomination:
                    return Dico.langues[Dico.current][104 - 1];
                case e_classe.KrissaDesperado:
                    return Dico.langues[Dico.current][105 - 1];
                case e_classe.KrissaCanonnier:
                    return Dico.langues[Dico.current][106 - 1];
                default:
                    return Dico.langues[Dico.current][107-1];
            }
        }
        public static string getText(e_classe c_)
        {
            switch (c_)
            {
                case e_classe.PingvinWalkyrie:
                    return Dico.langues[Dico.current][70+37];
                case e_classe.PingvinLanceFlammes:
                    return Dico.langues[Dico.current][71 + 37];
                case e_classe.PingvinChar:
                    return Dico.langues[Dico.current][72 + 37];
                case e_classe.PingvinUgin:
                    return Dico.langues[Dico.current][73 + 37];
                case e_classe.PingvinBolter:
                    return Dico.langues[Dico.current][74 + 37];
                case e_classe.PingvinBerserker:
                    return Dico.langues[Dico.current][75 + 37];
                case e_classe.PingvinThor:
                    return Dico.langues[Dico.current][76 + 37];
                case e_classe.PingvinMugin:
                    return Dico.langues[Dico.current][77 + 37];
                case e_classe.PingvinOdin:
                    return Dico.langues[Dico.current][78 + 37];
                case e_classe.PandawanMoine:
                    return Dico.langues[Dico.current][79 + 37];
                case e_classe.PandawanYabusame:
                    return Dico.langues[Dico.current][80 + 37];
                case e_classe.PandawanBushi:
                    return Dico.langues[Dico.current][82 - 1 + 37];
                case e_classe.PandawanCharDragon:
                    return Dico.langues[Dico.current][83 - 1 + 37];
                case e_classe.PandawanMerco:
                    return Dico.langues[Dico.current][84 - 1 + 37];
                case e_classe.PandawanSokei:
                    return Dico.langues[Dico.current][85 - 1 + 37];
                case e_classe.PandawanNinja:
                    return Dico.langues[Dico.current][86 - 1 + 37];
                case e_classe.PandawanSniper:
                    return Dico.langues[Dico.current][87 - 1 + 37];
                case e_classe.PandawanSayan:
                    return Dico.langues[Dico.current][88 - 1 + 37];
                case e_classe.FenrirWarBlade:
                    return Dico.langues[Dico.current][89 - 1 + 37];
                case e_classe.FenrirTireur:
                    return Dico.langues[Dico.current][90 - 1 + 37];
                case e_classe.FenrirPsyker:
                    return Dico.langues[Dico.current][91 - 1 + 37];
                case e_classe.FenrirTemplier:
                    return Dico.langues[Dico.current][92 - 1 + 37];
                case e_classe.FenrirEclaireur:
                    return Dico.langues[Dico.current][93 - 1 + 37];
                case e_classe.FenrirDreadnought:
                    return Dico.langues[Dico.current][94 - 1 + 37];
                case e_classe.FenrirRailgun:
                    return Dico.langues[Dico.current][95 - 1+37];
                case e_classe.FenrirWarlord:
                    return Dico.langues[Dico.current][96 - 1 + 37];
                case e_classe.FenrirOkami:
                    return Dico.langues[Dico.current][97 - 1 + 37];
                case e_classe.KrissaChef:
                    return Dico.langues[Dico.current][98 - 1 + 37];
                case e_classe.KrissaAssassin:
                    return Dico.langues[Dico.current][99 - 1 + 37];
                case e_classe.KrissaLegionnaire:
                    return Dico.langues[Dico.current][100 - 1 + 37];
                case e_classe.KrissaGeolier:
                    return Dico.langues[Dico.current][101 - 1 + 37];
                case e_classe.KrissaMaraudeur:
                    return Dico.langues[Dico.current][102 - 1 + 37];
                case e_classe.KrissaVermine:
                    return Dico.langues[Dico.current][103 - 1 + 37];
                case e_classe.KrissaAbomination:
                    return Dico.langues[Dico.current][104 - 1 + 37];
                case e_classe.KrissaDesperado:
                    return Dico.langues[Dico.current][105 - 1 + 37];
                case e_classe.KrissaCanonnier:
                    return Dico.langues[Dico.current][106 - 1 + 37];
                default:
                    return Dico.langues[Dico.current][107 - 1 + 37];
            }
        }

        //Loohy
        public static void UpdateBoutonCoulisse(BoutonaCoulisse item_)
        {
            if (item_.estActif())
            {
                item_.yCoulisse = Contents.getRelativeMouse().Y - item_.rect.Y;
                if (item_.yCoulisse < 0)
                {
                    item_.yCoulisse = 0;
                }
                else
                {
                    if (item_.yCoulisse > 300)
                    {
                        item_.yCoulisse = 300;
                    }
                }
            }
        }

        public static string String_Of_Key(Keys k)
        {
            if (Keyboard.GetState() == new KeyboardState(new Keys[]{Keys.None, k}))
            {
                return k.ToString().ToLower();
            }
            else if (Keyboard.GetState() == new KeyboardState(new Keys[] { Keys.None, k, Keys.LeftShift }))
            {
                return k.ToString().ToUpper();
            }
            else
            {
                return "";
            }
            
        }
    }
}
