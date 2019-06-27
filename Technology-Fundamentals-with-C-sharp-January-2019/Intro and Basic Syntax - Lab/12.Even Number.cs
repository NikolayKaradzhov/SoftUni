using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {  
            while (true)
            {
                int evenNumberInput = int.Parse(Console.ReadLine());

                if (evenNumberInput % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {Math.Abs(evenNumberInput)}");
                    break;
                }            
            }
        }
    }
}
