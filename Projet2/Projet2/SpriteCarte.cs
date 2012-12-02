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
    class SpriteCarte
    {
        Carte _carte;

        int _type;

        Texture2D _textureTileSet, _textureTileHover;

        Vector2 _camera;
       
        public SpriteCarte(Carte _carte, int _type, Vector2 _camera)
        {
            this._carte = _carte;
            this._type = _type;
            this._camera = _camera;
        }

        public void LoadContent(ContentManager content, String _asset1, String _asset2)
        {
            _textureTileSet = content.Load<Texture2D>(_asset1);
            _textureTileHover = content.Load<Texture2D>(_asset2);

        }

        public void Update(Vector2 _camera)
        {
            //Console.WriteLine("carte Update Camera : " + _camera);
            this._camera = _camera;
            //Console.WriteLine("moteurGraphique carte camera = " + _camera);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            for (int y = 0; y < _carte.TileTotalHeight; y++)
            {
                for (int x = 0; x < _carte.TileTotalWidth; x++)
                {
                    if (_type == 1)
                        switch (_carte.TileArray[x, y])
                        {

                            case '.':
                                _carte.XTile = 7; _carte.YTile = 0;
                                break;
                            case 'a':
                                _carte.XTile = 0; _carte.YTile = 0;
                                break;
                            case 'b':
                                _carte.XTile = 1; _carte.YTile = 0;
                                break;
                            case 'c':
                                _carte.XTile = 2; _carte.YTile = 0;
                                break;
                            case 'd':
                                _carte.XTile = 3; _carte.YTile = 0;
                                break;
                            case 'e':
                                _carte.XTile = 4; _carte.YTile = 0;
                                break;
                            case 'f':
                                _carte.XTile = 5; _carte.YTile = 0;
                                break;
                            case 'g':
                                _carte.XTile = 6; _carte.YTile = 0;
                                break;
                            case 'h':
                                _carte.XTile = 0; _carte.YTile = 1;
                                break;
                            case 'i':
                                _carte.XTile = 1; _carte.YTile = 1;
                                break;
                            case 'j':
                                _carte.XTile = 2; _carte.YTile = 1;
                                break;
                            case 'k':
                                _carte.XTile = 3; _carte.YTile = 1;
                                break;
                            case 'l':
                                _carte.XTile = 4; _carte.YTile = 1;
                                break;
                            case 'm':
                                _carte.XTile = 5; _carte.YTile = 1;
                                break;
                            case 'n':
                                _carte.XTile = 6; _carte.YTile = 1;
                                break;
                            case 'o':
                                _carte.XTile = 7; _carte.YTile = 1;
                                break;
                            case 'p':
                                _carte.XTile = 0; _carte.YTile = 2;
                                break;
                            case 'q':
                                _carte.XTile = 1; _carte.YTile = 2;
                                break;
                            case 'r':
                                _carte.XTile = 2; _carte.YTile = 2;
                                break;
                            case 's':
                                _carte.XTile = 3; _carte.YTile = 2;
                                break;
                            case 'T':
                                _carte.XTile = 0; _carte.YTile = 3;
                                break;
                            case 'U':
                                _carte.XTile = 1; _carte.YTile = 3;
                                break;
                            case 'V':
                                _carte.XTile = 2; _carte.YTile = 3;
                                break;
                            case 'W':
                                _carte.XTile = 3; _carte.YTile = 3;
                                break;
                            case 'X':
                                _carte.XTile = 4; _carte.YTile = 3;
                                break;
                            case 'Y':
                                _carte.XTile = 5; _carte.YTile = 3;
                                break;
                            case 'Z':
                                _carte.XTile = 6; _carte.YTile = 3;
                                break;
                            case '1':
                                _carte.XTile = 7; _carte.YTile = 3;
                                break;
                            case '2':
                                _carte.XTile = 8; _carte.YTile = 3;
                                break;
                            case '3':
                                _carte.XTile = 0; _carte.YTile = 4;
                                break;
                            case '4':
                                _carte.XTile = 1; _carte.YTile = 4;
                                break;
                            case '5':
                                _carte.XTile = 2; _carte.YTile = 4;
                                break;
                            case '6':
                                _carte.XTile = 3; _carte.YTile = 4;
                                break;
                            default:
                                break;
                        }
                    else if (_type == 2)
                        switch (_carte.TileArray[x, y])
                        {
                            case '.':
                                _carte.XTile = 7; _carte.YTile = 0;
                                break;
                            case 'A':
                                _carte.XTile = 0; _carte.YTile = 5;
                                break;
                            case 'B':
                                _carte.XTile = 1; _carte.YTile = 5;
                                break;
                            case 'C':
                                _carte.XTile = 2; _carte.YTile = 5;
                                break;
                            case 'D':
                                _carte.XTile = 3; _carte.YTile = 5;
                                break;
                            case 'E':
                                _carte.XTile = 4; _carte.YTile = 5;
                                break;
                            case 'F':
                                _carte.XTile = 5; _carte.YTile = 5;
                                break;
                            case 'G':
                                _carte.XTile = 6; _carte.YTile = 5;
                                break;
                            case 'H':
                                _carte.XTile = 7; _carte.YTile = 5;
                                break;
                            case 'I':
                                _carte.XTile = 8; _carte.YTile = 5;
                                break;
                            case 'J':
                                _carte.XTile = 9; _carte.YTile = 5;
                                break;
                            case 'K':
                                _carte.XTile = 1; _carte.YTile = 6;
                                break;
                            case 'L':
                                _carte.XTile = 4; _carte.YTile = 6;
                                break;
                            case 'M':
                                _carte.XTile = 5; _carte.YTile = 6;
                                break;
                            case 'N':
                                _carte.XTile = 6; _carte.YTile = 6;
                                break;
                            case 'O':
                                _carte.XTile = 0; _carte.YTile = 8; //debut de l'eau
                                break;
                            case 'P':
                                _carte.XTile = 1; _carte.YTile = 8;
                                break;
                            case 'Q':
                                _carte.XTile = 2; _carte.YTile = 8;
                                break;
                            case 'R':
                                _carte.XTile = 3; _carte.YTile = 8;
                                break;
                            case 'S':
                                _carte.XTile = 4; _carte.YTile = 8;
                                break;
                            case 'T':
                                _carte.XTile = 5; _carte.YTile = 8;
                                break;
                            case 'U':
                                _carte.XTile = 6; _carte.YTile = 8;
                                break;
                            case 'V':
                                _carte.XTile = 7; _carte.YTile = 8;
                                break;
                            case 'W':
                                _carte.XTile = 8; _carte.YTile = 8;
                                break;
                            case 'X':
                                _carte.XTile = 9; _carte.YTile = 8;
                                break;
                            case 'Y':
                                _carte.XTile = 0; _carte.YTile = 9;
                                break;
                            case 'Z':
                                _carte.XTile = 1; _carte.YTile = 9;
                                break;
                            case '1':
                                _carte.XTile = 2; _carte.YTile = 9;
                                break;
                            case '2':
                                _carte.XTile = 3; _carte.YTile = 9;
                                break;
                            case '3':
                                _carte.XTile = 4; _carte.YTile = 9;
                                break;
                            case '4':
                                _carte.XTile = 5; _carte.YTile = 9;
                                break;
                            case '5':
                                _carte.XTile = 6; _carte.YTile = 9;
                                break;
                            case '6':
                                _carte.XTile = 7; _carte.YTile = 9;
                                break;
                            case '7':
                                _carte.XTile = 8; _carte.YTile = 9;
                                break;
                            case '8':
                                _carte.XTile = 9; _carte.YTile = 9;
                                break;
                            case '9':
                                _carte.XTile = 0; _carte.YTile = 10;
                                break;
                        }


                    _spriteBatch.Draw(_textureTileSet, new Rectangle((int)_camera.X + _carte.TileStepX * (x - y),(int)_camera.Y + _carte.TileStepY * (x + y), _carte.TileWidth, _carte.TileHeight), new Rectangle(_carte.XTile * 64, _carte.YTile * 64, 64, 64), Color.White, 0, Vector2.Zero, SpriteEffects.None, (float)Math.Exp(- _carte.TileStepY * (x + y) / 200 ));//(float)Math.Exp(-(_carte.TileStepY * (x + y) + _carte.TileHeight)));
                        
                }
                if (_type == 1)
                    _spriteBatch.Draw(_textureTileHover, new Rectangle((int)_camera.X + _carte.TileStepX * ((int)_carte.TileHover.X - (int)_carte.TileHover.Y),(int)_camera.Y + 32 + _carte.TileStepY * ((int)_carte.TileHover.X + (int)_carte.TileHover.Y), 64, 32), Color.White);
            }

        }

    }
}
