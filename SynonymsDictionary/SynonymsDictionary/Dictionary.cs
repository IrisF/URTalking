using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynonymsDictionary
{
    public class Dictionary
    {
        private Dictionary<string, string> synonymHash;

        public Dictionary(List<SynonymsObject> synonymsObjects)
        {
            synonymHash = new Dictionary<string, string>();

            InitDictionary(synonymsObjects);
        }

        public static Dictionary LoadDictionary(string path)
        {
            List<SynonymsObject> synonymsObjects = ModelHandler.DeserializeFile(path);

            return new Dictionary(synonymsObjects);
        }

        public string GetSynonym(string word)
        {
            string synonym = null;
            string punctuation = "";

            char lastLetter = word[word.Length-1];

            if(Char.IsPunctuation(lastLetter)){
                punctuation = lastLetter.ToString();
                word = word.Substring(0, word.Length - 1);
            }

            word = word.ToLower();
            
            return synonymHash.TryGetValue(word, out synonym) ? (synonym + punctuation) : word;
        }

        public string getSynonymSentence(string sentence)
        {
            sentence = sentence.ToLower();

            foreach(KeyValuePair<string, string> entry in synonymHash){
                string toBeReplaced = entry.Key;
                string phrase = entry.Value;
                int index = sentence.IndexOf(toBeReplaced);
                if (index != -1)
                {
                    if (SimpleString.String.isStandalonePhrase(sentence, toBeReplaced, index))
                    {
                        sentence = SimpleString.String.replaceStringByString(sentence, toBeReplaced, phrase);
                    }
                }
            }

            return sentence;
        }

        private void InitDictionary(List<SynonymsObject> synonymsObjects)
        {
            foreach (SynonymsObject synonymObject in synonymsObjects)
            {
                var word = synonymObject.Word;
                var synonyms = synonymObject.Synonyms;

                foreach(string synonym in synonyms){
                    if(!synonymHash.ContainsKey(synonym)){
                        synonymHash.Add(synonym, word);  
                    }
                }
            }
        }
    }
}
