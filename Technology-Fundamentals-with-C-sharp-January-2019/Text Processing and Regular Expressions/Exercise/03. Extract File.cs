using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p03.Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> splitted = input.Split("\\").ToList();

            foreach (var item in splitted)
            {
                if (item.Contains("."))
                {
                    List<string> split = item.Split(".").ToList();
                    Console.WriteLine($"File name: {split[0]}");
                    Console.WriteLine($"File extension: {split[1]}");
                    break;
                }
            }
        }
    }
}
