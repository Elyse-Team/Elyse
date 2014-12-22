using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class Item : IPositionable, IMaterializable
    {
        // Position
        private bool _material;
        private int _x;
        private int _y;

        // Render
        readonly string _name;
        private Style _style;

        public bool Material
        {
            get { return _material; }
            set { _material = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Style ItemStyle
        {
            get { return _style; }
            set { _style = value; }
        }

        internal enum Style
        {
            Cloud,
            Smoke,
            Blood
        }

        public Item(Style style, int x, int y, string name = "unknow item")
        {
            Material = true;
            ItemStyle = style;
            X = x;
            Y = y;
            _name = name;
        }
    }
}
