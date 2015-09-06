using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Iveonik.Stemmers;
using UR_Talking.DAO;

namespace UR_Talking
{
    public class ValuesController : ApiController
    {
        private AnswerDAO answerDAO;
        private IStemmer germanStemmer;

        public ValuesController(AnswerDAO answerDAO, IStemmer germanStemmer)
        {
            this.answerDAO = answerDAO;
            this.germanStemmer = germanStemmer;
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
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            String request = StemmerAndTokenizer.stemAndTokenize(new GermanStemmer(), value);
            String answer = this.answerDAO.GetAnswer(request.Split());
            return answer;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}