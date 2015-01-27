using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    [Serializable]
    public class Character : IPositionable, IKillable
    {
        // Position
        private int _x;
        private int _y;

        // Render
        readonly string _name;
        private Gender _gender;
        private SkinColor _skinColor;
        private ShirtColor _shirtColor;
        private Style _style;

        // Health
        private Health _health;

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

        public Gender MyGender
        {
            get { return _gender; }
            private set { _gender = value; }
        }

        public SkinColor MySkinColor
        {
            get { return _skinColor; }
            private set { _skinColor = value; }
        }

        public ShirtColor MyShirtColor
        {
            get { return _shirtColor; }
            set { _shirtColor = value; }
        }

        public Style MyStyle
        {
            get { return _style; }
            set { _style = value; }
        }

        public Health MyHealth
        {
            get { return _health; }
            set { _health = value; }
        }

        public enum Gender
        {
            Male,
            Female
        }

        public enum SkinColor
        {
            White,
            Black
        }

        public enum ShirtColor
        {
            Blue,
            Green,
            Purple,
            Red,
            Yellow
        }

        public enum Style
        { 
            None,
            Vampire,
            Werewolf,
            Ghost,
            Zombie,
            Cramp,
            Pirat,
            Alien,
            Clown,
            Punk,
            Batman,
            Freddy,
            Jason,
            Trucker,
            WhiteSuit,
            BlackSuit
        }

        public enum Health
        {
            Alive,
            Bleeding,
            Dead,
            Zombie,
            Ghost
        }

        public Character(string name, int x, int y,
                        Gender gender = Gender.Male,
                        SkinColor skinColor = SkinColor.White,
                        ShirtColor shirtColor = ShirtColor.Blue,
                        Style style = Style.None)
        {
            X = x;
            Y = y;
            _name = name;
            MyGender = gender;
            MySkinColor = skinColor;
            MyShirtColor = shirtColor;
            MyStyle = style;
        }

    }
}
