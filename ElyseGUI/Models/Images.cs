using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseGUI.Models
{
    class Images
    {
        private string[] _heads;
        public string[] Heads
        {
            get
            {
                _loadHeads();
                return _heads;
            }
        }

        private void _loadHeads()
        {
            if (_heads == null)
            {
                _heads = _fetchHeads();
            }
        }

        private string[] _fetchHeads()
        {
            return Directory.GetFiles(System.IO.Path.GetFullPath("..\\..\\") + "/Images/heads/", "Head*")
                .Select(s => s.Replace(".png", "").Substring(s.LastIndexOf("/") + 1)).ToArray();
        }

        private string[] _bodies;
        public string[] Bodies {
            get
            {
                _loadBodies();
                return _bodies;
            }
        }

        private void _loadBodies()
        {
            if (_bodies == null)
            {
                _bodies = _fetchBodies();
            }
        }

        private string[] _fetchBodies()
        {
            return Directory.GetFiles(System.IO.Path.GetFullPath("..\\..\\") + "/Images/bodies/", "Body*")
                .Select(s =>  s.Replace(".png", "").Substring(s.LastIndexOf("/")+1)).ToArray();
        }

        private string[] _backgrounds;
        public string[] Backgrounds
        {
            get
            {
                _loadBackgrounds();
                return _backgrounds;
            }
        }

        private void _loadBackgrounds()
        {
            if (_backgrounds == null)
            {
                _backgrounds = _fetchBackgrounds();
            }
        }

        private string[] _fetchBackgrounds()
        {
            return Directory.GetFiles(System.IO.Path.GetFullPath("..\\..\\") + "/Images/backgrounds/", "background*")
                .Select(s => s.Replace(".jpg", "").Substring(s.LastIndexOf("/") + 1)).ToArray();
        }
    }
}
