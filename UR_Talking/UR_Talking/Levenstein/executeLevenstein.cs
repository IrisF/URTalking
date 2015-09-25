using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UR_Talking.Levenstein
{
    public class ExecuteLevenstein
    {


        public int useLevenstein(string sNew, string sOld)
        {
            try
            {
                Levenshtein l = new Levenshtein();
                /// Original version
                /// 
                ///
                /* Read the initial time. */
                DateTime startTime = DateTime.Now;

                int match = l.LD(sNew, sOld);
                
                System.Diagnostics.Debug.WriteLine("For given question " + sNew + " check answer: " + sOld + " 0==perfect match 100==totaly different. Match: " + match);
                /* Read the end time. */
                DateTime stopTime = DateTime.Now;

                /* Compute the duration between the initial and the end time. */
                TimeSpan duration = stopTime - startTime;
                Console.WriteLine("Original:" + duration);


                /// New version
                /// 
                ///
                /* Read the initial time. */
                startTime = DateTime.Now;

                l.iLD(sNew, sOld);

                /* Read the end time. */
                stopTime = DateTime.Now;

                /* Compute the duration between the initial and the end time. */
                duration = stopTime - startTime;
                Console.WriteLine("New     :" + duration);

                Console.WriteLine("----------------");
                return match;

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            return -1;
        }

    }
}