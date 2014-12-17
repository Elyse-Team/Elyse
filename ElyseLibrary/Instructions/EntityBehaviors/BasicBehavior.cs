using ElyseLibrary.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary.EntityBehaviors
{
    internal abstract class BasicBehavior : Instruction
    {
        protected Entity _entity;
        public Entity Entity
        {
            get { return _entity; }
        }

        public BasicBehavior(Entity entity)
        {
            _entity = entity;
        }
    }
}
