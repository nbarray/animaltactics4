using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonNouvellePartie : Bouton
    {
        bool sound;
        Rectangle tuveuxvoir;
        int indexDico;

        public BoutonNouvellePartie(int x, int y, Rectangle sub_, int indexDico_)
            : base(new Rectangle(Divers.X / 2 - 200, y, 400, 75), sub_)
        {
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
            sound = true;
            indexDico = indexDico_;
        }

        public override void Update(GameTime gameTime)
        {
            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public void UpdateSpecial(GameTime gameTime, string nomDeLaMap_, List<string> nomDesArmees_, List<int> difficultes_, List<int> camp_, List<Color> couleurs_,
            e_typeDePartie conditionsDeVictoire_, e_brouillardDeGuerre fog_,int tempsMax_, int limiteDeTours_ = 0)
        {
            if (Contents.contientLaSouris(base.rect))
            {
                if (!een && Mouse.GetState().LeftButton == ButtonState.Pressed&&nomDeLaMap_!= "" && nomDesArmees_.Count>=2)
                {
                    MoteurSon.PlayFX("bouton");
                    Engine.scenes.Push(new ScenePartie(32, 32));
                    ((ScenePartie)Engine.scenes.Peek()).p.Initialize(nomDeLaMap_, nomDesArmees_, difficultes_, camp_, couleurs_, conditionsDeVictoire_, fog_, tempsMax_, limiteDeTours_);
                    een = true;
                }
            }

            if (Engine.scenes.Count == 0)
            {
                Game1.quitter = true;
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                Contents.Draw("bouton_normal", rect);
                sound = true;
            }
            else
            {
                if (sound)
                    MoteurSon.PlayFX("clic");
                sound = false;
                //Fait la moins dure, loohy, c'est pour ton bien
                Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico], rect);
        }
    }
}
