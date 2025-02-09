using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolution
{
    public class AnswerClass
    {

        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }


        public AnswerClass( string answerText, bool isCorrect)
        {
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{AnswerText} - {(IsCorrect ? "Correct" : "Incorrect")}";
        }
    }

    public class AnswerList : List<AnswerClass>
    {
        /*
        private readonly string _logFilePath;

        public AnswerList(string logFilePath)
        {
            _logFilePath = logFilePath;

            using (TextWriter writer = new StreamWriter(logFilePath))
            {
                writer.Write(string.Empty);
            }
        }
        */
        public new void Add(AnswerClass answer)
        {
            base.Add(answer);
            /*
            using (TextWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine(answer.ToString());
            }
            */
        }

        /*
        public string ReadAllAnswers()
        {
            using (TextReader reader = new StreamReader(_logFilePath))
            {
                return reader.ReadToEnd();
            }
        }
        */
        public override string ToString()
        {
            return string.Join('/', this);
        }
    }
}
