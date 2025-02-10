using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskSolution
{
    public class QuestionList : List<QuestionClass>, ICloneable, IComparable<QuestionList>
    {
        private readonly string _logFilePath;

        public QuestionList(string logFilePath, bool RemoveCurAdition = false)
        {
            _logFilePath = logFilePath;
            if (RemoveCurAdition)
            {
                using (TextWriter writer = new StreamWriter(_logFilePath, false))
                {
                    writer.Write(string.Empty);
                }
            }
        }

        public new void Add(QuestionClass question)
        {
            base.Add(question);

            using (TextWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine('\n' + question.ToString());
            }
        }

        private void AddAsbase(QuestionClass question)
        {
            base.Add(question);
        }

        public static void ReadAllQuestions(QuestionList NewList)
        {
            if (!File.Exists(NewList._logFilePath)) return;

            using (TextReader reader = new StreamReader(NewList._logFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] splittedQuestions = line.Split(new char[] { ',', ':' });
                    if (splittedQuestions.Length % 6 != 0) return;
                    for (int i = 0; i < splittedQuestions.Length; i += 6)
                    {
                        QuestionClass Question;
                        string[] options = splittedQuestions[i + 5].Split(new char[] { '-', '/' });
                        int mark;
                        string QuestionText = splittedQuestions[i + 1];
                        bool valid = int.TryParse(splittedQuestions[i + 3].Trim(), out mark);
                        if (!valid) return;

                        if (splittedQuestions[i].Trim() == "TF")
                        {
                            if (options.Length != 4) return;
                            Question = new TF(QuestionText, options[1].Trim() == "Correct", mark);
                        }
                        else if (splittedQuestions[i].Trim() == "Choose One")
                        {
                            if (options.Length % 2 != 0) return;
                            AnswerList ourOptions = new AnswerList();
                            for (int it = 0; it < options.Length; it += 2)
                            {
                                ourOptions.Add(new AnswerClass(options[it].Trim(), options[it + 1].Trim() == "Correct"));
                            }
                            Question = new MCQOneChoice(QuestionText, ourOptions, mark);
                        }
                        else if (splittedQuestions[i].Trim() == "Choose All")
                        {
                            if (options.Length % 2 != 0) return;
                            AnswerList ourOptions = new AnswerList();
                            for (int it = 0; it < options.Length; it += 2)
                            {
                                ourOptions.Add(new AnswerClass(options[it].Trim(), options[it + 1].Trim() == "Correct"));
                            }
                            Question = new MCQMultiChoices(QuestionText, ourOptions, mark);
                        }
                        else
                        {
                            return;
                        }
                        NewList.AddAsbase(Question);
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Join('\n', this);
        }

        public object Clone()
        {
            QuestionList clonedList = new QuestionList(_logFilePath);
            foreach (var question in this)
            {
                clonedList.Add((QuestionClass)question.Clone()); 
            }
            return clonedList;
        }

        public int CompareTo(QuestionList other)                                                 //Note:Complete handle it later
        {
            if (other == null) return 1;
            return this.Count.CompareTo(other.Count);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this._logFilePath, this);
        }
    }
}
