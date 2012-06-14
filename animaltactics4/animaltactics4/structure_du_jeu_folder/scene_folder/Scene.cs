using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    abstract class Scene
    {
        protected Rectangle fond;
        protected List<Bouton> boutons;
        public Scene()
        {
            fond = new Rectangle(0, 0, Divers.X, Divers.Y);
            boutons = new List<Bouton>();
        }
        public virtual void UpdateScene(GameTime gameTime)
        {
            foreach (Bouton item in boutons)
            {
                item.Update(gameTime);
            }
        }
        public virtual void DrawScene()
        {
            Contents.Draw("space", fond);
            foreach (Bouton item in boutons)
            {
                item.Draw();
            }
        }
    }
}
