using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ElyseGUI.Models;
using System.Windows.Input;

namespace ElyseGUI.ViewModels
{
    internal class StoryBookViewModel
    {
        private MainViewModel _mainViewModel;
        public List<String> Items
        {
            get;
            private set;
        }

        public StoryBookViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Items = new List<String>();
            LoadList();
        }

        private void LoadList()
        {
            var items = _mainViewModel.StoryBook.GetSubStrList();

            foreach (KeyValuePair<string, string> entry in items)
            {
                Items.Add(entry.Value);
            }
        }
    }
}
