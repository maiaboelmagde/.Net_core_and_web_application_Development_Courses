using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
namespace TaskSolution
{
    public abstract class QuestionClass
    {
        public string Header { get; set; }
        public AnswerList Body { get; set; }
        public int Marks { get; set; }

        protected QuestionClass(string header, AnswerList body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
        }

        public virtual string GetQuestionInfo()
        {
            return $"Header: {Header}, Marks: {Marks}";
        }

        public override string ToString()
        {
            return $"MCQ: {Header}, Marks: {Marks}, Body: {Body.ToString()}";
        }
    }

    
    public class MCQOneChoice : QuestionClass
    {
        public MCQOneChoice(string header, AnswerList body, int marks) : base(header, body, marks)
        {
            EnsureOnlyOneCorrectAnswer();
        }

        private void EnsureOnlyOneCorrectAnswer()
        {
            if (Body.Count(a => a.IsCorrect) > 1)
            {
                // Keep only the first correct answer, set the rest to false
                bool foundCorrect = false;
                foreach (var answer in Body)
                {
                    if (answer.IsCorrect)
                    {
                        if (!foundCorrect)
                            foundCorrect = true;
                        else
                            answer.IsCorrect = false; // Set the extra correct answers to false
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"Choose One: {Header}, Marks: {Marks}, Options: { Body.ToString()}";
        }
    }

    public class MCQMultiChoices : QuestionClass
    {
        public MCQMultiChoices(string header, AnswerList body, int marks) : base(header, body, marks)
        {
        }

        
        public override string ToString()
        {
            return $"Choose All: {Header}, Marks: {Marks}, Options: {Body.ToString()}";
        }
    }

    public class TF : QuestionClass
    {
        public TF(string header, bool isCorrect, int marks) : base(header, new AnswerList { new AnswerClass("True", isCorrect ? true : false), new AnswerClass("False", isCorrect ? false : true) }, marks)
        {
        }

        public override string ToString()
        {
            return $"TF: {Header}, Marks: {Marks}, Options: { Body.ToString()}";
        }
    }

}