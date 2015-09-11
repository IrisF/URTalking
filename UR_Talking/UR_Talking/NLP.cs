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
            this.answerTypeDetect = new AnswerTypeDetect();
            this.dictionary = Dictionary.LoadDictionary(@"D:\synonym_model.bin");

            answerTypeDetect.LoadPersonModel(@"D:/person_model.dat");
            answerTypeDetect.LoadLocationModel(@"D:/location_model.dat");
            answerTypeDetect.LoadDateModel(@"D:/date_model.dat");
        }

        public static void CreateDictionaryModel()
        {
            List<SynonymsObject> synonymsList = new List<SynonymsObject>();

            string word1 = "hauptfach";
            var synonyms1 = new List<string> { "hf" };

            string word2 = "informationswissenschaft";
            var synonyms2 = new List<string> { "inf", "Infwiss", "infowiss", "infowissenschaften", "infowissenschaft", "informationswissenschaften" };

            SynonymsObject s1 = new SynonymsObject(synonyms1, word1);
            SynonymsObject s2 = new SynonymsObject(synonyms2, word2);

            synonymsList.Add(s1);
            synonymsList.Add(s2);

            SynonymsDictionary.ModelHandler.SerializeFile(@"D:\synonym_model.bin", synonymsList);
        }

        public List<string> ReplaceBySynonym(string question)
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

        public List<SearchObject> GetAnswerTypList(string question)
        {
            List<string> sentences = ReplaceBySynonym(question);

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