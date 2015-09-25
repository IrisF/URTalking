using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleString
{
    public static class String
    {
        public static bool isStandalonePhrase(string sentence, string phrase, int index)
        {
            bool isFirstWord = String.isFirst(index);
            bool isLastWord = String.isLast(sentence, phrase, index);

            if (isFirstWord && isLastWord)
            {
                return true;
            }
            if (isFirstWord)
            {
                if (!Char.IsLetterOrDigit(sentence[index + phrase.Length]))
                {
                    return true;
                }
            }
            if (isLastWord)
            {
                if (!Char.IsLetterOrDigit(sentence[index - 1]))
                {
                    return true;
                }
            }
            if (!isLastWord && !isFirstWord)
            {
                return !Char.IsLetterOrDigit(sentence[index - 1]) && !Char.IsLetterOrDigit(sentence[index + phrase.Length]);
            }

            return false;
        }

        public static string replaceStringByString(string sentence, string toBeReplaced, string phrase)
        {
            int index = sentence.IndexOf(toBeReplaced);

            if(index != -1){
                sentence = sentence.Substring(0, index) + phrase + sentence.Substring(index + toBeReplaced.Length); 
            }

            return sentence;
        }

        private static bool isFirst(int index)
        {
            return index == 0;
        }

        private static bool isLast(string sentence, string phrase, int index)
        {
            return (phrase.Length + index) == sentence.Length;
        }
    }
}
