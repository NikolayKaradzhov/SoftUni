using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p01._Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string currentWord = string.Empty;

            bool firstPartIsTrue = false;

            List<string> nums = new List<string>();
            Dictionary<char, int> letters = new Dictionary<char, int>();

            string[] separated = input.Split('|');

            //First Part
            for (int i = 0; i < 1; i++)
            {
                string pattern = @"(?<g>[#%&*$][A-Z]+[#%&*$])";
                Regex order = new Regex(pattern);

                MatchCollection matches = order.Matches(separated[0]);

                foreach (Match match in matches)
                {
                    string currentString = match.Groups["g"].Value;
                    char currentFirstSymbol = currentString[0];
                    char currentLastSymbol = currentString[currentString.Length - 1];
                    currentWord = currentString.Substring(1, currentString.Length - 2);

                    if (currentFirstSymbol == currentLastSymbol && currentWord.Length >= 1)
                    {
                        firstPartIsTrue = true;
                    }
                }
            }
            //Second Part
            for (int i = 0; i < 1; i++)
            {
                string pattern2 = @"(?<nums>(6[5-9]|[78][0-9]|90):([0-9]{2}))";
                Regex order2 = new Regex(pattern2);

                MatchCollection matches2 = order2.Matches(separated[1]);

                foreach (Match match in matches2)
                {
                    string currentMatch = match.Groups["nums"].Value;

                    if (!nums.Contains(currentMatch))
                    {
                        nums.Add(currentMatch);
                    }       
                }

                foreach (var item in nums)
                {
                    string[] separate = item.Split(':');
                    int c = Convert.ToInt32(separate[0]);
                    char charrrr = Convert.ToChar(c);
                    int length = int.Parse(separate[1]);
                    letters.Add(charrrr, length);
                }
            }
            //Third Part
            string thirdPhrase = separated[2];
            string[] thirdPhraseSplitted = thirdPhrase.Split(' ');

            if (firstPartIsTrue)
            {
                foreach (var character in currentWord)
                {
                    string currentCharrr = character.ToString();
                    foreach (var letter in letters)
                    {
                        foreach (var word in thirdPhraseSplitted)
                        {
                            if (character == letter.Key
                                && word.Contains(currentCharrr)
                                && word.Length == letter.Value + 1)
                            {
                                Console.WriteLine(word);
                            }
                        }
                    }
                }
            }
        }
    }
}
