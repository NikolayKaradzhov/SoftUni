using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p02.Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            StringBuilder result = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result.Append(word);
                }
            }
            Console.WriteLine(result);
        }
    }
}
