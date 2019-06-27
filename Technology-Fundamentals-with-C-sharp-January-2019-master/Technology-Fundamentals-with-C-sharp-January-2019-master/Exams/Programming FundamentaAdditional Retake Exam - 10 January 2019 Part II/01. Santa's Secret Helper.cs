using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace p01.Santas_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@(?<name>[A-Za-z]+)[^@\-!:>]+!(?<gOrN>[G|N])!";

            int key = int.Parse(Console.ReadLine());

            string message = Console.ReadLine();
            string newMessage = string.Empty;
            string kidsName = string.Empty;

            string gORn = string.Empty;

            List<string> goodKids = new List<string>();

            while (message != "end")
            {
                newMessage = string.Empty;

                foreach (var character in message)
                {
                    newMessage += (char)(character - key);
                }

                Regex order = new Regex(pattern);

                MatchCollection matches = order.Matches(newMessage);

                foreach (Match item in matches)
                {
                    kidsName = item.Groups["name"].Value;
                    gORn = item.Groups["gOrN"].Value;

                    if (gORn == "G")
                    {
                        goodKids.Add(kidsName);
                    }
                }

                message = Console.ReadLine();
            }

            foreach (var name in goodKids)
            {
                Console.WriteLine(name);
            }
        }
    }
}
