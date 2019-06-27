using System;
using System.Linq;

namespace p08.Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int finalResult = 0;

            int[] condensed = new int[numbers.Length - 1];

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
            }
            else
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        condensed[j] = numbers[j] + numbers[j + 1];
                        numbers[j] = condensed[j];
                    }
                    finalResult = condensed[0];
                }
                Console.WriteLine(finalResult);
            }      
        }
    }
}
