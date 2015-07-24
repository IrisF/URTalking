using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UR_Talking.DAO;

namespace UR_Talking.DAO_Impl
{
    public class AnswerDAOImpl : AnswerDAO
    {
        private TestRequest tr;
     
        public AnswerDAOImpl()
        {
            tr = new TestRequest();
        }

        public string GetAnswer(string[] question)
        {
            return tr.matchRequest(question);
        }

    }
}