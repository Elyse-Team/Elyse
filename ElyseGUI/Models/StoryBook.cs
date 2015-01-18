using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseGUI.Models
{
    class StoryBook
    {
        private string[] GetFileList()
        {
            string[] filePaths = new string[]{};

            if (Directory.Exists("books"))
            {
                filePaths = Directory.GetFiles("books", "*");
            }

            return filePaths;
        }

        public Dictionary<string, string> GetSubStrList(int length = 35)
        {
            var list = new Dictionary<string, string>();
            var filePaths = GetFileList();
            if (filePaths != null)
            {
                foreach(var path in filePaths)
                {
                    list.Add(path, SubStringFromFile(path, length));
                }
            }

            return list;
        }

        private string SubStringFromFile(string path, int length)
        {
            string substring = "";
            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                length = line.Length > length ? length : line.Length;
                substring = line.Substring(0, length);
            }

            return substring;
        }

        public string GetPathFromSubstring(string substr)
        {
            var items = GetSubStrList();

            foreach (KeyValuePair<string, string> entry in items)
            {
                if( entry.Value.Equals(substr))
                {
                    return entry.Key;
                }
            }

            return null;
        }

        public string GetFileContent(string path)
        {
            string file = "";
            using (StreamReader reader = new StreamReader(path))
            {
                file = reader.ReadToEnd();
            }

            return file;
        }

        public bool IsExists(Story story)
        {
            var filePaths = GetFileList();
            foreach(var path in filePaths)
            {
                if(story.text.Equals(GetFileContent(path)))
                {
                    return true;
                }
            }

            return false;
        }

        public void Save(Story story)
        {
            if(String.IsNullOrWhiteSpace(story.text))
            {
                return;
            }

            CreateDirectory();

            Random rnd = new Random();

            using (StreamWriter outfile = new StreamWriter(@"books/"+rnd.Next(1,9000)+".txt"))
            {
                outfile.Write(story.text);
            }
        }

        private void CreateDirectory()
        {
            if (Directory.Exists("books")) return;

            Directory.CreateDirectory("books");
        }
    }
}
