using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class Time : Instruction
    {
        private int _time;

        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public Time(int time)
        {
            Time = time;
        }
    }
}
