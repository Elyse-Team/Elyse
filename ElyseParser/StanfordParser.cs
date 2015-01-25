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

namespace ElyseParser
{
    public class StanfordParser
    {
        readonly StanfordCoreNLP _core;

	    public StanfordCoreNLP Core
	    {
		    get { return _core;}
	    }

        // Builder
        public StanfordParser(string elysePath)
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
        public Annotation Parse(string text)
        {
            // Annotations
            Annotation document = new Annotation(text);
            _core.annotate(document);

            return document;
        }
    }
}