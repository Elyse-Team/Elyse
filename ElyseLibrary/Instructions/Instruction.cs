using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElyseLibrary
{
    public abstract class Instruction
    {
        public abstract T Accept<T>(IInstructionVisitor<T> visitor);
    }
}
