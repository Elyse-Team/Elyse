using java.io;
using edu.stanford.nlp.process;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.parser.lexparser;
using java.util;
using System;
using System.IO;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.ie;
using System.Collections.Generic;
using edu.stanford.nlp.util;
using edu.stanford.nlp.semgraph;
using edu.stanford.nlp.dcoref;


namespace ElyseConsole
{
    public class StanfordParserConsole
    {
        readonly StanfordCoreNLP _core;

        // only for ElyseConsole
        private Annotation _annotation;

	    public StanfordCoreNLP Core
	    {
		    get { return _core;}
	    }

        // only for ElyseConsole
        public Annotation Annotation
        {
            get { return _annotation; }
            set { _annotation = value; }
        }

        // Builder
        public StanfordParserConsole(string elysePath)
        {
            // chemin d'accès aux modèles d'annotations
            string jarRoot = elysePath + "/Elyse/CoreNLP";

            // spécifications des modules d'annotations à lancer
            // Tokenizer - SentenceSplitter - PartOfSpeech - Lemma - NamedEntityRecognizer - Parser - Coreference
            Properties props = new Properties();
            props.put("annotators", "tokenize, ssplit, pos, lemma, ner, parse, dcoref");
            props.put("ner.model", elysePath + "/Elyse/CoreNLP/edu/stanford/nlp/models/ner/english.all.3class.distsim.crf.ser.gz");

            // Gestion des valeurs numériques et du temps : OFF
            props.put("ner.applyNumericClassifiers", "false");
            props.put("ner.useSUTime", "false");
            props.put("sutime.binders", "0");

            // Chargement du fichier de propriétés / Retour au répertoire-racine des modèles
            string curDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(jarRoot);
            StanfordCoreNLP pipeline = new StanfordCoreNLP(props);
            Directory.SetCurrentDirectory(curDir);

            _core = pipeline;
        }

        // Parsing
        public Annotation Parse(String text)
        {
            // Annotations
            Annotation annotation = new Annotation(text);
            _core.annotate(annotation);

            // only for ElyseConsole
            this.Annotation = annotation;

            return annotation;
        }


        // Morph AST
        public void MorphAST()
        {
            ArrayList sentences = this.Annotation.get(new CoreAnnotations.SentencesAnnotation().getClass()) as ArrayList;
    
            foreach(CoreMap sentence in sentences)
            {
                // liste de tokens
                var tokens = sentence.get(new CoreAnnotations.TokensAnnotation().getClass()) as List;
                
                for (var i = 0; i < tokens.size(); i++)
                {
                    var token = tokens.get(i) as CoreLabel;
                    var text = token.get(new CoreAnnotations.TextAnnotation().getClass());
                    var pos = token.get(new CoreAnnotations.PartOfSpeechAnnotation().getClass());
                    var lemma = token.get(new CoreAnnotations.LemmaAnnotation().getClass());
                    var ner = token.get(new CoreAnnotations.NamedEntityTagAnnotation().getClass());

                    System.Console.WriteLine("- text : " + text + " - pos : " + pos + " - lemma : " + lemma + " - ner : " + ner + " -");
                }
                System.Console.WriteLine("\n");
            }
        }

        // Test Console
        public void TestConsole()
        {
            using (ByteArrayOutputStream stream = new ByteArrayOutputStream())
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