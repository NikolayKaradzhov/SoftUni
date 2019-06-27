using System;

namespace p03.Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal inputAndSum = 0m;

            for (int i = 0; i < n; i++)
            {
                inputAndSum += decimal.Parse(Console.ReadLine());                
            }
            Console.WriteLine(inputAndSum);
        }
    }
}
