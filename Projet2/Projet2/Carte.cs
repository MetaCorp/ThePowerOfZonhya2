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
    class Carte
    {
        int _tileTotalWidth;
        public int TileTotalWidth { get { return _tileTotalWidth; } set { _tileTotalWidth = value; } }
            
        int _tileTotalHeight;
        public int TileTotalHeight { get { return _tileTotalHeight; } set { _tileTotalHeight = value; } }

        int _tileWidth;
        public int TileWidth { get { return _tileWidth; } set { _tileWidth = value; } }
        
        int _tileHeight;
        public int TileHeight { get { return _tileHeight; } set { _tileHeight = value; } }

        int _tileStepX;
        public int TileStepX { get { return _tileStepX; } set { _tileStepX = value; } }

        int _tileStepY;
        public int TileStepY { get { return _tileStepY; } set { _tileStepY = value; } }

        Vector2 _tileHover;
        public Vector2 TileHover { get { return _tileHover; } set { _tileHover = value; } }

        Char[,] _tileArray;
        public Char[,] TileArray { get { return _tileArray; } set { _tileArray = value; } }

        int _xTile; // pour le draw
        public int XTile { get { return _xTile; } set { _xTile = value; } }

        int _yTile;
        public int YTile { get { return _yTile; } set { _yTile = value; } }

        Vector2 _camera;

        public Carte(Char[,] _tileArray, int _tileTotalWidth, int _tileTotalHeight, Vector2 _camera, int _tileWidth, int _tileHeight, int _tileStepX, int _tileStepY)
        {
            this._tileTotalWidth = _tileTotalWidth;
            this._tileTotalHeight = _tileTotalHeight;

            this._camera = _camera;

            this._tileArray = _tileArray;

            this._tileWidth = _tileWidth;
            this._tileHeight = _tileHeight;
            this._tileStepX = _tileStepX;
            this._tileStepY = _tileStepY;
        }

        public void Update(Vector2 _positionSouris, Vector2 _camera, GameTime _gameTime)
        {
            _tileHover = setTileHover(_positionSouris);
            this._camera = _camera;
        }

        public Vector2 setTileHover(Vector2 _positionSouris)
        {
            Color couleur;

            Vector2 _tileHoverAux;

            _tileHoverAux.X = (((_positionSouris.Y - _camera.Y) / 32 + (_positionSouris.X - 32 - _camera.X) / 64) / 2) * 2;
            _tileHoverAux.Y = (((_positionSouris.Y - _camera.Y) / 32 - (_positionSouris.X - 32 - _camera.X) / 64) / 2) * 2;

            /*_mouseMapPos.X = _positionSouris.X % 64;
            if (_tileHover.X % 4 == 0)
                _mouseMapPos.Y = _positionSouris.Y % 64;
            else _mouseMapPos.Y = (_positionSouris.Y + 32) % 64;

            if (_mouseMapPos.X + (_mouseMapPos.Y % 32) * 64 > 0)
                couleur = _colorMouseMap[(int)(_mouseMapPos.X + (_mouseMapPos.Y % 32) * 64)];*/

            //Console.WriteLine("Couleur : " + couleur);

            /*if (couleur == Color.Red)
                tileHoverX2 = tileHoverX2 - 1;
            else if (couleur == Color.Yellow)
                tileHoverY2 = tileHoverY2 - 1;
            else if (couleur == Color.Blue)
                tileHoverX2 = tileHoverX2 + 1;
            else if (couleur == Color.Green)
                tileHoverY2 = tileHoverY2 + 1;*/

            _tileHover = _tileHoverAux - Vector2.One ;

            //Console.WriteLine("Case : x = " + (int)_tileHover.X + ", y = " + (int)_tileHover.Y);
            

            return _tileHover;
        }
    }
}
