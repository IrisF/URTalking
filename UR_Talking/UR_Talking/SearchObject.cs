using SimpleAnswerTypeDetector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UR_Talking
{
    public class SearchObject
    {
        private string sentence;
        private List<AnswerType> answerTyps;

        public SearchObject(string sentence, List<AnswerType> answerTyps)
        {
            this.sentence = sentence;
            this.answerTyps = answerTyps;
        }

        public string Sentence
        {
            get { return sentence; }
            set { sentence = value; }
        }

        public List<AnswerType> AnswerTyps
        {
            get { return answerTyps; }
            set { answerTyps = value; }
        }

    }
}