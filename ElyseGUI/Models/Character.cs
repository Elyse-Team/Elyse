using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ElyseGUI.Models
{
    class Character : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
                OnPropertyChanged("IsFilled");
                OnPropertyChanged("IsEmpty");
            }
        }

        private string _headImage;
        public string HeadImage
        {
            get { return _headImage; }
            set 
            {
                _headImage = String.Format("/ElyseGUI;component/Images/heads/{0}.png", value);
                OnPropertyChanged("HeadImage");
            }
        }

        private string _bodyImage;
        public string BodyImage
        {
            get { return _bodyImage; }
            set
            {
                _bodyImage = String.Format("/ElyseGUI;component/Images/bodies/{0}.png", value);   
                OnPropertyChanged("BodyImage");
            }
        }

        private bool _isFilled;
        public bool IsFilled
        {
            //get { return !String.IsNullOrWhiteSpace(Name); }
            get { return !IsEmpty; }
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get { return String.IsNullOrWhiteSpace(Name); }
        }

        public Character()
        {

            //Name = "Test perso pornographique";
            HeadImage = "head-left-batman";
            BodyImage = "Body-left-alien";
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
