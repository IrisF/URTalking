using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using MySql.Data.MySqlClient;

namespace UR_Talking
{
    public class ConnectToMySQL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private int countColumns;

        public int CountColumns
        {
            get { return countColumns; }
           
        }
        //Constructor
        public ConnectToMySQL()
        {
            Initialize();
        }
        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "elise01";
            uid = ""; 
            password = ""; 
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }



        
        public List<string> MySqlCollectionQuery()
        {
            List<string> QueryResult = new List<string>();
            MySqlCommand cmdName = new MySqlCommand("show tables", connection);
            if (this.OpenConnection() == true)
            {
                MySqlDataReader reader = cmdName.ExecuteReader();
                while (reader.Read())
                {
                    QueryResult.Add(reader.GetString(0));
                }
                reader.Close(); }
                return QueryResult;
           
        }


        List<string>[] list;
        //Select statement
        public List<string>[] Select(string select)
        {
            string query = "SELECT * FROM "+select;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Create a list to store the result
                createListForcols(dataReader.FieldCount);
                countColumns = dataReader.FieldCount;

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        list[i].Add(dataReader[dataReader.GetName(i)] + "");
                    }
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public List<string>[] createListForcols(int cols)
        {
            //Create a list to store the result
            list = new List<string>[cols];
            for (int i = 0; i < cols; i++) { 
                list[i] = new List<string>();
            }
            return list;
        }
    }
}