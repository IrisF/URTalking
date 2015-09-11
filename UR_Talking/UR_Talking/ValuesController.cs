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
<<<<<<< HEAD

        public ValuesController(AnswerDAO answerDAO)
        {
            this.answerDAO = answerDAO;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
=======
        private NLP nlp;

        public ValuesController(AnswerDAO answerDAO, NLP nlp)
        {
            this.answerDAO = answerDAO;
            this.nlp = nlp;
>>>>>>> origin/SharpNLP
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
<<<<<<< HEAD
            String request = StemmerAndTokenizer.stemAndTokenize(value);
            String answer = this.answerDAO.GetAnswer(request.Split());
=======
            List<SearchObject> searchObjects = nlp.GetAnswerTypList(value);

            string answer = this.answerDAO.GetAnswer(searchObjects);
         
>>>>>>> origin/SharpNLP
            return answer;
        }
    }
}