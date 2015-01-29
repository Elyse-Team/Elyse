using ElyseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public class Scene
    {
        // Environment
        private List<Position> _positions;
        readonly int _height;
        readonly int _width;
        private Background _background;

        // Entities
        private List<Character> _characters;


        public List<Position> Positions { get { return _positions; } }
        internal int Height { get { return _height; } }
        internal int Width { get { return _width; } }
        public Background Background { get { return _background; } set { _background = value; } }

        public List<Character> Characters { get { return _characters; } }

        // Constructeur de la Scene
        public Scene(SceneBuilder sceneBuilder)
        {
            _positions = new List<Position>();
            _characters = new List<Character>(sceneBuilder.Characters);

            _height = 2;
            _width = 5;
            Background = sceneBuilder.Background;

            // définition des positions
            AddPosition("center", _width / 2, 0);
            AddPosition("left", 0, 0);
            AddPosition("right", _width - 1, 0);
            AddPosition("sky", _width / 2, _height - 1);
            AddPosition("outleft", -2, 0);
            AddPosition("outright", _width + 2, 0);
            AddPosition("outsky", _width / 2, 0);

        }

        internal void AddPosition(string name, int x = -1, int y = -1)
        {
            _positions.Add(new Position(name, x, y));
        }

        internal Position PositionExist(string nameToFind)
        {
            return _positions.Find((e) => { return String.Compare(e.Name, nameToFind) == 0; });
        }

        internal bool IsOnScreen(Position p)
        {
            return p.X >= 0 && p.X < _width && p.Y >= 0 && p.Y < _height;
        }

        internal bool PositionIsFree(Position p)
        {
            Character c = _characters.Find((e) => { return p.X == e.X && p.Y == e.Y; });
            return c == null;
        }

        public Position FindFreePosition(IPositionable p)
        {
            Position t = new Position("temp", p.X, p.Y);
            int d = 1;
            bool i = false;
            while (!PositionIsFree(t) && IsOnScreen(t))
            {
                i = !i;
                if (i) t.X = p.X + d;
                else { t.X = p.X - d; d++; }
            }
            return t;
        }


    }
}