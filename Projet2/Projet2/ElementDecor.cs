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
    class ElementDecor
    {
        int[,] _decorTableau;
        public int[,] DecorTableau { get { return _decorTableau; } set { _decorTableau = value; } }

        int _nbDecor;
        public int NbDecor { get { return _nbDecor; } set { _nbDecor = value; } }

        public ElementDecor(int[,] _decorTableau)
        {
            this._decorTableau = _decorTableau;

            _nbDecor = _decorTableau.Length / 3;// car 3 nb pour chaque decor, type x y
        }


    }
}
