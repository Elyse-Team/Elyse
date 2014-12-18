﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Move from a position to another position
    // CHARACTER & ANIMAL
    internal class Move : BasicBehavior
    {
        private IPositionable _target;
        public IPositionable Target
        {
            get { return _target; }
            set { _target = value; }
        }

		public Move(IKillable entity, IPositionable target)
            : base(entity)
		{
		    Target = target;
		}
    }
}