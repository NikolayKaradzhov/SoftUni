using System;
using System.Linq;

namespace p05.Even_and_Odd_Substraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumOdd = 0;
            int sumEven = 0;
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currenNumber = numbers[i];
                if (currenNumber % 2 == 1)
                {
                    sumOdd += currenNumber;
                }
                else if (currenNumber % 2 == 0)
                {
                    sumEven += currenNumber;
                }
            }
            result = sumEven - sumOdd;
            Console.WriteLine(result);
        }
    }
}
