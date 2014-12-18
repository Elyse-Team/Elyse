using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal abstract class BasicBehavior : Instruction
    {
        readonly Character _character;
        public Character Character
        {
            get { return _character; }
        }

        public BasicBehavior(Character character)
        {
            _character = character;
        }
    }
}
