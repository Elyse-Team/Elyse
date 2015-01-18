using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.Models
{
    class Character
    {
        public string Name
        {
            get;
            private set;
        }

        public string HeadImage
        {
            get;
            private set;
        }

        public string BodyImage
        {
            get;
            private set;
        }

        public Character()
        {

            Name = "Test perso";
            HeadImage = String.Format("/ElyseGUI;component/Images/heads/{0}.png", "head-left-batman");
            BodyImage = String.Format("/ElyseGUI;component/Images/bodies/{0}.png", "Body-left-alien");
        }
    }
}
