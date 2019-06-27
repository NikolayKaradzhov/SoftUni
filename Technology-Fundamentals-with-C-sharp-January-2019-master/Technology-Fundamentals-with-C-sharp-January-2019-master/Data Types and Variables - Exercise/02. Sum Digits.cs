using System;

namespace p02.Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int getNum = 0;
            int sum = 0;

            while (input != 0)
            {
                getNum = input % 10;
                sum += getNum;
                input = input / 10;
            }
            Console.WriteLine(sum);
        }
    }
}
