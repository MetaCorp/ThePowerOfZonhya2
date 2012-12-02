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

        enum StatusJeu
        {
            PageAccueil,
            EnCours,
            enPause
        }

        StatusJeu _statusJeu;

        Carte _carte1;
        public Carte Carte1 { get { return _carte1; } set { _carte1 = value; } }

        Carte _carte2;
        public Carte Carte2 { get { return _carte2; } set { _carte2 = value; } }

        ElementDecor _elementDecor;
        public ElementDecor ElementDecor { get { return _elementDecor; } set { _elementDecor = value; } }

        Personnage _personnage1;
        public Personnage Personnage1 { get { return _personnage1; } set { _personnage1 = value; } }

        public MoteurJeu()
        {
            _statusJeu = StatusJeu.PageAccueil;
        }

        public void Initialize(MoteurSysteme _moteurSysteme, MoteurPhysique _moteurPhysique, Color[] _colorMouseMap)
        {
            this._moteurSysteme = _moteurSysteme;
            this._moteurPhysique = _moteurPhysique;

            _personnage1 = new Personnage("Meta", 100, 90, 6, 3);
            _carte1 = new Carte(_moteurSysteme.CarteTableau1, _colorMouseMap, _moteurSysteme.CarteTableauWidth, _moteurSysteme.CarteTableauHeight, 64, 64, 32, 16);
            _carte2 = new Carte(_moteurSysteme.CarteTableau2, _colorMouseMap,_moteurSysteme.CarteTableauWidth, _moteurSysteme.CarteTableauHeight, 64, 64, 32, 16);
            _elementDecor = new ElementDecor(_moteurSysteme.ElementDecorTableau);
        }

        public void Update(GameTime _gameTime)
        {
            _carte1.Update(new Vector2(_moteurSysteme.EvenementUtilisateur.MouseState.X, _moteurSysteme.EvenementUtilisateur.MouseState.Y), _gameTime);
            _personnage1.update(_moteurSysteme.EvenementUtilisateur.MouseState, _carte1.TileHover, _moteurPhysique, _gameTime);
            //_personnage1.BougerPersonnage(_moteurSysteme.EvenementUtilisateur.MouseState, _gameTime);
        }


    }
}
