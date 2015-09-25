using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UR_Talking
{
    public class KeyWords
    {
        private static string notFound = "Hmm das kann ich dir jetzt leider grad ausm Stehgreif nicht sagen :/. Ich vermerke mir das in meiner Datenbank. Frag mich bitte morgen nochmal"; 

        internal static void init()
        {
           
        }

        static int i = 0;

        internal static string getBuzzTable(string[] keys)
        {

            if (keys != null) { 
            ConnectToMySQL connect = new ConnectToMySQL();
            List<string>[] buzzwords = connect.Select("buzz_words");
            string table = "";
            foreach (string key in keys) {
                for (int i = 0; i < buzzwords[1].Count; i++ )
                {
                    if (buzzwords[1].Contains(key))
                    {
                        
                         table = buzzwords[2].ElementAt(buzzwords[1].IndexOf(key));
                    }
                }
               
            }
            if (table != "")
                return table;
            }
                return null;
            }





        internal static List<string> allTables()
        {
            ConnectToMySQL connect = new ConnectToMySQL();
            List<string> alltables = connect.MySqlCollectionQuery();
            if (alltables.Contains("buzz_words")) {
                alltables.Remove("buzz_words");
            }

            return alltables; 
        }


    }
}