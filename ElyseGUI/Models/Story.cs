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
        public List<Error> SpellCheckerErrors { get { return _spellCheckerErrors; } }
        private List<Error> _spellCheckerErrors;

        public bool HasError { get { return _spellCheckerErrors.Count > 0;  } }

        private string _text;

        public string Text {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private bool _canEdit;

        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                _canEdit = value;
                OnPropertyChanged("CanEdit");
            }
        }

        public bool CanPlay
        {
            get { return !IsEmpty && _canEdit; }
        }

        public bool IsEmpty
        {
            get { return String.IsNullOrWhiteSpace(_text);  }
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
