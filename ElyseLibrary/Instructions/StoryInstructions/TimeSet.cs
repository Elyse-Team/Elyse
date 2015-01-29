using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    public class TimeSet : Instruction
    {
        private int _time;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public TimeSet(int time)
        {
            Time = time;
        }
        public override T Accept<T>(IInstructionVisitor<T> visitor)
        {
            return visitor.visit(this);
        }
    }
}
