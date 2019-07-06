using System;

namespace p03.Characters_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            PrintCharsBetweenTwoChars(firstChar, secondChar);
           
        }
        private static void PrintCharsBetweenTwoChars(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                for (char i = (char)(secondChar + 1); i < firstChar; i++)
                {
                    Console.Write(i + " "); ;
                }
            }
            else if (firstChar < secondChar)
            {
                for (char i = (char)(firstChar + 1); i < secondChar; i++)
                {
                    Console.Write(i + " "); ;
                }
            }
        }
    }
}
