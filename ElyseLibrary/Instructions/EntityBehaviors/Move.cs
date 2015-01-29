using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Move from a position to another position
    // CHARACTER & ANIMAL
    public class Move : BasicBehavior
    {
        private IPositionable _target;
        public IPositionable Target
        {
            get { return _target; }
            set { _target = value; }
        }

		public Move(Character entity, IPositionable target)
            : base(entity)
		{
		    Target = target;
		}


        public override T Accept<T>(IInstructionVisitor<T> visitor)
        {
            return visitor.visit(this);
        }
    }
}