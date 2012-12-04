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
    class InterfaceUtilisateur
    {
        Texture2D _texture;

        public InterfaceUtilisateur()
        {
        }

        public void LoadContent(ContentManager content, String _asset)
        {
           _texture = content.Load<Texture2D>(_asset);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, new Rectangle(300, 220, 200, 40), new Rectangle(0, 30, 75, 15), Color.White);
        }
    }
}
