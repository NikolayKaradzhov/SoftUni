using System;
using System.IO;

namespace p01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SoftUni\C# Advanced\C# Advanced - May 2019\Streams, Files And Directories\Lab\Resources\01. Odd Lines";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            string outputFile = "output.txt";

            using (var reader = new StreamReader(filePath))
            {
                int counter = 0;

                string line = reader.ReadLine();

                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            Console.WriteLine(line);
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}