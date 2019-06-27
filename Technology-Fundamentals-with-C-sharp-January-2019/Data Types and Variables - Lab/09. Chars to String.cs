using System;

namespace p09.Chars_To_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            string result = $"{firstChar}{secondChar}{thirdChar}";

            Console.WriteLine(result);
        }
    }
}
