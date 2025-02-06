namespace _1stTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array :");
            int n;
            n = int.Parse( Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxDist = -1;
            int idx = -1;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[i] && j - i > maxDist)
                    {
                        maxDist = j - i - 1;
                        idx = i;
                    }
                }
            }
            if (idx != -1)
            {
                Console.WriteLine($"Max distance is {maxDist} and the value is {arr[idx]}");
            }
            else
            {
                Console.WriteLine("there;s no equal values !!!");
            }
        }
    }
}
