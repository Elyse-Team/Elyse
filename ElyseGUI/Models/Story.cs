using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elyse.Languagetool;

namespace ElyseGUI.Models
{
    internal class Story : INotifyPropertyChanged
    {
        public List<Error> spellCheckerErrors { get { return _spellCheckerErrors; } }
        private List<Error> _spellCheckerErrors;

        public bool hasError { get { return _spellCheckerErrors.Count > 0;  } }

        private string _text;

        public string text {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("text");
            }
        }

        public bool canEdit;

        public bool canPlay
        {
            get { return !String.IsNullOrEmpty(_text)  && canEdit; }
        }

        public Story()
        {
            _spellCheckerErrors = new List<Error>();
        }

        public async Task<bool> FindSpellCheckerErrors()
        {
            Languagetool spellChecker = new Languagetool("http://localhost:8081/");
            _spellCheckerErrors = await spellChecker.GetErrors(_text);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
