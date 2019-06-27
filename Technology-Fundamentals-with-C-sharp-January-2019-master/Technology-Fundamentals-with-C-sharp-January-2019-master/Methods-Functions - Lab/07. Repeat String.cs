using System;

namespace p07.Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int timesToRepeat = int.Parse(Console.ReadLine());

            string printedResult = RepeatString(input, timesToRepeat);
            Console.WriteLine(printedResult);
        }

        private static string RepeatString(string input, int timesToRepeat)
        {
            for (int i = 1; i < timesToRepeat; i++)
            {
                Console.Write(input);
            }
            return input;
        }
    }
}
