using System;
using System.IO;

namespace p02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\SoftUni\\C# Advanced\\C# Advanced - May 2019\\Streams, Files And Directories\\Lab\\Resources\\01. Odd Lines";
            string fileName = "input.txt";
            string filePath = Path.Combine(path, fileName);

            string outputFile = "output2.txt";

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {
                    var counter = 1;

                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");

                        line = reader.ReadLine();
                        counter++;
                    }
                }
            }
        }
    }
}