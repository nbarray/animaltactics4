using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    class BoutonAction : Bouton
    {
        e_modeAction type;
        Color color;

        public BoutonAction(e_modeAction type_)
            : base(new Rectangle(0, 0, 32, 32), new Rectangle(0, 0, 500, 500))
        {
            type = type_;
            switch (type_)
            {
                case e_modeAction.Attaque:
                    color = Color.Red;
                    break;
                case e_modeAction.Mouvement:
                    color = Color.Blue;
                    break;
                case e_modeAction.Pouvoir:
                    color = Color.Purple;
                    break;
                default:
                    break;
            }
        }

        public void DrawPos(int x_, int y_)
        {

            base.rect.X = x_;
            base.rect.Y = y_;
            Contents.Draw("px3", base.rect, color);
            switch (type)
            {
                case e_modeAction.Attaque:
            Contents.DrawString(Dico.langues[Dico.current][145], new Rectangle(rect.X+34,rect.Y,0,0));
                    break;
                case e_modeAction.Mouvement:
            Contents.DrawString(Dico.langues[Dico.current][146], new Rectangle(rect.X+34,rect.Y,0,0));
                    break;
                default:
            Contents.DrawString(Dico.langues[Dico.current][147], new Rectangle(rect.X+34,rect.Y,0,0));
                    break;
            }
        }
        public void UpdateRef(ref e_modeAction mood_)
        {
            if (Contents.contientLaSouris(base.rect) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mood_ = type;
            }
        }
        public override void Update(GameTime gameTime) { }
        public override void Draw() { }
    }
}
