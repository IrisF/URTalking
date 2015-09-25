using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynonymsDictionary
{
    [Serializable]
    public class SynonymsObject
    {
        private List<string> synonyms;
        private string word;

        public SynonymsObject(List<string> synonyms, string word)
        {
            this.synonyms = synonyms;
            this.word = word;
        }

        public List<string> Synonyms
        {
            get { return this.synonyms; }
            set { this.synonyms = value; }
        }

        public string Word
        {
            get { return this.word; }
            set { this.word = value; }
        }
    }
}
