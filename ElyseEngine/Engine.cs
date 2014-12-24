using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseParser;
using ElyseLibrary;

namespace ElyseEngine
{
    public class Engine
    {

        public void method()
        {
            string path = "B:/Visual Studio Projects";

            SceneBuilder _sceneBuilder = new SceneBuilder();

            string story = _sceneBuilder.GetStory();

            ParserEngine _parser = new ParserEngine(story, path);
        }
        
    }
}
