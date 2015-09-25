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
        public static void WriteToFile(string directory)
        {
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + @"/person_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Person.ToString());
                writer.Write("wer");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + @"/date_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Date.ToString());
                writer.Write("wann");
                writer.Write("termin");
                writer.Write("datum");
                writer.Write("zeitpunkt");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + @"/location_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Location.ToString());
                writer.Write("wo");
                writer.Write("ort");
                writer.Write("woher");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + @"/period_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Period.ToString());
                writer.Write("dauer");
                writer.Write("zeitraum");
                writer.Write("dauert");
                writer.Write("dauern");
                writer.Write("regelzeit");
                writer.Write("studienzeit");
            }
            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(directory + @"/number_model.dat", FileMode.Create)))
            {
                writer.Write(AnswerType.Number.ToString());
                writer.Write("wie viel");
                writer.Write("wie viele");
                writer.Write("wieviel");
                writer.Write("wieviele");
                writer.Write("wie oft");

            }
        }
    }
}