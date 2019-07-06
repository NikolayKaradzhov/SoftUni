using System;

namespace p05.Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int endIndex = int.Parse(Console.ReadLine());

            for (int i = startIndex; i <= endIndex; i++)
            {
                char c = (char)i;
                Console.Write($"{Convert.ToChar(i)} ");
            }
        }
    }
}
