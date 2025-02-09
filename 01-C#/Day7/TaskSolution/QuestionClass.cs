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
        public string[] Body { get; set; }
        public int Marks { get; set; }

        protected QuestionClass(string header, string[] body, int marks)
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
            return $"MCQ: {Header}, Marks: {Marks}, Body: {string.Join(", ", Body)}";
        }
    }

    
    public class MCQOneChoice : QuestionClass
    {
        public MCQOneChoice(string header, string[] body, int marks) : base(header, body, marks)
        {
        }
        public override string ToString()
        {
            return $"Choose One: {Header}, Marks: {Marks}, Options: {string.Join(", ", Body)}";
        }
    }

    public class MCQMultiChoices : QuestionClass
    {
        public MCQMultiChoices(string header, string[] body, int marks) : base(header, body, marks)
        {
        }

        public override string ToString()
        {
            return $"Choose All: {Header}, Marks: {Marks}, Options: {string.Join(", ", Body)}";
        }
    }

    public class TF : QuestionClass
    {
        public TF(string header, int marks) : base(header, new string[] {"True", "False"}, marks)
        {

        }

        public override string ToString()
        {
            return $"TF: {Header}, Marks: {Marks}, Options: {string.Join(", ", Body)}";
        }
    }

}