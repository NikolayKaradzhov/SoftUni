using System;

namespace p10.Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Abs(GetMultipleOfEvenAndOdds(number)));
        }
        private static int GetMultipleOfEvenAndOdds(int number)
        {
          return  GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        private static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    evenSum += digit;
                }
                number = number / 10;
            }
            return evenSum;
        }
        private static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;

            while (number != 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    oddSum += digit;
                }
                number = number / 10;
            }
            return oddSum;
        }
    }
}
