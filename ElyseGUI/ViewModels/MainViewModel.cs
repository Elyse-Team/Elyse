using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseGUI.Models;

namespace ElyseGUI.ViewModels
{
    class MainViewModel
    {
        public Story story
        {
            get;
            private set;
        }

        public MainViewModel()
        {
            story = new Story();
            //story.text = "changement";
        }

        public void SaveTextChanges()
        {

        }


    }
}
