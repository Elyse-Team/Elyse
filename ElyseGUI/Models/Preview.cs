using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ElyseGUI.Models
{
    class Preview : INotifyPropertyChanged
    {
        private string _backgroundImage;

        public string backgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = String.Format("/ElyseGUI;component/Images/backgrounds/{0}.jpg", value); ;
                OnPropertyChanged("backgroundImage");
            }
        }
            
        public Preview()
        {
            backgroundImage = "background_beach";
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
