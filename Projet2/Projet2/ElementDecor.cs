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

        // provisoire
        int _nbDecor = 5;
        public int NbDecor { get { return _nbDecor; } set { _nbDecor = value; } }

        public ElementDecor(int[,] _decorTableau)
        {
            this._decorTableau = _decorTableau;
        }


    }
}
