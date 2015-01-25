using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Talk alone or with another entity
    // CHARACTER & ANIMAL
    internal class Talk : BasicBehavior
    {
        private IMaterializable _target;
        private string _sentence;

        public IMaterializable Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public string Sentence
        {
            get { return _sentence; }
            set { _sentence = value; }
        }

		public Talk(IKillable entity, IMaterializable target, string sentence)
            : base(entity)
		{
			Target = target;
            Sentence = sentence;
		}
    }
}
