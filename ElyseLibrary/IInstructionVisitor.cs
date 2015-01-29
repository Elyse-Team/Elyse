using ElyseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public interface IInstructionVisitor<T>
    {
        T visitInstruction(Instruction i);
        T visit(Move i);
        T visit(Feel i);
        T visit(Talk i);
        T visit(Think i);
        T visit(Fight i);
        T visit(Error i);
        T visit(BackgroundSet i);
        T visit(Narrator i);
        T visit(TimeSet i);
    }
}
