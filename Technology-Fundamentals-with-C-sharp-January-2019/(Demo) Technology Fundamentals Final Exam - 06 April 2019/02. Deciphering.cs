using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string subStrings = Console.ReadLine();
            string pattern = @"^[d-z{}\|#]*$";

            Regex order = new Regex(pattern);

            StringBuilder sb = new StringBuilder();

            string decodedText = string.Empty;

            if (order.IsMatch(input))
            {
                foreach (var character in input)
                {
                    sb.Append((char)(character - 3));
                }

                string[] splitStrings = subStrings.Split(" ");
                string wordToReplace = splitStrings[0];
                string second = splitStrings[1];

                sb.Replace(wordToReplace, second);

                Console.WriteLine(sb);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }      
        }
    }
}
