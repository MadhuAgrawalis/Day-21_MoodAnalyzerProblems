using System;
using System.Runtime.Serialization;

namespace TestProject2
{
    [TestClass]
    public class TestCases
    {
        private MoodAnalyser moodAnalyser;

        MoodAnalyser happyMood;

        [TestInitialize]
        public void SetUp()
        {
            moodAnalyser = new MoodAnalyser(message);
        }
       // <summary>
        //UC2-Handling exceptions
       // </summary>
        [TestMethod]
        public void TestMethodForHappyMood(MoodAnalyser moodAnalyser)

        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodForSadMood(MoodAnalyser moodAnalyser)

        {
            string expected = "sad";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForNullMood(MoodAnalyser moodAnalyser, MoodAnalyser moodAnalyser)

        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        // <summary>
        // UC3-Customized Exception
        // </summary>
        [TestMethod]
        public void TestMethodForCustomizedNullException()

        {
            string expected = "Mood should not be null";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(null);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void TestMethodForCustomizedEmptyException()

        {
            string expected = "Mood should not be empty";
            try
            {

                MoodAnalyser moodAnalyser = new MoodAnalyser(string.Empty);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        /// <summary>
        /// Using Reflection-UC4-Default Constructor
        /// </summary>
        [TestMethod]
        public void Reflection_Return_Default_Constructor()
        {
            MoodAnalyser expected = new MoodAnalyser();
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        //Neagtive Case
        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Class_Found()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnaly", "MoodAnaly");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        //Neagtive Case
        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Constructor_Found()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnaly");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        /// <summary>
        /// Using Reflection-UC5-Parameterized Constructor
        /// </summary>
        [TestMethod]
        public void Reflection_Return_Parameterized_Constructor()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            object actual = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser", message);

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
            actual.Equals(expected);
        }
        //Invalid case
        [TestMethod]
        public void Reflection_Return_Parameterized_Class_Invalid()
        {
            string message = "I am in happy mood";
            MoodAnalyser expected = new MoodAnalyser(message);
            object actual = null;
            try
            {
                MoodAnalyserFactory factory = new MoodAnalyserFactory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAna", "MoodAnalyser", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }
        /// <summary>
        /// UC6-Using Reflection-Invoke Method
        /// </summary>
        [TestMethod]
        public void Reflection_Return_Method()
        {
            string expected = "happy";
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            string actual = factory.InvokeAnalyserMethod("happy", "AnalyzeMood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reflection_Return_Invalid_Method()
        {
            string expected = "happy";
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            string actual = factory.InvokeAnalyserMethod("happy", "Analyze");

            Assert.AreEqual(expected, actual);
        }
    }

    [Serializable]
    internal class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}