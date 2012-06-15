using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace animaltactics4
{
    abstract class Bouton
    {
        protected Rectangle rect, sub;

        public Bouton(Rectangle rect_, Rectangle sub_)
        {
            rect = rect_;
            sub = sub_;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
        
    }
}
