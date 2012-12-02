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

        InterfaceUtilisateur _interfaceUtilisateur;

        SpriteAnime _personnage1;

        public MoteurGraphique()
        {
            _interfaceUtilisateur = new InterfaceUtilisateur();
        }

        public void Initialize(MoteurJeu _moteurJeu)
        {
            _spriteCarte1 = new SpriteCarte(_moteurJeu.Carte1, 1);
            _spriteCarte2 = new SpriteCarte(_moteurJeu.Carte2, 2);

            _spriteDecor = new SpriteDecor(_moteurJeu.ElementDecor);
            this._moteurJeu = _moteurJeu;

            _personnage1 = new SpriteAnime(_moteurJeu.Personnage1.PositionTile, 2, 4, 100);
        }



        public void LoadContent(ContentManager _content)
        {
            _spriteCarte1.LoadContent(_content, "TileSetIso", "hilight");
            _spriteCarte2.LoadContent(_content, "TileSetIso", "hilight");
            _personnage1.LoadContent(_content, "brasegali");
            _spriteDecor.LoadContent(_content, "TileSetIso");
        }

        public void Update(GameTime _gameTime)
        {
            _personnage1.Update(_moteurJeu.Personnage1.PositionTile, _moteurJeu.Personnage1.Orientation, _moteurJeu.Personnage1.IsMouving, _gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteCarte1.Draw(_spriteBatch);
            _spriteCarte2.Draw(_spriteBatch);
            _personnage1.Draw(_spriteBatch);
            _spriteDecor.Draw(_spriteBatch);
        }


    }
}
