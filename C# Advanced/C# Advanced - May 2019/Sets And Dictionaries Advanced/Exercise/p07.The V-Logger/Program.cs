using System;
using System.Collections.Generic;

namespace p07.The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vLogger = new Dictionary<string, Dictionary<HashSet<string>, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[1] == "joined")
                {
                    string vloggerName = tokens[0];

                    if (!vLogger.ContainsKey(vloggerName))
                    {
                        vLogger.Add(vloggerName, new Dictionary<HashSet<string>, HashSet<string>>());
                    }
                    else
                    {

                    }

                }
                else if (tokens[1] == "followed")
                {
                    string vloggerName = tokens[0];
                    string followedVlogger = tokens[2];

                    HashSet<string> followers = new HashSet<string>();
                    HashSet<string> following = new HashSet<string>();

                    
                }

                input = Console.ReadLine();
            }
        }
    }
}
