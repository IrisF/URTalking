using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UR_Talking.Levenstein;
using SimpleAnswerTypeDetector;

namespace UR_Talking
{

    //http://www.codeproject.com/Articles/36106/Chatbot-Tutorial
    public class CreateAnswer
    {
        private List<String> savedConversation = new List<String>();
        private List<string>[] res;
        private List<string>[] resHelper;

        public string speak(List<SearchObject> searchObjects)
        {
            List<string> answers = new List<string>();

            for (int i = 0; i < searchObjects.Count; i++)
            {
                SearchObject searchObject = searchObjects.ElementAt(i);
                string question = searchObject.Sentence;
                string tableName = getTableName(searchObject.AnswerTyps.ElementAt(0));
                
                answers.Add(getAnswer(question, tableName));
            }

            return joinAnswers(answers);
        }

        private string getTableName(AnswerType at){

            if (at.ToString() == "Period" || at.ToString() == "Date" || at.ToString() == "Number")
            {
                at = AnswerType.Unknown;
            }
            switch (at)
            {
                case AnswerType.Person:
                    return AnswerType.Person.ToString().ToLower();
                //case AnswerType.Period:
                //    return AnswerType.Period.ToString().ToLower();
                //case AnswerType.Date:
                //    return AnswerType.Date.ToString().ToLower();
                case AnswerType.Location:
                    return AnswerType.Location.ToString().ToLower();
                //case AnswerType.Number:
                //    return AnswerType.Number.ToString().ToLower();
                case AnswerType.Unknown:
                    return AnswerType.Unknown.ToString().ToLower();
                default:
                    return AnswerType.Unknown.ToString().ToLower();
            }
        }

        private string getAnswer(string question, string searchInTable)
        {
            List<string> alltables;
            string elise_speak;


            if (question != null)
            {
                createListForcols(3);
                //string question = joinQuestionWords(key);
                ConnectToMySQL connect = new ConnectToMySQL();

                if (searchInTable != AnswerType.Unknown.ToString().ToLower())
                {
                    resultsFromTable(connect, searchInTable);
                    elise_speak = testAlgorithmLevenstein(connect, question);
                }
                
                // if there is no buzz key search in all tables
                else{
                    alltables = KeyWords.allTables();
                    foreach(string table in alltables){
                    resultsFromTable(connect, table);
                        }
                    elise_speak = testAlgorithmLevenstein(connect, question);
                }
                return elise_speak;

            }

            else { 
            return "Du hast vergessen die Frage zu stellen";
            }
        }

        private string joinAnswers(List<string> sentences)
        {
            string answer = "";
           foreach(string sentence in sentences){
               answer = answer +" "+ sentence;            
           }
           return answer;
        }

        public string testAlgorithmLevenstein(ConnectToMySQL connect, string question_user)
        {   
            ExecuteLevenstein l = new ExecuteLevenstein();
            List<string> question_db = res[1];
            List<string> answers_db = res[2];
  //          List<string> type_db = res[3];
            string answer_match = "Hmm die Frage kann ich leider noch nicht beantworten. Soll ich diese Frage mit in die Datenbank aufnehmen?";


            int helper = l.useLevenstein(question_user, question_db[0]);
           
            for (int i = 0; i < answers_db.Count; i++)
            {
                if (helper >= l.useLevenstein(question_user, question_db[i]))
                {
                    helper = l.useLevenstein(question_user, question_db[i]);
                    answer_match = answers_db[i];
                }
            }

            if (helper > 75) {
                answer_match = "Hmm die Frage kann ich leider noch nicht beantworten. Soll ich diese Frage mit in die Datenbank aufnehmen?";
            }
            return answer_match;
        }




        public List<string>[] resultsFromTable(ConnectToMySQL connect, string searchInTable)
        {
       
             resHelper = connect.Select(searchInTable);
             for (int i = 0; i < 3; i++ )
                 addingResults(i, resHelper);
             return res;
        }


         private void addingResults(int at, List<string>[] resHelper) {
           
             foreach (string result in resHelper[at])
             {
                 res[at].Add(result);
             }
             

         }
         public List<string>[] createListForcols(int cols)
         {
             //Create a list to store the result
             res = new List<string>[cols];
             for (int i = 0; i < cols; i++)
             {
                 res[i] = new List<string>();
             }
             return res;
         }



    }
}