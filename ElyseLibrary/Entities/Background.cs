using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary.Entities
{
    internal class Background
    {
        private Background _background;

        public Background MyBackground
        {
            get { return _background; }
            set { _background = value; }
        }

        public enum Background
        {
            None,
            Beach,
            Dungeon,
            Garden,
            GothamCity,
            House,
            Ovni,
            Party,
            Street
        }

        public Background(Background background = Background.None)
        {
            MyBackground = background;
        }
    }
}
