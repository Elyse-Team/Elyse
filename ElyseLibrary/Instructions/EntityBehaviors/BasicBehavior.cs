using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Basic behavior of alive entities
    // CHARACTER & ANIMAL
    public abstract class BasicBehavior : Instruction
    {
        readonly Character _entity;
        public Character Entity
        {
            get { return _entity; }
        }

        public BasicBehavior(Character entity)
        {
            _entity = entity;
        }

        
    }
}
