using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSolution
{
    public abstract class ExamClass
    {
        int Time { set; get; }
        public SubjectClass SubjectClass { get;}
        public int NumberOfQuestions;
        public Dictionary<int, List<string>> answers;
        public QuestionList Questions;
        public string ExamText;

        protected ExamClass(string LogFilePath)
        {
            SubjectClass = new SubjectClass("Default Subject");
            Questions = new QuestionList(LogFilePath);
            QuestionList.ReadAllQuestions(Questions);
            NumberOfQuestions = Questions.Count;
            answers = new Dictionary<int, List<string>>();
        }

        public void Show()
        {
            for (int it = 0; it < Questions.Count; it++)
            {
                bool valid;
                do
                {
                    Console.WriteLine(Questions[it].getQuestion());
                    List<int> choices = new List<int>();

                    if (Questions[it] is MCQMultiChoices)
                    {
                        Console.WriteLine("Enter multiple choice numbers separated by spaces:\nYour Answer Numbers: ");
                        string[] input = Console.ReadLine().Split(' ');
                        valid = true;

                        foreach (string s in input)
                        {
                            if (int.TryParse(s, out int output))
                            {
                                choices.Add(output - 1); 
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your Answer Number: ");
                        valid = int.TryParse(Console.ReadLine(), out int output);
                        if (valid)
                        {
                            choices.Add(output - 1);
                        }
                    }

                    foreach (int choice in choices)
                    {
                        if (choice < 0 || choice >= Questions[it].Body.Count)
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        if (!answers.ContainsKey(it))
                        {
                            answers[it] = new List<string>();
                        }

                        foreach (int choice in choices)
                        {
                            answers[it].Add(Questions[it].Body[choice].AnswerText);
                        }
                    }

                    if(!valid)
                        Console.WriteLine("Please enter a valid option");

                } while (!valid);
            }

            foreach (KeyValuePair<int, List<string>> iter in answers)
            {
                string questionString = iter.Key + ":";
                foreach (string answer in iter.Value)
                {
                    questionString = questionString + " " + answer;
                }
                Console.WriteLine(questionString);
            }

            this.afterShow();
        }

        public abstract void afterShow();
    }

    public class PracticeExam : ExamClass
    {
        public PracticeExam(string LogFilePath) : base(LogFilePath) { }

        public override void afterShow()
        {
            int Score = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine(Questions[i].getQuestion());
                List<string> correctAnswer = new List<string>();
                for(int idx = 0; idx < Questions[i].Body.Count; idx++)
                {
                    if (Questions[i].Body[idx].IsCorrect == true)
                    {
                        correctAnswer.Add(Questions[i].Body[idx].AnswerText);
                    }
                }
                string finalCorrectAnswer = "";
                foreach (string answer in correctAnswer) finalCorrectAnswer += $"{answer} ";
                string finalYourAnswer = "";
                foreach (string answer in answers[i]) finalYourAnswer += $"{answer} ";
                Console.WriteLine($"correctAnswer : {finalCorrectAnswer}");
                Console.WriteLine($"You Answer : {finalYourAnswer}");
                if (finalCorrectAnswer == finalYourAnswer) Score += Questions[i].Marks;
            }
            Console.WriteLine(" _________________________");
            Console.WriteLine();
            Console.WriteLine($"| So you Scored   {Score}  Marks |");
            Console.WriteLine(" _________________________");
        }
    }

    public class FinalExam : ExamClass
    {
        public FinalExam(string LogFilePath) : base(LogFilePath) { }

        public override void afterShow()
        {
            Console.WriteLine(" -------------------------");
            Console.WriteLine("| Exam Finished, Thank you |");
            Console.WriteLine(" -------------------------");

        }

    }
}
