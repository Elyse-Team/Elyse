using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Basic behavior of alive entities
    // CHARACTER & ANIMAL
    internal abstract class BasicBehavior : Instruction
    {
        readonly IKillable _entity;
        public IKillable Entity
        {
            get { return _entity; }
        }

        public BasicBehavior(IKillable entity)
        {
            _entity = entity;
        }
    }
}
