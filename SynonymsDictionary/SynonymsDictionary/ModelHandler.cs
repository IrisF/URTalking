using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynonymsDictionary
{
    public static class ModelHandler
    {
        public static void WriteToFile(string pathJson, string pathToSave)
        {
            List<SynonymsObject> items = LoadJson(pathJson);

            SerializeFile(pathToSave, items);
        }

        private static List<SynonymsObject> LoadJson(string path)
        {
            using (StreamReader r = File.OpenText(path))
            {
                string json = r.ReadToEnd();
                List<SynonymsObject> items = JsonConvert.DeserializeObject<List<SynonymsObject>>(json);
                return items;
            }
        }

        private static void SerializeFile(string path, List<SynonymsObject> synonymsList)
        {
            try{
                using (Stream stream = File.Open(path + @"\synonyms_model.bin", FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, synonymsList);
                }
            }catch{
                throw new Exception();
            }
        }

        public static List<SynonymsObject> DeserializeFile(string path)
        {
            try
            {
                using (Stream stream = File.Open(path, FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    List<SynonymsObject> synonymObjects = (List<SynonymsObject>)bformatter.Deserialize(stream);

                    return synonymObjects;
                }
            }
            catch
            {
                throw new Exception("Can't deserialize File");
            }
        }
    }
}
