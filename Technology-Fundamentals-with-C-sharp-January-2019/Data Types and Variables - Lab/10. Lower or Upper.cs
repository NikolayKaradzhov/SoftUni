using System;

namespace p10.Lower_Or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char readChar = char.Parse(Console.ReadLine());

            string upperResult = "upper-case";

            string lowerResult = "lower-case";

            if (readChar >= 65 && readChar <= 90)
            {
                Console.WriteLine(upperResult);
            }
            else
            {
                Console.WriteLine(lowerResult);
            }
        }
    }
}
