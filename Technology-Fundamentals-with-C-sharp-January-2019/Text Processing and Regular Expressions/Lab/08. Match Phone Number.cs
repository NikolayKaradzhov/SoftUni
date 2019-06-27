using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p08.Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([+][3][5][9])(?<delimeter>[ -])[2]\k'delimeter'(?<grp1>[0-9]{3})\k'delimeter'(?<grp2>[0-9]{4})\b";
                             
            MatchCollection matches = Regex.Matches(input, pattern);

            for (int i = 1; i <= matches.Count; i++)
            {
                if (i == matches.Count)
                {
                     Console.Write(matches[i - 1]);
                }
                else
                {
                    Console.Write(matches[i - 1] + ", ");
                }
            }
            Console.WriteLine();
        }
    }
}
