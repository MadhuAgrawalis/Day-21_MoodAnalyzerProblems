using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerException
{
    public class uc1_AnalyzeTheMood
    {
        string message;
        public void MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
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
    }
}