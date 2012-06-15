using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    static class Engine
    {
        static public Stack<Scene> scenes;

        static public void Initialize()
        {
            scenes = new Stack<Scene>();

            scenes.Push(new MenuPrincipal());
        }
        static public void Update(GameTime gameTime)
        {

            if (scenes.Count > 0)
            {
                scenes.Peek().UpdateScene(gameTime);


            }
            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                BoutonLien.een = false;
            }


        }
        static public void Draw()
        {
            if (scenes.Count > 0)
            {
                scenes.Peek().DrawScene();
            }
        }
    }
}
