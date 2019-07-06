using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int i = startNumber; i <= endNumber; i++)
            {
                totalSum += i;
                Console.Write(i + " ");      
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {totalSum}");
        }
    }
}
