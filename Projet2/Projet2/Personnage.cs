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
    class Personnage
    {
        String _nom;
        int _vieTotale, _vieActuelle;
        int _pointAction, _pointMouvement;

        int _orientation; // dans le sens trigo en partant de 0 jusqu'a 7
        public int Orientation { get { return _orientation; } set { _orientation = value; } }

        bool _isMouving = false; // pour savoir si il faut faire l'animation de marche ou pas
        public bool IsMouving { get { return _isMouving; } set { _isMouving = value; } }

        Vector2 _position;
        public Vector2 Position { get { return _position; } set { _position = value; } }

        Vector2 _direction;

        Vector2 _nextPosition;

        Vector2 _positionTile, _finalPositionTile, _nextPositionTile, _directionTile, _vitesseTile;

        public Vector2 PositionTile { get { return _positionTile; } set { _positionTile = value; } }

        List<Vector2> _path;

        Texture2D _texture;
        public Texture2D Texture { get { return _texture; } set { _texture = value; } }

        int i = 0;

        public Personnage(String _nom, int _vieTotale, int _vieActuelle, int _pointAction, int _pointMouvement)
        {
            this._nom = _nom;
            this._pointAction = _pointAction;
            this._pointMouvement = _pointMouvement;
            this._vieActuelle = _vieActuelle;
            this._vieTotale = _vieTotale;

            _path = new List<Vector2>();

            _positionTile = new Vector2(8, 5);// position sur la tile iso

            // position absolue
            _position = new Vector2( 32 * (_positionTile.X - _positionTile.Y) + 16, 16 * (_positionTile.X + _positionTile.Y) + 16 + 2);
            
            _nextPosition = _position;// si deplacement

            _vitesseTile = new Vector2(0.05f, 0.05f);

            _direction = Vector2.Normalize(new Vector2(2, 1));

            _orientation = 6;
        }

        public void update(MouseState _mouseState, Vector2 _tileHover, MoteurPhysique _moteurPhysique, GameTime _gameTime)
        {
            if (_mouseState.RightButton == ButtonState.Pressed)// si on clique c'est qui faut bouger le personnage
                SetNextPosPersonnage(_mouseState, _tileHover, _moteurPhysique, _gameTime);
            BougerPersonnage(_path);
        }


        public void SetNextPosPersonnage(MouseState _mouseState, Vector2 _tileHover, MoteurPhysique _moteurPhysique, GameTime _gameTime)
        {
            _isMouving = true;

            _finalPositionTile = _tileHover;

            if (_path.Count == 0)// si il n'y a pas de déplacement
            {
                _path = _moteurPhysique.GetPath(_positionTile, _finalPositionTile);// retourne toutes les positions en tile par les quelles le personnage va devoir passer
                _path.RemoveAt(0); // on enleve la premiere position car c'est celle de départ
            }


            /*Console.WriteLine("Path a effectuer : ");
            foreach (Vector2 v in _path)
                Console.Write(v + ", ");
            Console.WriteLine();*/
        }

        public void BougerPersonnage(List<Vector2> _path)
        {


            if (_path.Count > 0)
            {
                _nextPositionTile = _path[0]; // se deplacer a la prochaine position

                // pour l'animation

                if (_positionTile != _nextPositionTile)
                {
                    //Console.WriteLine("Mouvement en cours");
                    //Console.WriteLine("_positionTile.X = " + _positionTile.X + ", _nextPositionTile.X = " + _nextPositionTile.X);
                    //Console.WriteLine(" _positionTile == _nextPositionTile : " +  (_positionTile == _nextPositionTile));

                    if (_positionTile.X < _nextPositionTile.X)
                        _directionTile.X = 1;
                    else if (_positionTile.X > _nextPositionTile.X)
                        _directionTile.X = -1;
                    else
                        _directionTile.X = 0;

                    if (_positionTile.Y < _nextPositionTile.Y)
                        _directionTile.Y = 1;
                    else if (_positionTile.Y > _nextPositionTile.Y)
                        _directionTile.Y = -1;
                    else
                        _directionTile.Y = 0;

                    //_positionTile.X += _directionTile.X;// *_vitesseX * (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
                    //_positionTile.Y += _directionTile.Y;//  *_vitesseY * (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
                    _positionTile += _directionTile * _vitesseTile;

                }
                // fin
                //Console.WriteLine("_positionTile.X = " + _positionTile.X + ", _nextPositionTile.X = " + _nextPositionTile.X);
                i++;

                if (i == 20)// 1/_vitesseTile.X)//_positionTile == _nextPositionTile)
                {
                    _positionTile = _path[0];
                    //Console.WriteLine("_path remove !");
                    _path.RemoveAt(0);// lorsque la position est atteinte on enleve la position et on recommence
                    i = 0;
                }

                //Console.WriteLine("i = " + i);

                if (_path.Count == 0)// si le deplacement est finit
                {
                    _isMouving = false;
                    i = 0;
                }
            }
            if (_directionTile.Equals(new Vector2(1, 0)))
                _orientation = 7;
            else if (_directionTile.Equals(new Vector2(1, -1)))
                _orientation = 0;
            else if (_directionTile.Equals(new Vector2(0, -1)))
                _orientation = 1;
            else if (_directionTile.Equals(new Vector2(-1, -1)))
                _orientation = 2;
            else if (_directionTile.Equals(new Vector2(-1, 0)))
                _orientation = 3;
            else if (_directionTile.Equals(new Vector2(-1, 1)))
                _orientation = 4;
            else if (_directionTile.Equals(new Vector2(0, 1)))
                _orientation = 5;
            else if (_directionTile.Equals(new Vector2(1, 1)))
                _orientation = 6;

        }

        
    }
}
