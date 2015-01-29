using ElyseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public class BackgroundSet : Instruction
    {
        private Background _background;

        public Background Background
        {
            get { return _background; }
            private set { _background = value; }
        }

        public BackgroundSet(Background background)
        {
            _background = background;
        }

        public override T Accept<T>(IInstructionVisitor<T> visitor)
        {
            return visitor.visit(this);
        }
    }
}