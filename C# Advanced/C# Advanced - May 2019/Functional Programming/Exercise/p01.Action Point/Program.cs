using System;
using System.Linq;

namespace p01.Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = names => 
                Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(inputNames);
        }
    }
}