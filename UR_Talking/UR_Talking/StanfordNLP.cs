using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using edu.stanford.nlp.ie.crf;
using java.util;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.process;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.ling;
using java.io;
using System.IO;
using edu.stanford.nlp.pipeline;

namespace UR_Talking
{
    public class StanfordNLP
    {
        //private static string germanPath = @"D:\Studium\Informationswissenschaften\UR-Talking\StanfordNLP\stanford-german-2015-01-30-models\edu\stanford\nlp\models\ner\german.hgc_175m_600.crf.ser.gz";
        //private static string englishPath = @"D:\Studium\Informationswissenschaften\UR-Talking\StanfordNLP\stanford-corenlp-models-current\edu\stanford\nlp\models\ner\english.all.3class.distsim.crf.ser.gz";

        //private static CRFClassifier classifier = CRFClassifier.getClassifierNoExceptions(germanPath);

        public List<string> splitSentences(string question)
        { //from: http://www.rhyous.com/2014/10/20/splitting-sentences-in-c-using-stanford-nlp/ visit on 06.09.2015 01:28 o'clock
            List<string> sentences = new List<string>();

            var props = new Properties();
            props.setProperty("annotators", "tokenize, ssplit");

            var pipeline = new StanfordCoreNLP(props);

            var annotation = new Annotation(question);
            pipeline.annotate(annotation);

            var sentencesObject = annotation.get(typeof(CoreAnnotations.SentencesAnnotation));

            foreach (Annotation sentence in sentencesObject as ArrayList)
            {
                sentences.Add(sentence.toString());
            }

            return sentences;
        }

    /*    public string Test(string sentence)
        {
            var jarRoot = @"..\..\..\StanfordNLP\stanford-german-2015-01-30-models\edu\stanford\nlp\models";

            var lp = LexicalizedParser.loadModel(@"D:\Studium\Informationswissenschaften\UR-Talking\StanfordNLP\stanford-german-2015-01-30-models\edu\stanford\nlp\models\lexparser\germanPCFG.ser.gz");

            var tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "");
            var sent2Reader = new StringReader(sentence);
            var rawWords2 = tokenizerFactory.getTokenizer(sent2Reader);
            sent2Reader.close();
            var tree2 = lp.apply(rawWords2);

          
            var tlp = new PennTreebankLanguagePack();
            var gsf = tlp.grammaticalStructureFactory();
            var gs = gsf.newGrammaticalStructure(tree2);
            var tdl = gs.typedDependenciesCCprocessed();
            System.Console.WriteLine("\n{0}\n", tdl);

            var tp = new TreePrint("penn,typedDependenciesCollapsed");
            tp.printTree(tree2);

            return tree2.ToString();
        }

        public string NER(string sentence)
        {
            var result = "";
            foreach (List senten in classifier.classify(sentence).toArray())
            {
                foreach (CoreLabel word in senten.toArray())
                {
                    result += word.word().ToString() + "/" + word.get(new CoreAnnotations.AnswerAnnotation().getClass()).ToString();
                }
            }

            return result;

            const string S1 = "Good afternoon Rajat Raina, how are you today?";
            const string S2 = "I go to school at Stanford University, which is located in California.";
            Console.WriteLine("{0}\n", classifier.classifyToString(S1));
            Console.WriteLine("{0}\n", classifier.classifyWithInlineXML(S2));
            Console.WriteLine("{0}\n", classifier.classifyToString(S2, "xml", true));

            var classification = classifier.classify(S2).toArray();
            for (var i = 0; i < classification.Length; i++)
            {
                Console.WriteLine("{0}\n:{1}\n", i, classification[i]);
            }
        
        }*/
    }
}