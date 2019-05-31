using System;
using System.IO;
using System.Linq;

namespace p02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\Resources\text.txt";
            string outputFilePath = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Exercise\p02.Line Numbers\output.txt";

            string[] allTextLines = File.ReadAllLines(textFilePath);
            var lineCounter = 1;

            foreach (var currentLine in allTextLines)
            {
                int letterCount = currentLine.Count(char.IsLetter);
                int puncSignsCount = currentLine.Count(char.IsPunctuation);
                File.AppendAllText(outputFilePath, $"Line {lineCounter}: {currentLine} ({letterCount})({puncSignsCount})" +
                    $"{Environment.NewLine}");
                lineCounter++;
            }
        }  
    }
}