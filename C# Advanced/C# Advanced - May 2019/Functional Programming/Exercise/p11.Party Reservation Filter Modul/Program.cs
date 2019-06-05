using System;
using System.Collections.Generic;
using System.Linq;

namespace p11.Party_Reservation_Filter_Modul
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] partyList = Console.ReadLine()
                .Split()
                .ToArray();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] tokens = input.Split(';');

                string command = tokens[0];

                if (command == "Add filter")
                {
                    filters.Add($"{tokens[1]};{tokens[2]}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{tokens[1]};{tokens[2]}");
                }

                input = Console.ReadLine();
            }

            Func<string, int, bool> lengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);

            foreach (var currentFilter in filters)
            {
                string[] currentFilterInfo = currentFilter.Split(';');

                string action = currentFilterInfo[0];
                string parameter = currentFilterInfo[1];

                if (action == "Starts with")
                {
                    partyList = partyList.Where(name => !startsWithFilter(name, parameter)).ToArray(); 
                }
                else if (action == "Ends with")
                {
                    partyList = partyList.Where(name => !endsWithFilter(name, parameter)).ToArray();
                }
                else if (action == "Length")
                {
                    int length = int.Parse(parameter);

                    partyList = partyList.Where(name => !lengthFilter(name, length)).ToArray();
                }
                else if (action == "Contains")
                {
                    partyList = partyList.Where(name => !containsFilter(name, parameter)).ToArray();
                }
            }
            Console.WriteLine(string.Join(" ", partyList));
        }
    }
}