using System;
using System.Collections.Generic;

namespace p07.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPList = new HashSet<string>();
            HashSet<string> regularList = new HashSet<string>();

            string inputList = Console.ReadLine();

            while (inputList != "PARTY")
            {
                if (char.IsDigit(inputList[0]))
                {
                    VIPList.Add(inputList);
                }
                else
                {
                    regularList.Add(inputList);
                }

                inputList = Console.ReadLine();
            }

            string peopleCameToParty = Console.ReadLine();

            while (peopleCameToParty != "END")
            {
                if (VIPList.Contains(peopleCameToParty))
                {
                    VIPList.Remove(peopleCameToParty);
                }
                if (regularList.Contains(peopleCameToParty))
                {
                    regularList.Remove(peopleCameToParty);
                }

                peopleCameToParty = Console.ReadLine();
            }

            int totalPeopleCount = VIPList.Count + regularList.Count;

            Console.WriteLine(totalPeopleCount);

            foreach (var person in VIPList)
            {
                Console.WriteLine(person);
            }

            foreach (var person in regularList)
            {
                Console.WriteLine(person);
            }
        }
    }
}