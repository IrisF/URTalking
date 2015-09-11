using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Iveonik.Stemmers;
using UR_Talking.DAO;
using UR_Talking.DAO_Impl;
using SynonymsDictionary;
using System.IO;

namespace UR_Talking
{
    public class ValuesController : ApiController
    {
        private AnswerDAO answerDAO;
        private NLP nlp;

        public ValuesController(AnswerDAO answerDAO, NLP nlp)
        {
            this.answerDAO = answerDAO;
            this.nlp = nlp;
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            String request = StemmerAndTokenizer.stemAndTokenize(value);

            List<SearchObject> searchObjects = nlp.GetAnswerTypList(request);

            string answer = this.answerDAO.GetAnswer(searchObjects);
         
            return value;
        }
    }
}