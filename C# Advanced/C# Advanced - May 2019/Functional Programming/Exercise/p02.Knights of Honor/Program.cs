using System;

namespace p02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = names =>
                Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", names));

            printNames(inputNames);
        }
    }
}
