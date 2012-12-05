using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Projet2
{
    class MoteurSysteme
    {
        EvenementUtilisateur _evenementUtilisateur;
        public EvenementUtilisateur EvenementUtilisateur { get { return _evenementUtilisateur; } set { _evenementUtilisateur = value; } }

        Char[,] _carteTableau1;
        public Char[,] CarteTableau1 { get { return _carteTableau1; } set { _carteTableau1 = value; } }

        Char[,] _carteTableau2;
        public Char[,] CarteTableau2 { get { return _carteTableau2; } set { _carteTableau2 = value; } }

        int _carteTableauWidth;
        public int CarteTableauWidth { get { return _carteTableauWidth; } set { _carteTableauWidth = value; } }

        int _carteTableauHeight;
        public int CarteTableauHeight { get { return _carteTableauHeight; } set { _carteTableauHeight = value; } }

        int[,] _elementDecorTableau;
        public int[,] ElementDecorTableau { get { return _elementDecorTableau; } set { _elementDecorTableau = value; } }

        System.IO.StreamReader _fileCarte;
        System.IO.StreamReader _fileDecor;

        public MoteurSysteme()
        {
            _evenementUtilisateur = new EvenementUtilisateur();

            _carteTableau1 = lireCarte(Environment.CurrentDirectory + @"\carte1.txt", _carteTableau1);
            _carteTableau2 = lireCarte(Environment.CurrentDirectory + @"\carte2.txt", _carteTableau2);
            _elementDecorTableau = lireDecor(Environment.CurrentDirectory + @"\decor.txt");
        }

        public void Update(GameTime _gameTime)
        {
            _evenementUtilisateur.Update(_gameTime);
        }

        public Char[,] lireCarte(String asset, Char[,] _carteTableau)
        {
            _fileCarte = new System.IO.StreamReader(asset);

            _carteTableauWidth = Convert.ToInt32(_fileCarte.ReadLine());
            _carteTableauHeight = Convert.ToInt32(_fileCarte.ReadLine());

            _carteTableau = new Char[_carteTableauWidth, _carteTableauHeight];

            for (int j = 0; j < _carteTableauHeight; j++)
            {
                for (int i = 0; i < _carteTableauWidth; i++)
                {
                    _carteTableau[i, j] = (Char)_fileCarte.Read();

                    if (i == (_carteTableauWidth - 1) && j != (_carteTableauHeight - 1)) // passe le char de retour à la ligne
                    {
                        _fileCarte.Read();
                        _fileCarte.Read();
                    }
                }
            }
            return _carteTableau;
        }

        public int[,] lireDecor(String asset) //chaque ligne etant de type : 5(2,4)
        {//                                         avec 5 le type, 2 le x et 4 le y
            _fileDecor = new System.IO.StreamReader(asset);

            int _nbDecor = Convert.ToInt32(_fileDecor.ReadLine());

            Console.WriteLine(_nbDecor);

            int[,] _decorTableau = new int[3, _nbDecor];

            String _ligne;

            for (int i = 0; i < _nbDecor; i++)
            {
                _ligne = _fileDecor.ReadLine();

                int a = 0, b = 0, c = 0;

                int _currentVariable = 1;

                for (int j = 0; j < _ligne.Length; j++)
                {
                    if (_ligne[j] == '(' || _ligne[j] == ',' || _ligne[j] == ')')
                    {
                        _currentVariable++;
                    }
                    else 
                    {
                        if (_currentVariable == 1)
                                a = a * 10 + Convert.ToInt32(_ligne[j].ToString());

                        if (_currentVariable == 2)
                                b = b * 10 + Convert.ToInt32(_ligne[j].ToString());

                        if (_currentVariable == 3)
                                c = c * 10 + Convert.ToInt32(_ligne[j].ToString());

                        
                    }
                }

                Console.WriteLine("a = " + a + " b = " + b + " c = " + c);

                _decorTableau[0, i] = a;
                _decorTableau[1, i] = b;
                _decorTableau[2, i] = c;
            }

            return _decorTableau;

        }

    }
}
