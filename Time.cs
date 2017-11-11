using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJURO_CS_Utils
{
    public class Time
    {
        public static string GetReadableElapsedTime(long miliseconds)
        {
            var ids = new string[] { " miliseconds ", " seconds and ", " minutes ", " hours ", " days " };    // time ranges : ms/sec/min/hour/day/week
            var timeSteps = new long[] { 1000, 60, 60, 24, 7 };    // time ranges : ms/sec/min/hour/day/week
            string elapsedTime = "";
            for (var i = 0; (miliseconds > 0 || i < 1) && i < timeSteps.Length; i++)
            {
                long rest = miliseconds % timeSteps[i];
                elapsedTime = rest + ids[i] + elapsedTime;
                miliseconds = miliseconds / timeSteps[i];
            }
            return elapsedTime.Substring(0, elapsedTime.Length - 1);
        }
    }
}
