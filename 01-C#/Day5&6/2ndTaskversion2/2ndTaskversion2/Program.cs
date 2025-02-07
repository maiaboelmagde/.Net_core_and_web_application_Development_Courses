using System;

namespace _2ndTaskversion2
{
    class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN;
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Addition: " + MathOperations.Add(10, 5));
            Console.WriteLine("Subtraction: " + MathOperations.Subtract(10, 5));
            Console.WriteLine("Multiplication: " + MathOperations.Multiply(10, 5));
            Console.WriteLine("Division: " + MathOperations.Divide(10, 5));
        }
    }

}
