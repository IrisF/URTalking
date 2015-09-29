using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAnswerTypeDetector.Model
{
    public class ModelWriter
    {
        public static void CreatePersonModel(string pathJson, string directory)
        {
            List<string> items = LoadJson(pathJson);

            WriteToFile(directory, @"/person_model.dat", AnswerType.Person, items);
        }

        public static void CreatePeriodModel(string pathJson, string directory)
        {
            List<string> items = LoadJson(pathJson);

            WriteToFile(directory, @"/period_model.dat", AnswerType.Period, items);
        }

        public static void CreateLocationModel(string pathJson, string directory)
        {
            List<string> items = LoadJson(pathJson);

            WriteToFile(directory, @"/location_model.dat", AnswerType.Location, items);
        }

        public static void CreateDateModel(string pathJson, string directory)
        {
            List<string> items = LoadJson(pathJson);

            WriteToFile(directory, @"/date_model.dat", AnswerType.Date, items);
        }

        public static void CreateNumberModel(string pathJson, string directory)
        {
            List<string> items = LoadJson(pathJson);

            WriteToFile(directory, @"/number_model.dat", AnswerType.Number, items);
        }

        private static void WriteToFile(string directory, string name, AnswerType type, List<string> items)
        {
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + name, FileMode.Create)))
            {
                writer.Write(type.ToString());
                for (int i = 0; i < items.Count; i++)
                {
                    writer.Write(items.ElementAt(i));
                }
            }
        }

        private static List<string> LoadJson(string path)
        {
            using (StreamReader r = File.OpenText(path))
            {
                string json = r.ReadToEnd();
                List<string> items = JsonConvert.DeserializeObject<List<string>>(json);
                return items;
            }
        }
    }
}
