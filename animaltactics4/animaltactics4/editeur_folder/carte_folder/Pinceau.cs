using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class Pinceau
    {
        public e_pinceau type;

        public Pinceau()
        {

        }

        public void Update(MoteurGraphique ground_)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                foreach (Tile item in ground_.map)
                {
                    if (item.estEnSurbrillance)
                    {
                        switch (type)
                        {
                            case e_pinceau.Plaine:
                                item.E_Sol = e_Typedesol.herbe;
                                break;
                            case e_pinceau.Neige:
                                item.E_Sol = e_Typedesol.neige;
                                break;
                            case e_pinceau.Banquise:
                                item.E_Sol = e_Typedesol.banquise;
                                break;
                            case e_pinceau.Sable:
                                item.E_Sol = e_Typedesol.sable;
                                break;
                            case e_pinceau.Eau:
                                item.E_Sol = e_Typedesol.mer;
                                break;
                            case e_pinceau.Route:
                                break;
                            case e_pinceau.Riviere:
                                break;
                            case e_pinceau.Bunker:
                                break;
                            case e_pinceau.Foret:
                                break;
                            case e_pinceau.Ruine:
                                break;
                            case e_pinceau.Cratere:
                                break;
                            case e_pinceau.Village:
                                break;
                            case e_pinceau.Montagne:
                                break;
                            case e_pinceau.Vallee:
                                break;
                            case e_pinceau.Lissage:
                                break;
                            case e_pinceau.Rien:
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
