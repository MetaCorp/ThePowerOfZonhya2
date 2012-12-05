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
    class MoteurGraphique
    {
        MoteurJeu _moteurJeu;

        SpriteCarte _spriteCarte1;
        public SpriteCarte SpriteCarte1 { get { return _spriteCarte1; } set { _spriteCarte1 = value; } }

        SpriteCarte _spriteCarte2;

        SpriteDecor _spriteDecor;

        SpriteIU _spriteIU;

        SpriteAnime _personnage1;

        Vector2 _camera;

        public MoteurGraphique()
        {
            
        }

        public void Initialize(MoteurJeu _moteurJeu, Vector2 _camera)
        {
            _spriteIU = new SpriteIU(_moteurJeu.InterfaceUtilisateur);

            this._camera = _camera;

            _spriteCarte1 = new SpriteCarte(_moteurJeu.Carte1, 1, _camera);// carte de fond
            _spriteCarte2 = new SpriteCarte(_moteurJeu.Carte2, 2, _camera);// 2nde carte pour l'eau etc

            _spriteDecor = new SpriteDecor(_moteurJeu.ElementDecor, _camera);// arbres, buissons, etc
            this._moteurJeu = _moteurJeu;


            _personnage1 = new SpriteAnime(_moteurJeu.Personnage1.PositionTile, 2, 4, 100, _camera);
        }



        public void LoadContent(ContentManager _content)
        {
            _spriteCarte1.LoadContent(_content, "TileSetIso", "hilight");
            _spriteCarte2.LoadContent(_content, "TileSetIso", "hilight");
            _personnage1.LoadContent(_content, "brasegali");
            _spriteDecor.LoadContent(_content, "TileSetIso");
            _spriteIU.LoadContent(_content, "rpg_gui_v1", "SpriteFont1");
        }

        public void Update(Vector2 _camera, GameTime _gameTime)
        {
            if (_moteurJeu.StatusDuJeu == Projet2.MoteurJeu.StatusJeu.EnCours)
            {
                _personnage1.Update(_moteurJeu.Personnage1.PositionTile, _moteurJeu.Personnage1.Orientation, _moteurJeu.Personnage1.IsMouving, _camera, _gameTime);
                _spriteCarte1.Update(_camera);
                _spriteCarte2.Update(_camera);
                _spriteDecor.Update(_camera);
            }
            else if (_moteurJeu.StatusDuJeu == Projet2.MoteurJeu.StatusJeu.EnPause)
            {
                _spriteIU.Update(_moteurJeu.InterfaceUtilisateur.ItemHover);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (_moteurJeu.StatusDuJeu == Projet2.MoteurJeu.StatusJeu.EnCours)
            {
                _spriteCarte1.Draw(_spriteBatch, Color.White);
                _spriteCarte2.Draw(_spriteBatch, Color.White);
                _personnage1.Draw(_spriteBatch, Color.White);
                _spriteDecor.Draw(_spriteBatch, Color.White);
            }
            else if (_moteurJeu.StatusDuJeu == Projet2.MoteurJeu.StatusJeu.EnPause)
            {
                _spriteCarte1.Draw(_spriteBatch, Color.Gray);
                _spriteCarte2.Draw(_spriteBatch, Color.Gray);
                _personnage1.Draw(_spriteBatch, Color.Gray);
                _spriteDecor.Draw(_spriteBatch, Color.Gray);

                _spriteIU.Draw(_spriteBatch);
            }


        }


    }
}
