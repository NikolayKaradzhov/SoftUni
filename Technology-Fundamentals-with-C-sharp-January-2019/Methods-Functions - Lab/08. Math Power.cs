using System;

namespace p08.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintPoweredNumber(number, power));
        }

        private static double PrintPoweredNumber(double number, int power)
        {
            double result = 1.0d;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
