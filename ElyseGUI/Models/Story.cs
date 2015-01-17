using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elyse.Languagetool;

namespace ElyseGUI.Models
{
    internal class Story
    {
        public List<Error> syntaxErrors;
        private string _text;

        public bool canPreview;
        public bool canPlay;
        public bool haveError;
        public bool haveSyntaxError;
        public bool haveMeaningError;

        public string text {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }


        public Story()
        {

        }
    }
}
