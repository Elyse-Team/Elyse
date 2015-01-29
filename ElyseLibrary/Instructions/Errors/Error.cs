using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public class Error : Instruction
    {
        public override T Accept<T>(IInstructionVisitor<T> visitor)
        {
            return visitor.visit(this);
        }
    }
}
