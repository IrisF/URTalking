using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UR_Talking.Levenstein;
using SimpleAnswerTypeDetector;
using Iveonik.Stemmers;

namespace UR_Talking
{

    //http://www.codeproject.com/Articles/36106/Chatbot-Tutorial
    public class CreateAnswer
    {
        private List<String> savedConversation = new List<String>();
        private List<string>[] res;
        private List<string>[] resHelper;
        private ConnectToMySQL connect = new ConnectToMySQL();
        private NLP nlp;
        private bool search_flag = false;

        public CreateAnswer(NLP nlp)
        {
            this.nlp = nlp;
        }

        public List<Answer> speak(List<SearchObject> searchObjects)
        {
            List<Answer> answers = new List<Answer>();

            for (int i = 0; i < searchObjects.Count; i++)
            {
                SearchObject searchObject = searchObjects.ElementAt(i);
                string question = searchObject.Sentence;
                string tableName = getTableName(searchObject.AnswerTyps.ElementAt(0));
                
                answers.Add(getAnswer(question, tableName));
            }

            return answers;
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

        private Answer getAnswer(string question, string searchInTable)
        {
            List<string> alltables;
            Answer elise_speak;

            if (searchInTable != "searchAllTables")
            {
                resultsFromTable(connect, searchInTable);
                elise_speak = testAlgorithmLevenstein(connect, question);
            }

        //    if there is no buzz key search in all tables
            else
            {
                search_flag = true;
                alltables = KeyWords.allTables();
                foreach (string table in alltables)
                {
                    resultsFromTable(connect, table);
                }
                elise_speak = testAlgorithmLevenstein(connect, question);
            }

                return elise_speak;
        }

        private string joinAnswers(List<Answer> sentences)
        {
            string answer = "";
           foreach(Answer sentence in sentences){
               answer = answer +" "+ sentence;            
           }
           return answer;
        }

        public Answer testAlgorithmLevenstein(ConnectToMySQL connect, string question_user)
        {   
            ExecuteLevenstein l = new ExecuteLevenstein();
            Answer a = new Answer();
            List<string> question_db = res[1];
            List<string> answers_db = res[2];
            List<string> type_db = res[3];

            int helper = 100;

            String question_user_stemm = StemmerAndTokenizer.stemAndTokenize(question_user);

            string[] question_user_splitt = question_user_stemm.Split();
            Array.Sort(question_user_splitt);
            question_user_stemm = string.Join(" ", question_user_splitt);

            for (int i = 0; i < answers_db.Count; i++)
            {

                    question_db[i] = nlp.ReplaceBySynonyms(question_db[i]);

                    String question_db_stemm = StemmerAndTokenizer.stemAndTokenize(question_db[i]);
                    
                    string[] question_db_splitt = question_db_stemm.Split();
                   
                    Array.Sort(question_db_splitt);
                  
                    question_db_stemm = string.Join(" ", question_db_splitt);
                   


                    if (helper >= l.useLevenstein(question_user_stemm , question_db_stemm ) && type_db[i] == "text")
                    {
                        helper = l.useLevenstein(question_user_stemm, question_db_stemm);
                        a.AnswerText = answers_db[i];
                        a.Type = type_db[i];
                    }


                    if (helper >= l.useLevenstein(question_user_stemm, question_db_stemm) && type_db[i] == "link")
                     {
                    helper = l.useLevenstein(question_user, question_db[i]);
                    a.Type = type_db[i];
                    a.Link = answers_db[i];

                }
            }

            if (helper > 40 && search_flag == false) {
                getAnswer(question_user, "searchAllTables");
            }


            if (helper > 60 && search_flag == true)
            {
                a.AnswerText = "Leider habe ich die Antwort nicht gefunden. Eventuell finde ich eine Antwort auf deine Frage, wenn du sie anders stellst :)";
                a.Type = "text";
                a.Link = "";
            }

           return a;

        }


        public List<string>[] resultsFromTable(ConnectToMySQL connect, string searchInTable)
        {
       
             resHelper = connect.Select(searchInTable);
             createListForcols(connect.CountColumns);
             for (int i = 0; i < connect.CountColumns; i++)
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

             if (res == null)
             {
                 //Create a list to store the result
                 res = new List<string>[cols];
                 for (int i = 0; i < cols; i++)
                 {
                     res[i] = new List<string>();
                 }
             } 
             
             return res;


         }
    }
}