namespace TaskSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            // Create a list of questions
            QuestionList questions = new QuestionList("./file.txt")
            {
                new TF("Is the sky blue?", 1),
                new MCQOneChoice("What is 2 + 2?", new string[] { "3", "4", "5" }, 2),
                new MCQMultiChoices("Which are prime numbers?", new string[] { "2", "3", "4", "5" }, 3)
            };

            // Display all questions
            Console.WriteLine(questions.ToString());
        }
    }
}
