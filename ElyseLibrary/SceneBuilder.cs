using ElyseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    [Serializable]
    public class SceneBuilder
    {
        private List<Character> _characters;
        private Background _background;
        private string _story;

        public List<Character> Characters { get { return _characters; } set { _characters = value; } }
        internal Background Background { get { return _background; } set { _background = value; } }
        internal string Story { get { return _story; } set { _story = value; } }

        public SceneBuilder()
        {
            _characters = new List<Character>();
            _background = new Background(Background.BackgroundType.None);
            _story = "";
        }

        public void AddCharacter(string name, Character.Gender gender, Character.SkinColor skinColor, Character.ShirtColor shirtColor)
        {
            _characters.Add(new Character(name, -1, -1, gender, skinColor, shirtColor, Character.Style.None));
        }

        public void DeleteCharacter(Character character)
        {
            _characters.Remove(character);
        }

        public void SetBackground(Background.BackgroundType background)
        {
            _background.MyBackground = background;
        }

        public void EditStory(string story)
        {
            Story = story;
        }

        public string GetStory()
        {
            return Story;
        }
    }
}
