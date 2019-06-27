using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputPounds = double.Parse(Console.ReadLine());

            double convertPoundsToDollars = 1.31 * inputPounds;

            Console.WriteLine($"{convertPoundsToDollars:F3}");
        }
    }
}
