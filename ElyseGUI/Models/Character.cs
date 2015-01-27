using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ElyseLibrary;

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
            get { return !IsEmpty; }
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get { return String.IsNullOrWhiteSpace(Name); }
        }

        private ElyseLibrary.Character _coreCharacter;

        public Character(ElyseLibrary.Character coreCharacter) : this()
        {
            _coreCharacter = coreCharacter;
        }

        public Character()
        {
            HeadImage = "head-left-batman";
            BodyImage = "Body-left-alien";
        }

        public void SetBody(int index)
        {
            _coreCharacter.MyShirtColor = (ElyseLibrary.Character.ShirtColor)  index;

            string name = ((ElyseLibrary.Character.ShirtColor)index).ToString();

            BodyImage = "Body-left-"+name;
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
