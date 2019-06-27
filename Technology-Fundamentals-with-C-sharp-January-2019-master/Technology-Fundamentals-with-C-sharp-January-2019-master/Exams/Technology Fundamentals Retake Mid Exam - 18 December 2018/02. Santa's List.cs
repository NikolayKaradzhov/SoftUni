using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kids = Console.ReadLine().Split("&").ToList();

            string token = Console.ReadLine();

            while (token != "Finished!")
            {
                List<string> input = token.Split().ToList();

                string command = input[0];
                string kidName = input[1];

                if (command == "Bad")
                {
                    if (kids.Contains(kidName))
                    {

                    }
                    else
                    {
                        kids.Insert(0, kidName);
                    }
                }
                else if (command == "Good")
                {
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                    }
                }
                else if (command == "Rename")
                {
                    string oldName = input[1];
                    string newName = input[2];
                    int oldKidIndex = -1;

                    for (int i = 0; i < kids.Count; i++)
                    {
                        if (kids[i] == oldName)
                        {
                            oldKidIndex = i;
                            break;
                        }
                    }
                    if (kids.Contains(oldName))
                    {
                        kids[oldKidIndex] = newName;
                    }
                }
                else if (command == "Rearrange")
                {
                    if (kids.Contains(kidName))
                    {
                        kids.Remove(kidName);
                        kids.Add(kidName);
                    }
                }

                token = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ", kids));
        }
    }
}
