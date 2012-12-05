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
    class MoteurPhysique
    {

        Carte _carte1;
        Carte _carte2;
        ElementDecor _elementDecor;

        int[,] _collisionTableau;

        public MoteurPhysique()
        {
            _collisionTableau = new int[20, 20];
        }

        public void Initialize(Carte _carte1, Carte _carte2, ElementDecor _elementDecor)
        {
            this._carte1 = _carte1;
            this._carte2 = _carte2;
            this._elementDecor = _elementDecor;

            _collisionTableau = SetCollisionTableau(_carte1, _carte2, _elementDecor);
        }

        // algorythme Astar simplifié (beaucoup ?) (je sais pas si il faut essayer de comprendre ca xD)
        public List<Vector2> GetPath(Vector2 _positionDepart, Vector2 _positionFinale) // position sur les tiles isos
        {
            Console.WriteLine("set path :");
            _positionFinale.X = (int)_positionFinale.X;
            _positionFinale.Y = (int)_positionFinale.Y;
            //Console.WriteLine("Depart : " + _positionDepart);
            //Console.WriteLine("Arrivé : " + _positionFinale);

            Node _currentNode = new Node(null, GetF(_positionDepart, _positionFinale, _positionDepart, 0), _positionDepart);
            List<Node> _openList = new List<Node>();
            List<Node> _closedList = new List<Node>();

            bool _retour = false; // vaut vrai si la position a deja ete parcouru (evite de retourner en arriere)

            List<Vector2> _path = new List<Vector2>(); ;

            Vector2[] _adjacentNodePos = new Vector2[8];

            _openList.Add(_currentNode);

            int x = 0;
            while (_currentNode.Pos != _positionFinale && !_retour)
            //for (int j = 0; j < 5; j++)
            {
                _adjacentNodePos[0] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y);
                _adjacentNodePos[1] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y);
                _adjacentNodePos[2] = new Vector2(_currentNode.Pos.X, _currentNode.Pos.Y + 1);
                _adjacentNodePos[3] = new Vector2(_currentNode.Pos.X, _currentNode.Pos.Y - 1);
                _adjacentNodePos[4] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y + 1);
                _adjacentNodePos[5] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y - 1);
                _adjacentNodePos[6] = new Vector2(_currentNode.Pos.X + 1, _currentNode.Pos.Y - 1);
                _adjacentNodePos[7] = new Vector2(_currentNode.Pos.X - 1, _currentNode.Pos.Y + 1);

                for (int i = 0; i < 8; i++)
                {
                    //Console.WriteLine("X : " + (int)_adjacentNodePos[i].X + " Y : " + (int)_adjacentNodePos[i].Y + " coef : " + _collisionTableau[(int)_adjacentNodePos[i].X, (int)_adjacentNodePos[i].Y]);
                    /*foreach(Node n in _closedList)
                        if (_adjacentNodePos[i] == n.Pos)
                            _retour = true;

                    if (!_retour)*/
                    _openList.Add(new Node(_currentNode, GetF(_positionDepart, _positionFinale, _adjacentNodePos[i], _collisionTableau[(int)_adjacentNodePos[i].X, (int)_adjacentNodePos[i].Y]), _adjacentNodePos[i]));
                    //new Node(_currentNode, GetF(_positionDepart, _positionFinale, _adjacentNodePos[i], _collisionTableau[(int)_adjacentNodePos[i].X, (int)_adjacentNodePos[i].Y]), _adjacentNodePos[i]).display();
                }

                if (!isRetour(_openList[0], _closedList))
                    _closedList.Add(_openList[0]);
                else
                {
                    Console.WriteLine("occurence de retour !");
                    _retour = true;
                }// on deplace le noeud parent dans la closedList

                Console.WriteLine("nouvelle position : " + _openList[0].Pos + ", sa value : " + _collisionTableau[(int)_openList[0].Pos.X, (int)_openList[0].Pos.Y]);

                _openList.RemoveAt(0);

                for (int i = 0; i < 7; i++)
                {
                    if (_openList[0].F < _openList[1].F) // garde le f le plus petit
                        _openList.RemoveAt(1);
                    else _openList.RemoveAt(0);
                }

                _currentNode = _openList[0];

                x++;
            }

            _closedList.Add(_openList[0]);

            foreach (Node n in _closedList)
                _path.Add(n.Pos);

            return _path;

        }

        public bool isRetour(Node _newNode, List<Node> _closedList)
        {
            Console.WriteLine("test isRetour");

            foreach (Node n in _closedList)
            {
                Console.WriteLine("newNode = " + _newNode.Pos + ", n = " + n.Pos);
                if (n.Pos == _newNode.Pos)
                    return true;
            }

            return false;
        }

        public float GetF(Vector2 _startPos, Vector2 _endPos, Vector2 _currentPos, float _coef) // 0 si rien 1 si mur
        {
            return //(float)Math.Sqrt((Math.Pow(_currentPos.X - _startPos.X, 2) + Math.Pow(_currentPos.Y - _startPos.Y, 2)))
                 +(float)Math.Sqrt((Math.Pow(_endPos.X - _currentPos.X, 2) + Math.Pow(_endPos.Y - _currentPos.Y, 2)))
                 + _coef * 1000;
        }

        public int[,] SetCollisionTableau(Carte _carte1, Carte _carte2, ElementDecor _elementDecor)
        {
            int[,] _collisionTableau = new int[_carte1.TileTotalWidth,_carte1.TileTotalHeight];

            Console.WriteLine("setcollision");

            for (int y = 0; y < 40; y++)
            {
                for (int x = 0; x < 40; x++)
                {// reste a ajouter les numéros
                    if ((_carte1.TileArray[x, y] > 64 && _carte1.TileArray[x, y] < 91) || (_carte2.TileArray[x, y] > 64 && _carte2.TileArray[x, y] < 91))
                    {
                        _collisionTableau[x, y] = 1;
                        Console.WriteLine("Collision en " + x + ", " + y);
                    }

                    //_collisionTableau[_elementDecor.DecorTableau[1, y], _elementDecor.DecorTableau[2, y]] = 1;
                }
            }


            return _collisionTableau;
        }
    }

    class Node
    {
        Node _parentNode;
        public Node ParentNode { get { return _parentNode; } set { _parentNode = value; } }

        float _f;
        public float F { get { return _f; } set { _f = value; } }

        Vector2 _pos;
        public Vector2 Pos { get { return _pos; } set { _pos = value; } }

        public Node(Node _parentNode, float _f, Vector2 _pos)
        {
            this._parentNode = _parentNode;
            this._f = _f;
            this._pos = _pos;
        }

    }
}
