using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace 02.Activation_Keys1
{
    class Program
    {
        static void Main(string[] args)
        {
            string gameKeys = Console.ReadLine();

            string pattern = @"((?<divider>&)|(?<key>[A-Za-z0-9]{16,25}))";

            var order = new Regex(pattern);

            List<string> keys = new List<string>();

            string dashedStringKey = string.Empty;
            string currentString = string.Empty;
            char currentSymbol = ' ';
            int currentDigit = 0;
            char currentLetter = ' ';

            MatchCollection matches = order.Matches(gameKeys);

            foreach (Match match in matches)
            {
                string currentStringKey = match.Groups["key"].Value;
                dashedStringKey = string.Empty;

                if (currentStringKey.Length == 16)
                {
                    for (int j = 1; j <= 16; j++)
                    {
                        currentSymbol = currentStringKey[j - 1];

                        if (Char.IsDigit(currentSymbol))
                        {
                            currentDigit = '9' - currentSymbol;
                            if (j % 4 == 0 && j != 16)
                            {
                                currentString += currentDigit + "-";
                            }
                            else
                            {
                                currentString += currentDigit;
                            }
                        }
                        else if (Char.IsLetter(currentSymbol))
                        {
                            currentLetter = Char.ToUpper(currentSymbol);
                            if (j % 4 == 0 && j != 16)
                            {
                                currentString += currentLetter + "-";
                            }
                            else
                            {
                                currentString += currentLetter;
                            }
                        }
                    }
                    keys.Add(currentString);
                    currentString = string.Empty;
                }
                else if (currentStringKey.Length == 25)
                {
                    for (int j = 1; j <= 25; j++)
                    {
                        currentSymbol = currentStringKey[j - 1];

                        if (Char.IsDigit(currentSymbol))
                        {
                            currentDigit = '9' - currentSymbol;
                            if (j % 5 == 0 && j != 25)
                            {
                                currentString += currentDigit + "-";
                            }
                            else
                            {
                                currentString += currentDigit;
                            }
                        }
                        else if (Char.IsLetter(currentSymbol))
                        {
                            currentLetter = Char.ToUpper(currentSymbol);
                            if (j % 5 == 0 && j != 25)
                            {
                                currentString += currentLetter + "-";
                            }
                            else
                            {
                                currentString += currentLetter;
                            }
                        }
                    }
                    keys.Add(currentString);
                    currentString = string.Empty;
                }
            }
            for (int i = 0; i < keys.Count; i++)
            {
                if (i == keys.Count - 1)
                {
                    Console.Write(keys[i]);
                }
                else
                {
                    Console.Write(keys[i] + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
