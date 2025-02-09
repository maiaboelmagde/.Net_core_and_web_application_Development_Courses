namespace TaskSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Create a list of questions
            QuestionList questions = new QuestionList("./file.txt")
            {
                new TF("Is the sky blue?", true,1),
                new MCQOneChoice("What is 2 + 2?", new AnswerList { new AnswerClass("3",true), new AnswerClass("4", false), new AnswerClass("5",false)}, 2),
                new MCQMultiChoices("Which are prime numbers?", new AnswerList{new AnswerClass("3",false), new AnswerClass("4", true), new AnswerClass("5",true) }, 3)
            };
            // Display all questions
            Console.WriteLine(questions.ToString());
        }
    }
}
