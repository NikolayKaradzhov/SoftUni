using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words.Add(word, new List<string>());
                    words[word].Add(synonym);
                }
                else
                {
                    words[word].Add(synonym);
                }
            }
            foreach (var item in words)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
