using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p04.Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string banWords = Console.ReadLine();
            var wordsToRemove = banWords.Split(", ");
            string words = Console.ReadLine();

            foreach (var wordToRemove in wordsToRemove)
            {
                string replaceText = new string('*', wordToRemove.Length);
                words = words.Replace(wordToRemove, replaceText);
            }
            Console.WriteLine(words);
        }
    }
}
