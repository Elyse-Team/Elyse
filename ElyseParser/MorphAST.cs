using edu.stanford.nlp.ling;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.util;
using ElyseLibrary;
using java.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ElyseParser
{
    internal class MorphAST
    {
        private Annotation _ast;

        private Annotation ast
        {
            get { return _ast; }
            set { _ast = value; }
        }

      // This is the coreference link graph
      // Each chain stores a set of mentions that link to each other,
      // along with a method for getting the most representative mention
      // Both sentence and token offsets start at 1!
        /*
      Map<Integer, CorefChain> graph = 
        document.get(CorefChainAnnotation.class);
*/
        internal MorphAST(Annotation baseAST)
        {
            ast = baseAST;
        }

        internal List<Instruction> run(Scene scene)
        {
            List<Instruction> storyInstructions = new List<Instruction>();
            Regex moveAction = new Regex("(walk|come|appear)");
            Regex talkAction = new Regex("(talk|say)");

            ArrayList sentences = this.ast.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;

            // phrases
            foreach (CoreMap sentence in sentences)
            {
                // liste de tokens dans la phrase
                var tokens = sentence.get(new CoreAnnotations.TokensAnnotation().getClass()) as List;

                List<Character> characterList = new List<Character>();
                List<string> movementList = new List<string>();
                List<IPositionable> positionList = new List<IPositionable>();

                // token courant
                for (var i = 0; i < tokens.size(); i++)
                {
                    var token = tokens.get(i) as CoreLabel;

                    if (token.ner() == "PERSON")
                    {
                        foreach(Character character in scene.Characters)
                        {
                            if (token.originalText() == character.Name) characterList.Add(character);
                        }
                    }

                    if (token.tag() == "NN")
                    {
                        foreach (IPositionable position in scene.Positions)
                        {
                            if (token.originalText() == position.Name) positionList.Add(position);
                        }
                    }

                    if (moveAction.IsMatch(token.lemma())) movementList.Add(token.lemma());
                }

                if (characterList.Count == 1 && movementList.Count == 1 && positionList.Count == 1)
                {
                    storyInstructions.Add(new Move(characterList[0], positionList[0]));
                }
            }

            return storyInstructions;
        }
    }
}
