using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonPause : Bouton
    {
        int indexDico;
        bool inGame;
        Rectangle tuveuxvoir;

        public BoutonPause(int x, int y,  int indexDico_, bool inGame_)
            : base(new Rectangle(x, y, 400, 75), new Rectangle(0, 0, 800, 300))
        {
            indexDico = indexDico_;
            inGame = inGame_;
            tuveuxvoir = new Rectangle(0, base.rect.Y - 12, Divers.X, 100);
        }

        public override void Update(GameTime gameTime)  {}
        public void UpdatePause(ref bool enPause)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && Contents.contientLaSouris(base.rect))
            {
                enPause = inGame;
            }
        }
        public override void Draw()
        {
            if (!Contents.contientLaSouris(base.rect))
            {
                Contents.Draw("bouton_normal", rect);
            }
            else
            {
                //Fait la moins dure, loohy, c'est pour ton bien
                if (!inGame)
                    Contents.Draw("grosse", tuveuxvoir, Color.DeepSkyBlue);
                Contents.Draw("bouton_selected", rect);
            }
            Contents.DrawStringInBoxCentered(Dico.langues[Dico.current][indexDico], rect);
        }
    }
}
