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
        private Annotation ast;

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
            ast = _parser.Parse(story);
            List<Instruction> storyInstructions = new List<Instruction>();
            MorphAST morphAST = new MorphAST(ast);
            storyInstructions = morphAST.run(_scene);
            return storyInstructions;
        }
    }
}
