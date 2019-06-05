using System;
using System.Linq;

namespace p05.Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            Func<int, int> addFunction = x => x += 1;
            Func<int, int> multiplyFunction = x => x *= 2;
            Func<int, int> substractFunction = x => x -= 1;

            Action<int[]> printAllNumbers = numbersToPrint => 
                    Console.WriteLine(string.Join(" ", numbersToPrint));

            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(addFunction).ToArray();
                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiplyFunction).ToArray();
                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(substractFunction).ToArray();
                }
                else if (command == "print")
                {
                    printAllNumbers(numbers);
                }

                command = Console.ReadLine(); 
            }
        }
    }
}