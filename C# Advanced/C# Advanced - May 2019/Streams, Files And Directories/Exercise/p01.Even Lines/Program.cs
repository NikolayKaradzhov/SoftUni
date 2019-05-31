using System;
using System.IO;
using System.Linq;

namespace p01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources\text.txt";

            int counter = 0;

            using (StreamReader sr = new StreamReader(textFilePath))
            {
                string currentLine = sr.ReadLine();

                while (currentLine != null)
                {   
                    if (counter % 2 == 0)
                    {
                        string replaceSymbols = ReplaceSymbols(currentLine);
                        string reverseWords = ReverseWords(replaceSymbols);
                        Console.WriteLine(reverseWords);
                    }

                    currentLine = sr.ReadLine();

                    counter++;
                }
            }
        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSymbols(string currentLine)
        {
            return currentLine.Replace('-', '@')
                .Replace(',', '@')
                .Replace('.', '@')
                .Replace('!', '@')
                .Replace('?', '@');
        }
    }
}