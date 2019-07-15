using System;
using System.Collections.Generic;
namespace p05.GreedyTimes
{
    using System.Linq;

    public class Potato
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());

            string[] stash = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long rocks = 0;
            long money = 0;

            for (int i = 0; i < stash.Length; i += 2)
            {
                string name = stash[i];
                long count = long.Parse(stash[i + 1]);

                string itemType = string.Empty;

                if (name.Length == 3)
                {
                    itemType = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    itemType = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    itemType = "Gold";
                }

                if (itemType == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + count)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (count > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + count > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(itemType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (count > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[itemType].Values.Sum() + count > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(name))
                {
                    bag[itemType][name] = 0;
                }

                bag[itemType][name] += count;

                if (itemType == "Gold")
                {
                    gold += count;
                }
                else if (itemType == "Gem")
                {
                    rocks += count;
                }
                else if (itemType == "Cash")
                {
                    money += count;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}