using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            while (true)
            {
                List<string> tokens = input.Split().ToList();
                bool isObtained = false;

                for (int i = 0; i < tokens.Count; i += 2)
                {
                    int value = int.Parse(tokens[i]);
                    string item = tokens[i + 1].ToLower();

                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        if (!keyMaterials.ContainsKey(item))
                        {
                            keyMaterials.Add(item, 0);
                        }
                        else
                        {
                            keyMaterials[item] += value;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(item))
                        {
                            junkMaterials.Add(item, value);
                        }
                        else
                        {
                            junkMaterials[item] += value;
                        }
                    }
                    if ((keyMaterials["shards"] >= 250) 
                        || keyMaterials["motes"] >= 250
                        || keyMaterials["fragments"] >= 250)
                    {
                        keyMaterials[item] = keyMaterials[item] - 250;

                        if (item == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                        }
                        else if (item == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                        }
                        else if (item == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                        }
                        isObtained = true;
                        break;
                    }
                }
                if (isObtained)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            var orderedKeyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            var alphabeticalOrderJunks = junkMaterials.OrderBy(x => x.Key);
            foreach (var item in orderedKeyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in alphabeticalOrderJunks)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
