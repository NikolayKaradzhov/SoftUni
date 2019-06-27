using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sumOddNumbers = 0;
           
                for (int i = 1; i <= n * 2; i++)
                {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    sumOddNumbers += i;
                }
                }
            Console.WriteLine($"Sum: {sumOddNumbers}");
        }
    }
}
