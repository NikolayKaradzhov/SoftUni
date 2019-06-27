using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04.Refactoring Prime Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)//2, 3, 4, 5 Prime : 2-true, 3-true, 4-false, 5- true
            {
                bool isPrime = true;
                string writeTrue = string.Empty;
                string writeFalse = string.Empty;

                for (int j = 1; j <= i; j++)//1, 2, 3, 4, 5
                {
                    if (i % j == 0 && j != 1 && j != i)
                    {
                        isPrime = false;
                        writeFalse = "false";
                        break;
                    }
                    else
                    {
                        isPrime = true;
                        writeTrue = "true";
                    }  
                }
                if (isPrime)
                {
                    Console.WriteLine($"{i} -> {writeTrue}");
                }
                else
                {
                    Console.WriteLine($"{i} -> {writeFalse}");
                }   
            }
        }
    }
}
