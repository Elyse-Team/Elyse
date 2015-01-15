using edu.stanford.nlp.pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseParser
{
    internal class VisitorMorph
    {
/*
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
        public VisitorMorph(Annotation ast)
        {
 
        }
    }
}
