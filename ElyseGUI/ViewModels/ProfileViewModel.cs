using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseGUI.ViewModels
{
    internal class ProfileViewModel
    {
        private ProfileWindow _window;
        private MainViewModel _mainViewModel;
        public Models.Character Character
        {
            get;
            private set;
        }

        public ProfileViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void OpenWindow(Models.Character character)
        {
            Character = character;

            if( _window != null)
            {
                _window.Focus();
                return;
            }

            
            _window = new ProfileWindow();
            _window.DataContext = this;
            _window.Show();
        }
    }
}
