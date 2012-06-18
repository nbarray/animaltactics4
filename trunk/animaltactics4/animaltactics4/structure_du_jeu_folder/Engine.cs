using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace animaltactics4
{
    //Coldman & Loohy
    static class Engine
    {
        static public ListeDesFichiers files;
        static public Stack<Scene> scenes;

        //Coldman & Loohy
        static public void Initialize()
        {
            scenes = new Stack<Scene>();
            scenes.Push(new MenuPrincipal());
            recharge();
        }
        //Coldman
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
        //Coldman
        static public void Draw()
        {
            if (scenes.Count > 0)
            {
                scenes.Peek().DrawScene();
            }
            Contents.Cadre();
        }

        //Loohy
        static public void recharge()
        {
            try
            {
                files = (ListeDesFichiers)Divers.deserializer("allTheLists4242Penguin");
            }
            catch (Exception)
            {
                files = new ListeDesFichiers();
                Divers.serializer(files, "allTheLists4242Penguin");
            }
        }
    }
}
