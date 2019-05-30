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
            string path = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Lab\Resources\03. Word Count";
            string words = "words.txt";
            string text = "text.txt";
            string output = "output.txt";

            string wordsPath = Path.Combine(path, words);
            string textPath = Path.Combine(path, text);

            var wordsSeparated = new List<string>();
            var database = new Dictionary<string, int>();

            using (var wordReader = new StreamReader(wordsPath))
            {
                string line = wordReader.ReadLine();

                while (line != null)
                {
                    string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in tokens)
                    {
                        wordsSeparated.Add(word);
                        database.Add(word, 0);
                    }
                    line = wordReader.ReadLine();
                }
            }

            using (var textReader = new StreamReader(textPath))
            {
                string line = textReader.ReadLine();

                while (line != null)
                {
                    string[] lineSplitedd = line
                .Split(new string[] { " ", ", ", "-", "." }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in wordsSeparated)
                    {
                        foreach (var separateWord in lineSplitedd)
                        {
                            if (separateWord.Equals(word, StringComparison.InvariantCultureIgnoreCase))
                            {
                                database[word] += 1;
                            }
                        }
                    }
                    line = textReader.ReadLine();
                }
            }
            using (var writer = new StreamWriter(Path.Combine(path, output)))
            {
                var orderedDatabase = database.OrderByDescending(x => x.Value);
                foreach (var kvp in orderedDatabase)
                {
                    writer.WriteLine($"{kvp.Key}-{kvp.Value}");
                }
            }
        }
    }
}