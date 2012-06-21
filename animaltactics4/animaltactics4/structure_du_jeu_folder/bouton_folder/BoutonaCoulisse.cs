using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonaCoulisse : Bouton
    {
        public int decalage_x, decalage_y;
        public int yCoulisse, bulles;
        public bool actif;
        private Random punkHazard;
        private Color couleur;

        public BoutonaCoulisse(int x_, int y_, Color couleur_)
            : base(new Rectangle(x_, y_, 0, 0), new Rectangle(0, 0, 0, 0))
        {
            decalage_x = 0;
            decalage_y = 0;
            actif = false;
            punkHazard = new Random();
            yCoulisse = 150;
            couleur = couleur_;
        }

        public override void Draw()
        {
            Contents.Draw("px", new Rectangle(rect.X - 5, rect.Y + yCoulisse, 30, 300 - yCoulisse), couleur);
            Contents.Draw("Bulles", new Rectangle(rect.X - 5, rect.Y + yCoulisse, 30, 300 - yCoulisse),
                new Rectangle(0, bulles, 30, 300 - yCoulisse));
            Contents.Draw("CurseurCoulisse", new Rectangle(rect.X - 5, rect.Y + yCoulisse - 6, 60, 12), couleur);
            Contents.Draw("Tube", new Rectangle(rect.X - 11, rect.Y - 7, 42, 324));
            bulles += 3;
            if (bulles > 375)
            {
                bulles -= 375;
            }
        }
        public void DrawTxt(int index)
        {
            Contents.Draw("px", new Rectangle(rect.X - 30, rect.Y -50, 80+ rect.Width, 30), couleur);
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][index], new Rectangle(rect.X - 30, rect.Y -50, 80+ rect.Width, 30));
        }

        public bool estActif()
        {
            if (actif)
            {
                actif = Mouse.GetState().LeftButton == ButtonState.Pressed;
            }
            else
            {
                Rectangle tagada = new Rectangle(rect.X - 5, rect.Y + yCoulisse - 10, 40, 20);
                actif = Contents.contientLaSouris(tagada) && Mouse.GetState().LeftButton == ButtonState.Pressed;
            }
            return actif;
        }

        public override void Update(GameTime gameTime) { }
    }
}
