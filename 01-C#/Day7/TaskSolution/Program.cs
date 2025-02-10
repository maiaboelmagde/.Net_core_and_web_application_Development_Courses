namespace TaskSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string FinalExamPath = "./finalExam.txt";
            string practiceExamPath = "./practiceExam.txt";
            /*
            QuestionList questions = new QuestionList(practiceExamPath, true)
            {
                new TF("Is the sky blue?", true,1),
                new MCQOneChoice("What is 2 + 2?", new AnswerList { new AnswerClass("3",true), new AnswerClass("4", false), new AnswerClass("5",false)}, 2),
                new MCQMultiChoices("Which are prime numbers?", new AnswerList{new AnswerClass("3",false), new AnswerClass("4", true), new AnswerClass("5",true) }, 3)
            };
            

            QuestionList questions2 = new QuestionList(FinalExamPath, true)
            {
                new TF("HTML is a programming Language?", false,1),
                new MCQOneChoice("What is 3 | 2?", new AnswerList { new AnswerClass("3",true), new AnswerClass("4", false), new AnswerClass("5",false)}, 2),
                new MCQMultiChoices("Which are Programming Language?", new AnswerList{new AnswerClass("Java",true), new AnswerClass("C", true), new AnswerClass("XML",false), new AnswerClass("Python",true) }, 3)
            };
            */

            bool valid;
            int input;
            do
            {
                
                Console.WriteLine("Enter 1 for Practice Exam and 2 for Final Exam : ");
                valid = int.TryParse(Console.ReadLine(), out input);
                if (!valid || !(input == 1 || input == 2))
                {
                    valid = false;
                    Console.WriteLine("Please , enter a valid number");
                }

            } while (!valid);
            if(input == 1)
            {
                PracticeExam practiceExam = new PracticeExam(practiceExamPath);
                practiceExam.Show();
            }
            else
            {
                FinalExam finalExam = new FinalExam(FinalExamPath);
                finalExam.Show();
            }

        }
    }
}
