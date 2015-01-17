using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elyse.Languagetool;

namespace ElyseGUI.Models
{
    class TutorialBox : INotifyPropertyChanged
    {
        private string _msg;

        public string msg
        {
            get
            {
                return _msg;
            }
            set
            {
                _msg = value;
                OnPropertyChanged("msg");
            }
        }

        public void SetMsgFromErrors(List<Error> errors)
        {
            _msg = "";

            foreach(Error e in errors)
            {
                _msg += String.Format("msg: {0}, cat: {1}, rep: {2}", e.msg, e.category, String.Join("-", e.replacements));
                _msg += "\n";
            }
            msg = _msg;
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
