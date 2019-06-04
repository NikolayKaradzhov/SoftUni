using System;
using System.Linq;

namespace p03.Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> printNumber = x => Console.WriteLine(x);  

            int[] numbersInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> selectMinNumber = numbers =>
            {
                int minNumber = numbers.Min();
                return minNumber;
            };

            int minValue = selectMinNumber(numbersInput);
            printNumber(minValue);
        }
    }
}