using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class Entity : IPosition
    {
        private int _x;
        private int _y;
        private string _name;
        internal enum EntityType
        {
            Character,
            Animal,
            Item,
            Position
        }
        // enum SkinColor { White, Black }, enum Gender { Male, Female }

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
            set { _name = value; }
        }

        private EntityType _type;
        internal EntityType Type
        {
            get { return _type; }
            private set { _type = value; }
        }

        internal Entity(string name, int x, int y, EntityType type)
        {
            _name = name;
            _type = type;
            _x = x;
            _y = y;
        }

        
    }
}
