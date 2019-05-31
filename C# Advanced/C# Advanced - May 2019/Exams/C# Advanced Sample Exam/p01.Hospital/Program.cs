using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> hospital = new Dictionary<string, int>();

            while (input != "Output")
            {
                List<string> tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                string department = tokens[0];
                string doctor = tokens[1];
                string patient = tokens[2];


                input = Console.ReadLine();
            }

            string inputAgain = Console.ReadLine();

            while (inputAgain != "End")
            {


                inputAgain = Console.ReadLine();
            }
        }
    }
}