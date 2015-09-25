using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UR_Talking.Levenstein;

namespace UR_Talking
{

    //http://www.codeproject.com/Articles/36106/Chatbot-Tutorial
    public class CreateAnswer
    {
        private List<String> savedConversation = new List<String>();
        private List<string>[] res;
        private List<string>[] resHelper;



        public string speak(string[] key)
        {
            string searchInTable;
            List<string> alltables;
            string elise_speak;
           

            if (key != null)
            {
                createListForcols(3);
                string question = joinQuestionWords(key);
                ConnectToMySQL connect = new ConnectToMySQL();

                //if there is a buzz key get spezific table
                searchInTable = KeyWords.getBuzzTable(key);
                if (searchInTable != null){
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

        private string joinQuestionWords(string[] keys)
        {
            string question = "";
           foreach(string key in keys){
               question = question +" "+ key;            
           }
           return question;
        }

        public string testAlgorithmLevenstein(ConnectToMySQL connect, string question_user)
        {   
            ExecuteLevenstein l = new ExecuteLevenstein();
            List<string> question_db = res[1];
            List<string> answers_db = res[2];
            string answer_match = "Hmm die Frage kann ich leider noch nicht beantworten. Soll ich diese Frage mit in die Datenbank aufnehmen?";


            int helper = l.useLevenstein(question_user, question_db[0]);

            for (int i = 0; i < answers_db.Count; i++)
            {
                if (helper > l.useLevenstein(question_user, question_db[i]))
                {
                    helper = l.useLevenstein(question_user, question_db[i]);
                    answer_match = answers_db[i];
                }
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