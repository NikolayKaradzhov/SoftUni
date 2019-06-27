using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!dictionary.ContainsKey(word[i]) && word[i] != ' ')
                {
                    dictionary.Add(word[i], 1);
                }
                else if (word[i] != ' ')
                {
                    dictionary[word[i]]++;
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
