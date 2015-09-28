using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UR_Talking.Levenstein;
using SimpleAnswerTypeDetector;

namespace UR_Talking
{

    public class Answer
    {
        private string answer = "";
        private string link = "";
        private string image = "";
        private string type = "text";



        public string AnswerText
        {
            get { return answer; }
            set { answer = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }




    }
}