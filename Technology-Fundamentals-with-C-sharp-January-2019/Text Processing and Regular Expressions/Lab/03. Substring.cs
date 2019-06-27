using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p02
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string word = Console.ReadLine();

            while (word.Contains(wordToRemove))
            {
                int indexOfWordToRemove = word.IndexOf(wordToRemove, StringComparison.InvariantCultureIgnoreCase);

                word = word.Remove(indexOfWordToRemove, wordToRemove.Length);
            }
            Console.WriteLine(word);
        }
    }
}
