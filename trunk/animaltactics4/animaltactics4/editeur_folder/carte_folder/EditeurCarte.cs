using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Loohy
    class EditeurCarte : Scene
    {
        WriteBox writer;
        public e_toolSize tsize;
        public e_pinceau tstate;
        public MoteurGraphique titanAE;

        public EditeurCarte()
            : base()
        {
            boutons.Add(new BoutonDeroulant(new Rectangle(0, 0, 180, 50), 49));
            boutons.Add(new BoutonDeroulant(new Rectangle(181, 0, 150, 50), 50));
            boutons.Add(new BoutonLien(50, 800, new Rectangle(0, 0, 800, 300), null, 5));
            titanAE = new MoteurGraphique(32, 32);
            //titanAE.viderVue();
            writer = new WriteBox(new Rectangle(600, Divers.Y - 220, 450, 75));
            titanAE.centrerSur(16, 16);
        }

        public override void UpdateScene(GameTime gameTime)
        {
            base.UpdateScene(gameTime);
            //foreach (Bouton item in boutons)
            //{
            ((BoutonDeroulant)boutons[0]).UpdateDeroulantNicoTuFaitPasChier(ref  tsize, ref tstate);
            ((BoutonDeroulant)boutons[1]).UpdateDeroulantNicoTuFaitPasChier(ref  tsize, ref tstate);
            //}
            Rectangle mike = new Rectangle(1000, 800, 150, 50);
            writer.Update();
            if (Contents.contientLaSouris(mike) && writer.text != "")
            {
                Sauvegarde(ref writer.text);
            }
            if (((BoutonDeroulant)boutons[0]).state == e_etatDeroulant.Ferme&&((BoutonDeroulant)boutons[1]).state == e_etatDeroulant.Ferme)
            {
                titanAE.UpdateEditeur(((BoutonDeroulant)boutons[0]).tstate, ((BoutonDeroulant)boutons[1]).tsize);
            }
            Rectangle izia = new Rectangle(332, 0, 150, 50);
            if (Contents.contientLaSouris(izia) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                titanAE.NEW(32, 32);
            }
        }

        public override void DrawScene()
        {
            titanAE.DrawEditeur();
            foreach (Bouton item in boutons)
            {
                item.Draw();
            }
            writer.Draw();
            Rectangle izia = new Rectangle(332, 0, 150, 50);
            if (!Contents.contientLaSouris(izia))
            {
                Contents.Draw("px", izia, Color.Gray);
                Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][151], izia, Color.Black);
            }
            else
            {
                Contents.Draw("px", izia, Color.DarkRed);
                Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][151], izia);
            }
            #region bouton save
            Rectangle mike = new Rectangle(1000, 800, 150, 50);
            if (Contents.contientLaSouris(mike))
            {
                Contents.Draw("px", mike, Color.Gray);
                Contents.DrawString("Sauvegarde", new Rectangle(mike.X + 10, mike.Y + 5, 0, 0), Color.Black);
            }
            else
            {
                Contents.Draw("px", mike, Color.DarkGray);
                Contents.DrawString("Sauvegarde", new Rectangle(mike.X + 10, mike.Y + 5, 0, 0), Color.White);
            }
            #endregion
        }
        public void Sauvegarde(ref string txt_)
        {
            Divers.serializer(titanAE, txt_);
            Engine.files.AddMapName(txt_);
            Divers.serializer(Engine.files, "allTheLists4242Penguin");
            txt_ = "";
        }
    }
}
