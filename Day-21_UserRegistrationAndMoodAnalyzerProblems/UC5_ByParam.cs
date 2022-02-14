using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MoodAnalyzerException
{
    public class uc5_ByParam
    {
        string message;
        private readonly object CustomException;

        public void MoodAnalyser()
        {
        }

        public void MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {
                if (message.Equals(string.Empty))
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_EXCEPTION, "Mood should not be empty");
                }

                else if (message.ToLower().Contains("happy"))
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
                throw new CustomException(CustomException.ExceptionType.NULL_EXCEPTION, "Mood should not be null");

            }
        }
    }

    [Serializable]
    internal class CustomException : Exception
    {
        private object eMPTY_EXCEPTION;
        private string v;

        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(object eMPTY_EXCEPTION, string v)
        {
            this.eMPTY_EXCEPTION = eMPTY_EXCEPTION;
            this.v = v;
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}