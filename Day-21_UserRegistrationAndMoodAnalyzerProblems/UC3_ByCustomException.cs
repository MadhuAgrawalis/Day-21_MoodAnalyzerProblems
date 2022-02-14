using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MoodAnalyzerException
{
    public class UC3_ByCustomException
    {
        string message;
        private readonly object UC_CustomException;

        public UC3_ByCustomException(object customException)
        {
            this.UC_CustomException = customException;
        }

        public UC3_ByCustomException(string message)
        {
            this.message = message;
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
                    throw new CustomException(UC_CustomException.ExceptionType.EMPTY_EXCEPTION,
                                              "Mood should not be empty");
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
                return "happy";

            }
        }

        [Serializable]
        private class CustomException : Exception
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
}