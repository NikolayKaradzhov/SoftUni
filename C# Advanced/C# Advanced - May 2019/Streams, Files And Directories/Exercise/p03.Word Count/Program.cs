using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace p03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources\text.txt";
            string wordsFilePath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources\words.txt";
            string actualResultPath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p03.Word Count\actualResult.txt";
            string expectedResultPath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p03.Word Count\expectedResult.txt";

            string[] textLines = File.ReadAllLines(textFilePath);
            string[] words = File.ReadAllLines(wordsFilePath);

            var wordsInfo = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsInfo.ContainsKey(word))
                {
                    wordsInfo.Add(word, 0);
                }
            }

            foreach (var currentLine in textLines)
            {
                string[] wordsSplitted = currentLine
                .ToLower()
                .Split(new char[] { ' ', '-', ',', '?', '!', '\'', '.', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentWord in wordsSplitted)
                {
                    if (wordsInfo.ContainsKey(currentWord))
                    {
                        wordsInfo[currentWord]++;
                    }
                }
            }

            foreach (var kvp in wordsInfo)
            {
                File.AppendAllText(actualResultPath, $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }

            var ordered = wordsInfo.OrderByDescending(x => x.Value);

            foreach (var kvp in ordered)
            {
                File.AppendAllText(expectedResultPath, $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }
        }
    }
}