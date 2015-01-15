using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.util;
using ElyseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseParser
{
    public class ParserEngine
    {
        private Scene _scene;
        private StanfordParser _parser;
        private Annotation _ast;

        public Scene scene
        {
            get { return _scene; }
            set { _scene = value; }
        }

        public ParserEngine(string elysePath)
        {
            _parser = new StanfordParser(elysePath);
        }

        public List<Instruction> Run(SceneBuilder sceneBuilder)
        {
            _scene = new Scene(sceneBuilder);
            string story = sceneBuilder.GetStory();
            _ast = _parser.Parse(story);

            // return a list of instructions
            return blabla;
        }
    }
}
