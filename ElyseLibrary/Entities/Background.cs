using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary.Entities
{
    internal class Background
    {
        private BackgroundType _background;

        public BackgroundType MyBackground
        {
            get { return _background; }
            set { _background = value; }
        }

        public enum BackgroundType
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

        public Background(BackgroundType background = BackgroundType.None)
        {
            MyBackground = background;
        }
    }
}
