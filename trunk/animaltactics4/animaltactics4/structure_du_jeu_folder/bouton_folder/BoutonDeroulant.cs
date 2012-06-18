using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Loohy
    class BoutonDeroulant : Bouton
    {
        protected e_pinceau tstate;
        protected e_toolSize tsize;
        protected e_etatDeroulant state;
        protected int hauteur, indexDico;

        //Loohy
        public BoutonDeroulant(Rectangle rect_, int indexDico_) : base(rect_, new Rectangle(42,7,42,7)) // i = 49 ou 50
        {
            state = e_etatDeroulant.Ferme;
            tstate = e_pinceau.Plaine;
            tsize = e_toolSize.Standard;
            hauteur = 0;
            indexDico = indexDico_;
        }

        public override void Update(GameTime gameTime) { }
        //Loohy
        public override void UpdateD(ref e_toolSize tsize_, ref e_pinceau tstate_)
        {
            switch (state)
            {
                case e_etatDeroulant.Ouvert:
                    if (Contents.contientLaSouris(base.rect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        state = e_etatDeroulant.Montant;
                    }
                    break;
                case e_etatDeroulant.Montant:
                    hauteur -= 10;
                    if (hauteur < 0)
                    {
                        hauteur = 0;
                        state = e_etatDeroulant.Ferme;
                    }
                    break;
                case e_etatDeroulant.Descendant:
                    hauteur += 10;
                    if (indexDico == 49)
                    {
                        if (hauteur > Contents.MeasureString("S").Y * 16)
                        {
                            hauteur = (int)(Contents.MeasureString("S").Y + 2) * 16;
                            state = e_etatDeroulant.Ouvert;
                        }
                    }
                    else
                    {
                        if (hauteur > Contents.MeasureString("S").Y * 6)
                        {
                            hauteur = (int)(Contents.MeasureString("S").Y + 2) * 6;
                            state = e_etatDeroulant.Ouvert;
                        }
                    }
                    break;
                default:
                    if (Contents.contientLaSouris(base.rect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        state = e_etatDeroulant.Descendant;
                    }
                    break;
            }
            if (indexDico == 49)
            {
                tstate_ = tstate;
            }
            else
            {
                tsize_ = tsize;
            }
        }
        //Loohy
        public override void Draw()
        {
            switch (state)
            {
                #region Ouvert
                case e_etatDeroulant.Ouvert:
                    Contents.Draw("px", new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, hauteur), Color.DarkRed);
                    Rectangle rect2 = new Rectangle(rect.X, rect.Y + rect.Height,
                    110, (int)(Contents.MeasureString("S").Y + 2));
                    //hauteur = (int)(font.MeasureString("S").Y + 2) * 15;
                    Color c = Color.Red;
                    #region Type
                    if (indexDico == 49)//
                    {
                        e_pinceau tableau = e_pinceau.Plaine;
                        while (tableau != e_pinceau.Rien)
                        {
                            Contents.DrawString(Dico.langues[Dico.current][ToolText(tableau)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                            if (Contents.contientLaSouris(rect2))
                            {
                                Contents.Draw("px", rect2, c);
                                Contents.DrawString(Dico.langues[Dico.current][ToolText(tableau)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                                {
                                    tstate = tableau;
                                    //logBox_.ToLogBox("La brosse actuelle est : " + tstate.ToString());
                                    state = e_etatDeroulant.Montant;
                                }
                            }
                            rect2.Y += (int)(Contents.MeasureString("S").Y + 2);
                            tableau++;
                        }
                        Contents.DrawString(Dico.langues[Dico.current][ToolText(tableau)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                        if (Contents.contientLaSouris(rect2))
                        {
                            Contents.Draw("px", rect2, c);
                            Contents.DrawString(Dico.langues[Dico.current][ToolText(tableau)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                tstate = tableau;
                                //logBox_.ToLogBox("La brosse actuelle est : " + tstate.ToString());
                                state = e_etatDeroulant.Montant;
                            }
                        }
                    }
                    #endregion
                    #region Size
                    else if (indexDico == 50)//
                    {
                        e_toolSize tableur = e_toolSize.XSmall;
                        while (tableur != e_toolSize.XLarge)
                        {
                            Contents.DrawString(Dico.langues[Dico.current][SizeText(tableur)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                            if (Contents.contientLaSouris(rect2))
                            {
                                Contents.Draw("px", rect2, c);
                                Contents.DrawString(Dico.langues[Dico.current][SizeText(tableur)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                                {
                                    tsize = tableur;
                                    //logBox_.ToLogBox("La taille de la brosse est : " + SizeText(tableur));
                                    state = e_etatDeroulant.Montant;
                                }
                            }
                            rect2.Y += (int)(Contents.MeasureString("S").Y + 2);
                            tableur++;
                        }
                        Contents.DrawString(Dico.langues[Dico.current][SizeText(tableur)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                        if (Contents.contientLaSouris(rect2))
                        {
                            Contents.Draw("px", rect2, c);
                            Contents.DrawString(Dico.langues[Dico.current][SizeText(tableur)], new Rectangle(rect2.X, rect2.Y, 0, 0));
                            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                            {
                                tsize = tableur;
                                //logBox_.ToLogBox("La taille de la brosse est : " + SizeText(tableur));
                                state = e_etatDeroulant.Montant;
                            }
                        }
                    #endregion
                    }
                    goto default; 
                #endregion
                #region Montant/Descendant
                case e_etatDeroulant.Montant:
                case e_etatDeroulant.Descendant:
                    Contents.Draw("px", new Rectangle(rect.X, rect.Y + rect.Height, rect.Width, hauteur), Color.DarkRed);
                    goto default; 
                #endregion
                #region Bouton
                default:
                    int s;
                    if (indexDico == 49)
                    {
                        s = ToolText(tstate);
                    }
                    else
                    {
                        s = SizeText(tsize);
                    }
                    if (!Contents.contientLaSouris(base.rect))
                    {
                        Contents.Draw("px", rect, Color.Gray);
                        Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico] + " : "
                            + Dico.langues[Dico.current][s], rect, Color.Black);
                    }
                    else
                    {
                        Contents.Draw("px", rect, Color.DarkRed);
                        Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico] + " : "
                            + Dico.langues[Dico.current][s], rect);
                    }
                    break; 
                #endregion
            }
        }

        //Loohy
        private int SizeText(e_toolSize size_)
        {
            int text = 0;
            switch (size_)
            {
                case e_toolSize.XSmall:
                    text = 27;
                    break;
                case e_toolSize.Small:
                    text = 28;
                    break;
                case e_toolSize.Standard:
                    text = 29;
                    break;
                case e_toolSize.Medium:
                    text = 30;
                    break;
                case e_toolSize.Large:
                    text = 31;
                    break;
                default:
                    text = 32;
                    break;
            }
            return text;
        }
        //Loohy
        private int ToolText(e_pinceau type_)
        {
            int text = 0;
            switch (type_)
            {
                case e_pinceau.Plaine:
                    text = 33;
                    break;
                case e_pinceau.Neige:
                    text = 34;
                    break;
                case e_pinceau.Banquise:
                    text = 35;
                    break;
                case e_pinceau.Sable:
                    text = 36;
                    break;
                case e_pinceau.Eau:
                    text = 37;
                    break;
                case e_pinceau.Route:
                    text = 38;
                    break;
                case e_pinceau.Riviere:
                    text = 39;
                    break;
                case e_pinceau.Bunker:
                    text = 40;
                    break;
                case e_pinceau.Foret:
                    text = 41;
                    break;
                case e_pinceau.Ruine:
                    text = 42;
                    break;
                case e_pinceau.Cratere:
                    text = 43;
                    break;
                case e_pinceau.Village:
                    text = 44;
                    break;
                case e_pinceau.Montagne:
                    text = 45;
                    break;
                case e_pinceau.Vallee:
                    text = 46;
                    break;
                case e_pinceau.Lissage:
                    text = 47;
                    break;
                default:
                    text = 48;
                    break;
            }
            return text;
        }
    }
}
