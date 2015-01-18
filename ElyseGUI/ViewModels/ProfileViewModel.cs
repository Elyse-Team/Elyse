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

        public ProfileViewModel(MainViewModel mainViewModel, Models.Character character)
        {
            Character = character;
            _mainViewModel = mainViewModel;
        }
    }
}
