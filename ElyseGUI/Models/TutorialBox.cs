using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(p));
        }
    }
}
