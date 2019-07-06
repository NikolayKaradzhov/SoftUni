using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02.Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, int> time = new Dictionary<string, int>();
            Dictionary<string, int> passangers = new Dictionary<string, int>();

            string town = string.Empty;
            int timeTravel = 0;
            int passangerCount = 0;


            while ((input = Console.ReadLine()) != "Slide rule")
            {
                if (input.Contains("ambush"))
                {
                    string[] split = input.Split(new String[] { ":", "->" },
                                 StringSplitOptions.RemoveEmptyEntries);

                    town = split[0];
                    string ambush = split[1];
                    passangerCount = int.Parse(split[2]);

                    if (ambush == "ambush")
                    {
                        if (!time.ContainsKey(town) && !passangers.ContainsKey(town))
                        {
                            continue;
                        }
                        else
                        {
                            passangers[town] -= passangerCount;
                            time[town] = 0;
                        }
                    }

                }
                else
                {
                    string[] split = input.Split(new String[] { ":", "->"},
                                 StringSplitOptions.RemoveEmptyEntries);

                    town = split[0];
                    timeTravel = int.Parse(split[1]);
                    passangerCount = int.Parse(split[2]);

                    if (!time.ContainsKey(town) && !passangers.ContainsKey(town))
                    {
                        time.Add(town, timeTravel);
                        passangers.Add(town, passangerCount);
                    }
                    else if (time.ContainsKey(town) && passangers.ContainsKey(town))
                    {
                        if (timeTravel < time[town])
                        {
                            time.Remove(town);
                            time.Add(town, timeTravel);
                        }
                        if (time[town] == 0)
                        {
                            time[town] += timeTravel;
                        }
                        passangers[town] += passangerCount;
                    }
                }
            }

            foreach (var pair in time.OrderBy(p => p.Value).ThenBy(p => p.Key))
            {
                string city = pair.Key;

                if (time[city] == 0 || passangers[city] == 0)
                {
                    continue;
                }

                Console.WriteLine($"{city} -> Time: {pair.Value} -> Passengers: {passangers[city]}");
            }
        }
    }
}
