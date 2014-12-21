using ElyseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    [Serializable()]
    public class SceneBuilder
    {
        private List<Character> _characters;
        private Background _background;

        public List<Character> Characters { get { return _characters; } }
        public Background Background { get { return _background; } private set { _background = value; } }

        public SceneBuilder()
        {
            _characters = new List<Character>();
            _background = new Background(Background.Background.None);
        }

        internal void AddCharacter(string name, Character.Gender gender, Character.SkinColor skinColor, Character.ShirtColor shirtColor)
        {
            _characters.Add(new Character(name, -1, -1, gender, skinColor, shirtColor, Character.Style.None));
        }

        internal void DeleteCharacter(Character character)
        {
            _characters.Remove(character);
        }

        internal void SetBackground(Background.Background background)
        {
            _background.MyBackground = background;
        }
    }
}
