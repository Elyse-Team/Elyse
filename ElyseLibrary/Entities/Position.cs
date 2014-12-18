using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class Position : IPositionable
    {
        // Position
        readonly string _name;
        readonly int _x;
        readonly int _y;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Position(string name, int x, int y)
        {
            _name = name;
            _x = x;
            _y = y;
        }
    }
}
