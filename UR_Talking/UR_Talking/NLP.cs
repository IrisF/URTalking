using SimpleAnswerTypeDetector;
using SynonymsDictionary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UR_Talking
{
    public class NLP
    {
        private AnswerTypeDetect answerTypeDetect;
        private Dictionary dictionary;
        private StanfordNLP stanfordNLP;

        public NLP()
        {
            this.stanfordNLP = new StanfordNLP();
            this.dictionary = Dictionary.LoadDictionary(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\Dictionary\synonym_model.bin");
            this.answerTypeDetect = new AnswerTypeDetect(this.dictionary);

            answerTypeDetect.LoadPersonModel(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\AnswerTypDetect\person_model.dat");
            answerTypeDetect.LoadLocationModel(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\AnswerTypDetect\location_model.dat");
            answerTypeDetect.LoadDateModel(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\AnswerTypDetect\date_model.dat");
            answerTypeDetect.LoadPeriodModel(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\AnswerTypDetect\period_model.dat");
            answerTypeDetect.LoadNumberModel(@"C:\Users\Iris\Documents\URTalking\Chatbot\URTalking\UR_Talking\UR_Talking\Models\AnswerTypDetect\number_model.dat");

            answerTypeDetect.setSynonyms();
        }

        public List<string> ReplaceByWordSynonyms(string question)
        {
            List<string> sentences = GetSentences(question);

            for(int i = 0; i < sentences.Count; i++){
                string[] sentence = sentences.ElementAt(i).Split();

                for (int j = 0; j < sentence.Length; j++)
                {
                    string word = sentence[j];
                    sentence[j] = dictionary.GetSynonym(word);
                }

                sentences[i] = String.Join(" ", sentence);
            }

            return sentences;
        }

        public string ReplaceBySynonyms(string question)
        {
            return dictionary.getSynonymSentence(question);
        }

        public List<string> SplitIntoSentences(string question)
        {
            return stanfordNLP.splitSentences(question);
        }

        public List<SearchObject> GetAnswerTypList(List<string> sentences)
        {
            List<SearchObject> sentencesAnswerTyps = GetSentencesAnswerTyps(sentences);

            return sentencesAnswerTyps;
        }

        private List<SearchObject> GetSentencesAnswerTyps(List<string> sentences)
        {
            var sentencesAnswerTyps = new List<SearchObject>();

            foreach (var sentence in sentences)
            {
                SearchObject searchObj = new SearchObject(sentence, answerTypeDetect.GetAllAnswerTyps(sentence));
              
                sentencesAnswerTyps.Add(searchObj);
            }

            return sentencesAnswerTyps;
        }

        private List<string> GetSentences(string question)
        {
            return stanfordNLP.splitSentences(question);
        }
    }
}