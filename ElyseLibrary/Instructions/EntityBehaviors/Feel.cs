﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary.EntityBehaviors
{
    // Represent the mood of a character
    internal class Feel : BasicBehavior
    {
        private string _feeling;
        public string Feeling
        {
            get { return _feeling; }
            set { _feeling = value; }
        }

        public Feel(Entity character, string feeling)
            : base(character)
        {
            Feeling = feeling;
        }
    }
}
