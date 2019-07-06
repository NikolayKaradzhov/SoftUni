using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02.Santas_New_List 
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, int> children = new Dictionary<string, int>();
            Dictionary<string, int> presents = new Dictionary<string, int>();

            while (input != "END")
            {
                List<string> tokens = input.Split("->").ToList();

                string childName = tokens[0];
                string typeOfToy = tokens[1]; 

                if (childName == "Remove")
                {
                    children.Remove(typeOfToy);
                }
                else
                {
                    int ammount = int.Parse(tokens[2]);

                    if (!children.ContainsKey(childName) && !presents.ContainsKey(typeOfToy))
                    {
                        children.Add(childName, ammount);
                        presents.Add(typeOfToy, ammount);
                    }
                    else if (children.ContainsKey(childName) && presents.ContainsKey(typeOfToy))
                    {
                        children[childName] += ammount;
                        presents[typeOfToy] += ammount;
                    }
                    else if (children.ContainsKey(childName) && !presents.ContainsKey(typeOfToy))
                    {
                        children[childName] += ammount;
                        presents.Add(typeOfToy, ammount);
                    }
                    else if (!children.ContainsKey(childName) && presents.ContainsKey(typeOfToy))
                    {
                        children.Add(childName, ammount);
                        presents[typeOfToy] += ammount;
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Children:");

            var childrenOrdered = children.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var kvp in childrenOrdered)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine("Presents:");

            foreach (var kvp in presents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
