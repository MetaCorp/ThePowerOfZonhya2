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
    class Sprite
    {
        Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }

        Color _color;
        public Color Color { get { return _color; } set { _color = value; } }

        Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        public Sprite(Vector2 _position)
        {
            this._position = _position;

            _color = Color.White;
        }

        public void LoadContent(ContentManager content, String _asset)
        {
            _texture = content.Load<Texture2D>(_asset);
        }

        public void Update(Vector2 _position)
        {
            this._position = _position;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, _color);
        }

        public void Draw(SpriteBatch _spriteBatch, Rectangle _rectangleSource)
        {
            _spriteBatch.Draw(_texture, _position, _rectangleSource, _color);
        }
    }
}
