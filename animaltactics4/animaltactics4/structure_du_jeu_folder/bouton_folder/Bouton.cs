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
        protected string assetName;
        static public bool isPressed = false;

        public Bouton(Rectangle rect_, Rectangle sub_, String assetName_)
        {
            rect = rect_;
            sub = sub_;
            assetName = assetName_;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();
        
    }
}
