using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    internal class Narrator : Instruction
    {
        private string _narration;
        private int _duration;

        public string Narration
        {
            get { return _narration; }
            set { _narration = value; }
        }

        public int Duration
        {
            get;
            set;
        }

        public Narrator(string narration, int duration = 2)
        {
            Narration = narration;
            Duration = duration;
        }
    }
}
