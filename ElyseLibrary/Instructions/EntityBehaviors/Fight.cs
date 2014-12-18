using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseLibrary
{
    // A selection of combat actions
    // CHARACTER only
    internal class Fight : BasicBehavior
    {

       private string _strike;
       public string Strike
       {
           get { return _strike; }
           set { _strike = value; }
       }

       public Fight(Character character, string strike)
         : base(character)
       {
           Strike = strike;
       }
   }
}