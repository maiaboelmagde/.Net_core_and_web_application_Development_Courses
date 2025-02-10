using System;
using System.Linq;

namespace TaskSolution
{
    public abstract class QuestionClass : ICloneable, IComparable<QuestionClass>
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
            return $"Header: {Header}, Marks: {Marks} ";
        }

        public string getQuestion()
        {
            string question = $"{Header} ({Marks} Marks) ";
            int index = 1;
            foreach (var item in Body)
            {
                question += $"\n{index} - {item.getOption()}";
                index++;
            }
            return question;
        }

        public override string ToString()
        {
            return $"Question: {Header}, Marks: {Marks}, Body: {Body.ToString()}";
        }



        public object Clone()
        {
            AnswerList clonedBody = new AnswerList();
            foreach (var answer in Body)
            {
                clonedBody.Add((AnswerClass)answer.Clone());
            }

            switch (this)
            {
                case MCQOneChoice mcqOne:
                    return new MCQOneChoice(Header, clonedBody, Marks);
                case MCQMultiChoices mcqMulti:
                    return new MCQMultiChoices(Header, clonedBody, Marks);
                case TF tf:
                    return new TF(Header, Body.First().IsCorrect, Marks);
                default:
                    throw new NotImplementedException("Unknown question type");
            }
        }


        public int CompareTo(QuestionClass other)                                                      //Note: complete handling it later
        {
            if (other == null) return 1;
            return this.Marks.CompareTo(other.Marks);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Header, Marks);
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
                bool foundCorrect = false;
                foreach (var answer in Body)
                {
                    if (answer.IsCorrect)
                    {
                        if (!foundCorrect)
                            foundCorrect = true;
                        else
                            answer.IsCorrect = false;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Choose One: {Header}, Marks: {Marks}, Options: {Body.ToString()}";
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
        public TF(string header, bool isCorrect, int marks) : base(header, new AnswerList { new AnswerClass("True", isCorrect), new AnswerClass("False", !isCorrect) }, marks)
        {
        }

        public override string ToString()
        {
            return $"TF: {Header}, Marks: {Marks}, Options: {Body.ToString()}";
        }
    }
}
