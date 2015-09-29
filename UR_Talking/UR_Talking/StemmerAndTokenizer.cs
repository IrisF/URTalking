using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Iveonik.Stemmers;



namespace Iveonik.Stemmers
{
    class StemmerAndTokenizer
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

        }

        public static string stemAndTokenize(string userInput)
        {
            GermanStemmer stemmer = new GermanStemmer();
            string[] userInputAsArray = userInput.Split();
            ISet<string> stopwordList = Lucene.Net.Analysis.De.GermanAnalyzer.GetDefaultStopSet();
            List<string> filteredWords = filteredStopWords(stopwordList, userInputAsArray);
            string filteredAndStemmedUserInput = "";
            for (int i = 0; i < filteredWords.Count; i++)
            {
                string newWord = stemmer.Stem(CleanInput(filteredWords.ElementAt(i)));
                filteredAndStemmedUserInput += newWord + " ";
            }
            return filteredAndStemmedUserInput;
        }

        private static List<string> filteredStopWords(ISet<string> stopWordList, string[] userInput)
        {
            List<string> filteredList = new List<string>();
            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < stopWordList.Count; j++)
                {
                    if (userInput[i] != null)
                    {
                        if (userInput[i].Equals(stopWordList.ElementAt(j)))
                        {
                            userInput[i] = null;
                        }
                    }
                }
            }
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i] != null)
                {
                    filteredList.Add(userInput[i]);
                }
            }
            return filteredList;
        }

        static string CleanInput(string strIn)
        {
            try
            {
                string newstr = new Regex("([!@#$%^&*()]|(?:[.](?![a-z0-9]+$)))", RegexOptions.IgnoreCase).Replace(strIn, "");
                return Regex.Replace(newstr, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return string.Empty;
            }
        }


    }
}
