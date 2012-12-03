using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projet2
{
    class EvenementUtilisateur
    {
        KeyboardState _keyboardState;
        public KeyboardState KeyBoardState { get { return _keyboardState; } set { _keyboardState = value; } }

        MouseState _mouseState;
        public MouseState MouseState { get { return _mouseState; } set { _mouseState = value; } }

        public EvenementUtilisateur()
        {

        }

        public void Update(GameTime _gameTime)
        {
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();

        }

    }
}
