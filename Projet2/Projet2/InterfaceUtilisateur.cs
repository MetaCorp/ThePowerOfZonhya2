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
    class InterfaceUtilisateur
    {
        string[] _item;
        public String[] Item { get { return _item; } set { _item = value; } }

        int _itemHover;
        public int ItemHover { get { return _itemHover; } set { _itemHover = value; } }

        String _sousMenu = "";
        public String SousMenu { get { return _sousMenu; } set { _sousMenu = value; } }
        

        public InterfaceUtilisateur(string[] _item)
        {
            this._item = _item;
            _itemHover = -1;
        }

        public void Update(MouseState _mouseState)
        {
            _itemHover = setItemHover(new Vector2(_mouseState.X, _mouseState.Y));

            if (_mouseState.LeftButton == ButtonState.Pressed && _sousMenu != "")
            {
                if (_sousMenu == "Reglage")
                {
                    if ((_mouseState.Y > 100 && _mouseState.Y < 140) && (_mouseState.X > 460 && _mouseState.Y < 500))
                        _sousMenu = "";
                }
                else if (_sousMenu == "Sauvegarder")
                    _sousMenu = "";
                    
            }
        }

        public int UpdateStatus()
        {
            if (_itemHover == 0)
                return 1;
            else if (ItemHover == 1 || ItemHover == 2)
            {
                _sousMenu = _item[ItemHover];
                return 2;
            }
            else if (ItemHover == 3)
                return 3;
            else return 2;
        }

        public int setItemHover(Vector2 _positionSouris)
        {
            int _nb = -1;

            if (_positionSouris.X > 300 && _positionSouris.X < 500)
            {
                if (_positionSouris.Y > 150 && _positionSouris.Y < 190)
                    _nb = 0;
                else if (_positionSouris.Y > 200 && _positionSouris.Y < 240)
                    _nb = 1;
                else if (_positionSouris.Y > 250 && _positionSouris.Y < 290)
                    _nb = 2;
                else if (_positionSouris.Y > 300 && _positionSouris.Y < 340)
                    _nb = 3;
            }


            return _nb;
        }

    }
}
