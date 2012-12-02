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
    class SpriteDecor
    {
        ElementDecor _elementDecor;

        Texture2D _texture;

        int _xIndex, _yIndex;
        int _width, _height;

        public SpriteDecor(ElementDecor _elementDecor)
        {
            this._elementDecor = _elementDecor;
        }

        public void LoadContent(ContentManager content, String _asset)
        {
           _texture = content.Load<Texture2D>(_asset);
        }

        public void Update(GameTime _gameTime)
        {

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int y = 0; y < _elementDecor.NbDecor; y++)
            {
                switch (_elementDecor.DecorTableau[0, y])
                {
                    case 1 :
                        _xIndex = 0; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 2:
                        _xIndex = 1; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 3:
                        _xIndex = 2; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 4:
                        _xIndex = 3; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 5:
                        _xIndex = 4; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 6:
                        _xIndex = 5; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 7:
                        _xIndex = 6; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 8:
                        _xIndex = 7; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 9:
                        _xIndex = 8; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 10:
                        _xIndex = 9; _yIndex = 11; _width = 64; _height = 64;
                        break;

                    case 11:
                        _xIndex = 0; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 12:
                        _xIndex = 1; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 13:
                        _xIndex = 2; _yIndex = 12; _width = 64; _height = 64*2;
                        break;

                    case 14:
                        _xIndex = 3; _yIndex = 12; _width = 64; _height = 64*2;
                        break;

         
                    case 15:
                        _xIndex = 4; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 16:
                        _xIndex = 5; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 17:
                        _xIndex = 6; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 18:
                        _xIndex = 7; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 19:
                        _xIndex = 8; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 20:
                        _xIndex = 9; _yIndex = 12; _width = 64; _height = 64;
                        break;

                    case 21:
                        _xIndex = 0; _yIndex = 13; _width = 64; _height = 64*3;
                        break;

                    case 22:
                        _xIndex = 1; _yIndex = 13; _width = 64; _height = 64*3;
                        break;

                    case 23:
                        _xIndex = 2; _yIndex = 14; _width = 64; _height = 64*2;
                        break;

                    case 24:
                        _xIndex = 3; _yIndex = 14; _width = 64; _height = 64*2;
                        break;

                    case 25:
                        _xIndex = 4; _yIndex = 13; _width = 64*3; _height = 64*3;
                        break;

                    case 26:
                        _xIndex = 7; _yIndex = 13; _width = 64*3; _height = 64*3;
                        break;

                }

                _spriteBatch.Draw(_texture, new Rectangle(32 * (_elementDecor.DecorTableau[1,y] -_elementDecor.DecorTableau[2,y]), 16 * (_elementDecor.DecorTableau[1,y] +_elementDecor.DecorTableau[2,y]), _width, _height), new Rectangle(64 * _xIndex, 64 * _yIndex, _width, _height), Color.White);
              
            }


        }

    }
}
