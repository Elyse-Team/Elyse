using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // Represent the mood of a character
    // CHARACTER only
    public class Feel : BasicBehavior
    {
        private string _feeling;
        public string Feeling
        {
            get { return _feeling; }
            set { _feeling = value; }
        }

        public Feel(Character character, string feeling)
            : base(character)
        {
            Feeling = feeling;
        }

        public override T Accept<T>(IInstructionVisitor<T> visitor)
        {
            return visitor.visit(this);
        }
    }
}
