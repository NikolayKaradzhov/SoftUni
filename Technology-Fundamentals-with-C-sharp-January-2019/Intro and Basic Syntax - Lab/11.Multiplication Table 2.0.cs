using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int multiplier = int.Parse(Console.ReadLine());

            for (int i = multiplier; i <= 10; i++)
            { 
                    int result = input * i;
                    Console.WriteLine($"{input} X {i} = {result}");
            }
            if (multiplier > 10)
            {
                Console.WriteLine($"{input} X {multiplier} = {input * multiplier}");
            }
        }
    }
}
