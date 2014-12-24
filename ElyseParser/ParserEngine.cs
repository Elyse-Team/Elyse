﻿using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseParser
{
    public class ParserEngine
    {
        private StanfordParser _parser;
        private Annotation _ast;

        public ParserEngine(string elysePath)
        {
            _parser = new StanfordParser(elysePath);
        }

        public void Run(string story)
        {
            _ast = _parser.Parse(story);
        }
        
       /*
      // these are all the sentences in this document
      // a CoreMap is essentially a Map that uses class objects as keys and has values with custom types
      List<CoreMap> sentences = document.get(SentencesAnnotation.class);
    
      for(CoreMap sentence: sentences) {
        // traversing the words in the current sentence
        // a CoreLabel is a CoreMap with additional token-specific methods
        for (CoreLabel token: sentence.get(TokensAnnotation.class)) {
          // this is the text of the token
          String word = token.get(TextAnnotation.class);
          // this is the POS tag of the token
          String pos = token.get(PartOfSpeechAnnotation.class);
          // this is the NER label of the token
          String ne = token.get(NamedEntityTagAnnotation.class);       
        }

        // this is the parse tree of the current sentence
        Tree tree = sentence.get(TreeAnnotation.class);

        // this is the Stanford dependency graph of the current sentence
        SemanticGraph dependencies = sentence.get(CollapsedCCProcessedDependenciesAnnotation.class);
      }

      // This is the coreference link graph
      // Each chain stores a set of mentions that link to each other,
      // along with a method for getting the most representative mention
      // Both sentence and token offsets start at 1!
      Map<Integer, CorefChain> graph = 
        document.get(CorefChainAnnotation.class);
        */
    }
}
