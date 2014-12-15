using java.io;
using edu.stanford.nlp.process;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.parser.lexparser;
using java.util;
using System;
using System.IO;
using edu.stanford.nlp.pipeline; 

namespace StanfordParser
{
    public class StanfordParser
    {
        readonly StanfordCoreNLP _core;
        private Annotation _annotation;

	    public StanfordCoreNLP Core
	    {
		    get { return _core;}
	    }

        public Annotation Annotation
        {
            get { return _annotation; }
            set { _annotation = value; }
        }

        // Builder
        public StanfordParser()
        {
            // chemin d'accès aux modèles d'annotations
            var jarRoot = @"B:\Elyse\StanfordParser\CoreNLP";

            // spécifications des modules d'annotations à lancer
            // Tokenizer - SentenceSplitter - PartOfSpeech - Lemma - Parser
            var props = new Properties();
            props.setProperty("annotators", "tokenize, ssplit, pos, lemma, parse");

            // Chargement du fichier de propriétés / Retour au répertoire-racine des modèles
            var curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
            var pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);

            _core = pipeline;
        }

        // Parsing
        public void Parse(String text)
        {
            // Annotations
            var annotation = new Annotation(text);
            _core.annotate(annotation);

            this.Annotation = annotation;
        }

        // Test Console
        public void TestConsole()
        {
            using (var stream = new ByteArrayOutputStream())
            {
                _core.prettyPrint(this.Annotation, new PrintWriter(stream));
                string lines = stream.toString();
                System.Console.WriteLine(lines);
                System.Console.WriteLine("\nSave file ? <y>es - <n>o");
                string response = System.Console.ReadLine();
                if (response == "y")
                {
                    System.IO.File.WriteAllText(@"B:\StanfordParser\Test.txt", lines);
                }
                stream.close();
            }
            
        }
    }
}
