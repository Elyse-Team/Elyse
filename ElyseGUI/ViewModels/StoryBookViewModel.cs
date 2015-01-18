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
        private StoryBook _storyBook;
        public List<String> Items
        {
            get;
            private set;
        }

        public bool hasItems { get { return Items.Count() > 0; }}

        public StoryBookViewModel()
        {
            Items = new List<String>();
            LoadList();
        }

        private void LoadList()
        {
            _storyBook = new StoryBook();

            var items = _storyBook.GetSubStrList();

            foreach (KeyValuePair<string, string> entry in items)
            {
                Items.Add(entry.Value);
            }
        }
    }
}
