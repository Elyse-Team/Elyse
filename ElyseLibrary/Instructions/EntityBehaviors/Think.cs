using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Thoughts of an entity
    // CHARACTER & ANIMAL
    internal class Think : BasicBehavior
    {
        private string _thoughts;

        public string Thoughts
        {
            get { return _thoughts; }
            set { _thoughts = value; }
        }

        public Think(IKillable entity, string thoughts)
            : base(entity)
        {
            Thoughts = thoughts;
        }
    }
}
