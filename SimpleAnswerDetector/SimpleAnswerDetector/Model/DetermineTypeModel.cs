using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAnswerTypeDetector.Model
{
    class DetermineTypeModel
    {
        private AnswerType answerType;
        private List<string> determineWords;

        public DetermineTypeModel(List<string> determineWords, AnswerType answerType)
        {
            this.determineWords = determineWords;
            this.answerType = answerType;
        }

        public static DetermineTypeModel LoadModel(string path, AnswerType answerType)
        {
            List<string> determineWordsOfFile = ReadFileFromPath(path, answerType);
            return new DetermineTypeModel(determineWordsOfFile, answerType);
        }

        private static List<string> ReadFileFromPath(string path, AnswerType answerType){
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (BinaryReader b = new BinaryReader(fs))
            {
                List<string> determineWordsOfFile = new List<string>();

                string type = b.ReadString();
       
                if (IsValidModel(type, answerType))
                {
                    while (b.BaseStream.Position != b.BaseStream.Length)
                    {
                        string word = b.ReadString();
                        determineWordsOfFile.Add(word);
                    }
                }
           

                return determineWordsOfFile;
            }
        }

        private static bool IsValidModel(string type, AnswerType answerType)
        {
            if (type == answerType.ToString())
            {
                return true;
            }
            else
            {
                throw new Exception("Invalid Model!");
            }
        }

        public bool ContainsDetermineWord(string question)
        {
            question = question.ToLower();

            for (int i = 0; i < determineWords.Count; i++)
            {
                string word = determineWords.ElementAt(i);
                int index = question.IndexOf(word);
                if(index != -1){
                    return SimpleString.String.isStandalonePhrase(question, word, index);
                }
            }

            return false;
        }

        public List<string> getDetermineWords()
        {
            return determineWords;
        }

        public void setDetermineWord(string word, int index){
            if(index >= 0 && index < determineWords.Count){
                determineWords[index] = word;
            }
        }

        public AnswerType GetType()
        {
            return answerType;
        }
    }
}
