using System;

namespace p04.Sum_Of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int sumOfChars = 0;

            for (int i = 0; i < numberOfChars; i++)
            {
                char readChar = char.Parse(Console.ReadLine());
                sumOfChars += readChar;
            }
            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
