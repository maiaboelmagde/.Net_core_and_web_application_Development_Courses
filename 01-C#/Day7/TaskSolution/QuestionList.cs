using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolution
{
    public class QuestionList : List<QuestionClass>
    {
        private readonly string _logFilePath;

        public QuestionList(string logFilePath)
        {
            _logFilePath = logFilePath;

            using (TextWriter writer = new StreamWriter(_logFilePath))
            {
                writer.Write(string.Empty);
            }
        }

        public new void Add(QuestionClass question)
        {
            base.Add(question);

            using (TextWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine('\n'+question.ToString());
            }
        }

        public string ReadAllQuestions()
        {
            using (TextReader reader = new StreamReader(_logFilePath))
            {
                return reader.ReadToEnd();
            }
        }

        public override string ToString()
        {
            return string.Join('\n', this);
        }
    }
}
