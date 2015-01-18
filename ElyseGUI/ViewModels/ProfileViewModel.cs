using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseGUI.ViewModels
{
    class ProfileViewModel
    {
        private ProfileWindow _window;
        private MainViewModel _mainViewModel;

        public ProfileViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void OpenWindow()
        {
            if( _window != null)
            {
                _window.Focus();
                return;
            }

            _window = new ProfileWindow();
            _window.Show();
        }
    }
}
