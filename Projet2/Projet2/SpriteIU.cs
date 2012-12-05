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
    class SpriteIU
    {
        Texture2D _texture;

        InterfaceUtilisateur _interfaceUtilisateur;

        SpriteFont _font;

        int _tileHover;

        public SpriteIU(InterfaceUtilisateur _interfaceUtilisateur)
        {
            this._interfaceUtilisateur = _interfaceUtilisateur;
        }

        public void LoadContent(ContentManager content, String _assetTexture, String _assetFont)
        {
            _texture = content.Load<Texture2D>(_assetTexture);
            _font = content.Load<SpriteFont>(_assetFont);
        }

        public void Update(int _tileHover)
        {
            this._tileHover = _tileHover;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int i = 0; i < _interfaceUtilisateur.Item.Length; i++)
            {
                if (_tileHover >= 0 && i == _tileHover)
                    _spriteBatch.Draw(_texture, new Rectangle(300, 150 + 50 * i, 200, 40), new Rectangle(0, 49, 75, 15), Color.White);
                else
                    _spriteBatch.Draw(_texture, new Rectangle(300, 150 + 50 * i, 200, 40), new Rectangle(0, 30, 75, 15), Color.White);
                _spriteBatch.DrawString(_font, _interfaceUtilisateur.Item[i], new Vector2(340, 156 + 50 * i), Color.Black);
            }

            if (_interfaceUtilisateur.SousMenu == "Reglage")
            {
                _spriteBatch.Draw(_texture, new Rectangle(200, 100, 400, 300), new Rectangle(29, 111, 48 - 29, 129 - 111), Color.White);
                _spriteBatch.DrawString(_font, _interfaceUtilisateur.SousMenu, new Vector2(240, 120), Color.Black);
            }
        }

    }
}
