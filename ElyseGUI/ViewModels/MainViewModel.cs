using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseGUI.Models;
using System.Windows.Input;

namespace ElyseGUI.ViewModels
{
    internal class MainViewModel
    {
        public Story story
        {
            get;
            private set;
        }

        public ICommand PlayCommand
        {
            get;
            private set;
        }
        public MainViewModel()
        {
            story = new Story();
            PlayCommand = new Commands.PlayCommand(this);
        }

        public bool CanPlayStory { 
            get { 
                return !String.IsNullOrEmpty(story.text); 
            } 
        }

        internal void Play()
        {
            story.text = "clicked";
        }
    }
}
