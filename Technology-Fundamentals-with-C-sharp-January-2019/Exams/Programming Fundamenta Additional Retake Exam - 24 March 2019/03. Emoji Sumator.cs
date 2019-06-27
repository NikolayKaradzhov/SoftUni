using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p03.Emoji_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string emojiCode = Console.ReadLine();
            string emojiCodeToWord = string.Empty;
            int emojiTotalPower = 0;
                               //Positive Lookbehind     //Positive Lookahead
            string pattern = @"(?<= )(?<emoji>:[a-z]{4,}:)(?= |,|\.|!|\?)";
            
            /*
            Hello I am Mark from :England: and I am :one: :seven: years old, I have a :hamster:.as pet.

            In the Sofia Zoo there are many animals, such as :ti ger:, :elephan:t, :monk3y:, :goriLLa:, :fox:.
            :sunny: 
            :smiley: 
            :smiley:.
            */

            Regex order = new Regex(pattern);

            MatchCollection matches = order.Matches(input);

            List<string> matchedEmojis = new List<string>();
            string currentWordToPrint = string.Empty;

            //Find emojiCode word
            string[] splittedCode = emojiCode.Split(":");

            foreach (var code in splittedCode)
            {
                int currentCode = Convert.ToInt32(code);
                emojiCodeToWord += (char)(currentCode);
            }

            foreach (Match match in matches)
            {
                string currentWord = match.Groups["emoji"].Value;

                matchedEmojis.Add(currentWord);

                for (int i = 1; i < currentWord.Length - 1; i++)
                {
                    var letter = currentWord[i];
                    emojiTotalPower += (int)(letter);
                }
            }
            foreach (var word in matchedEmojis)
            {
               var currentWord = word.Substring(1, word.Length - 2);
                if (currentWord == emojiCodeToWord)
                {
                    emojiTotalPower *= 2;
                }
            }

            if (matchedEmojis.Count > 0)
            {
                Console.Write($"Emojis found:");
                for (int i = 0; i < matchedEmojis.Count; i++)
                {
                    string emoji = matchedEmojis[i];
                    int lastItem = matchedEmojis.Count - 1;
                    if (i == lastItem)
                    {
                        Console.Write($" {emoji}");
                    }
                    else
                    {
                        Console.Write($" {emoji},");
                    }

                }
                Console.WriteLine();
                Console.WriteLine($"Total Emoji Power: {emojiTotalPower}");
            }
            else
            {
                Console.WriteLine($"Total Emoji Power: {emojiTotalPower}");
            }
        }
    }
}
