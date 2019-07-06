using System;
using System.Globalization;
using System.Linq;

class TriangleOfNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int newNumber = number;

        int sum = 0;

        while (number > 0)
        {
            int lastDigit = number % 10;

            number = number / 10;

            int factoriel = 1;

            for (int i = 1; i <= lastDigit; i++)
            {
                factoriel = factoriel * i;
            }
            sum = sum + factoriel;
        }

        bool isStrong = sum == newNumber;

        if (isStrong)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
