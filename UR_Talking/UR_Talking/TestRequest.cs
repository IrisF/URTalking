using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UR_Talking
{
    public class TestRequest
    {
        const string FAIL_1 = "Sorry, ich bin erst ein paar Tage alt :-/ Deswegen bin ich leider noch ein bisschen dumm und versteh nicht was du von mir willst... ";
        const string FAIL_2 = "Sorry, hab dich akustisch nicht verstanden...";
        String[] inp;
        String[] fail = {FAIL_1, FAIL_2};
        Random rnd;

        public TestRequest(string input)
        {
            this.inp = input.Split();
            rnd = new Random();
        }

        public string matchRequest()
        {
            for (int i = 0; i < inp.Length; i++)
            {
                if (inp[i].Equals("geht") || inp[i].Equals("gut") )
                {
                    return "Auch sehr gut, danke der Nachfage! Gehen wir nachher in die Mensa?";
                }
                if (inp[i].Equals("nein") || inp[i].Equals("nö"))
                {
                    return "Schade, aber vielleicht hat ja Simon lust. Kennst du ihn?";
                }
                if (inp[i].Equals("ja") || inp[i].Equals("jo"))
                {
                    return "Cool, das freut mich :) Ich hab gesehen es gibt heut Leberwurstauflauf!";
                }
            }
            return fail[rnd.Next(2)];
        }



    }
}