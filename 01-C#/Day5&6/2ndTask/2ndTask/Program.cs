
using System;

namespace _2ndTask
{ 
    class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
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
            MathOperations math = new MathOperations();

            Console.WriteLine("Addition: " + math.Add(10, 5));
            Console.WriteLine("Subtraction: " + math.Subtract(10, 5));
            Console.WriteLine("Multiplication: " + math.Multiply(10, 5));
            Console.WriteLine("Division: " + math.Divide(10, 5));
        }
    }

}
