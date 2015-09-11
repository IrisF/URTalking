using SimpleAnswerTypeDetector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UR_Talking
{
    public class ModelWriter
    {
        public static void WriteToFile()
        {
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open("D:/person_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Person.ToString());
                writer.Write("wer");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open("D:/date_model.dat", FileMode.Create)))
            {

                writer.Write(AnswerType.Date.ToString());
                writer.Write("wann");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open("D:/location_model.dat", FileMode.Create)))
            {

                writer.Write(AnswerType.Location.ToString());
                writer.Write("wo");
                writer.Write("sag mir den ort");
            }
        }
    }
}