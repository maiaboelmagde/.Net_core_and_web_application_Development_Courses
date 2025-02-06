namespace _3rdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
             //using String Functions
          /*
            int totalCount = 0;

            for (int i = 1; i < 100_000_000; i++)
            {
                string number = i.ToString();
                totalCount += number.Split('1').Length - 1;
            }

            Console.WriteLine($"Total occurrences of '1': {totalCount}");
            


            */
            /*
            
            //using Numeric values :
            int totalCount = 0;

            for (int i = 1; i < 100_000_000; i++)
            {
                int number = i;
                while (number > 0)
                {
                    if (number % 10 == 1)
                    {
                        totalCount++;
                    }
                    number /= 10;
                }
            }

            Console.WriteLine($"Total occurrences of '1': {totalCount}");

            */
            
            
            //using equation:

            //100_000_000 contains 9 digits , number of 1s calculated accord the following equation : d×(10powerd-1)
            int d = 8;
            long totalOnes = d * (long)Math.Pow(10, d - 1);

            Console.WriteLine($"Total number of '1's from 1 to 100_000_000: {totalOnes}");
            
        }
    }
}
