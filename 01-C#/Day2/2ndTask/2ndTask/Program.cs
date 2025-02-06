namespace _2ndTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your statement");
            string statement = Console.ReadLine();

            string[] words = statement.Split(new[] { ' ' });

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write($"{words[i]} ");
            }
        }
    }
}
