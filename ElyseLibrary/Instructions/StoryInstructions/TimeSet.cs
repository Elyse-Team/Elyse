using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class TimeSet : Instruction
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
    }
}
