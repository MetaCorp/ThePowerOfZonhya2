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
    class MoteurJeu
    {
        MoteurSysteme _moteurSysteme;
        MoteurPhysique _moteurPhysique;

        public enum StatusJeu
        {
            PageAccueil,
            EnCours,
            EnPause
        } 

        StatusJeu _statusDuJeu;
        public StatusJeu StatusDuJeu { get { return _statusDuJeu; } set { _statusDuJeu = value; } }

        Carte _carte1;
        public Carte Carte1 { get { return _carte1; } set { _carte1 = value; } }

        Carte _carte2;
        public Carte Carte2 { get { return _carte2; } set { _carte2 = value; } }

        ElementDecor _elementDecor;
        public ElementDecor ElementDecor { get { return _elementDecor; } set { _elementDecor = value; } }

        Personnage _personnage1;
        public Personnage Personnage1 { get { return _personnage1; } set { _personnage1 = value; } }

        Vector2 _camera;
        public Vector2 Camera { get { return _camera; } set { _camera = value; } }

        public MoteurJeu()
        {
            _statusDuJeu = StatusJeu.EnCours;
        }

        public void Initialize(MoteurSysteme _moteurSysteme, MoteurPhysique _moteurPhysique)
        {
            this._moteurSysteme = _moteurSysteme;
            this._moteurPhysique = _moteurPhysique;

            _camera = new Vector2(50, -50);

            _personnage1 = new Personnage("Meta", 100, 90, 6, 3);
            _carte1 = new Carte(_moteurSysteme.CarteTableau1, _moteurSysteme.CarteTableauWidth, _moteurSysteme.CarteTableauHeight, _camera, 64, 64, 32, 16);
            _carte2 = new Carte(_moteurSysteme.CarteTableau2,_moteurSysteme.CarteTableauWidth, _moteurSysteme.CarteTableauHeight, _camera, 64, 64, 32, 16);
            _elementDecor = new ElementDecor(_moteurSysteme.ElementDecorTableau);
        }

        public void Update(GameTime _gameTime)
        {
            if (_moteurSysteme.EvenementUtilisateur.KeyBoardState.IsKeyDown(Keys.Escape))
            {
                if(_statusDuJeu == StatusJeu.EnCours)
                    _statusDuJeu = StatusJeu.EnPause;

                else if (_statusDuJeu == StatusJeu.EnPause)
                    _statusDuJeu = StatusJeu.EnCours;

                Console.WriteLine(_statusDuJeu);
            }

            if (_statusDuJeu == StatusJeu.EnCours)
            {
                _carte1.Update(new Vector2(_moteurSysteme.EvenementUtilisateur.MouseState.X, _moteurSysteme.EvenementUtilisateur.MouseState.Y), _camera, _gameTime);
                _personnage1.update(_moteurSysteme.EvenementUtilisateur.MouseState, _carte1.TileHover, _moteurPhysique, _gameTime);
                UpdateCamera(_personnage1.PositionTile);
            }
        }

        public void UpdateCamera(Vector2 _positionTile)
        {
            Vector2 _position = new Vector2(_camera.X + 32 * (_positionTile.X - _positionTile.Y) + 32, _camera.Y + 16 * (_positionTile.X + _positionTile.Y) + 48);
            int _vitesse = 400;
            //_camera = -_position;// - Vector2.One) *10;

            if (_position.X < 300)
                _camera.X += _vitesse / (_position.X + 100);// / (_position.X-213);
            else if (_position.X > 500)
                _camera.X -= _vitesse / ((-_position.X + 800) + 100);

            if (_position.Y < 180)
                _camera.Y += _vitesse / (_position.Y + 100);
            else if (_position.Y > 300)
                _camera.Y -= _vitesse
                    / ((-_position.Y + 480) + 100);


        }


    }
}
