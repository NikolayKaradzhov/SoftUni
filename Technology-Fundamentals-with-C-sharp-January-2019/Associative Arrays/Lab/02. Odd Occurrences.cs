using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var word in input)
            {
                string wordInLowercase = word.ToLower();

                if (words.ContainsKey(wordInLowercase))
                {
                    words[wordInLowercase]++;
                }
                else
                {
                    words.Add(wordInLowercase, 1);
                }
            }
            foreach (var count in words)
            {
                if (count.Value % 2 == 1)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
