using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p02.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string firstWord = input[0];
            string secondWord = input[1];

            string longerWord = string.Empty;
            string shorterWord = string.Empty;
            int cont = 0;

            int sum = 0;

            if (firstWord.Length >= secondWord.Length)
            {
                longerWord = firstWord;
                shorterWord = secondWord;

            }
            else
            {
                longerWord = secondWord;
                shorterWord = firstWord;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                sum += longerWord[i] * shorterWord[i];
            }
            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }
            Console.WriteLine(sum);
        }
    }
}
