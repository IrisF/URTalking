using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAnswerTypeDetector.Model;
using SynonymsDictionary;

namespace SimpleAnswerTypeDetector
{
    public class AnswerTypeDetect{
        private List<DetermineTypeModel> typeModels;
        private Dictionary dictionary;

        public AnswerTypeDetect(Dictionary dictionary)
        {
            this.dictionary = dictionary;
            typeModels = new List<DetermineTypeModel>();
        }

        public List<AnswerType> GetAllAnswerTyps(string question)
        {
            List<AnswerType> answerTyps = new List<AnswerType>();

            for (int i = 0; i < typeModels.Count; i++)
            {
                bool isOfType = typeModels.ElementAt(i).ContainsDetermineWord(question);
                if(isOfType){
                    answerTyps.Add(typeModels.ElementAt(i).GetType());
                }
            }

            if(answerTyps.Count == 0){
                answerTyps.Add(AnswerType.Unknown);
            }

            return answerTyps;
        }

        public void setSynonyms(){
            if(dictionary != null){
                for (int i = 0; i < typeModels.Count; i++ )
                {
                    DetermineTypeModel determineTypeModel = typeModels.ElementAt(i);
                    List<string> determineWords = determineTypeModel.getDetermineWords();
                    for(int j = 0; j < determineWords.Count; j++){
                        string word = determineWords.ElementAt(j);
                    
                    
                        determineTypeModel.setDetermineWord(dictionary.GetSynonym(word), j);
                    }
                }
            }
        }

        public void LoadPersonModel(string path)
        {
            typeModels.Add(DetermineTypeModel.LoadModel(path, AnswerType.Person));
        }

        public void LoadDateModel(string path)
        {
            typeModels.Add(DetermineTypeModel.LoadModel(path, AnswerType.Date));
        }

        public void LoadLocationModel(string path)
        {
            typeModels.Add(DetermineTypeModel.LoadModel(path, AnswerType.Location));
        }

        public void LoadPeriodModel(string path)
        {
            typeModels.Add(DetermineTypeModel.LoadModel(path, AnswerType.Period));
        }

        public void LoadNumberModel(string path)
        {
            typeModels.Add(DetermineTypeModel.LoadModel(path, AnswerType.Number));
        }
    }
}
