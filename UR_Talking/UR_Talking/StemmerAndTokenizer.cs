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

        public static String[] stemAndTokenize(IStemmer stemmer, String userInput)
        {
                String[] userInputAsArray = userInput.Split();
                for(int i = 0; i < userInputAsArray.Length; i++)
                {
                    String newWord = stemmer.Stem(CleanInput(userInputAsArray[i]));
                    userInputAsArray[i] = newWord;
                    Console.WriteLine("Stemmed: " + newWord);
                }
            return userInputAsArray;
        }

        static string CleanInput(string strIn)
        {
            try
            {
                String newstr = new Regex("([!@#$%^&*()]|(?:[.](?![a-z0-9]+$)))", RegexOptions.IgnoreCase).Replace(strIn, "");
                return Regex.Replace(newstr, @"[^\w\.@-]", "",
                                     RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

    }
}
