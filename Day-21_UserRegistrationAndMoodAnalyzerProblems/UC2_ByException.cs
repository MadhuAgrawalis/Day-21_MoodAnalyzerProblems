using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerException
{
    public class uc2_ByException
    {
        string message;
        public void MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {

                if (message.ToLower().Contains("happy"))
                {
                    return "happy";
                }
                else
                {
                    return "sad";
                }
            }
            catch (NullReferenceException)
            {
                return "happy";

            }
        }
    }
}